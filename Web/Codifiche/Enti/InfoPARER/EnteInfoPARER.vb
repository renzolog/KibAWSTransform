Imports System.Data.SqlClient

Namespace Codifiche.Enti.InfoPARER
    Public Class EnteInfoPARER

        Friend Shared Function internalRead(ISTAT As String) As EnteInfoPARERDati
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return Read(cn, ISTAT)
            End Using
        End Function

        Friend Shared Function Read(UseCN As SqlConnection, ISTAT As String, Optional UseTS As SqlTransaction = Nothing) As EnteInfoPARERDati
            Dim EnteInfoPARERDati As EnteInfoPARERDati = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoPARER.ReadByISTAT, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteInfoPARERDati = New EnteInfoPARERDati()
                        EnteInfoPARERDati.ISTAT = sdr.Item("ISTAT")
                        EnteInfoPARERDati.Ambiente = sdr.Item("Ambiente").ToString
                        EnteInfoPARERDati.DenominazioneEnte = sdr.Item("DenominazioneEnte").ToString
                        EnteInfoPARERDati.VersioneConservazione = sdr.Item("VersioneConservazione").ToString
                        EnteInfoPARERDati.Struttura = sdr.Item("Struttura").ToString
                        Boolean.TryParse(sdr.Item("Disabilitato").ToString, EnteInfoPARERDati.Disabilitato)
                    End While
                End Using
            End Using
            Return EnteInfoPARERDati
        End Function


        Friend Shared Sub Insert(UseCN As SqlConnection, UseTS As SqlTransaction, ISTAT As String, Dati As EnteInfoPARERDatiInsertArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoPARER.Insert, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.Parameters.AddWithValue("@Ambiente", Dati.Ambiente.Truncate(50))
                cm.Parameters.AddWithValue("@DenominazioneEnte", Dati.DenominazioneEnte.Truncate(50))
                cm.Parameters.AddWithValue("@VersioneConservazione", Dati.VersioneConservazione.Truncate(50))
                cm.Parameters.AddWithValue("@Struttura", Dati.Struttura.Truncate(50))
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Friend Shared Sub UpdateByISTAT(UseCN As SqlConnection, UseTS As SqlTransaction, ISTAT As String, Dati As EnteInfoPARERDatiUpdateArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoPARER.UpdateByISTAT, UseCN, UseTS)
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.Parameters.AddWithValue("@Ambiente", Dati.Ambiente.Truncate(50))
                cm.Parameters.AddWithValue("@DenominazioneEnte", Dati.DenominazioneEnte.Truncate(50))
                cm.Parameters.AddWithValue("@VersioneConservazione", Dati.VersioneConservazione.Truncate(50))
                cm.Parameters.AddWithValue("@Struttura", Dati.Struttura.Truncate(50))
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                cm.ExecuteNonQuery()
            End Using
        End Sub
    End Class
End Namespace


