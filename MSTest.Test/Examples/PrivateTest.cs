using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples
{
	[TestClass]
	public class PrivateTest
	{

		const int testValue = 42;

		[TestMethod]
		public void Test_PrivateVoid_ThatThrows()
		{
			Boolean hasThrown = false;

			PrivateObject po = new PrivateObject(new PublicClassWithPrivateFunction());
			try
			{
				po.Invoke("ThrowException", new { });
			}
			catch
			{
				hasThrown = true;
			}

			Assert.AreEqual(hasThrown, true, "The private function should have thrown");
		}

		[TestMethod]
		public void Test_PrivateFunction_in_PublicClass()
		{
			PrivateObject po = new PrivateObject(new PublicClassWithPrivateFunction());

			int valueFromPrivate = (int)po.Invoke("DoubleValue", new object[] { testValue });

			Assert.AreEqual(valueFromPrivate, 2 * testValue);
		}

	}

	public class PublicClassWithPrivateFunction
	{

		private void ThrowException()
		{
			throw new Exception();
		}

		private int DoubleValue(int inValue)
		{
			return 2 * inValue;
		}

	}

}
