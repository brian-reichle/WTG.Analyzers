using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WTG.Analyzers
{
	sealed class EmitMethodNameRetriever : CSharpSyntaxVisitor<string>
	{
		public static EmitMethodNameRetriever Instance { get; } = new EmitMethodNameRetriever();

		EmitMethodNameRetriever()
		{
		}

		public override string DefaultVisit(SyntaxNode node) => null;
		public override string VisitMemberAccessExpression(MemberAccessExpressionSyntax node) => node.Name?.Accept(this);
		public override string VisitIdentifierName(IdentifierNameSyntax node) => node.Identifier.Text;
	}
}
