Imports Web.Codifiche.Enti.InfoCERT
Imports Web.Codifiche.Enti.InfoDAX
Imports Web.Codifiche.Enti.InfoPARER
Imports Web.Codifiche.Enti.InfoPARVENETO

Namespace Codifiche.Enti
    Public Class EnteDatiUpdateArgs
        Property Denominazione As String
        Property Disattivo As Boolean
        Property Conservatore As UnitaDocumentarie.TipoConservatore 'Non modificabile
        Property InCollaudo As Boolean
        Property DatiAggiuntivi As IEnteInfoDatiUpdateArgs

        Sub Valida()
            If String.IsNullOrEmpty(Denominazione) Then
                Throw New ExceptionHelper.DatoObbligatorioException("La Denominazione è obbligatoria")
            End If


            If Conservatore <> UnitaDocumentarie.TipoConservatore.NonDefinito Then
                If DatiAggiuntivi Is Nothing Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi mancanti")
                End If

                If Conservatore = UnitaDocumentarie.TipoConservatore.Infocert AndAlso Not TypeOf DatiAggiuntivi Is EnteInfoCERTDatiiUpdateArgs Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi errati o mancanti")
                ElseIf Conservatore = UnitaDocumentarie.TipoConservatore.PARER AndAlso Not TypeOf DatiAggiuntivi Is EnteInfoPARERDatiUpdateArgs Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi errati o mancanti")
                ElseIf Conservatore = UnitaDocumentarie.TipoConservatore.DAX AndAlso Not TypeOf DatiAggiuntivi Is EnteInfoDAXDatiUpdateArgs Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi errati o mancanti")
                ElseIf Conservatore = UnitaDocumentarie.TipoConservatore.PARVeneto AndAlso Not TypeOf DatiAggiuntivi Is EnteInfoPARVenetoDatiUpdateArgs Then
                    Throw New ExceptionHelper.DatoObbligatorioException("Dati aggiuntivi errati o mancanti")
                End If
            End If
        End Sub
    End Class
End Namespace


