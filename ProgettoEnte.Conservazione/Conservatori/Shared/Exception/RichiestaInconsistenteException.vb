Namespace Conservatori.Shared.Exception
    Public Class RichiestaInconsistenteException
        Inherits SystemException

        Public Sub New(Metodo As String)
            MyBase.New("Richiesta Inconsistente")
            LogSystem.LogException(Nothing, Metodo, Message, Me)
        End Sub

        Public Sub New(Metodo As String, Message As String)
            MyBase.New(Message)
            LogSystem.LogException(Nothing, Metodo, Message, Me)
        End Sub

    End Class
End Namespace
