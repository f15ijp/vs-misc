using System;
using System.Globalization;
using NUnit.Framework;

namespace Examples.Examples.System
{
	public class DateTimeExamples
	{
		[Test]
		public void ToString_Examples()
		{
			var dateValue = DateTime.Now;
			TestContext.WriteLine($"Without formating/culture [a.k.a. use current culture] {dateValue.ToString()}");

			CultureInfo[] cultures = {
				new CultureInfo("en-US"),
				new CultureInfo("fr-FR"),
				new CultureInfo("it-IT"),
				new CultureInfo("de-DE"),
				new CultureInfo("sv-SE")
		};
			foreach (var culture in cultures)
			{
				TestContext.WriteLine("Using culture {0}: {1}", culture.Name, dateValue.ToString(culture));
			}
		}

		[Test]
		public void RemoveTimePartFromDateTime()
		{
			var currentDateAndTime = DateTime.Now;
			var currentDateWithoutHoursAndMinutes = currentDateAndTime.Date;

			TestContext.WriteLine("currentDateAndTime '{0}' - currentDateWithoutHoursAndMinutes '{1}' ", currentDateAndTime, currentDateWithoutHoursAndMinutes);
			Assert.That(currentDateAndTime, Is.Not.EqualTo(currentDateWithoutHoursAndMinutes));
		}
	}
}
