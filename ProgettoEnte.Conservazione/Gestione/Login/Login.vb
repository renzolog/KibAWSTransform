Namespace Autenthicate

    Friend Class Login



        Public Shared Function Effettua(LogModule As String, InfoLogin As LoginManager) As LoginInfo


            If String.IsNullOrEmpty(InfoLogin.Utente) Then
                Throw New ArgumentException("Utente Non Definito")
            End If

            If String.IsNullOrEmpty(InfoLogin.Password) Then
                Throw New ArgumentException("Password Non Definita")
            End If

            If String.IsNullOrEmpty(InfoLogin.ISTAT) Then
                Throw New ArgumentException("ISTAT Non Definito")
            End If


            Dim de As Data.EnteUtente = Data.EnteUtente.Read(InfoLogin.Utente, InfoLogin)

            If de Is Nothing Then
                Throw New Autenthicate.LoginException(LogModule, String.Format("Nome utente e/o password non validi {0} - {1} - {2}", InfoLogin.ISTAT, InfoLogin.Utente, InfoLogin.Password))
            End If


            If InfoLogin.Software = [Shared].TipoSoftware.Nessuno Then
                Throw New ArgumentOutOfRangeException("Software", "Software non gestito")
            End If

            ' Sostituire la risposta di questa funzione

            If de.Ente.Conservatore = Data.Enum.TipoConservatore.Infocert Then
                Return New ProgettoEnte.Conservazione.Conservatori.Infocert.Autenticazione.InfocertLoginInfo(InfoLogin, de.Ente, de)
            ElseIf de.Ente.Conservatore = Data.Enum.TipoConservatore.PARER Then
                Return New ProgettoEnte.Conservazione.Conservatori.PARER.Autenticazione.PARERLoginInfo(InfoLogin, de.Ente, de)
            ElseIf de.Ente.Conservatore = Data.Enum.TipoConservatore.DAX Then
                Return New ProgettoEnte.Conservazione.Conservatori.DAX.Autenticazione.DAXLoginInfo(InfoLogin, de.Ente, de)
            ElseIf de.Ente.Conservatore = Data.Enum.TipoConservatore.PARVeneto Then
                Return New ProgettoEnte.Conservazione.Conservatori.PARVeneto.Autenticazione.PARVenetoLoginInfo(InfoLogin, de.Ente, de)
            ElseIf de.Ente.Conservatore = Data.Enum.TipoConservatore.NonDefinito Then
                Throw New ArgumentException("Conservatore Non Definito")
            Else
                Throw New ArgumentOutOfRangeException("Conservatore", "Conservatore non gestito")
            End If

        End Function

    End Class

End Namespace
