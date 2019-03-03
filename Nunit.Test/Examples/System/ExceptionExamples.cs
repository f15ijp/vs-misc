using NUnit.Framework;
using System;

namespace Examples.Examples.System {
	[TestFixture]
	public class ExceptionExamples {
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