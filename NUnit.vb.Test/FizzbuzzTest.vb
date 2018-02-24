Option Explicit On

Imports NUnit.Framework

<TestFixture>
Public Class FizzbuzzTest

	<TestCase(1, ExpectedResult:="1")>
	<TestCase(2, ExpectedResult:="2")>
	<TestCase(3, ExpectedResult:="Fizz")>
	<TestCase(5, ExpectedResult:="Buzz")>
	<TestCase(15, ExpectedResult:="FizzBuzz")>
	Public Function TestCases(Input As Integer) As String
		Return Fizzbuzz.FizzBuzz(Input)
	End Function

	<TestCase(-1)>
	Public Sub TestExceptions_Assert_Throws(input As Integer)
		Assert.Throws(Of ArgumentException)(Sub() Fizzbuzz.FizzBuzz(input))
	End Sub

	<TestCase(-1)>
	Public Sub TestException_Assert_That(input As Integer)
		Assert.That(Sub() Fizzbuzz.FizzBuzz(input), Throws.ArgumentException)
	End Sub

End Class