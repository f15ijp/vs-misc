Imports System.Data
Imports NUnit.Framework

Namespace SystemData

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

		<Test> Public Sub DataRow_Type_With_Conversion_When_Null()

			Dim drWithValue As DataRow = GetDataRow(True)
			Dim drWithoutValue As DataRow = GetDataRow(False)

			Assert.That(ConvertTo(Of String)(drWithValue("string")), [Is].TypeOf(GetType(String)))
			Assert.That(ConvertTo(Of String)(drWithoutValue("string")), [Is].Null)

			Assert.That(ConvertTo(Of Object)(drWithValue("object")), [Is].TypeOf(GetType(Object)))
			Assert.That(ConvertTo(Of Object)(drWithoutValue("object")), [Is].Null)

			Assert.That(ConvertTo(Of Integer)(drWithValue("integer")), [Is].TypeOf(GetType(Integer)))
			Assert.That(ConvertTo(Of Integer)(drWithoutValue("integer")), [Is].TypeOf(GetType(Integer)))

		End Sub

		Shared Function ConvertTo(Of T)(ByVal value As Object) As T
			If TypeOf (value) Is DBNull Then
				Return CType(Nothing, T)
			End If

			Try
				Return CType(value, T)
			Catch ex As InvalidCastException
				Return CType(Nothing, T)
			End Try
		End Function

#Region "Infrastructure"

		Public Function GetDataRow(popluateWithValues As Boolean) As DataRow

			Dim dr As DataRow = GetDataTable().NewRow()
			If (popluateWithValues) Then
				dr("string") = String.Empty
				dr("object") = New Object
				dr("integer") = 1
			End If

			Return dr

		End Function

		Public Function GetDataTable() As DataTable

			Dim dt As New DataTable()
			dt.Columns.Add(New DataColumn("string", GetType(String)))
			dt.Columns.Add(New DataColumn("object", GetType(Object)))
			dt.Columns.Add(New DataColumn("integer", GetType(Integer)))
			dt.Columns.Add(New DataColumn("null", GetType(Object)))

			dt.AcceptChanges()
			Return dt

		End Function

#End Region

	End Class

End Namespace