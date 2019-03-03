using System;
using System.Text.RegularExpressions;
using System.Xml;
using NUnit.Framework;

namespace Examples.Examples.Xml
{
	[TestFixture]
	public class XmlExamples
	{

		public const string InvalidChar = "\uFFFD";

		public const string XmlWithInvalidChar = "\x00<?xml version=\"1.0\" encoding=\"UTF-8\"?><rootNode></rootNode>";

		[TestCase(true)]
		[TestCase(false)]
		public void RemoveInvalidChars(bool removeInsteadOfReplace)
		{
			//regexp from https://stackoverflow.com/questions/397250/unicode-regex-invalid-xml-characters/961504#961504
			var xml = Regex.Replace(
				XmlWithInvalidChar,
				@"(?<![\uD800-\uDBFF])[\uDC00-\uDFFF]|[\uD800-\uDBFF](?![\uDC00-\uDFFF])|[\x00-\x08\x0B\x0C\x0E-\x1F\x7F-\x9F\uFEFF\uFFFE\uFFFF]",
				(removeInsteadOfReplace ? string.Empty : InvalidChar),
				RegexOptions.Compiled
			);

			Assert.That(xml, Does.Not.Contain("\x00"));
		}

		[Test]
		public void AddCDataToXmlElement()
		{
			var xdoc = new XmlDocument();
			var xmlElement = xdoc.CreateElement("test");
			// Create an XmlCDataSection from your document
			var cdata = xdoc.CreateCDataSection("some string that needs to be CData");

			// Append the cdata section to your node
			xmlElement.AppendChild(cdata);

			Assert.That(xmlElement.InnerXml, Does.Contain("![CDATA["));
		}
	}
}