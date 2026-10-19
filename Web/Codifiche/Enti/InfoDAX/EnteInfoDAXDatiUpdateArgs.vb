Namespace Codifiche.Enti.InfoDAX
    Public Class EnteInfoDAXDatiUpdateArgs
        Implements IEnteInfoDatiUpdateArgs

        Property Intestazione As String
        Property Label As String
        Property Disabilitato As Boolean

        Public Sub Valida() Implements IEnteInfoDatiUpdateArgs.Valida
            If String.IsNullOrEmpty(Intestazione) Then
                Throw New ExceptionHelper.DatoObbligatorioException("L'Intestazione è obbligatorio")
            End If
        End Sub
    End Class
End Namespace


