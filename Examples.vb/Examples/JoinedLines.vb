Namespace Examples

	Public Class JoinedLines
		Public Sub JoinLinedExample()
			Dim a As Integer, b As Integer, c As Integer

			If a > 10 Then a = a + 1 : b = b + a : c = c + b

			'Is equal to
			If a > 10 Then
				a = a + 1
				b = b + a
				c = c + b
			End If

		End Sub
	End Class
End Namespace