Imports System.Data.SqlClient

Namespace Codifiche.Registri.Dettagli
    Public Class RegistroDettaglio

        Private Shared Function GetDati(sdr As SqlDataReader) As RegistroDettaglioDati
            Dim obj As New RegistroDettaglioDati()
            obj.Id = sdr.Item("Id")
            obj.IdRegistro = sdr.Item("IdRegistro")
            obj.NomeFile = sdr.Item("NomeFile").ToString
            obj.Hash = sdr.Item("Hash").ToString
            obj.Token = sdr.Item("Token").ToString
            Return obj
        End Function

        Function GetList(IdRegistro As Integer) As List(Of RegistroDettaglioDati)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return GetList(cn, IdRegistro)
            End Using
        End Function
        Friend Function GetList(UseCN As SqlConnection, IdRegistro As Integer) As List(Of RegistroDettaglioDati)
            Dim RegistroDettaglioDati As List(Of RegistroDettaglioDati) = Nothing
            Using cm As New SqlCommand(My.Resources.QueryRegistroDettaglio.GetListByIdRegistro, UseCN)
                cm.Parameters.AddWithValue("@IdRegistro", IdRegistro)
                Using objdt As New SqlDataAdapter(cm)
                    Using sdr As SqlDataReader = cm.ExecuteReader
                        While sdr.Read
                            If RegistroDettaglioDati Is Nothing Then
                                RegistroDettaglioDati = New List(Of RegistroDettaglioDati)
                            End If
                            RegistroDettaglioDati.Add(GetDati(sdr))
                        End While
                    End Using
                End Using
            End Using
            Return RegistroDettaglioDati
        End Function

    End Class
End Namespace
