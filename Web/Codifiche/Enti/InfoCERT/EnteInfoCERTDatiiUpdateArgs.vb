Namespace Codifiche.Enti.InfoCERT
    Public Class EnteInfoCERTDatiiUpdateArgs
        Implements IEnteInfoDatiUpdateArgs

        Property Disabilitato As Boolean
        Property Bucket As String

        Public Sub Valida() Implements IEnteInfoDatiUpdateArgs.Valida
            If String.IsNullOrEmpty(Bucket) Then
                Throw New ExceptionHelper.DatoObbligatorioException("Il Bucket è obbligatorio")
            End If
        End Sub
    End Class
End Namespace


