using System.Globalization;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WTG.Analyzers.Utils
{
	public static class LiteralSyntaxFactory
	{
		public static LiteralExpressionSyntax CreateInt(int value)
		{
			return SyntaxFactory.LiteralExpression(
				SyntaxKind.NumericLiteralExpression,
				SyntaxFactory.Literal(value));
		}

		public static LiteralExpressionSyntax CreateLong(long value)
		{
			return SyntaxFactory.LiteralExpression(
				SyntaxKind.NumericLiteralExpression,
				SyntaxFactory.Literal(value.ToString(CultureInfo.InvariantCulture) + "L", value));
		}

		public static LiteralExpressionSyntax CreateFloat(float value)
		{
			return SyntaxFactory.LiteralExpression(
				SyntaxKind.NumericLiteralExpression,
				SyntaxFactory.Literal(value.ToString(CultureInfo.InvariantCulture) + "f", value));
		}

		public static LiteralExpressionSyntax CreateDouble(double value)
		{
			return SyntaxFactory.LiteralExpression(
				SyntaxKind.NumericLiteralExpression,
				SyntaxFactory.Literal(value.ToString(CultureInfo.InvariantCulture) + "d", value));
		}
	}
}
