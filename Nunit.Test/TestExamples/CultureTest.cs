using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace Examples.TestExamples {
	public class CultureTest {

		[Test]
		[SetCulture("en-US")]
		public void SingleCultreUsingSetCulture_USA() {
			var date = new DateTime(2012, 10, 14);
			var dateString = date.ToString("dd/MM/yyyy");
			Assert.That(dateString, Is.EqualTo("14/10/2012"));
		}

		[Test]
		[SetCulture("sv-SE")]
		public void SingleCultreUsingSetCulture_Sweden() {
			var date = new DateTime(2012, 10, 14);
			var dateString = date.ToString("dd/MM/yyyy");
			Assert.That(dateString, Is.EqualTo("14-10-2012"));
		}

		[Test]
		[TestCase("en-US")]
		[TestCase("sv-SE")]
		[TestCase("da-DK")]
		public void MultipleCulturesUsingTestCases(string cultureName) {
			var culture = CultureInfo.GetCultureInfo(cultureName);
			Thread.CurrentThread.CurrentCulture = culture;
			Thread.CurrentThread.CurrentUICulture = culture;

			var date = new DateTime(2012, 10, 14);
			var dateString = date.ToString("dd/MM/yyyy");
			//This is a bad test, it is only here to show that the culture is different 
			Assert.That(dateString, cultureName == "en-US" ? Is.EqualTo("14/10/2012") : Is.EqualTo("14-10-2012"));
		}
	}
}
