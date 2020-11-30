Option Explicit On

Imports NUnit.Framework


Namespace System

	<TestFixture>
	Public Class StringExamples

		<Test>
		Public Sub TestAddingNothingToString()
			Assert.Multiple(Sub()
								Assert.That((String.Empty + Nothing), [Is].TypeOf(Of String), " + null")
								Assert.That((String.Empty & Nothing), [Is].TypeOf(Of String), "& null")
								Assert.Throws(Of ArgumentNullException)(Sub()
																		String.Empty.Concat(Nothing)
																	End Sub, "Concat null gives exception")
							End Sub)
		End Sub

		<Test>
		Public Sub StringInterpolationWithNothing()
			TestContext.WriteLine($"Adding nothing should not give an exception? '{Nothing}'")
			Dim newString As String
			TestContext.WriteLine($"Adding new string should not give an exception? '{newString}'")
		End Sub

		<Test>
		Public Sub SubStringOnNothing()
			Dim testString As String = Nothing
			Assert.Throws(Of NullReferenceException)(Sub()
' ReSharper disable once ReturnValueOfPureMethodIsNotUsed
				testString.Substring(0, 1)
			End Sub)
		End Sub

	End Class

End Namespace