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

		Public Shared Function GetEnumFromName(Of T)(ByVal name As String) As T

			Try
				Dim theEnum As T = CType([Enum].Parse(GetType(T), name), T)
				If [Enum].IsDefined(GetType(T), theEnum) Then
					Return theEnum
				End If
			Catch e As ArgumentException
			End Try
			Return Nothing

		End Function

		<Test()> Public Sub GetEnumFromName_Example()

			For Each item As EnumExamples.ExampleEnum In [Enum].GetValues(GetType(ExampleEnum))
				Dim statusFromString As ExampleEnum = GetEnumFromName(Of ExampleEnum)(item.ToString())
				Assert.That(statusFromString, [Is].EqualTo(item))
			Next

		End Sub

	End Class
End Namespace