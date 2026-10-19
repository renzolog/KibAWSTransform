Namespace Codifiche.UnitaDocumentarie
    Public Class UnitaDocumentarioDatiInsertArgs

        Property ISTAT As String
        Property Conservatore As TipoConservatore
        Property Disabilitato As Boolean
        Property Codice As String
        Property DenominazioneTipologiaDocumento As String
        Property DenominazioneTipoDocumentoPrincipale As String
        Property VersanteUserName As String
        Property VersantePassword As String
        Property EsibizioneUserName As String
        Property EsibizionePassword As String
        Property Tipo As TipoOggetto
        Property Demografici As Boolean
        Property Contabilita As Boolean
        Property Policy As String
        Property Versione As TipoVersione

        Sub Valida()
            If String.IsNullOrEmpty(ISTAT) Then
                Throw New ExceptionHelper.DatoObbligatorioException("L'ISTAT è obbligatorio")
            End If

            If String.IsNullOrEmpty(Codice) Then
                Throw New ExceptionHelper.DatoObbligatorioException("Il Codice è obbligatorio")
            End If

            If String.IsNullOrEmpty(DenominazioneTipologiaDocumento) Then
                Throw New ExceptionHelper.DatoObbligatorioException("La Denominazione Tipologia Documento è obbligatoria")
            End If

            If String.IsNullOrEmpty(DenominazioneTipoDocumentoPrincipale) Then
                Throw New ExceptionHelper.DatoObbligatorioException("La Denominazione Tipo Documento Principale è obbligatoria")
            End If

            If String.IsNullOrEmpty(VersanteUserName) Then
                Throw New ExceptionHelper.DatoObbligatorioException("Il Versante Utente è obbligatorio")
            End If

            If String.IsNullOrEmpty(VersantePassword) Then
                Throw New ExceptionHelper.DatoObbligatorioException("La Versante Password è obbligatoria")
            End If

            If String.IsNullOrEmpty(EsibizioneUserName) Then
                Throw New ExceptionHelper.DatoObbligatorioException("L'Esibizione Utente è obbligatorio")
            End If

            If String.IsNullOrEmpty(EsibizionePassword) Then
                Throw New ExceptionHelper.DatoObbligatorioException("L'Esibizione Password è obbligatorio")
            End If
        End Sub

    End Class
End Namespace



