Imports ProgettoEnte.Conservazione.Conservatori.PARER.Conservazione

Namespace Conservatori.PARER.Autenticazione
    Friend Class Gestione

        Public Shared Function Login(LoginInfo As PARERLoginInfo) As PARERLoginSession

            If LoginInfo Is Nothing Then
                Return Nothing
            End If



            Dim l As New PARERLoginSession(LoginInfo.Ente, LoginInfo.EnteUtente)
            l.PARERLoginInfo = LoginInfo

            Dim e As New Data.EnteInfoPARER(LoginInfo.EnteUtente.AuthicatedUser)
            e = e.READAttivo()
            If e Is Nothing Then
                Throw New Autenthicate.LoginException("ReadParametri", "Dati PARER non trovati")
            End If
            l.PARERInfo = e



           

            Return l
        End Function

        Private Sub New()

        End Sub
    End Class
End Namespace

