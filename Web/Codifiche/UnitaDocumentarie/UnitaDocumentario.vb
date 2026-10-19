Imports System.Data.SqlClient

Namespace Codifiche.UnitaDocumentarie
    Public Class UnitaDocumentario

        Private Shared Function GetDati(sdr As SqlDataReader) As UnitaDocumentarioDati
            Dim obj As New UnitaDocumentarioDati()
            obj.Id = sdr.Item("Id")
            obj.ISTAT = sdr.Item("ISTAT").ToString
            Integer.TryParse(sdr.Item("Conservatore").ToString, obj.Conservatore)
            Boolean.TryParse(sdr.Item("Disabilitato").ToString, obj.Disabilitato)
            obj.Codice = sdr.Item("Codice").ToString
            obj.DenominazioneTipologiaDocumento = sdr.Item("DenominazioneTipologiaDocumento").ToString
            obj.DenominazioneTipoDocumentoPrincipale = sdr.Item("DenominazioneTipoDocumentoPrincipale").ToString
            obj.VersanteUserName = sdr.Item("VersanteUserName").ToString
            obj.VersantePassword = sdr.Item("VersantePassword").ToString
            obj.EsibizioneUserName = sdr.Item("EsibizioneUserName").ToString
            obj.EsibizionePassword = sdr.Item("EsibizionePassword").ToString
            Integer.TryParse(sdr.Item("Tipo").ToString, obj.Tipo)
            Boolean.TryParse(sdr.Item("Segreteria").ToString, obj.Segreteria)
            Boolean.TryParse(sdr.Item("Demografici").ToString, obj.Demografici)
            Boolean.TryParse(sdr.Item("Contabilita").ToString, obj.Contabilita)
            obj.Policy = sdr.Item("Policy").ToString
            Integer.TryParse(sdr.Item("Versione").ToString, obj.Versione)
            Return obj
        End Function
        Function GetList(ISTAT As String) As List(Of UnitaDocumentarioDati)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return GetList(cn, ISTAT)
            End Using
        End Function
        Friend Function GetList(UseCN As SqlConnection, ISTAT As String) As List(Of UnitaDocumentarioDati)
            Dim UnitaDocumentarioDati As List(Of UnitaDocumentarioDati) = Nothing
            Using cm As New SqlCommand(My.Resources.QueryUnitaDocumentarie.GetListByISTAT, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                Using objdt As New SqlDataAdapter(cm)
                    Using sdr As SqlDataReader = cm.ExecuteReader
                        While sdr.Read
                            If UnitaDocumentarioDati Is Nothing Then
                                UnitaDocumentarioDati = New List(Of UnitaDocumentarioDati)
                            End If
                            UnitaDocumentarioDati.Add(GetDati(sdr))
                        End While
                    End Using
                End Using
            End Using
            Return UnitaDocumentarioDati
        End Function
        Sub Insert(Dati As UnitaDocumentarioDatiInsertArgs)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Dim Id = Insert(cn, Dati, ts)
                    ts.Commit()
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub
        Friend Function Insert(UseCN As SqlConnection, Dati As UnitaDocumentarioDatiInsertArgs, Optional UseTS As SqlTransaction = Nothing) As Integer
            Dati.Valida()
            Dim Id As Integer
            Using cm As New SqlCommand(My.Resources.QueryUnitaDocumentarie.Insert, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", Dati.ISTAT)
                cm.Parameters.AddWithValue("@Conservatore", Dati.Conservatore)
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.Parameters.AddWithValue("@Codice", Dati.Codice.Truncate(50))
                cm.Parameters.AddWithValue("@DenominazioneTipologiaDocumento", Dati.DenominazioneTipologiaDocumento.Truncate(100))
                cm.Parameters.AddWithValue("@DenominazioneTipoDocumentoPrincipale", Dati.DenominazioneTipoDocumentoPrincipale.Truncate(100))
                cm.Parameters.AddWithValue("@VersanteUserName", Dati.VersanteUserName.Truncate(50))
                cm.Parameters.AddWithValue("@VersantePassword", Dati.VersantePassword.Truncate(50))
                cm.Parameters.AddWithValue("@EsibizioneUserName", Dati.EsibizioneUserName.Truncate(50))
                cm.Parameters.AddWithValue("@EsibizionePassword", Dati.EsibizionePassword.Truncate(50))
                cm.Parameters.AddWithValue("@Tipo", Dati.Tipo)
                cm.Parameters.AddWithValue("@Segreteria", False)
                cm.Parameters.AddWithValue("@Demografici", Dati.Demografici)
                cm.Parameters.AddWithValue("@Contabilita", Dati.Contabilita)
                cm.Parameters.AddWithValue("@Policy", Dati.Policy.TruncateOrDBNullIfEmpty(50))
                cm.Parameters.AddWithValue("@Versione", Dati.Versione)
                cm.ExecuteNonQuery()
            End Using
            Return Id
        End Function
        Sub Update(Id As Integer, Dati As UnitaDocumentarioDatiUpdateArgs)
            Dati.Valida()
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Using cm As New SqlCommand(My.Resources.QueryUnitaDocumentarie.UpdateById, cn, ts)
                        cm.Parameters.AddWithValue("@Conservatore", Dati.Conservatore)
                        cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                        cm.Parameters.AddWithValue("@Codice", Dati.Codice.Truncate(50))
                        cm.Parameters.AddWithValue("@DenominazioneTipologiaDocumento", Dati.DenominazioneTipologiaDocumento.Truncate(100))
                        cm.Parameters.AddWithValue("@DenominazioneTipoDocumentoPrincipale", Dati.DenominazioneTipoDocumentoPrincipale.Truncate(100))
                        cm.Parameters.AddWithValue("@VersanteUserName", Dati.VersanteUserName.Truncate(50))
                        cm.Parameters.AddWithValue("@VersantePassword", Dati.VersantePassword.Truncate(50))
                        cm.Parameters.AddWithValue("@EsibizioneUserName", Dati.EsibizioneUserName.Truncate(50))
                        cm.Parameters.AddWithValue("@EsibizionePassword", Dati.EsibizionePassword.Truncate(50))
                        cm.Parameters.AddWithValue("@Tipo", Dati.Tipo)
                        cm.Parameters.AddWithValue("@Segreteria", False)
                        cm.Parameters.AddWithValue("@Demografici", Dati.Demografici)
                        cm.Parameters.AddWithValue("@Contabilita", Dati.Contabilita)
                        cm.Parameters.AddWithValue("@Policy", Dati.Policy.TruncateOrDBNullIfEmpty(50))
                        cm.Parameters.AddWithValue("@Versione", Dati.Versione)
                        cm.Parameters.AddWithValue("@Id", Id)
                        cm.ExecuteNonQuery()
                    End Using
                    ts.Commit()
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Sub Delete(Id As Integer)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Using cm As New SqlCommand(My.Resources.QueryUnitaDocumentarie.DeleteById, cn, ts)
                        cm.Parameters.AddWithValue("@Id", Id)
                        cm.ExecuteNonQuery()
                    End Using
                    ts.Commit()
                Catch exs As SqlException
                    ts.Rollback()
                    If exs.Number = 547 Then
                        Throw New ExceptionHelper.DatoNonCancellabile("L'Unita Documentario non è possibile cancellarlo")
                    End If
                    Throw exs
                End Try
            End Using
        End Sub

    End Class
End Namespace



