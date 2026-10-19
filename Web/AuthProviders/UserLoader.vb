Imports ProgettoEnte.Conservazione.AuthProviders

Namespace AuthProviders
    Public Class UserLoader
        Friend Const SessionKey As String = "User"

        ''' <summary>
        ''' Ritorna la classe User dell'utente loggato
        ''' </summary>
        Public Shared Function GetUserObject(username As String) As User

            If username = "" Then
                Return Nothing
            End If

            Dim context As HttpContext = HttpContext.Current

            Dim u As User
            If context.Session IsNot Nothing Then
                If context.Session(SessionKey) Is Nothing Then
                    u = User.GetUserObject(username)
                    context.Session.Add(SessionKey, u)
                End If
                u = TryCast(context.Session(SessionKey), User)
            Else
                u = User.GetUserObject(username)
            End If

            If u Is Nothing Then
                Return Nothing
            End If

            Return u
        End Function

        ''' <summary>
        ''' Cancella i dati dell'utente dalla memoria
        ''' </summary>
        Public Shared Sub ClearCache()
            Dim context As HttpContext = HttpContext.Current

            If context.Session IsNot Nothing AndAlso context.Session(SessionKey) IsNot Nothing Then
                context.Session(SessionKey) = Nothing
            End If
        End Sub


    End Class
End Namespace
