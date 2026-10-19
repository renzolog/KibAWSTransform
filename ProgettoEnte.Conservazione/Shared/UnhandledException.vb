Public Class UnhandledException
    Inherits SystemException
     
    Friend Sub New(Metodo As String, innerException As SystemException)
        MyBase.New("Eccezione non gestita vedere innerexception per ulteriori dettagli", innerException)
        LogSystem.LogException(Nothing, Metodo, innerException.Message, innerException)
    End Sub
End Class
