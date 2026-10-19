Imports System.Runtime.Serialization

Namespace Conservatori.Infocert.Exception

    Public Class InfocertExtededSystemException
        Inherits System.Exception

        Private _ErrorInfo As Infocert.Shared.ErrorInfo
        Public ReadOnly Property ErrorInfo As Infocert.Shared.ErrorInfo
            Get
                Return _ErrorInfo
            End Get
        End Property

        Public Sub New(Metodo As String, Message As String, InnerException As System.Exception, ErrorInfo As Infocert.Shared.ErrorInfo, LoginSession As Object)
            MyBase.New(Message, InnerException)

            _ErrorInfo = ErrorInfo
            LogSystem.LogException(LoginSession, Metodo, String.Format("{0}: {1}", Message, ErrorInfo), InnerException)
        End Sub

        'Sub New()
        '    Dim ErrorInfo As New [Shared].ErrorInfo

        '    If WebEx.Response IsNot Nothing Then
        '        Using reader As New IO.StreamReader(WebEx.Response.GetResponseStream())
        '            ErrorInfo = GetErrorInfo(reader.ReadToEnd)
        '        End Using

        '    End If

        '    '  Return New Exception.InfocertExtededSystemException(Metodo, WebEx.Message, WebEx.InnerException, ErrorInfo)

        'End Sub
    End Class

End Namespace
