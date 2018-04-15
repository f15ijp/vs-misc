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
	End Class
End Namespace