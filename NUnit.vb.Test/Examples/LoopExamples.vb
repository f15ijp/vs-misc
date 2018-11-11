Imports NUnit.Framework

Namespace Examples
	<TestFixture()>
	Public Class LoopExamples
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

	End Class
End Namespace