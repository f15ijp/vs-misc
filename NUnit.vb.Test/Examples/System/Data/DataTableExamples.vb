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
		<Test()>
		Public Sub Accessing_non_existant_row_by_index_gives_indexOutOfRangeExcetion()
			Dim dt As DataTable = GetDataTable()
			Assert.Throws(Of IndexOutOfRangeException)(Function()
															Return dt.Rows(0)
														End Function)
		End Sub

#Region "Infrastructure"

		Public Shared Function GetDataTable() As DataTable

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