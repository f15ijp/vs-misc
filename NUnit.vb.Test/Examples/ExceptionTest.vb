Option Explicit On

Imports System
Imports NUnit.Framework

Namespace Examples

	<TestFixture>
	Public Class ExceptionTest

		<Test>
		Public Sub Excpetion_Assert_Throws_TestSub()
			Assert.Throws(Of ArgumentException)(Sub() SubThatThrows())
		End Sub

		<Test>
		Public Sub Excpetion_Assert_That_TestSub()
			Assert.That(AddressOf SubThatThrows, Throws.ArgumentException)
		End Sub

		<Test>
		Public Sub Excpetion_Assert_Throws_Function()
			Assert.Throws(Of ArgumentException)(Function() FunctionThatThrows())
		End Sub

		<Test>
		Public Sub Excpetion_Assert_That_Function()
			Assert.That(AddressOf FunctionThatThrows, Throws.ArgumentException)
		End Sub

		Private Shared Sub SubThatThrows()
			Throw New ArgumentException("Throws for test")
		End Sub

		Private Shared Function FunctionThatThrows()
			Throw New ArgumentException("Throws for test")
		End Function

	End Class

End Namespace