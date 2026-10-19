Imports ProgettoEnte.Conservazione.Autenthicate

Namespace Conservatori.PARER.Autenticazione
    ''' <summary>
    ''' Oggetto di login specifico per il Conservatore PARER 
    ''' </summary> 
    Public Class PARERLoginInfo
        Inherits Autenthicate.LoginInfo

        Public Overrides Function ToString() As String
            Return String.Format("Username '{0}' - Password '{1}'", "", "")
        End Function

        Sub New(InfoLogin As LoginManager, Ente As Data.EnteBase, EnteUtente As Data.EnteUtenteBase)
            MyBase.New(InfoLogin, Ente, EnteUtente)
        End Sub

    End Class
End Namespace
