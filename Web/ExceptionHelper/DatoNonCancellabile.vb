Namespace ExceptionHelper
    Public Class DatoNonCancellabile
        Inherits System.Exception
        Implements ValidationException

        Sub New(Message As String)
            MyBase.New(Message)
        End Sub

        Public Property Logged As Boolean Implements ValidationException.Logged

    End Class
End Namespace
