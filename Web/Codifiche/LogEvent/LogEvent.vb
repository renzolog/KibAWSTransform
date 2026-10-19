Imports System.Data.SqlClient

Namespace Codifiche.LogEvent
    Public Class LogEvent

        Private Shared Function GetDati(sdr As SqlDataReader) As LogEventDati
            Dim obj As New LogEventDati()
            obj.Id = sdr.Item("Id")
            obj.ISTAT = sdr.Item("ISTAT").ToString
            Date.TryParse(sdr.Item("Data").ToString, obj.Data)
            Integer.TryParse(sdr.Item("Severity").ToString, obj.Severity)
            obj.Metodo = sdr.Item("Metodo").ToString
            obj.Messagge = sdr.Item("Messagge").ToString
            obj.EnteDenominazione = sdr.Item("EnteDenominazione").ToString
            Return obj
        End Function

        Function GetList(Filtro As LogEventDatiFilterArgs) As List(Of LogEventDati)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return GetList(cn, Filtro)
            End Using
        End Function
        Friend Function GetList(UseCN As SqlConnection, Filtro As LogEventDatiFilterArgs) As List(Of LogEventDati)
            Dim LogEventDati As List(Of LogEventDati) = Nothing
            Using cm As New SqlCommand(My.Resources.QueryLogEvent.GetListByFiltro, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", Filtro.ISTAT.DBNullIfEmpty)
                cm.Parameters.AddWithValue("@Dal", Filtro.Dal)
                cm.Parameters.AddWithValue("@Al", Filtro.Al)
                Using objdt As New SqlDataAdapter(cm)
                    Using sdr As SqlDataReader = cm.ExecuteReader
                        While sdr.Read
                            If LogEventDati Is Nothing Then
                                LogEventDati = New List(Of LogEventDati)
                            End If
                            LogEventDati.Add(GetDati(sdr))
                        End While
                    End Using
                End Using
            End Using
            Return LogEventDati
        End Function

    End Class
End Namespace
