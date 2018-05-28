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

		<TestCase("1", "2")>
		<TestCase("a", "b")>
		<TestCase("2000-01-01", "2000-01-02")>
		Public Sub LessThan(Byval a As String, Byval b As String)
			Assert.That(a, [Is].LessThanOrEqualTo(b))
		End Sub

		<Test>
		Public Sub CompareDateToString()
			Assert.That(Today.ToString(), [Is].Not.EqualTo(Today))
			Assert.That(Today.ToString() = Today)
		End Sub

	End Class
End Namespace
