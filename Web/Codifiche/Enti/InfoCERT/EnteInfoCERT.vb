Imports System.Data.SqlClient

Namespace Codifiche.Enti.InfoCERT
    Public Class EnteInfoCERT

        Friend Shared Function internalRead(ISTAT As String) As EnteInfoCERTDati
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return Read(cn, ISTAT)
            End Using
        End Function

        Friend Shared Function Read(UseCN As SqlConnection, ISTAT As String, Optional UseTS As SqlTransaction = Nothing) As EnteInfoCERTDati
            Dim EnteInfoCERTDati As EnteInfoCERTDati = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoCERT.ReadByISTAT, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteInfoCERTDati = New EnteInfoCERTDati()
                        EnteInfoCERTDati.ISTAT = sdr.Item("ISTAT")
                        Boolean.TryParse(sdr.Item("Disabilitato").ToString, EnteInfoCERTDati.Disabilitato)
                        EnteInfoCERTDati.Bucket = sdr.Item("Bucket")
                    End While
                End Using
            End Using
            Return EnteInfoCERTDati
        End Function

        Friend Shared Sub Insert(UseCN As SqlConnection, UseTS As SqlTransaction, ISTAT As String, Dati As EnteInfoCERTDatiInsertArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoCERT.Insert, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.Parameters.AddWithValue("@Bucket", Dati.Bucket.Truncate(50))
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Friend Shared Sub UpdateByISTAT(UseCN As SqlConnection, UseTS As SqlTransaction, ISTAT As String, Dati As EnteInfoCERTDatiiUpdateArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoCERT.UpdateByISTAT, UseCN, UseTS)
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.Parameters.AddWithValue("@Bucket", Dati.Bucket.Truncate(50))
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                cm.ExecuteNonQuery()
            End Using
        End Sub
    End Class
End Namespace


