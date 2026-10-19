Imports Web.Codifiche.Enti.InfoCERT
Imports Web.Codifiche.Enti.InfoDAX
Imports Web.Codifiche.Enti.InfoPARER
Imports Web.Codifiche.Enti.InfoPARVENETO

Namespace Codifiche.Enti
    Public Class EnteDatiInsertArgs

        Property ISTAT As String
        Property Denominazione As String
        Property Disattivo As Boolean
        Property Conservatore As UnitaDocumentarie.TipoConservatore
        Property InCollaudo As Boolean
        Property DatiAggiuntivi As IEnteInfoDatiInsertArgs

        Sub Valida()
            If String.IsNullOrEmpty(ISTAT) Then
                Throw New ExceptionHelper.DatoObbligatorioException("L'ISTAT è obbligatorio")
            End If

            If ISTAT.Length <> 6 Then
                Throw New ExceptionHelper.DatoObbligatorioException("L'ISTAT deve contenere 6 caratteri")
            End If

            If String.IsNullOrEmpty(Denominazione) Then
                Throw New ExceptionHelper.DatoObbligatorioException("La Denominazione è obbligatoria")
            End If


            If Conservatore <> UnitaDocumentarie.TipoConservatore.NonDefinito Then
                If DatiAggiuntivi Is Nothing Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi mancanti")
                End If

                If Conservatore = UnitaDocumentarie.TipoConservatore.Infocert AndAlso Not TypeOf DatiAggiuntivi Is EnteInfoCERTDatiInsertArgs Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi errati o mancanti")
                ElseIf Conservatore = UnitaDocumentarie.TipoConservatore.PARER AndAlso Not TypeOf DatiAggiuntivi Is EnteInfoPARERDatiInsertArgs Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi errati o mancanti")
                ElseIf Conservatore = UnitaDocumentarie.TipoConservatore.DAX AndAlso Not TypeOf DatiAggiuntivi Is EnteInfoDAXDatiInsertArgs Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi errati o mancanti")
                ElseIf Conservatore = UnitaDocumentarie.TipoConservatore.PARVeneto AndAlso Not TypeOf DatiAggiuntivi Is EnteInfoPARVenetoDatiInsertArgs Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi errati o mancanti")
                End If
            End If
        End Sub

    End Class
End Namespace


