using Examples.System.Examples;
using NUnit.Framework;

namespace Examples.Statements
{
	[TestFixture]
	class SelectCaseExamples
	{
		[TestCase(EnumExamples.TestEnum.One, 1)]
		public void SelectCaseOnEnum(EnumExamples.TestEnum enumValue, int expectedValue)
		{
			int result = -42;
			switch (enumValue)
			{
				case EnumExamples.TestEnum.One:
					result = 1;
					break;
				case EnumExamples.TestEnum.Two:
					result = 2;
					break;
				default:
					break;
			}
			Assert.That(result, Is.EqualTo(expectedValue));
		}

	}
}
