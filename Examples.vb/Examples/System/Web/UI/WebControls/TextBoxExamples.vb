Option Explicit On

Imports System.Web
Imports System.Web.UI.WebControls
Imports NUnit.Framework

Namespace Examples.System.Web.UI.WebControls

	<TestFixture>
	Public Class TextBoxExamples

		Private Function GetTextBox() As TextBox
			Return New TextBox()
		End Function

		<Test> Public Sub SettingTextTo_Nothing()
			Dim textBox As TextBox = GetTextBox()
			textBox.Text = Nothing

			Assert.That(textBox.Text, [Is].Empty)
			Assert.That(textBox.Text, [Is].EqualTo(String.Empty))
		End Sub

		<Test> Public Sub SettingTextTo_NonExistingRequestString()
			Dim textBox As TextBox = GetTextBox()
			Dim request As New HttpRequest(String.Empty, "http://www.f15ijp.com", String.Empty)
			textBox.Text = request("keyNotFound")

			Assert.That(textBox.Text, [Is].Empty)
			Assert.That(textBox.Text, [Is].EqualTo(String.Empty))
		End Sub

	End Class

End Namespace