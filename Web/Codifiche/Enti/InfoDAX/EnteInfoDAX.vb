Imports System.Data.SqlClient

Namespace Codifiche.Enti.InfoDAX
    Public Class EnteInfoDAX

        Friend Shared Function internalRead(ISTAT As String) As EnteInfoDAXDati
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return Read(cn, ISTAT)
            End Using
        End Function

        Friend Shared Function Read(UseCN As SqlConnection, ISTAT As String, Optional UseTS As SqlTransaction = Nothing) As EnteInfoDAXDati
            Dim EnteInfoDAXDati As EnteInfoDAXDati = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoDAX.ReadByISTAT, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteInfoDAXDati = New EnteInfoDAXDati()
                        EnteInfoDAXDati.ISTAT = sdr.Item("Istat")
                        EnteInfoDAXDati.Intestazione = sdr.Item("Intestazione")
                        EnteInfoDAXDati.Label = sdr.Item("Label").ToString
                        Boolean.TryParse(sdr.Item("Disabilitato").ToString, EnteInfoDAXDati.Disabilitato)
                    End While
                End Using
            End Using
            Return EnteInfoDAXDati
        End Function
        Friend Shared Sub Insert(UseCN As SqlConnection, UseTS As SqlTransaction, ISTAT As String, Dati As EnteInfoDAXDatiInsertArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoDAX.Insert, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                cm.Parameters.AddWithValue("@Intestazione", Dati.Intestazione.Truncate(500))
                cm.Parameters.AddWithValue("@Label", Dati.Label.TruncateOrDBNullIfEmpty(500))
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Friend Shared Sub UpdateByISTAT(UseCN As SqlConnection, UseTS As SqlTransaction, ISTAT As String, Dati As EnteInfoDAXDatiUpdateArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoDAX.UpdateByISTAT, UseCN, UseTS)
                cm.Parameters.AddWithValue("@Intestazione", Dati.Intestazione.Truncate(500))
                cm.Parameters.AddWithValue("@Label", Dati.Label.TruncateOrDBNullIfEmpty(500))
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                cm.ExecuteNonQuery()
            End Using
        End Sub
    End Class
End Namespace


