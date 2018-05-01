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
		public void Excpetion_Assert_Throws_TestFunction()
		{
			Assert.Throws<ArgumentException>(() => FunctionThatThrows());
		}

		#endregion

		#region "Assert.That"

		[Test]
		public void Excpetion_Assert_That_TestVoid()
		{
			Assert.That(VoidThatThrows, Throws.ArgumentException);
			Assert.That(VoidThatDontThrow, Throws.Nothing);
		}

		[Test]
		public void Excpetion_Assert_That_TestFunction()
		{
			Assert.That(FunctionThatThrows, Throws.ArgumentException);
			Assert.That(FunctionThatDontThrow, Throws.Nothing);
		}

		#endregion

		#region "Assert.DoesNotThrow"
		[Test]
		public void Excpetion_Assert_DoesNotThrow_TestVoid()
		{
			Assert.DoesNotThrow(VoidThatDontThrow);
		}

		[Test]
		public void Excpetion_Assert_DoesNotThrow_TestFunction()
		{
			Assert.DoesNotThrow(() => FunctionThatDontThrow());
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

		private static void VoidThatDontThrow()
		{
		}

		private static string FunctionThatDontThrow()
		{
			return null;
		}

		#endregion

	}
}