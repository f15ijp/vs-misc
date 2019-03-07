Option Explicit On

Imports NUnit.Framework

Namespace Tests

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

		<Test>
		Public Sub Exception_Assert_that_checks_exception_typ_and_message()
			Dim myExceptionMessage As String = "Something we can look for"
			Assert.Throws(
								[Is].TypeOf(Of ArgumentException)().And.Message.Contains("look for"),
								Sub() SubThatThrows(myExceptionMessage)
							)
		End Sub

#Region "Don't Throw"
		Public Sub Assert_That_Dont_Throw()
			Assert.That(Sub() FunctionThatThrowsWithArgument(False), Throws.Nothing)
			Assert.That(Sub() SubThatThrowsWithArgument(False), Throws.Nothing)
		End Sub

		Public Sub Dont_Throw()
			Assert.DoesNotThrow(Sub() FunctionThatThrowsWithArgument(False), Nothing)
			Assert.DoesNotThrow(Sub() SubThatThrowsWithArgument(False), Nothing)
		End Sub

#End Region

#Region "Infrasctructure for test"

		Private Shared Sub SubThatThrows(Optional byval message As String = "Throws for test")
			Throw New ArgumentException(message)
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