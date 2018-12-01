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
			double testVar;
			Assert.That(Double.TryParse("1,5", out testVar), Is.True);
			Assert.That(Double.TryParse("1.5", out testVar), Is.True);
		}

		[Test]
		[SetCulture("en-UK")]
		public void DoubeTryParseExample_enUK()
		{
			double testVar;
			Assert.That(Double.TryParse("1,5", out testVar), Is.True);
			Assert.That(Double.TryParse("1.5", out testVar), Is.True);
		}

		[Test]
		[SetCulture("sv-SE")]
		public void DoubeTryParseExample_svSE()
		{
			double testVar;
			Assert.That(Double.TryParse("1,5", out testVar), Is.True);
			Assert.That(Double.TryParse("1.5", out testVar), Is.False);
		}
	}
}
