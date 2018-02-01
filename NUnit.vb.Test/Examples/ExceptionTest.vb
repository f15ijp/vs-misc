Option Explicit On

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
		Public Sub Excpetion_Assert_Throws_SubWithArgument()
			Assert.Throws(Of ArgumentException)(Sub() SubThatThrowsWithArgument(True))
		End Sub

		<Test>
		Public Sub Excpetion_Assert_That_SubWithArgument()
			Assert.That(Sub() SubThatThrowsWithArgument(True), Throws.ArgumentException)
		End Sub

		<Test>
		Public Sub Excpetion_Assert_Throws_Function()
			Assert.Throws(Of ArgumentException)(Function() FunctionThatThrows())
		End Sub

		<Test>
		Public Sub Excpetion_Assert_That_Function()
			Assert.That(AddressOf FunctionThatThrows, Throws.ArgumentException)
		End Sub

		<Test>
		Public Sub Excpetion_Assert_Throws_FunctionWithArgument()
			Assert.Throws(Of ArgumentException)(Function() FunctionThatThrowsWithArgument(True))
		End Sub

		<Test>
		Public Sub Excpetion_Assert_That_FunctionWithArgument()
			Assert.That(Sub() FunctionThatThrowsWithArgument(True), Throws.ArgumentException)
		End Sub

#Region "Infrasctructure for test"

		Private Shared Sub SubThatThrows()
			Throw New ArgumentException("Throws for test")
		End Sub

		Private Shared Sub SubThatThrowsWithArgument(ByVal shouldThrow As Boolean)
			If shouldThrow Then
				Throw New ArgumentException("Throws for test")
			End If
		End Sub

		Private Shared Function FunctionThatThrows()
			Throw New ArgumentException("Throws for test")
		End Function

		Private Shared Function FunctionThatThrowsWithArgument(ByVal shouldThrow As Boolean)
			If shouldThrow Then
				Throw New ArgumentException("Throws for test")
			Else
				Return Nothing
			End If
		End Function

#End Region

	End Class

End Namespace