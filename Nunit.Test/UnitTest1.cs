using System;
using NUnit.Framework;

namespace Nunit.Test
{
	[TestFixture]
	public class Nunit
	{
		[TestCase]
		public void TestMethod1()
		{
			Assert.That(true, Is.True);
		}
	}
}
