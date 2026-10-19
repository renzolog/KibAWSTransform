Namespace Autenthicate
Public Class LoginException
    Inherits SystemException
     
    Friend Sub New(Metodo As String, innerException As SystemException)
        MyBase.New("Autenticazione non valida: vedere inner exception per ulteriori dettagli", innerException)
            LogSystem.LogException(Nothing, Metodo, innerException.Message, innerException)
        End Sub

            Friend Sub New(Metodo As String, Message As String)
        MyBase.New( Message)
            LogSystem.LogException(Nothing, Metodo, Message, Nothing)
        End Sub

End Class
    End Namespace

