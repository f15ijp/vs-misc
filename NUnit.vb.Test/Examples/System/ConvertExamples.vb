Imports NUnit.Framework

Namespace Examples.System
	<TestFixture()>
	Public Class ConvertExamples

		<Test>
		Public Sub Convert_String_ToInt32_Throws()
			Assert.Multiple(Sub()
								Assert.Throws(Of FormatException)(Sub() Convert.ToInt32(String.Empty))
								Assert.Throws(Of FormatException)(Sub() Convert.ToInt32(Guid.NewGuid().ToString()))
							End Sub)

		End Sub

		<Test>
		Public Sub Convert_ToString_Boolean()
			Assert.Multiple(Sub()
								Assert.That(Convert.ToString(True), [Is].EqualTo("True"))
								Assert.That(Convert.ToString(False), [Is].EqualTo("False"))
							End Sub)
		End Sub

	End Class
End Namespace