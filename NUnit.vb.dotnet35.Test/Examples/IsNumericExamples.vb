Option Explicit On

Imports System
Imports NUnit.Framework

Namespace NUnit.vb.dotnet35.Test

	<TestFixture>
	Public Class IsNumericExamples

		<TestCase("1.0.0", true)>
		<TestCase("1.0,0", true)>
		<TestCase("1,0.0", false)>
		<TestCase("1,0,0", false)>
		Public Sub TestMethod(input As String, expected As Boolean)
			Assert.That(IsNumeric(input), [Is].EqualTo(expected))
		End Sub

	End Class

End Namespace