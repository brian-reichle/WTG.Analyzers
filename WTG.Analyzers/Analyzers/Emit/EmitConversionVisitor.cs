using System;
using System.Globalization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Simplification;
using WTG.Analyzers.Utils;

namespace WTG.Analyzers
{
	sealed class EmitConversionVisitor : CSharpSyntaxVisitor<ExpressionSyntax>
	{
		public EmitConversionVisitor(OpCodeOperand operandType)
		{
			this.operandType = operandType;
		}

		public override ExpressionSyntax DefaultVisit(SyntaxNode node)
		{
			return SyntaxFactory.CastExpression(
				GetCastType(),
				SyntaxFactory.ParenthesizedExpression((ExpressionSyntax)node)
					.WithAdditionalAnnotations(Simplifier.Annotation));
		}

		public override ExpressionSyntax VisitLiteralExpression(LiteralExpressionSyntax node)
		{
			if (node.Kind() == SyntaxKind.NumericLiteralExpression)
			{
				switch (operandType)
				{
					case OpCodeOperand.InlineI:
						return ExpressionSyntaxFactory.CreateLiteral(Convert.ToInt32(node.Token.Value, CultureInfo.InvariantCulture));
					case OpCodeOperand.InlineI8:
						return ExpressionSyntaxFactory.CreateLiteral(Convert.ToInt64(node.Token.Value, CultureInfo.InvariantCulture));
					case OpCodeOperand.ShortInlineR:
						return ExpressionSyntaxFactory.CreateLiteral(Convert.ToSingle(node.Token.Value, CultureInfo.InvariantCulture));
					case OpCodeOperand.InlineR:
						return ExpressionSyntaxFactory.CreateLiteral(Convert.ToDouble(node.Token.Value, CultureInfo.InvariantCulture));
				}
			}

			return base.VisitLiteralExpression(node);
		}

		public override ExpressionSyntax VisitCastExpression(CastExpressionSyntax node) => node.Expression.Accept(this);

		TypeSyntax GetCastType()
		{
			switch (operandType)
			{
				case OpCodeOperand.ShortInlineI:
					return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.SByteKeyword));
				case OpCodeOperand.ShortInlineVar:
					return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.ByteKeyword));

				case OpCodeOperand.InlineI:
					return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword));
				case OpCodeOperand.InlineVar:
					return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.ShortKeyword));

				case OpCodeOperand.InlineI8:
					return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.LongKeyword));

				case OpCodeOperand.InlineR:
					return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.DoubleKeyword));
				case OpCodeOperand.ShortInlineR:
					return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.FloatKeyword));
			}

			return null;
		}

		readonly OpCodeOperand operandType;
	}
}
