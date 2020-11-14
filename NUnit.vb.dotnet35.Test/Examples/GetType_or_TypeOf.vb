Imports NUnit.Framework

Namespace Examples
	Public Class GetType_or_TypeOf

		Public Class Animal

		End Class
		Public Class Dog
			Inherits Animal
		End Class

		<Test>
		Public Sub CheckType()
			Dim spot As New Dog()

			Assert.Multiple(Sub()
								Assert.That(spot.GetType() Is GetType(Animal), [Is].False)
								Assert.That(TypeOf spot Is Animal, [Is].True)
								Assert.That(spot.GetType() Is GetType(Dog), [Is].True)
								Assert.That(TypeOf spot Is Dog, [Is].True)
							End Sub)
		End Sub
	End Class
End Namespace
