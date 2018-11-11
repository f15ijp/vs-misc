Imports System.Data

Namespace Examples.System.Data
	Public Class DataTableExamples
		Public Sub LoopAllRowsAndColumnsInTable(ByVal dt As DataTable) 
			For Each dr As DataRow In dt.Rows
				Dim row As New List(Of KeyValuePair(Of String, String))
				For Each dc As DataColumn In dt.Columns
					row.Add(New KeyValuePair(Of String, String)(dc.ColumnName, dr(dc)))
				Next
			Next
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