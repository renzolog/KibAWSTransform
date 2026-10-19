Namespace Codifiche.Enti
    Public Class EnteDati

        Property ISTAT As String
        Property Denominazione As String
        Property Disattivo As Boolean
        Property Conservatore As UnitaDocumentarie.TipoConservatore
        Property InCollaudo As Boolean

        Private _datiAggiuntivi As IEnteInfoDati
        Public ReadOnly Property DatiAggiuntivi As IEnteInfoDati
            Get
                If _DatiAggiuntivi IsNot Nothing OrElse String.IsNullOrEmpty(ISTAT) Then
                    Return _DatiAggiuntivi
                End If

                If Conservatore = Codifiche.UnitaDocumentarie.TipoConservatore.Infocert Then
                    _datiAggiuntivi = InfoCERT.EnteInfoCERT.internalRead(ISTAT)
                ElseIf Conservatore = Codifiche.UnitaDocumentarie.TipoConservatore.PARER Then
                    _datiAggiuntivi = InfoPARER.EnteInfoPARER.internalRead(ISTAT)
                ElseIf Conservatore = Codifiche.UnitaDocumentarie.TipoConservatore.DAX Then
                    _datiAggiuntivi = InfoDAX.EnteInfoDAX.internalRead(ISTAT)
                ElseIf Conservatore = Codifiche.UnitaDocumentarie.TipoConservatore.PARVeneto Then
                    _datiAggiuntivi = InfoPARVENETO.EnteInfoPARVeneto.internalRead(ISTAT)
                End If
                Return _DatiAggiuntivi
            End Get
        End Property

    End Class
End Namespace


