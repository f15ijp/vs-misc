using System;
using NUnit.Framework;

namespace Examples.Examples.System {
	public class TimeSpanExamples {

		/// <summary>
		/// .Net versions &lt;= 4.0
		/// </summary>
		/// <param name="numberOfSeconds"></param>
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(60)]
		[TestCase(61)]
		public void CreateTimeSpanFromSeconds_dotnet_less_than_4(int numberOfSeconds) {
			var timespan = new TimeSpan(0, 0, numberOfSeconds);

			Assert.That(timespan.TotalSeconds, Is.EqualTo(numberOfSeconds));
		}


		/// <summary>
		/// .Net versions &gt; 4.0
		/// </summary>
		/// <param name="numberOfSeconds"></param>
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(60)]
		[TestCase(61)]
		public void CreateTimeSpanFromSeconds_dotnet_4_and_up(int numberOfSeconds) {
			var timespan = TimeSpan.FromSeconds(numberOfSeconds);

			Assert.That(timespan.TotalSeconds, Is.EqualTo(numberOfSeconds));
		}
	}
}