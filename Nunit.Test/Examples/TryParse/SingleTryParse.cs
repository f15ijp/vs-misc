using NUnit.Framework;
using System;

namespace Examples.TryParse
{
	[TestFixture]
	public class SingleTryParse
	{
		[Test]
		[SetCulture("en-US")]
		public void SingleTryParseExample_enUS()
		{
			Assert.That(Single.TryParse("1,5", out float testVar), Is.True);
			Assert.That(Single.TryParse("1.5", out testVar), Is.True);			
		}

		[Test]
		[SetCulture("en-UK")]
		public void SingleTryParseExample_enUK()
		{
			Assert.That(Single.TryParse("1,5", out float testVar), Is.True);
			Assert.That(Single.TryParse("1.5", out testVar), Is.True);
		}

		[Test]
		[SetCulture("sv-SE")]
		public void SingleTryParseExample_svSE()
		{
			Assert.That(Single.TryParse("1,5", out float testVar), Is.True);
			Assert.That(Single.TryParse("1.5", out testVar), Is.False);
		}

	}
}
