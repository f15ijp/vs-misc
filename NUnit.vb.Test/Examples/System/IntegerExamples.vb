Imports NUnit.Framework

Namespace Examples.System
	<TestFixture()>
	Public Class IntegerExamples

		<Test()>
		Public Sub Compare_Zero_with_empty_string()
			Assert.Throws(Of InvalidCastException)(Function()
													   Return 0 = ""
												   End Function)
		End Sub

	End Class
End Namespace