Imports System.IO
Imports NUnit.Framework

Namespace Examples.IO
	<TestFixture()>
	Public Class FileExamples

		Public Sub WriteByteArrayToFile(array As Byte(), fileName As String)
			File.WriteAllBytes(fileName, array)
		End Sub

	End Class
End Namespace