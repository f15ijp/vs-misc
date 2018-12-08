using NUnit.Framework;
using System;
using System.Linq;

namespace Examples.System
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
				Assert.That(string.Concat(Enumerable.Repeat("abab", 3)), Is.EqualTo("abababababab"));
			});
		}

		[TestCase("a.b.c.d", ".", 5)]
		public void LastIndoxOf_without_warning(string haystack, string needle, int lastIndex){
			Assert.Multiple(() => {
				Assert.That(haystack.LastIndexOf(needle, StringComparison.Ordinal), Is.EqualTo(lastIndex));
				Assert.That(haystack.LastIndexOf(needle, StringComparison.OrdinalIgnoreCase), Is.EqualTo(lastIndex));
			});
		}

	}
}
