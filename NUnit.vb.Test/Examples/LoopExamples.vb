Imports NUnit.Framework

Namespace Examples
	<TestFixture()>
	Public Class LoopExamples

#Region "For"
		<Test>
		Public Sub ForLoop_from_zero_to_one_minus_one()
			Dim counter As Integer = 0
			For i As Integer = 0 To 1 - 1
				counter += 1
			Next
			Assert.That(counter, [Is].EqualTo(1))
		End Sub

		<TestCase(0, 0, ExpectedResult:=1)>
		<TestCase(0, -1, ExpectedResult:=0)>
		Public Function ForLoop_number_of_itterations(from As Integer, endAt As Integer) As Integer
			Dim counter As Integer = 0
			For i As Integer = from To endAt
				counter += 1
			Next
			Return counter
		End Function

		<TestCase(0, 10, 11, ExpectedResult:=1)>
		<TestCase(0, 10, -1, ExpectedResult:=12)>
		Public Function ForLoop_change_value_of_i(startAt As Integer, endAt As Integer, changeTo As Integer)
			dim hasChanged As Boolean
			Dim counter As Integer = 0
			For i As Integer = startAt To endAt
				If Not hasChanged
					i = changeTo
					hasChanged = True
				End If
				counter += 1
			Next
			Return counter
		End Function

		<TestCase(0, 10, 11, ExpectedResult:=11)>
		<TestCase(0, 10, -1, ExpectedResult:=11)>
		Public Function ForLoop_change_value_of_EndAt(startAt As Integer, endAt As Integer, changeTo As Integer)
			dim hasChanged As Boolean
			Dim counter As Integer = 0
			For i As Integer = startAt To endAt
				If Not hasChanged
					'note: as the loop has already started changing the end of it will have no effect
					endAt = changeTo
					hasChanged = True
				End If
				counter += 1
			Next
			Return counter
		End Function

#End Region
#Region "While"
		<TestCase(0, 10, ExpectedResult:=10)>
		<TestCase(0, 0, ExpectedResult:=0)>
		<TestCase(0, -1, ExpectedResult:=0)>
		Public Function WhileLoop_number_of_itterations(from As Integer, endAt As Integer) As Integer
			Dim counter As Integer = 0
			Dim i As Integer = from
			While i < endAt
				counter += 1
				i += 1
			End While
			Return counter
		End Function
#End Region

	End Class
End Namespace