Imports System.Net
Imports NUnit.Framework

Namespace Examples.System

	Public Class ExecptionExamples

		<Test>
		Public Sub CatchExeptionWith()
			Try
				'Do some webrequest ...
			Catch ex As WebException When ex.Status = WebExceptionStatus.ConnectionClosed OrElse ex.Status = WebExceptionStatus.KeepAliveFailure

			End Try
		End Sub

	End Class

End Namespace