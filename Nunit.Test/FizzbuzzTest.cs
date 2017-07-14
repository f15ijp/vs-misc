using System;
using NUnit.Framework;

namespace Nunit.Test
{
	[TestFixture]
	public class FizzbuzzTest
	{
		[TestCase(1, ExpectedResult = "1")]
		[TestCase(2, ExpectedResult = "2")]
		[TestCase(3, ExpectedResult = "Fizz")]
		[TestCase(5, ExpectedResult = "Buzz")]
		[TestCase(15, ExpectedResult = "FizzBuzz")]
		public string testCases(int Input)
		{

			return Misc.Fizzbuzz.FizzBuzz(Input);

		}
		
		[TestCase(-1)]
		public void testExceptions(int input)
		{
			Assert.Throws<ArgumentException>(() => Misc.Fizzbuzz.FizzBuzz(input));
		}

	}
}
