Option Explicit On

Imports System
Imports NUnit.Framework

Namespace Examples

	<TestFixture>
	Public Class TypeOfTest

		<Test>
		Public Sub TypeOf_ListOfInt()

			Dim testList AS New List(Of Integer)
			Assert.That(testList, [Is].TypeOf(GetType(List(Of Integer))))

		End Sub

	End Class

End Namespace