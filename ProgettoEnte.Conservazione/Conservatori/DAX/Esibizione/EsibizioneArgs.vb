
Namespace Conservatori.DAX.Esibizione
    Public Class EsibizioneArgs

        Inherits ProgettoEnte.Conservazione.Shared.EsibisciArgs

        Property Token As String

        Sub New(EsibisciInfo As ProgettoEnte.Conservazione.Shared.EsibisciArgs)
                MyBase.New(EsibisciInfo.TokenID, EsibisciInfo.ReturnFlags)
            End Sub



        End Class
End Namespace


