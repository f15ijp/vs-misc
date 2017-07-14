using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.Test
{
	[TestClass]
	public class MSTest_Fizzbuzz
	{
		[TestMethod]
		public void TestNegativeNumberThrowsEx()
		{
			Exception expectedException = null;
			try
			{
				Misc.Fizzbuzz.FizzBuzz(-1);
			}
			catch(Exception ex)
			{
				expectedException = ex;
			}
			Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
		}
	}
}
