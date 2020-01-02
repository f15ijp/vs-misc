using NUnit.Framework;
using System;

namespace Examples.Examples.System {
	[TestFixture]
	public class ExceptionExamples {

		[Test]
		public void OnlyCatchCertainException()
		{
			try
			{
				//do something that can give ArgumentNullException, ArgumentOutOfRangeException or DivideByZeroException
			}
			catch (Exception e) when (e is ArgumentNullException || e is ArgumentOutOfRangeException)
			{
				//do something here
			}
			catch (Exception e) when (e is DivideByZeroException)
			{
				//do something else
			}
			//all other types of exceptions are thrown from this function
		}

		[Test]
		public void What_does_ToString_give()
		{
			var ex = new Exception("Some message");
			TestContext.WriteLine(ex.ToString());
		}


		[Test]
		public void ExceptionInLoopKeepOnRunning()
		{
			var loopedLines = 0;
			var linesWithException = 0;
			for (var counter = 0; counter < 10; counter++)
			{
				try 
				{
					ThrowIfModIsZero(counter, 5);
				}
				catch (Exception)
				{
					linesWithException++;
				}

				loopedLines++;
			}
			TestContext.WriteLine($"Total: {loopedLines.ToString()} number with exception: {linesWithException.ToString()}");
		}

		public void ThrowIfModIsZero(int number, int mod)
		{
			if (number % mod == 0)
			{
				throw new Exception();
			}
		}

	}
}