Imports System.Data
Imports NUnit.Framework

Namespace Examples.System.Data

	<TestFixture>
	Public Class DataRowExamples

		<Test> Public Sub DataRow_Type_When_Null()

			Dim drWithValue As DataRow = GetDataRow(True)
			Dim drWithoutValue As DataRow = GetDataRow(False)

			Assert.That(drWithValue("string"), [Is].TypeOf(GetType(String)))
			Assert.That(drWithoutValue("string"), [Is].TypeOf(GetType(DBNull)))

			Assert.That(drWithValue("object"), [Is].TypeOf(GetType(Object)))
			Assert.That(drWithoutValue("object"), [Is].TypeOf(GetType(DBNull)))

		End Sub

		<Test> Public Sub DataRow_Type_With_CType_Conversion_When_Null()

			Dim drWithValue As DataRow = GetDataRow(True)
			Dim drWithoutValue As DataRow = GetDataRow(False)

			Assert.That(ConvertByCtype(Of String)(drWithValue("string")), [Is].TypeOf(GetType(String)))
			Assert.That(ConvertByCtype(Of String)(drWithoutValue("string")), [Is].Null)

			Assert.That(ConvertByCtype(Of Object)(drWithValue("object")), [Is].TypeOf(GetType(Object)))
			Assert.That(ConvertByCtype(Of Object)(drWithoutValue("object")), [Is].Null)

			Assert.That(ConvertByCtype(Of Integer)(drWithValue("integer")), [Is].TypeOf(GetType(Integer)))
			Assert.That(ConvertByCtype(Of Integer)(drWithoutValue("integer")), [Is].TypeOf(GetType(Integer)))

		End Sub

		Shared Function ConvertByCtype(Of T)(ByVal value As Object) As T
			If TypeOf (value) Is DBNull Then
				Return CType(Nothing, T)
			End If

			Try
				Return CType(value, T)
			Catch ex As InvalidCastException
				Return CType(Nothing, T)
			End Try
		End Function

		<Test> Public Sub DataRow_Type_With_DefaultValue_Conversion_When_Null()

			Dim drWithValue As DataRow = GetDataRow(True)
			Dim drWithoutValue As DataRow = GetDataRow(False)

			Assert.That(Convert_With_DefaultValue(Of String)(drWithValue("string")), [Is].TypeOf(GetType(String)))
			Assert.That(Convert_With_DefaultValue(Of String)(drWithoutValue("string")), [Is].Null)

			Assert.That(Convert_With_DefaultValue(Of Object)(drWithValue("object")), [Is].TypeOf(GetType(Object)))
			Assert.That(Convert_With_DefaultValue(Of Object)(drWithoutValue("object")), [Is].Null)

			Assert.That(Convert_With_DefaultValue(Of Integer)(drWithValue("integer")), [Is].TypeOf(GetType(Integer)))
			Assert.That(Convert_With_DefaultValue(Of Integer)(drWithoutValue("integer")), [Is].TypeOf(GetType(Integer)))

		End Sub

		Shared Function Convert_With_DefaultValue(Of T)(ByVal value As Object) As T

			If TypeOf (value) Is DBNull Then
				Return GetDefaultValue(Of T)()
			End If

			Try
				Return CType(value, T)
			Catch ex As InvalidCastException
				Return GetDefaultValue(Of T)()
			End Try

		End Function

		Shared Function GetDefaultValue(Of T)() As T

			Dim retVal As T = Nothing

			If GetType(T).IsValueType Then
				retVal = Activator.CreateInstance(GetType(T))
			End If

			Return retVal

		End Function

#Region "Infrastructure"

		Public Shared Function GetDataRow(popluateWithValues As Boolean) As DataRow

			Dim dr As DataRow = DataTableExamples.GetDataTable().NewRow()
			If (popluateWithValues) Then
				dr("string") = String.Empty
				dr("object") = New Object
				dr("integer") = 1
			End If

			Return dr

		End Function

#End Region

	End Class

End Namespace