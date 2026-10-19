Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.Shared
    Public MustInherit Class Attributi

        Friend Shared Sub ValidaDatiSpecifici(Info As ConservationInfo)

            If Info.AttributiSpecifici Is Nothing Then
                Return
            ElseIf (Info.Tipologia = TipoOggetto.Protocollo AndAlso Not (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo)) _
                OrElse (Info.Tipologia = TipoOggetto.Delibera AndAlso Not (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera)) _
                OrElse (Info.Tipologia = TipoOggetto.Determina AndAlso Not (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDetermina)) _
                OrElse (Info.Tipologia = TipoOggetto.Generico AndAlso Not (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDocumentoGenerico)) _
                OrElse (Info.Tipologia = TipoOggetto.Contratto AndAlso Not (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiContratto)) _
                OrElse (Info.Tipologia = TipoOggetto.Affissione AndAlso Not (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiAffissione)) _
                OrElse (Info.Tipologia = TipoOggetto.RegistroProtocollo AndAlso Not (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiRegistroProtocollo)) _
                OrElse (Info.Tipologia = TipoOggetto.Fattura AndAlso Not (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaPassiva))
                Throw New ArgumentOutOfRangeException("AttributiSpecifici", "Attributi non corretti per il tipo " & Info.Tipologia.ToString)
            Else
                Return
            End If

        End Sub


        Property Fascicoli As List(Of Fascicolo)
        Property Oggetto As String
        Property DataDocumento As Date
        Property CodiceIdentificativoAmministrazione As String
        Property CodiceIdentificativoAOO As String
        Property IDUnivocoDocumento As String
        Property IndiceDiClassificazione As String
        Property DescrizioneDiClassificazione As String
        Property URLPianoDiClassificazione As String


        Property DocumentiCollegati As List(Of DocumentoCollegato)

        Property UsaNuovaVersione As Boolean

        Public Property IdentificativoSistemaGestionale As String

        Public Property ModalitaFormazione As TipoModalitaFormazione
    End Class

End Namespace

