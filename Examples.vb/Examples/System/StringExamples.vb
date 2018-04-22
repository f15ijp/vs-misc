Imports NUnit.Framework

Namespace Examples.System
	<TestFixture()>
	Public Class StringExamples
		
		<TestCase("")>
		<TestCase(",")>
		<TestCase("a,b")>
		Public Sub Split_FirstOrDefault(ByVal input As String)
			dim testVar As String = input.Split(",").FirstOrDefault()
			Assert.That(testVar, [Is].TypeOf(GetType(String)))
		End Sub

		<TestCase("")>
		<TestCase(",")>
		<TestCase("a,b")>
		Public Sub Split_ByIndex(ByVal input As String)
			dim testVar As String = input.Split(",")(0)
			Assert.That(testVar, [Is].TypeOf(GetType(String)))
		End Sub

	End Class
End Namespace
