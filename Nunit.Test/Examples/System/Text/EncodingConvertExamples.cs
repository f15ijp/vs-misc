using NUnit.Framework;
using System;
using System.Text;

namespace Examples.Examples.System.Text {
	[TestFixture]
	public class EncodingConvertExamples {
		[Test]
		public void TestConvert() {
			const string UNICODE_STRING = "This string contains the unicode character Pi (\u03a0)";

			// Create two different encodings.
			var ascii = Encoding.ASCII;
			var unicode = Encoding.Unicode;

			// Convert the string into a byte array.
			var unicodeBytes = unicode.GetBytes(UNICODE_STRING);

			// Perform the conversion from one encoding to the other.
			var asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

			// Convert the new byte[] into a char[] and then into a string.
			var asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
			ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
			var asciiString = new string(asciiChars);

			// Display the strings created before and after the conversion.
			TestContext.Out.WriteLine("Original string: {0}", UNICODE_STRING);
			TestContext.Out.WriteLine("Ascii converted string: {0}", asciiString);

			Assert.That(UNICODE_STRING, Is.Not.EqualTo(asciiString));
		}

		[Test]
		public void TestConvert_UTF8_to_Unicode()
		{
			const string UTF8_STRING = "Привет";
			var utf8Bytes = Encoding.UTF8.GetBytes(UTF8_STRING);

			var str1 = Encoding.Unicode.GetString(utf8Bytes);
			var str2 = Encoding.UTF8.GetString(utf8Bytes);

			var convertedBytes = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, Encoding.UTF8.GetBytes(UTF8_STRING));
			var convertedChars = new char[Encoding.Unicode.GetCharCount(convertedBytes, 0, convertedBytes.Length)];
			Encoding.Unicode.GetChars(convertedBytes, 0, convertedBytes.Length, convertedChars, 0);
			var str3 = new string(convertedChars);

			// Display the strings created before and after the conversion.
			TestContext.Out.WriteLine("Unicode string: {0}", str1);
			TestContext.Out.WriteLine("UTF8 string: {0}", str2);
			TestContext.Out.WriteLine("Converted string: {0}", str3);

			Assert.That(str1, Is.Not.EqualTo(str2));
			Assert.That(str1, Is.Not.EqualTo(str3));
		}

	}
}
