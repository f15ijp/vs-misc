using System;
using NUnit.Framework;

namespace Nunit.Test
{
	[TestFixture]
	public class FizzbuzzTest
	{
		[TestCase(1, ExpectedResult = "1")]
		[TestCase(2, ExpectedResult = "2")]
		public string testCases(int Input)
		{

			return Misc.Fizzbuzz.FizzBuzz(Input);

		}
	}
}
