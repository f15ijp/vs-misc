Imports NUnit.Framework

Namespace Examples.System
	Public Class IntegerExamples

		Public Class CIntExamples

			<TestCase("", "empty string")>
			<TestCase("one", "a string")>
			Public Sub CInt_throws_InvalidCastException(input As Object, message As String)
				Assert.Throws(Of InvalidCastException)(Function()
														   Return CInt(input)
													   End Function, message:=message)
			End Sub

			<TestCase("2147483648", "integer.MaxValue +1")>
			<TestCase("-2147483649", "Integer.MinValue -1")>
			Public Sub CInt_throws_OverflowException(input As Object, message As String)
				Assert.Throws(Of OverflowException)(Function()
														Return CInt(input)
													End Function, message:=message)
			End Sub

			<TestCase(Nothing, 0, "Nothing")>
			<TestCase("0", 0, "0 (as string)")>
			Public Sub CInt_gives_what_for_inputs(input As Object, expected As Integer, message As String)
				Assert.That(CInt(input), [Is].EqualTo(expected), message)
			End Sub

		End Class
	End Class
End Namespace