
Namespace ExceptionHelper
    Public Class DatoGiaPresenteException
        Inherits System.Exception
        Implements ValidationException

        Public Sub New()
            MyBase.New("Non è possibile inserire il dato. Tale dato è già presente.")
        End Sub

        Public Sub New(Messaggio As String)
            MyBase.New(Messaggio)
        End Sub

        Public Property Logged As Boolean Implements ValidationException.Logged

    End Class
End Namespace
