using NUnit.Framework;
using System;

namespace Examples.TryParse
{
	[TestFixture]
	public class DoubleTryParse
	{
		[Test]
		[SetCulture("en-US")]
		public void DoubeTryParseExample_enUS()
		{

			Assert.That(Double.TryParse("1,5", out double testVar), Is.True);
			Assert.That(Double.TryParse("1.5", out testVar), Is.True);
		}

		[Test]
		[SetCulture("en-UK")]
		public void DoubeTryParseExample_enUK()
		{

			Assert.That(Double.TryParse("1,5", out double testVar), Is.True);
			Assert.That(Double.TryParse("1.5", out testVar), Is.True);
		}

		[Test]
		[SetCulture("sv-SE")]
		public void DoubeTryParseExample_svSE()
		{
			Assert.That(Double.TryParse("1,5", out double testVar), Is.True);
			Assert.That(Double.TryParse("1.5", out testVar), Is.False);
		}
	}
}
