Namespace Codifiche.Enti.InfoCERT
    Public Class EnteInfoCERTDatiInsertArgs
        Implements IEnteInfoDatiInsertArgs

        Property Disabilitato As Boolean
        Property Bucket As String

        Public Sub Valida() Implements IEnteInfoDatiInsertArgs.Valida
            If String.IsNullOrEmpty(Bucket) Then
                Throw New ExceptionHelper.DatoObbligatorioException("Il Bucket è obbligatorio")
            End If
        End Sub
    End Class
End Namespace


