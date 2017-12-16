namespace WTG.Analyzers.Utils
{
	public enum Precidence
	{
		Document,
		AssignmentAndLambda,
		Conditional,
		NullCoalescing,
		LogicalOr,
		LogicalAnd,
		BitwiseOr,
		LogicalXOr,
		BitwiseAnd,
		Equality,
		RelationalAndTypeTesting,
		Shift,
		Additive,
		Multiplicative,
		Unary,
		Primary,
	}
}
