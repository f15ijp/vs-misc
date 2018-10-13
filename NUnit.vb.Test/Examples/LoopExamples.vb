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

		<Test>
		Public Sub ForLoop_from_zero_to_zero()
			Dim counter As Integer = 0
			For i As Integer = 0 To 0
				counter += 1
			Next
			Assert.That(counter, [Is].EqualTo(1))
		End Sub

	End Class
End Namespace