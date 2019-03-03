Namespace Examples.System
	Public Class PropertyExamples

		''' <summary>
		''' When only accessed to get or set there is no need for implementing get/set
		''' </summary>
		Public Property AutoProperty As String

		Private _property As String

		''' <summary>
		''' Property with implementation in get or set
		''' </summary>
		Public Property [Property] As String
			Get
				If String.IsNullOrEmpty(_property) Then
					_property = Guid.NewGuid().ToString()
				End If

				Return _property
			End Get
			Set(ByVal value As String)
				_property = value
			End Set
		End Property

		''' <summary>
		''' To have different access modifiers, simply declare them on get or set
		''' </summary>
		Public Property PropertyWithRestricedAccessModifier As String
			Get
				If String.IsNullOrEmpty(_property) Then
					_property = Guid.NewGuid().ToString()
				End If

				Return _property
			End Get
			Protected Set(ByVal value As String)
				_property = value
			End Set
		End Property

	End Class
End Namespace