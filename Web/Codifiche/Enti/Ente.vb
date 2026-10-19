Imports System.Data.SqlClient
Imports Web.Codifiche.Enti.InfoCERT
Imports Web.Codifiche.Enti.InfoDAX
Imports Web.Codifiche.Enti.InfoPARER
Imports Web.Codifiche.Enti.InfoPARVENETO

Namespace Codifiche.Enti
    Public Class Ente

        Function ReadList(ISTAT As String) As List(Of EnteDati)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim res As List(Of EnteDati) = Nothing
                Dim t = Read(cn, ISTAT)
                If t IsNot Nothing Then
                    res = New List(Of EnteDati)
                    res.Add(t)
                End If
                Return res
            End Using
        End Function
        Friend Function Read(UseCN As SqlConnection, ISTAT As String, Optional UseTs As SqlTransaction = Nothing) As EnteDati
            Dim EnteDati As EnteDati = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEnti.ReadByISTAT, UseCN, UseTs)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteDati = GetDati(sdr)
                    End While
                End Using
            End Using
            Return EnteDati
        End Function
        Private Shared Function GetDati(sdr As SqlDataReader) As EnteDati
            Dim obj As New EnteDati()
            obj.ISTAT = sdr.Item("ISTAT").ToString
            obj.Denominazione = sdr.Item("Denominazione").ToString
            Boolean.TryParse(sdr.Item("Disattivo").ToString, obj.Disattivo)
            Integer.TryParse(sdr.Item("Conservatore").ToString, obj.Conservatore)
            Boolean.TryParse(sdr.Item("InCollaudo").ToString, obj.InCollaudo)
            Return obj
        End Function
        Function GetList() As List(Of EnteDati)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return GetList(cn)
            End Using
        End Function
        Friend Function GetList(UseCN As SqlConnection) As List(Of EnteDati)
            Dim EnteDati As List(Of EnteDati) = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEnti.GetList, UseCN)
                Using objdt As New SqlDataAdapter(cm)
                    Using sdr As SqlDataReader = cm.ExecuteReader
                        While sdr.Read
                            If EnteDati Is Nothing Then
                                EnteDati = New List(Of EnteDati)
                            End If
                            EnteDati.Add(GetDati(sdr))
                        End While
                    End Using
                End Using
            End Using
            Return EnteDati
        End Function
        Function GetListLarge(FilterString As String, startIndex As Integer, endIndex As Integer) As List(Of EnteDati)
            Dim EnteDati As List(Of EnteDati) = Nothing
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Using cm As New SqlCommand(My.Resources.QueryEnti.GetListFiltered, cn)
                    cm.Parameters.AddWithValue("@Filter", FilterString)
                    cm.Parameters.AddWithValue("@startIndex", startIndex)
                    cm.Parameters.AddWithValue("@endIndex", endIndex)
                    Using objdt As New SqlDataAdapter(cm)
                        Using sdr As SqlDataReader = cm.ExecuteReader
                            While sdr.Read
                                If EnteDati Is Nothing Then
                                    EnteDati = New List(Of EnteDati)
                                End If
                                EnteDati.Add(GetDati(sdr))
                            End While
                        End Using
                    End Using
                End Using
            End Using
            Return EnteDati
        End Function


        Sub Insert(Dati As EnteDatiInsertArgs)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Insert(cn, ts, Dati)
                    ts.Commit()
                Catch ex As SqlException
                    If ex.Number = 2627 Then
                        Throw New ExceptionHelper.DatoGiaPresenteException(String.Format("L'Ente {0} è già presente", Dati.ISTAT))
                    End If
                    Throw ex
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Friend Sub Insert(UseCN As SqlConnection, UseTS As SqlTransaction, Dati As EnteDatiInsertArgs)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEnti.Insert, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", Dati.ISTAT.Truncate(6))
                cm.Parameters.AddWithValue("@Denominazione", Dati.Denominazione.Truncate(150))
                cm.Parameters.AddWithValue("@Disattivo", Dati.Disattivo)
                cm.Parameters.AddWithValue("@Conservatore", Dati.Conservatore)
                cm.Parameters.AddWithValue("@InCollaudo", Dati.InCollaudo)
                cm.ExecuteNonQuery()
            End Using


            If TypeOf Dati.DatiAggiuntivi Is EnteInfoCERTDatiInsertArgs Then
                EnteInfoCERT.Insert(UseCN, UseTS, Dati.ISTAT, Dati.DatiAggiuntivi)
            ElseIf TypeOf Dati.DatiAggiuntivi Is EnteInfoPARERDatiInsertArgs Then
                EnteInfoPARER.Insert(UseCN, UseTS, Dati.ISTAT, Dati.DatiAggiuntivi)
            ElseIf TypeOf Dati.DatiAggiuntivi Is EnteInfoDAXDatiInsertArgs Then
                EnteInfoDAX.Insert(UseCN, UseTS, Dati.ISTAT, Dati.DatiAggiuntivi)
            ElseIf TypeOf Dati.DatiAggiuntivi Is EnteInfoPARVenetoDatiInsertArgs Then
                EnteInfoPARVeneto.Insert(UseCN, UseTS, Dati.ISTAT, Dati.DatiAggiuntivi)
            End If
        End Sub
        Sub Update(ISTAT As String, Dati As EnteDatiUpdateArgs)
            Dati.Valida()
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Using cm As New SqlCommand(My.Resources.QueryEnti.UpdateByISTAT, cn, ts)
                        cm.Parameters.AddWithValue("@Denominazione", Dati.Denominazione.Truncate(150))
                        cm.Parameters.AddWithValue("@Disattivo", Dati.Disattivo)
                        cm.Parameters.AddWithValue("@InCollaudo", Dati.InCollaudo)
                        cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                        cm.ExecuteNonQuery()
                    End Using

                    If TypeOf Dati.DatiAggiuntivi Is EnteInfoCERTDatiiUpdateArgs Then
                        EnteInfoCERT.UpdateByISTAT(cn, ts, ISTAT, Dati.DatiAggiuntivi)
                    ElseIf TypeOf Dati.DatiAggiuntivi Is EnteInfoPARERDatiUpdateArgs Then
                        EnteInfoPARER.UpdateByISTAT(cn, ts, ISTAT, Dati.DatiAggiuntivi)
                    ElseIf TypeOf Dati.DatiAggiuntivi Is EnteInfoDAXDatiUpdateArgs Then
                        EnteInfoDAX.UpdateByISTAT(cn, ts, ISTAT, Dati.DatiAggiuntivi)
                    ElseIf TypeOf Dati.DatiAggiuntivi Is EnteInfoPARVenetoDatiUpdateArgs Then
                        EnteInfoPARVeneto.UpdateByISTAT(cn, ts, ISTAT, Dati.DatiAggiuntivi)
                    End If

                    ts.Commit()
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Sub Delete(ISTAT As String)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Using cm As New SqlCommand(My.Resources.QueryEnti.DeleteByISTAT, cn, ts)
                        cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                        cm.ExecuteNonQuery()
                    End Using
                    ts.Commit()
                Catch exs As SqlException
                    ts.Rollback()
                    If exs.Number = 547 Then
                        Throw New ExceptionHelper.DatoNonCancellabile("L'ISTAT non è possibile cancellarla")
                    End If
                    Throw exs
                End Try
            End Using
        End Sub


    End Class
End Namespace


