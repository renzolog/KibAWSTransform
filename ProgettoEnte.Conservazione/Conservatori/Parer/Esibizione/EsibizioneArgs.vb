Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.PARER.Esibizione
    Public Class EsibizioneArgs
        Inherits ProgettoEnte.Conservazione.Shared.EsibisciArgs 

        Property Token As Data.ChiaveRegistro

        Sub New(EsibisciInfo As ProgettoEnte.Conservazione.Shared.EsibisciArgs)
            MyBase.New(EsibisciInfo.TokenID, EsibisciInfo.ReturnFlags)
        End Sub

    End Class
End Namespace