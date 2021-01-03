using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Examples.Examples.System.Text.RegularExpressions {
	[TestFixture]
	public class RegexExamples {

		[Test]
		public void FindAttributeInHtmlTag()
		{
			const string INPUT = @"<font face=""arial"" size=""2"">Some text</font>";
			var regex = new Regex(@"(?<=\bface="")[^""]*");
			var match = regex.Match(INPUT);
			var title = match.Value;
			Assert.That(title, Is.EqualTo("arial"));
		}

		[Test]
		public void FindAttributeWithoutCitationCharInHtmlTag() {
			const string INPUT = @"<font face=arial>Other text</font>";
			var regex = new Regex(@"(?<=\bface=)[^ \>]*");
			var match = regex.Match(INPUT);
			var title = match.Value;
			Assert.That(title, Is.EqualTo("arial"));
		}

		[Test]
		public void FindHtmlTagsMissingCitationChars() {
			const string INPUT = @"<font face=arial size=2 size=""3"" a=""b"">some text</font>";

			var correctedTag = Regex.Replace(INPUT, @"(?<=\bface=)[^ ""\>]*|(?<=\bsize=)[^ ""\>]*", match => string.IsNullOrEmpty(match.Value) ? string.Empty : "\"" + match.Value + "\"", RegexOptions.Multiline | RegexOptions.Singleline);

			Assert.Multiple(() => {
				Assert.That(correctedTag, Does.Not.Contain("\"\""));
				Assert.That(correctedTag, Does.Contain("face=\"arial\""));
				Assert.That(correctedTag, Does.Contain("size=\"2\""));
			});
		}

		[Test]
		public void ReplaceAmpersandButNotXmlEntities()
		{
			const string INPUT = "A&B &amp; &lt;hi&gt;&nbsp;";

			var correctedTag = Regex.Replace(INPUT, @"&(?!(amp)|(lt)|(apos)|(gt)|(quot)|(nbsp);)", "&amp;");
			Assert.Multiple(() =>
			{
				Assert.That(correctedTag, Does.Not.Contain("A&B"));
				Assert.That(correctedTag, Does.Contain("A&amp;B"));
				Assert.That(correctedTag, Does.Contain("&lt;"));
				Assert.That(correctedTag, Does.Contain("&gt;"));
				Assert.That(correctedTag, Does.Contain("&nbsp;"));
			});
		}

		[TestCase("some text\r\n", true)]
		[TestCase("some text ", false)]
		[TestCase("text\r", true)]
		[TestCase("text\n", true)]
		[TestCase("text", false)]
		[TestCase("", false)]
		public void ConstainsCrLf(string haystack, bool matches) {
			var lastIndex = Regex.Match(haystack, @"\r\n?|\n", RegexOptions.RightToLeft);
			Assert.Multiple(() => {
				Assert.That((lastIndex.Index > 0), Is.EqualTo(matches), message:lastIndex.Index.ToString());
			});
		}

		/// <summary>
		/// Example from MSDN
		/// https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.matches
		/// </summary>
		[Test]
		public static void Matches() {
			var sentence = "Who writes these notes?";

			foreach (Match match in new Regex(@"\b\w+es\b").Matches(sentence))
				TestContext.WriteLine("Found '{0}' at position {1}",
					match.Value, match.Index);

			// The example displays the following output:
			//       Found 'writes' at position 4
			//       Found 'notes' at position 17
		}

		[Test]
		public static void MatchWidthWithQuotes() {
			const string imgTagg = "<img style=\"WIDTH: 1px\" src=\"cid:42\" width=\"2\">";

			var found = new Regex(
				@"width(?:\=|=3D)(?:""|')\s*(\d+)(?:""|')",
				RegexOptions.IgnoreCase | RegexOptions.Multiline).Match(imgTagg);

			Assert.That(found.Value, Is.EqualTo("width=\"2\""));
		}

	}
}