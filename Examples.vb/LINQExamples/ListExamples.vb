Imports NUnit.Framework

Namespace Examples.LINQExamples

	<TestFixture> Public Class ListExamples

		Class OtherType
			Property Id As Integer
			Property Name As String
			Property IdIsEven As Boolean
			Sub New(ByVal id As Integer)
				Me.Id = id
				Me.Name = id.ToString()
				Me.IdIsEven = (id Mod 2 = 0)
			End Sub
		End Class

		Shared Function GetList(ByVal getAll As Boolean) As List(Of Integer)

			Dim theList As New List(Of Integer)
			For i As Integer = 0 To 10
				If getAll OrElse Not i Mod 3 = 0 Then
					theList.Add(i)
				End If
			Next
			Return theList

		End Function
		Shared Function GetListOfOthers(ByVal getAll As Boolean) As List(Of OtherType)
			Return (From id In GetList(getAll) Select New OtherType(id)).ToList()	
		End Function

		<Test> Public Sub FindItemsInOneListNotInAnotherList_SameType()

			Dim oneList As List(Of Integer) = GetList(True)
			Dim anotherList As List(Of Integer) = GetList(False)

			Dim resultingList = oneList.Except(anotherList)
			Assert.That(resultingList.Count, [Is].GreaterThan(0))

		End Sub

		<Test> Public Sub FindItemsInOneListNotInAotherList_DiffentTypes()

			Dim oneList As List(Of Integer) = GetList(True)
			Dim anotherList As List(Of OtherType) = GetListOfOthers(False)

			Dim resultingList = oneList.Where(Function(item) Not anotherList.Any(Function(item2) item2.Id = item) )
			Assert.That(resultingList.Count, [Is].GreaterThan(0))
		End Sub

		<Test> Public Sub FindItemsInOneListNotInAotherList_DiffentTypes_OnlySome()

			Dim oneList As List(Of OtherType) = GetListOfOthers(True)
			Dim anotherList As List(Of Integer) = GetList(False)

			Dim resultingList = oneList.Where(Function(item) Not anotherList.Any(Function(item2) item.IdIsEven = False AndAlso item2 = item.Id) )
			Assert.That(resultingList.Count, [Is].GreaterThan(0))

		End Sub

	End Class

End Namespace