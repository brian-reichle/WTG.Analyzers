using System;
using System.Globalization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WTG.Analyzers.Utils;

namespace WTG.Analyzers
{
	sealed class ConversionVisitor : CSharpSyntaxVisitor<ExpressionSyntax>
	{
		public ConversionVisitor(OpCodeOperand operandType)
		{
			this.operandType = operandType;
		}

		public override ExpressionSyntax DefaultVisit(SyntaxNode node)
		{
			var type = GetCastType();
			var expression = (ExpressionSyntax)node;

			var precidence = expression.Kind().GetPrecidence();

			if (precidence < Precidence.Unary)
			{
				expression = SyntaxFactory.ParenthesizedExpression(expression);
			}

			return SyntaxFactory.CastExpression(type, expression);
		}

		public override ExpressionSyntax VisitLiteralExpression(LiteralExpressionSyntax node)
		{
			if (node.Kind() == SyntaxKind.NumericLiteralExpression)
			{
				switch (operandType)
				{
					case OpCodeOperand.InlineI: return LiteralSyntaxFactory.CreateInt(Convert.ToInt32(node.Token.Value, CultureInfo.InvariantCulture));
					case OpCodeOperand.InlineI8: return LiteralSyntaxFactory.CreateLong(Convert.ToInt64(node.Token.Value, CultureInfo.InvariantCulture));
					case OpCodeOperand.ShortInlineR: return LiteralSyntaxFactory.CreateFloat(Convert.ToSingle(node.Token.Value, CultureInfo.InvariantCulture));
					case OpCodeOperand.InlineR: return LiteralSyntaxFactory.CreateDouble(Convert.ToDouble(node.Token.Value, CultureInfo.InvariantCulture));
				}
			}

			return base.VisitLiteralExpression(node);
		}

		public override ExpressionSyntax VisitCastExpression(CastExpressionSyntax node) => node.Expression.Accept(this);

		TypeSyntax GetCastType()
		{
			switch (operandType)
			{
				case OpCodeOperand.ShortInlineI: return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.SByteKeyword));
				case OpCodeOperand.ShortInlineVar: return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.ByteKeyword));

				case OpCodeOperand.InlineI: return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword));
				case OpCodeOperand.InlineVar: return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.ShortKeyword));

				case OpCodeOperand.InlineI8: return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.LongKeyword));

				case OpCodeOperand.InlineR: return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.DoubleKeyword));
				case OpCodeOperand.ShortInlineR: return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.FloatKeyword));
			}

			return null;
		}

		readonly OpCodeOperand operandType;
	}
}
