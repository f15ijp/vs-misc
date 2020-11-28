using System.Web;
using NUnit.Framework;

namespace Examples.Examples.System.Web {
	public class HtmlEncodeExamples {

		[TestCase("hello<p>")]
		public void HtmlEncodeText(string input) {
			var encodedText = HttpUtility.HtmlEncode(input);
			TestContext.WriteLine($"input: '{input}'");
			TestContext.WriteLine($"result: '{encodedText}'");
		}

		[Test]
		public void HtmlEnocdeNull() {
			// ReSharper disable ExpressionIsAlwaysNull
			string input = null;
			// ReSharper disable once AssignNullToNotNullAttribute
			var encodedText = HttpUtility.HtmlEncode(s: input);
			Assert.That(encodedText, Is.Null);
			// ReSharper restore ExpressionIsAlwaysNull
		}


	}
}
