Namespace Codifiche.Enti.InfoPARVENETO
    Public Class EnteInfoPARVenetoDatiInsertArgs
        Implements IEnteInfoDatiInsertArgs

        Property IdentificativoEnte As String
        Property Intestazione As String
        Property Label As String
        Property Disabilitato As Boolean

        Public Sub Valida() Implements IEnteInfoDatiInsertArgs.Valida
            Return
        End Sub
    End Class
End Namespace


