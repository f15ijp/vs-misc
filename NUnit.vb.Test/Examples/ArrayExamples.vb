Imports NUnit.Framework

Namespace Examples

	<TestFixture>
	Public Class ArrayExamples

		<Test>
		Public Sub CallingIndexOutsideArrayGivesIndexOutOfRangeException()
			Dim theArray = {String.Empty, String.Empty}

			Assert.Throws(Of IndexOutOfRangeException)(Sub()
														   Dim test = theArray(3)
													   End Sub)

		End Sub

	End Class

End Namespace