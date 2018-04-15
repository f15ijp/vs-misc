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
					Return "integer"
			End Select
			Throw New ArgumentOutOfRangeException
		End Function

		<Test>
		Public Sub Test_GetTypeName_WorksOnDotNet3_5()
			Assert.That(SelectCaseByTypeExuvalient_WorksOnDotNet35(String.Empty), [Is].EqualTo("string"))
			Assert.That(SelectCaseByTypeExuvalient_WorksOnDotNet35(42), [Is].EqualTo("integer"))
		End Sub

		Function SelectCaseByTypeExuvalient_WorksOnDotNet35(ByVal input) As String
			If TypeOf input Is String Then
				Return "string"
			ElseIf TypeOf input Is Integer Then
				Return "integer"
			End If
			Throw New ArgumentOutOfRangeException
		End Function

	End Class
End Namespace