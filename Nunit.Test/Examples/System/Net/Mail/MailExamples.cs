using System;
using System.Net.Mail;
using NUnit.Framework;

namespace Examples.Examples.System.Net.Mail {
	[TestFixture]
	public class MailExamples {
		[TestCase(@"", false, Description = "Empty string is not a vaild adress")]
		[TestCase(@"a", false)]
		[TestCase(@"hello@example.com", true)]
		[TestCase(@"hel+lo@example.com", true)]
		[TestCase(@"hello@example.example", true)]
		[TestCase(@"""very.(),:;<>[]\"".VERY.\""very@\\ \""very\"".unusual""@strange.example.com", true)]
		[TestCase(@"customer/department=shipping@example.com", true)]
		[TestCase(@"!def!xyz%abc@example.com", true)]
		public void ValidateEmail(string email, bool isValid) {
			Assert.That(ValidateEmail(email), Is.EqualTo(isValid));
		}

		public bool ValidateEmail(string email) {
			var retVal = false;
			try {
				if (!string.IsNullOrEmpty(email))
				{
					// ReSharper disable once ObjectCreationAsStatement
					new MailAddress(email);
					retVal = true;
				}
			} catch (FormatException) {
				//Email adress is not valid
				retVal = false;
			}

			return retVal;
		}
	}
}