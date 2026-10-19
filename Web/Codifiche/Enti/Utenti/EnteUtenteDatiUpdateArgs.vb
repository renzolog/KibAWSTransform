Namespace Codifiche.Enti.Utenti
    Public Class EnteUtenteDatiUpdateArgs
        Property Password As String
        Property Disabilitato As Boolean
        Property Cognome As String
        Property Nome As String
        Property ROLES As List(Of String)
        Property Software As TipoSoftware

        Sub Valida()

            If String.IsNullOrEmpty(Password) Then
                Throw New ExceptionHelper.DatoObbligatorioException("La Password è obbligatoria")
            End If
        End Sub

    End Class
End Namespace



