Option Explicit On

Imports NUnit.Framework

Namespace Examples

	<TestFixture>
	Public Class ToStringExamples

		<Test>
		Public Sub Boolean_ToString(<Values>theBool as Boolean)
			TestContext.WriteLine(theBool.ToString())
			Assert.That(theBool.ToString(), [Is].Not.Empty)
		End Sub

	End Class

End Namespace