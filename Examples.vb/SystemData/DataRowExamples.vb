Imports System.Data
Imports NUnit.Framework

Namespace SystemData

	<TestFixture>
	Public Class DataRowExamples
		
		<Test>Public Sub DataRow_Type_When_Null()
			
			Dim drWithValue As DataRow = GetDataRow(True)
			Dim drWithoutValue As DataRow = GetDataRow(False)
			
			Assert.That(drWithValue("string"), [Is].TypeOf(GetType(String)))
			Assert.That(drWithoutValue("string"), [Is].TypeOf(GetType(DBNull)))

			Assert.That(drWithValue("object"), [Is].TypeOf(GetType(Object)))
			Assert.That(drWithoutValue("object"), [Is].TypeOf(GetType(DBNull)))

		End Sub


		Public Function GetDataRow(popluateWithValues As Boolean) As DataRow

			Dim dr As DataRow = GetDataTable().NewRow()
			If (popluateWithValues) Then
				dr("string") = String.Empty
				dr("object") = New Object
			End If

			Return dr

		End Function

		Public Function GetDataTable() As DataTable

			Dim dt As New DataTable()
			dt.Columns.Add(New DataColumn("string", GetType(String)))
			dt.Columns.Add(New DataColumn("object", GetType(Object)))
			dt.Columns.Add(New DataColumn("null", GetType(Object)))

			dt.AcceptChanges()
			Return dt

		End Function

	End Class

End Namespace