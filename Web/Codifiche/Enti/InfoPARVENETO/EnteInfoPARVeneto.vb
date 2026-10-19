Imports System.Data.SqlClient

Namespace Codifiche.Enti.InfoPARVENETO
    Public Class EnteInfoPARVeneto

        Friend Shared Function internalRead(ISTAT As String) As EnteInfoPARVenetoDati
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return Read(cn, ISTAT)
            End Using
        End Function

        Friend Shared Function Read(UseCN As SqlConnection, ISTAT As String, Optional UseTS As SqlTransaction = Nothing) As EnteInfoPARVenetoDati
            Dim EnteInfoPARVenetoDati As EnteInfoPARVenetoDati = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoPARVeneto.ReadByISTAT, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteInfoPARVenetoDati = New EnteInfoPARVenetoDati()
                        EnteInfoPARVenetoDati.ISTAT = sdr.Item("ISTAT")
                        EnteInfoPARVenetoDati.IdentificativoEnte = sdr.Item("IdentificativoEnte").ToString
                        EnteInfoPARVenetoDati.Intestazione = sdr.Item("Intestazione").ToString
                        EnteInfoPARVenetoDati.Label = sdr.Item("Label").ToString
                        Boolean.TryParse(sdr.Item("Disabilitato").ToString, EnteInfoPARVenetoDati.Disabilitato)
                    End While
                End Using
            End Using
            Return EnteInfoPARVenetoDati
        End Function
        Friend Shared Sub Insert(UseCN As SqlConnection, UseTS As SqlTransaction, ISTAT As String, Dati As EnteInfoPARVenetoDatiInsertArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoPARVeneto.Insert, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                cm.Parameters.AddWithValue("@IdentificativoEnte", Dati.IdentificativoEnte.TruncateOrDBNullIfEmpty(100))
                cm.Parameters.AddWithValue("@Intestazione", Dati.Intestazione.TruncateOrDBNullIfEmpty(500))
                cm.Parameters.AddWithValue("@Label", Dati.Label.TruncateOrDBNullIfEmpty(500))
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Friend Shared Sub UpdateByISTAT(UseCN As SqlConnection, UseTS As SqlTransaction, ISTAT As String, Dati As EnteInfoPARVenetoDatiUpdateArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoPARVeneto.UpdateByISTAT, UseCN, UseTS)
                cm.Parameters.AddWithValue("@IdentificativoEnte", Dati.IdentificativoEnte.TruncateOrDBNullIfEmpty(100))
                cm.Parameters.AddWithValue("@Intestazione", Dati.Intestazione.TruncateOrDBNullIfEmpty(500))
                cm.Parameters.AddWithValue("@Label", Dati.Label.TruncateOrDBNullIfEmpty(500))
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                cm.ExecuteNonQuery()
            End Using
        End Sub
    End Class
End Namespace


