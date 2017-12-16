using Microsoft.CodeAnalysis.CSharp;

namespace WTG.Analyzers.Utils
{
	public static class PrecedenceUtils
	{
		public static Precidence GetPrecidence(this SyntaxKind kind)
		{
			switch (kind)
			{
				case SyntaxKind.AliasQualifiedName:
				case SyntaxKind.AnonymousMethodExpression:
				case SyntaxKind.AnonymousObjectCreationExpression:
				case SyntaxKind.AnonymousObjectMemberDeclarator:
				case SyntaxKind.CharacterLiteralExpression:
				case SyntaxKind.CheckedExpression:
				case SyntaxKind.ConditionalAccessExpression:
				case SyntaxKind.DefaultExpression:
				case SyntaxKind.ElementAccessExpression:
				case SyntaxKind.FalseLiteralExpression:
				case SyntaxKind.IdentifierName:
				case SyntaxKind.InvocationExpression:
				case SyntaxKind.NullLiteralExpression:
				case SyntaxKind.NumericLiteralExpression:
				case SyntaxKind.ObjectCreationExpression:
				case SyntaxKind.ObjectInitializerExpression:
				case SyntaxKind.ParenthesizedExpression:
				case SyntaxKind.PointerMemberAccessExpression:
				case SyntaxKind.PostDecrementExpression:
				case SyntaxKind.PostIncrementExpression:
				case SyntaxKind.SimpleMemberAccessExpression:
				case SyntaxKind.SizeOfExpression:
				case SyntaxKind.StringLiteralExpression:
				case SyntaxKind.TrueLiteralExpression:
				case SyntaxKind.TypeOfExpression:
				case SyntaxKind.QualifiedName:
					return Precidence.Primary;

				case SyntaxKind.AddressOfExpression:
				case SyntaxKind.AwaitExpression:
				case SyntaxKind.BitwiseNotExpression:
				case SyntaxKind.CastExpression:
				case SyntaxKind.LogicalNotExpression:
				case SyntaxKind.PointerIndirectionExpression:
				case SyntaxKind.PreDecrementExpression:
				case SyntaxKind.PreIncrementExpression:
				case SyntaxKind.UnaryMinusExpression:
				case SyntaxKind.UnaryPlusExpression:
					return Precidence.Unary;

				case SyntaxKind.DivideExpression:
				case SyntaxKind.ModuloExpression:
				case SyntaxKind.MultiplyExpression:
					return Precidence.Multiplicative;

				case SyntaxKind.AddExpression:
				case SyntaxKind.SubtractExpression:
					return Precidence.Additive;

				case SyntaxKind.LeftShiftExpression:
				case SyntaxKind.RightShiftExpression:
					return Precidence.Shift;

				case SyntaxKind.AsExpression:
				case SyntaxKind.GreaterThanExpression:
				case SyntaxKind.GreaterThanOrEqualExpression:
				case SyntaxKind.LessThanExpression:
				case SyntaxKind.LessThanOrEqualExpression:
				case SyntaxKind.IsExpression:
					return Precidence.RelationalAndTypeTesting;

				case SyntaxKind.EqualsExpression:
				case SyntaxKind.NotEqualsExpression:
					return Precidence.Equality;

				case SyntaxKind.BitwiseAndExpression:
					return Precidence.BitwiseAnd;

				case SyntaxKind.BitwiseOrExpression:
					return Precidence.BitwiseOr;

				case SyntaxKind.LogicalAndExpression:
					return Precidence.LogicalAnd;

				case SyntaxKind.LogicalOrExpression:
					return Precidence.LogicalOr;

				case SyntaxKind.CoalesceExpression:
					return Precidence.NullCoalescing;

				case SyntaxKind.ConditionalExpression:
					return Precidence.Conditional;

				case SyntaxKind.AddAssignmentExpression:
				case SyntaxKind.AndAssignmentExpression:
				case SyntaxKind.DivideAssignmentExpression:
				case SyntaxKind.ExclusiveOrAssignmentExpression:
				case SyntaxKind.LeftShiftAssignmentExpression:
				case SyntaxKind.ModuloAssignmentExpression:
				case SyntaxKind.MultiplyAssignmentExpression:
				case SyntaxKind.OrAssignmentExpression:
				case SyntaxKind.ParenthesizedLambdaExpression:
				case SyntaxKind.RightShiftAssignmentExpression:
				case SyntaxKind.SimpleAssignmentExpression:
				case SyntaxKind.SimpleLambdaExpression:
				case SyntaxKind.SubtractAssignmentExpression:
					return Precidence.AssignmentAndLambda;
			}

			return Precidence.Document;
		}
	}
}
