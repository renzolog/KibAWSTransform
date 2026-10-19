Namespace Conservatori.PARER.Shared
    Module SharedInfo


        Private Const URIBaseConservazione As String = "https://parer.regione.emilia-romagna.it/sacer/VersamentoSync"
        Private Const URIBaseConservazionePre As String = "https://parer-pre.regione.emilia-romagna.it/sacer/VersamentoSync"
        Private Const URIBaseConservazioneAllegati As String = "https://parer.regione.emilia-romagna.it/sacer/AggiuntaAllegatiSync"
        Private Const URIBaseConservazioneAllegatiPre As String = "https://parer-pre.regione.emilia-romagna.it/sacer/AggiuntaAllegatiSync"
        Private Const URIBaseEsibizione As String = "https://parer.regione.emilia-romagna.it/sacer/RecDIPUnitaDocumentariaSync"
        Private Const URIBaseEsibizionePre As String = "https://parer-pre.regione.emilia-romagna.it/sacer/RecDIPUnitaDocumentariaSync"

        Public Const VersioneEsibizione As String = "1.0"


        Public Function getURIBaseConservazione(InCollaudo As Boolean) As String
            If InCollaudo Then
                Return URIBaseConservazionePre
            Else
                Return URIBaseConservazione
            End If
        End Function

        Public Function getURIBaseConservazioneAllegati(InCollaudo As Boolean) As String
            If InCollaudo Then
                Return URIBaseConservazioneAllegatiPre
            Else
                Return URIBaseConservazioneAllegati
            End If
        End Function

        Public Function getURIBaseEsibizione(InCollaudo As Boolean) As String
            If InCollaudo Then
                Return URIBaseEsibizionePre
            Else
                Return URIBaseEsibizione
            End If
        End Function

    End Module
End Namespace