using System.Collections.Immutable;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace WTG.Analyzers
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public sealed class EmitAnalyzer : DiagnosticAnalyzer
	{
		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
			Rules.UseCorrectEmitOverloadRule);

		public override void Initialize(AnalysisContext context)
		{
			context.EnableConcurrentExecution();
			context.RegisterSyntaxNodeAction(AnalyzeInvoke, SyntaxKind.InvocationExpression);
		}

		void AnalyzeInvoke(SyntaxNodeAnalysisContext context)
		{
			var invoke = (InvocationExpressionSyntax)context.Node;
			var actualEmitMethod = IdentifyEmitMethod(context.SemanticModel, invoke, context.CancellationToken);

			if (actualEmitMethod == EmitMethod.None)
			{
				return;
			}

			var fieldIdentifier = invoke.ArgumentList.Arguments[0].Accept(FieldAccessor.Instance);

			if (fieldIdentifier == null)
			{
				return;
			}

			var opCodeSymbol = context.SemanticModel.GetSymbolInfo(fieldIdentifier).Symbol;

			if (opCodeSymbol == null || opCodeSymbol.Kind != SymbolKind.Field)
			{
				return;
			}

			var opcode = EmitMatrix.GetOpCode((IFieldSymbol)opCodeSymbol);

			if (opcode == OpCode.Invalid)
			{
				return;
			}

			var supportedEmitMethod = EmitMatrix.GetSupportedMethods(opcode);

			if ((supportedEmitMethod & actualEmitMethod) != 0)
			{
				return;
			}

			if (opcode.GetOperand() == OpCodeOperand.InlineNone)
			{
				context.ReportDiagnostic(
					Diagnostic.Create(
						Rules.UseCorrectEmitOverload_NoneRule,
						invoke.GetLocation(),
						opcode.ToString()));
			}
			else
			{
				context.ReportDiagnostic(
					Diagnostic.Create(
						Rules.UseCorrectEmitOverloadRule,
						invoke.GetLocation(),
						opcode.ToString()));
			}
		}

		static EmitMethod IdentifyEmitMethod(SemanticModel model, InvocationExpressionSyntax invoke, CancellationToken token)
		{
			var name = invoke.Expression.Accept(EmitMethodNameRetriever.Instance);

			if (name == nameof(ILGenerator.Emit) || name == nameof(ILGenerator.EmitCall))
			{
				var methodSymbol = (IMethodSymbol)model.GetSymbolInfo(invoke, token).Symbol;

				if (methodSymbol != null)
				{
					return EmitMatrix.GetEmitMethod(methodSymbol);
				}
			}

			return EmitMethod.None;
		}
	}
}
