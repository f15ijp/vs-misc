using System;
using NUnit.Framework;

namespace Nunit.Test.Examples
{
	[TestFixture]
	public class ExceptionTest
	{

		#region "Assert.Throws"

		[Test]
		public void Excpetion_Assert_Throws_TestVoid()
		{
			Assert.Throws<ArgumentException>(VoidThatThrows);
		}

		[Test]
		public void Excpetion_Assert_Throws_TesFunction()
		{
			Assert.Throws<ArgumentException>(() => FunctionThatThrows());
		}

		#endregion

		#region "Assert.That"

		[Test]
		public void Excpetion_Assert_That_TestVoid()
		{
			Assert.That(VoidThatThrows, Throws.ArgumentException);
		}

		[Test]
		public void Excpetion_Assert_That_TestFunction()
		{
			Assert.That(FunctionThatThrows, Throws.ArgumentException);
		}

		#endregion

		#region "Infrastructure for test"


		private static void VoidThatThrows()
		{
			throw new ArgumentException("Throws for test");
		}

		private static string FunctionThatThrows()
		{
			throw new ArgumentException("Throws for test");
		}

		#endregion

	}
}