
Namespace Conservatori.DAX.Shared
    Public Class SharedInfo

        Private Const URIBaseConservazioneTest As String = "https://condidoc-test.regione.toscana.it:443/IrisBusiness/business/soap/WSCoreReceiveSipService"

        Private Const URIBaseEsibizioneTest As String = "	https://condidoc-test.regione.toscana.it:443/IrisBusiness/business/soap/WSCoreDIPSincroService"


        Shared Function getURIBaseConservazione(InCollaudo As Boolean) As String
            If InCollaudo Then
                Return URIBaseConservazioneTest
            Else
                Return ""
            End If
        End Function


        Shared Function getURIBaseEsibizione(InCollaudo As Boolean) As String
            If InCollaudo Then
                Return URIBaseEsibizioneTest
            Else
                Return ""
            End If
        End Function


    End Class

End Namespace
