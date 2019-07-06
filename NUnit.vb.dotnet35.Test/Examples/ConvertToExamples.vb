Option Explicit On

Imports NUnit.Framework

Namespace Examples

	<TestFixture>
	Public Class ConvertToExamples

		<SetCulture("en-US")>
		<TestCase("1,0", true)>
		<TestCase("1.0", true)>
		<TestCase("1.0.0", false)>
		<TestCase("", false)>
		Public Sub ToDouble(input As String, expected As Boolean)
			If expected Then
				Assert.DoesNotThrow(Sub() Convert.ToDouble(input))
			Else
				Assert.Throws(of FormatException)(Sub() Convert.ToDouble(input))
			End If
		End Sub

	End Class

End Namespace