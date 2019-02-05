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

	}
}