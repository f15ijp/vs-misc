using System;
using NUnit.Framework;

namespace Nunit.Test.TestExamples
{
	[TestFixture]
	public class FizzbuzzTest
	{
		[TestCase(1, ExpectedResult = "1")]
		[TestCase(2, ExpectedResult = "2")]
		[TestCase(3, ExpectedResult = "Fizz")]
		[TestCase(5, ExpectedResult = "Buzz")]
		[TestCase(15, ExpectedResult = "FizzBuzz")]
		public string TestCases(int input)
		{
			return Fizzbuzz.FizzBuzz(input);
		}
		
		[TestCase(-1)]
		public void TestExceptions_Assert_Throws(int input)
		{
			Assert.Throws<ArgumentException>(() => Fizzbuzz.FizzBuzz(input));
		}

		[TestCase(-1)]
		public void TestException_Assert_That(int input)
		{
			Assert.That(() => Fizzbuzz.FizzBuzz(input), Throws.ArgumentException);
		}

	}
}
