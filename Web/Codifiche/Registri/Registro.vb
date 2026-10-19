Imports System.Data.SqlClient

Namespace Codifiche.Registri
    Public Class Registro

        Private Shared Function GetDati(sdr As SqlDataReader) As RegistroDati
            Dim obj As New RegistroDati()
            obj.Id = sdr.Item("Id")
            obj.ISTAT = sdr.Item("ISTAT").ToString
            Integer.TryParse(sdr.Item("IDUnitaDocumentaria").ToString, obj.IDUnitaDocumentaria)
            Date.TryParse(sdr.Item("Data").ToString, obj.Data)
            obj.AnnoChiave = sdr.Item("AnnoChiave")
            obj.NumeroChiave = sdr.Item("NumeroChiave").ToString
            obj.Token = sdr.Item("Token").ToString
            obj.UnitaDocumentariaDenominazioneTipologiaDocumento = sdr.Item("UnitaDocumentariaDenominazioneTipologiaDocumento").ToString
            obj.EnteDenominazione = sdr.Item("EnteDenominazione").ToString
            Return obj
        End Function
        Function GetList(Filtro As RegistroDatiFilterArgs) As List(Of RegistroDati)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return GetList(cn, Filtro)
            End Using
        End Function
        Friend Function GetList(UseCN As SqlConnection, Filtro As RegistroDatiFilterArgs) As List(Of RegistroDati)
            Dim RegistroDati As List(Of RegistroDati) = Nothing
            Using cm As New SqlCommand(My.Resources.QueryRegistri.GetListByFiltro, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", Filtro.ISTAT.DBNullIfEmpty)
                cm.Parameters.AddWithValue("@Dal", Filtro.Dal)
                cm.Parameters.AddWithValue("@Al", Filtro.Al)
                Using objdt As New SqlDataAdapter(cm)
                    Using sdr As SqlDataReader = cm.ExecuteReader
                        While sdr.Read
                            If RegistroDati Is Nothing Then
                                RegistroDati = New List(Of RegistroDati)
                            End If
                            RegistroDati.Add(GetDati(sdr))
                        End While
                    End Using
                End Using
            End Using
            Return RegistroDati
        End Function

    End Class
End Namespace
