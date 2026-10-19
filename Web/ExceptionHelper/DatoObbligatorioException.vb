
Namespace ExceptionHelper
    Public Class DatoObbligatorioException
        Inherits Exception
        Implements ValidationException

        Public Property Logged As Boolean Implements ValidationException.Logged


        Private Sub New()

        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)

        End Sub
        Private Sub New(ByVal message As String, ByVal innerException As Exception)
            MyBase.New(message, innerException)

        End Sub
        Private Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
        End Sub

    End Class
End Namespace