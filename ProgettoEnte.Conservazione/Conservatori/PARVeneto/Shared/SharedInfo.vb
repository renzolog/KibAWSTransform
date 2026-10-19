Namespace Conservatori.PARVeneto.Shared
    Public Class SharedInfo

        Private Const URIBaseConservazioneAutenticazioneTest As String = "http://par.collaudo.regione.veneto.it/serviziPar/rest/login"
        Private Const URIBaseConservazioneAutenticazioneProduzione As String = ""

        Private Const URIBaseConservazioneTest As String = "http://par.collaudo.regione.veneto.it/serviziPar/rest/versamento"
        Private Const URIBaseConservazioneProduzione As String = ""


        Private Const URIBaseEsibizioneTest As String = "http://par.collaudo.regione.veneto.it/serviziPar/rest/esibizione"
        Private Const URIBaseEsibizioneProduzione As String = ""


        Shared Function getURIBaseAutenticazione(InCollaudo As Boolean) As String
            If InCollaudo Then
                Return URIBaseConservazioneAutenticazioneTest
            Else
                Return URIBaseConservazioneAutenticazioneProduzione
            End If
        End Function


        Shared Function getURIBaseConservazione(InCollaudo As Boolean) As String
            If InCollaudo Then
                Return URIBaseConservazioneTest
            Else
                Return URIBaseConservazioneProduzione
            End If
        End Function


        Shared Function getURIBaseEsibizione(InCollaudo As Boolean) As String
            If InCollaudo Then
                Return URIBaseEsibizioneTest
            Else
                Return URIBaseEsibizioneProduzione
            End If
        End Function
    End Class
End Namespace

