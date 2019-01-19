Imports NUnit.Framework

Namespace Examples.System
	<TestFixture()>
	Public Class BooleanExamples

		<Test>
		Public Sub ToStringGives()
			Assert.Multiple(Sub()
								Assert.That(True.ToString, [Is].EqualTo("True"))
								Assert.That(False.ToString, [Is].EqualTo("False"))
							End Sub)
		End Sub
	End Class
End Namespace