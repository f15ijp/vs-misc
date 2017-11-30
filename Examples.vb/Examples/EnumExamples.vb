Imports NUnit.Framework

Namespace Examples
	Public Class EnumExamples

		Enum ExampleEnum
			EnumOne
			EnumTwo
		End Enum

		Public Shared Function GetRandomEnum(Of T)() As T

			Dim v As T() = [Enum].GetValues(GetType(T))
			Return CType(v.GetValue(New Random().[Next](v.Length)), T)

		End Function

		<Test> Public Sub GetRandomEnum_Example()
			Assert.That(GetRandomEnum(Of ExampleEnum)(), [Is].TypeOf(GetType(ExampleEnum)))
		End Sub

	End Class
End NameSpace