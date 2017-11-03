Option Explicit On

Imports NUnit.Framework

Namespace Statements

	<TestFixture>
	Public Class SelectCaseExamples

		<Test>
		Public Sub Select_Case_Types()

			Assert.That(GetTypeName(Of String), [Is].EqualTo("string"))
			Assert.That(GetTypeName(Of Integer), [Is].EqualTo("integer"))
			
		End Sub

		Function GetTypeName(Of T)() As String
			
			Select Case GetType(T)
				Case GetType(String)
					Return "string"
				Case GetType(Integer)
					return "integer"
			End Select
			Throw New ArgumentOutOfRangeException
		End Function

	End Class

End Namespace