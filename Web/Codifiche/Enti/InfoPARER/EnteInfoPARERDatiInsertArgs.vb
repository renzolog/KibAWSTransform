Namespace Codifiche.Enti.InfoPARER
    Public Class EnteInfoPARERDatiInsertArgs
        Implements IEnteInfoDatiInsertArgs

        Property Disabilitato As Boolean
        Property Ambiente As String
        Property DenominazioneEnte As String
        Property VersioneConservazione As String
        Property Struttura As String

        Public Sub Valida() Implements IEnteInfoDatiInsertArgs.Valida
            If String.IsNullOrEmpty(Ambiente) Then
                Throw New ExceptionHelper.DatoObbligatorioException("L'Ambiente è obbligatorio")
            End If

            If String.IsNullOrEmpty(DenominazioneEnte) Then
                Throw New ExceptionHelper.DatoObbligatorioException("Denominazione Ente è obbligatorio")
            End If

            If String.IsNullOrEmpty(VersioneConservazione) Then
                Throw New ExceptionHelper.DatoObbligatorioException("La Versione Conservazione è obbligatoria")
            End If

            If String.IsNullOrEmpty(Struttura) Then
                Throw New ExceptionHelper.DatoObbligatorioException("La Struttura è obbligatoria")
            End If
        End Sub
    End Class
End Namespace


