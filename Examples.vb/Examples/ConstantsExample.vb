Imports NUnit.Framework

Namespace Examples
	<TestFixture>
	Public Class ConstantsExample
		Public Const PUBLIC_CONST As Integer = 42
		Private Const PRIVATE_CONST As Integer = 42

		<Test> Public Sub ShadowsConstGetsOtherValue()
			Assert.That(PUBLIC_CONST, [Is].Not.EqualTo(ClassThatInherits.PUBLIC_CONST))
		End Sub

	End Class

	Public Class ClassThatInherits
		Inherits ConstantsExample

		Public Shadows Const PUBLIC_CONST = 4
	End Class
End Namespace