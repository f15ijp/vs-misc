Option Explicit On

Imports NUnit.Framework

Namespace ConversionExamples
	<TestFixture>
	Public Class DoubleTryParse

		<Test> <SetCulture("en-US")>
		Public Sub DoubleTryParseExample_enUS()

			Assert.That(Double.TryParse("1,5", Nothing), [Is].True)
			Assert.That(Double.TryParse("1.5", Nothing), [Is].True)

		End Sub

		<Test> <SetCulture("sv-SE")>
		Public Sub DoubleTryParseExample_svSE()

			Assert.That(Double.TryParse("1,5", Nothing), [Is].True)
			Assert.That(Double.TryParse("1.5", Nothing), [Is].False)

		End Sub

	End Class
End Namespace