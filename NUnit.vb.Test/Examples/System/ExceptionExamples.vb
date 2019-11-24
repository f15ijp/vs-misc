Imports System.Net
Imports NUnit.Framework

Namespace Examples.System

	Public Class ExceptionExamples

		<Test>
		Public Sub CatchExceptionWhen()
			Try
				'Do some webrequest ...
			Catch ex As WebException When ex.Status = WebExceptionStatus.ConnectionClosed OrElse ex.Status = WebExceptionStatus.KeepAliveFailure
				'ConnectionClosed or KeepAliveFailure
			Catch ex As WebException When ex.Status = WebExceptionStatus.ConnectFailure
				'ConnectFailure
			End Try
		End Sub

	End Class

End Namespace