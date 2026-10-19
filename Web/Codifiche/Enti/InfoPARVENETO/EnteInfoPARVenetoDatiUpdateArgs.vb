Namespace Codifiche.Enti.InfoPARVENETO
    Public Class EnteInfoPARVenetoDatiUpdateArgs
        Implements IEnteInfoDatiUpdateArgs

        Property IdentificativoEnte As String
        Property Intestazione As String
        Property Label As String
        Property Disabilitato As Boolean

        Public Sub Valida() Implements IEnteInfoDatiUpdateArgs.Valida
            Return
        End Sub
    End Class
End Namespace


