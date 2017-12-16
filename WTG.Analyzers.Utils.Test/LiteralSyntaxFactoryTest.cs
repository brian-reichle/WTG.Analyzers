using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

namespace WTG.Analyzers.Utils.Test
{
	[TestFixture]
	class LiteralSyntaxFactoryTest
	{
		[TestCase(0, ExpectedResult = "0")]
		[TestCase(42, ExpectedResult = "42")]
		[TestCase(-42, ExpectedResult = "-42")]
		public string Int(int value)
		{
			var literal = LiteralSyntaxFactory.CreateInt(value);
			Assert.That(literal.Kind, Is.EqualTo(SyntaxKind.NumericLiteralExpression));
			Assert.That(literal.Token.Kind(), Is.EqualTo(SyntaxKind.NumericLiteralToken));
			Assert.That(literal.Token.Value, Is.EqualTo(value));
			return literal.Token.Text;
		}

		[TestCase(0, ExpectedResult = "0L")]
		[TestCase(42, ExpectedResult = "42L")]
		[TestCase(-42, ExpectedResult = "-42L")]
		public string Long(long value)
		{
			var literal = LiteralSyntaxFactory.CreateLong(value);
			Assert.That(literal.Kind, Is.EqualTo(SyntaxKind.NumericLiteralExpression));
			Assert.That(literal.Token.Kind(), Is.EqualTo(SyntaxKind.NumericLiteralToken));
			Assert.That(literal.Token.Value, Is.EqualTo(value));
			return literal.Token.Text;
		}

		[TestCase(0, ExpectedResult = "0f")]
		[TestCase(42, ExpectedResult = "42f")]
		[TestCase(-42, ExpectedResult = "-42f")]
		[TestCase(42.5f, ExpectedResult = "42.5f")]
		[TestCase(-42.5f, ExpectedResult = "-42.5f")]
		public string Float(float value)
		{
			var literal = LiteralSyntaxFactory.CreateFloat(value);
			Assert.That(literal.Kind, Is.EqualTo(SyntaxKind.NumericLiteralExpression));
			Assert.That(literal.Token.Kind(), Is.EqualTo(SyntaxKind.NumericLiteralToken));
			Assert.That(literal.Token.Value, Is.EqualTo(value));
			return literal.Token.Text;
		}

		[TestCase(0, ExpectedResult = "0d")]
		[TestCase(42, ExpectedResult = "42d")]
		[TestCase(-42, ExpectedResult = "-42d")]
		[TestCase(42.5d, ExpectedResult = "42.5d")]
		[TestCase(-42.5d, ExpectedResult = "-42.5d")]
		public string Double(double value)
		{
			var literal = LiteralSyntaxFactory.CreateDouble(value);
			Assert.That(literal.Kind, Is.EqualTo(SyntaxKind.NumericLiteralExpression));
			Assert.That(literal.Token.Kind(), Is.EqualTo(SyntaxKind.NumericLiteralToken));
			Assert.That(literal.Token.Value, Is.EqualTo(value));
			return literal.Token.Text;
		}
	}
}
