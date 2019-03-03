Imports System.Data
Imports NUnit.Framework

Namespace Examples.System.Data
	<TestFixture()>
	Public Class DataTableExamples
		Public Sub LoopAllRowsAndColumnsInTable(ByVal dt As DataTable) 
			For Each dr As DataRow In dt.Rows
				Dim row As New List(Of KeyValuePair(Of String, String))
				For Each dc As DataColumn In dt.Columns
					row.Add(New KeyValuePair(Of String, String)(dc.ColumnName, dr(dc)))
				Next
			Next
		End Sub

		<Test()>
		Public Sub Adding_a_row_to_an_empty_DataTable()
			Dim dt As DataTable = GetDataTable()
			dt.Rows.InsertAt(dt.NewRow(), 0)
			Assert.That(dt.Rows.Count, [Is].EqualTo(1))
		End Sub

		<Test()>
		Public Sub Removing_a_row_from_an_DataTable()
			Dim dt As DataTable = GetDataTable(noOfRows:=1)

			dt.Rows.RemoveAt(0)
			Assert.That(dt.Rows.Count, [Is].EqualTo(0))
		End Sub

		<Test()>
		Public Sub Removing_rows_from_position_zero_of_an_DataTable()
			Dim dt As DataTable = GetDataTable(noOfRows:=5)

			For i As Integer = 0 To dt.Rows.Count -1
				dt.Rows.RemoveAt(0)
			Next
			Assert.That(dt.Rows.Count, [Is].EqualTo(0))
		End Sub

		Private Sub DoSomethingWithADataRow(ByVal dr As DataRow)
		End Sub
		<Test()>
		Public Sub Accessing_non_existant_row_by_index_gives_indexOutOfRangeExcetion_when_calling_other_function()
			Dim dt As DataTable = GetDataTable()
			Assert.Throws(Of IndexOutOfRangeException)(Sub()
															DoSomethingWithADataRow(dt.Rows(0))
														End Sub)
		End Sub

		<Test()>
		Public Sub Accessing_non_existant_row_by_index_gives_indexOutOfRangeExcetion()
			Dim dt As DataTable = GetDataTable()
			Assert.Throws(Of IndexOutOfRangeException)(Function()
															Return dt.Rows(0)
														End Function)
		End Sub

		<Test()>
		Public Sub Accessing_column_in_non_existant_row_by_index_gives_indexOutOfRangeExcetion()
			Dim dt As DataTable = GetDataTable()
			Assert.Throws(Of IndexOutOfRangeException)(Function()
															Return dt.Rows(0)("string")
														End Function)
		End Sub

#Region "Infrastructure"

		Public Shared Function GetDataTable(Optional ByVal noOfRows As Integer = 0) As DataTable

			Dim dt As New DataTable()
			dt.Columns.Add(New DataColumn("string", GetType(String)))
			dt.Columns.Add(New DataColumn("object", GetType(Object)))
			dt.Columns.Add(New DataColumn("integer", GetType(Integer)))
			dt.Columns.Add(New DataColumn("null", GetType(Object)))

			dt.AcceptChanges()
			For i As Integer = 0 To noOfRows-1
				dt.Rows.InsertAt(dt.NewRow(), 0)
			Next

			Return dt

		End Function

#End Region

	End Class
End Namespace