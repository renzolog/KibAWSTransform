Imports ProgettoEnte.Conservazione.Autenthicate

Namespace Conservatori.Infocert.Autenticazione
    ''' <summary>
    ''' Oggetto di login specifico per il Conservatore Infocert 
    ''' </summary> 
    Public Class InfocertLoginInfo
        Inherits Autenthicate.LoginInfo

        Sub New(InfoLogin As LoginManager, Ente As Data.EnteBase, EnteUtente As Data.EnteUtenteBase)
            MyBase.New(InfoLogin, Ente, EnteUtente)
        End Sub

    End Class
End Namespace
