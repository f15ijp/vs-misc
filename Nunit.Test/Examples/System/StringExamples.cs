using NUnit.Framework;
using System;
using System.Linq;

namespace Nunit.Test.Examples.System
{
	[TestFixture]
	public class StringExamples
	{
		[Test]
		public void RepeatString()
		{
			Assert.Multiple(() =>
			{
				Assert.That(string.Concat(Enumerable.Repeat("a", 2)), Is.EqualTo("aa"));
				Assert.That(string.Concat(Enumerable.Repeat("abab", 3)), Is.EqualTo("ababab"));
			});
		}

	}
}
