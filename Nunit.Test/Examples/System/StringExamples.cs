using System;
using System.Linq;
using NUnit.Framework;

namespace Examples.Examples.System {
	[TestFixture]
	public class StringExamples {
		[Test]
		public void Repeat_string() {
			Assert.Multiple(() => {
				Assert.That(string.Concat(Enumerable.Repeat("a", 2)), Is.EqualTo("aa"));
				Assert.That(string.Concat(Enumerable.Repeat("abab", 3)), Is.EqualTo("abababababab"));
			});
		}

		[TestCase("a.b.c.d", ".", 5)]
		public void LastIndexOf_without_warning(string haystack, string needle, int lastIndex) {
			Assert.Multiple(() => {
				Assert.That(haystack.LastIndexOf(needle, StringComparison.Ordinal), Is.EqualTo(lastIndex));
				Assert.That(haystack.LastIndexOf(needle, StringComparison.OrdinalIgnoreCase), Is.EqualTo(lastIndex));
			});
		}

		[Test]
		public void DifferenceBetweenTrims() {
			var stringWithSpace = " hello ";

			Assert.Multiple(() =>
			{
				Assert.That(stringWithSpace.Trim(), Does.Not.Contain(" "));
				Assert.That(stringWithSpace.TrimEnd(), Does.Not.EndWith(" "));
				Assert.That(stringWithSpace.TrimStart(), Does.Not.StartWith(" "));
			});
			

		}

	}
}
