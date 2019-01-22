using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WTG.Analyzers
{
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(EmitCodeFixProvider))]
	public sealed class EmitCodeFixProvider : CodeFixProvider
	{
		public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(
			Rules.UseCorrectEmitOverloadDiagnosticID);

		public override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var document = context.Document;
			var diagnostic = context.Diagnostics.First();
			var root = await document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
			var invoke = (InvocationExpressionSyntax)root.FindNode(diagnostic.Location.SourceSpan, getInnermostNodeForTie: true);
			var data = new Data(document, root, invoke);

			var compilation = await document.Project.GetCompilationAsync(context.CancellationToken).ConfigureAwait(false);

			var suggestedFix = GetSuggestedFix(compilation, invoke, context.CancellationToken);

			switch (suggestedFix)
			{
				case SuggestedFix.DeleteArgument:
					context.RegisterCodeFix(
						CodeAction.Create(
							"Remove Argument",
							createChangedDocument: data.RemoveArgumentFixAsync,
							equivalenceKey: "RemoveArgument"),
						diagnostic);
					break;

				case SuggestedFix.ConvertArgument:
					context.RegisterCodeFix(
						CodeAction.Create(
							"Convert Argument",
							createChangedDocument: data.ConvertArgumentFixAsync,
							equivalenceKey: "ConvertArgument"),
						diagnostic);
					break;
			}
		}

		static SuggestedFix GetSuggestedFix(Compilation compilation, InvocationExpressionSyntax invoke, CancellationToken cancellationToken)
		{
			var model = compilation.GetSemanticModel(invoke.SyntaxTree);
			var invokeSymbol = model.GetSymbolInfo(invoke, cancellationToken).Symbol;

			if (invokeSymbol == null && invokeSymbol.Kind == SymbolKind.Method)
			{
				return SuggestedFix.NoAutoFix;
			}

			var argList = invoke.ArgumentList;
			var field = argList.Arguments[0].Accept(FieldAccessor.Instance);

			if (field == null)
			{
				return SuggestedFix.NoAutoFix;
			}

			var opcode = EmitMatrix.GetOpCode(field.Identifier.Text);
			var actualMethod = EmitMatrix.GetEmitMethod((IMethodSymbol)invokeSymbol);
			return SuggestAutoFix(opcode, actualMethod);
		}

		static SyntaxNode RemoveArgument(InvocationExpressionSyntax invoke)
		{
			var argList = invoke.ArgumentList;

			var newArgList = argList.WithArguments(
				SyntaxFactory.SeparatedList(new[] { argList.Arguments[0] }));

			if (invoke.Expression is MemberAccessExpressionSyntax expression &&
				expression.Name.Identifier.Text != nameof(ILGenerator.Emit))
			{
				invoke = invoke.WithExpression(
					SyntaxFactory.MemberAccessExpression(
						SyntaxKind.SimpleMemberAccessExpression,
						expression.Expression,
						SyntaxFactory.IdentifierName(nameof(ILGenerator.Emit))));
			}

			return invoke.WithArgumentList(newArgList);
		}

		static InvocationExpressionSyntax ConvertArgument(InvocationExpressionSyntax invoke)
		{
			var argList = invoke.ArgumentList;
			var field = argList.Arguments[0].Accept(FieldAccessor.Instance);

			if (field == null)
			{
				return invoke;
			}

			var opcode = EmitMatrix.GetOpCode(field.Identifier.Text);

			if (opcode == OpCode.Invalid)
			{
				return invoke;
			}

			var valueArgument = argList.Arguments[1];
			var valueExpression = valueArgument.Expression;

			return invoke
				.WithArgumentList(
					argList.WithArguments(
						argList.Arguments.Replace(
							valueArgument,
							valueArgument.WithExpression(
								valueExpression.Accept(new EmitConversionVisitor(opcode.GetOperand()))))));
		}

		static SuggestedFix SuggestAutoFix(OpCode opcode, EmitMethod actualMethod)
		{
			var operandType = opcode.GetOperand();

			switch (operandType)
			{
				case OpCodeOperand.InlineNone:
					return SuggestedFix.DeleteArgument;

				case OpCodeOperand.InlineI:
				case OpCodeOperand.InlineI8:
				case OpCodeOperand.InlineR:
				case OpCodeOperand.InlineVar:
				case OpCodeOperand.ShortInlineI:
				case OpCodeOperand.ShortInlineR:
				case OpCodeOperand.ShortInlineVar:
					{
						const EmitMethod Mask =
							EmitMethod.Emit_Byte
							| EmitMethod.Emit_SByte
							| EmitMethod.Emit_Int16
							| EmitMethod.Emit_Int32
							| EmitMethod.Emit_Int64
							| EmitMethod.Emit_Single
							| EmitMethod.Emit_Double;

						if ((Mask & actualMethod) != 0)
						{
							return SuggestedFix.ConvertArgument;
						}
					}
					break;
			}

			return SuggestedFix.NoAutoFix;
		}

		enum SuggestedFix
		{
			NoAutoFix,
			DeleteArgument,
			ConvertArgument,
		}

		sealed class Data
		{
			public Data(Document document, SyntaxNode root, InvocationExpressionSyntax invoke)
			{
				Document = document;
				Root = root;
				Invoke = invoke;
			}

			public Document Document { get; }
			public SyntaxNode Root { get; }
			public InvocationExpressionSyntax Invoke { get; }

			public Task<Document> RemoveArgumentFixAsync(CancellationToken cancellationToken)
			{
				return Task.FromResult(Document.WithSyntaxRoot(
					Root.ReplaceNode(
						Invoke,
						RemoveArgument(Invoke))));
			}

			public Task<Document> ConvertArgumentFixAsync(CancellationToken cancellationToken)
			{
				return Task.FromResult(Document.WithSyntaxRoot(
					Root.ReplaceNode(
						Invoke,
						ConvertArgument(Invoke))));
			}
		}
	}
}
