Imports ProgettoEnte.Conservazione.Autenthicate

Namespace Conservatori.DAX.Autenticazione
    ''' <summary>
    ''' Oggetto di login specifico per il Conservatore DAX 
    ''' </summary> 
    Public Class DAXLoginInfo
        Inherits Autenthicate.LoginInfo

        Sub New(InfoLogin As LoginManager, Ente As Data.EnteBase, EnteUtente As Data.EnteUtenteBase)
            MyBase.New(InfoLogin, Ente, EnteUtente)
        End Sub

    End Class
End Namespace