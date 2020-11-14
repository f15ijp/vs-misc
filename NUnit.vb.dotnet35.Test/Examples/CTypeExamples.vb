Imports NUnit.Framework

Namespace Examples
	Public Class CTypeExamples

		<Test>
		Public Sub CInt_Nohthing()
			Assert.That(CInt(Nothing), [Is].Zero)
		End Sub

	End Class
End Namespace