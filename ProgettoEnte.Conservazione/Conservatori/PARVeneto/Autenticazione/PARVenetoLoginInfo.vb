Imports ProgettoEnte.Conservazione.Autenthicate

Namespace Conservatori.PARVeneto.Autenticazione
    Public Class PARVenetoLoginInfo
        Inherits Autenthicate.LoginInfo

        Sub New(InfoLogin As LoginManager, Ente As Data.EnteBase, EnteUtente As Data.EnteUtenteBase)
            MyBase.New(InfoLogin, Ente, EnteUtente)
        End Sub
    End Class

End Namespace

