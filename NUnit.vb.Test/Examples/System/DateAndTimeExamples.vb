Imports NUnit.Framework

Namespace Examples.System
	<TestFixture()>
	Public Class DateAndTimeExamples

		<TestCase("2018-01-01", "2018-01-02", ExpectedResult := 1)>
		<TestCase("2018-01-01", "2018-01-02T01:02:03", ExpectedResult := 1)>
		<TestCase("2018-01-01T01:02:03", "2018-01-02", ExpectedResult := 0)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01", ExpectedResult := 0)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01T01:02:02", ExpectedResult := 0)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01T01:02:03", ExpectedResult := 1)>
		<TestCase("2018-10-31T01:02:03", "2018-11-01T01:02:04", ExpectedResult := 1)>
		public Function Example_of_datediff_with_days(dateFrom As String, dateTo As String)
			Return DateDiff(DateInterval.Day, DateTime.Parse(dateFrom), DateTime.Parse(dateTo))
		End Function
	End Class
End Namespace
