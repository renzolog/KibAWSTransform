Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione
    Friend Class Request


        Public Shared Function Create(LoginSession As Autenticazione.PARERLoginSession, EsibizioneArgs As EsibizioneArgs) As Byte()

            Dim p As New Schemi.Recupero

            p.Versione = [Shared].VersioneEsibizione
            p.Versatore = New Schemi.VersatoreType
            p.Versatore.Ambiente = LoginSession.PARERInfo.Ambiente
            p.Versatore.Ente = LoginSession.PARERInfo.DenominazioneEnte
            p.Versatore.Struttura = LoginSession.PARERInfo.Struttura
            p.Versatore.UserID = LoginSession.UserNameEsibizione

            p.Chiave = New Schemi.ChiaveType
            p.Chiave.Anno = EsibizioneArgs.Token.Anno
            p.Chiave.Numero = EsibizioneArgs.Token.Numero
            p.Chiave.TipoRegistro = EsibizioneArgs.Token.CodiceUnitaDocumentaria

            Dim seeserUnit As New XmlSerializer(GetType(Schemi.Recupero))

            Using writer As New IO.MemoryStream
                seeserUnit.Serialize(writer, p)
                Return writer.ToArray
            End Using

        End Function

    End Class
End Namespace

