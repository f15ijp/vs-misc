Imports NUnit.Framework

Namespace Examples.System
	<TestFixture()>
	Public Class DateAndTimeExamples

		<TestCase("2018-01-01", "2018-01-02", ExpectedResult:=1)>
		<TestCase("2018-01-01", "2018-01-02T01:02:03", ExpectedResult:=1)>
		<TestCase("2018-01-01T01:02:03", "2018-01-02", ExpectedResult:=0)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01", ExpectedResult:=0)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01T01:02:02", ExpectedResult:=0)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01T00:00:00", ExpectedResult:=0)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01T23:59:00", ExpectedResult:=1)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01T01:02:03", ExpectedResult:=1)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01T01:02:04", ExpectedResult:=1)>
		Public Function Example_of_datediff_with_days(dateFrom As String, dateTo As String)
			Return DateDiff(DateInterval.Day, DateTime.Parse(dateFrom), DateTime.Parse(dateTo))
		End Function

		<Test()>
		Public Sub Example_of_datediff_datetime_yesterday_with_time_compared_to_date_today()
			Dim yesterday As DateTime = DateTime.Now.AddDays(-1)
			Assert.Multiple(Sub()
								Assert.That(DateDiff(DateInterval.Day, DateTime.Parse(yesterday), DateTime.Today), [Is].EqualTo(0))
								Assert.That(DateDiff(DateInterval.Day, DateTime.Parse(yesterday), DateTime.Today.AddDays(1)), [Is].EqualTo(1))
							End Sub)
		End Sub

	End Class
End Namespace
