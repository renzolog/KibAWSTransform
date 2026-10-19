Imports System.Data.SqlClient

Namespace Codifiche.Enti.Utenti
    Public Class EnteUtente

        Private Shared Function GetDati(sdr As SqlDataReader) As EnteUtenteDati
            Dim obj As New EnteUtenteDati()
            obj.ISTAT = sdr.Item("ISTAT").ToString
            obj.UserName = sdr.Item("UserName").ToString
            obj.Password = sdr.Item("Password").ToString
            obj.Disabilitato = sdr.Item("Disabilitato").ToString
            obj.Cognome = sdr.Item("Cognome").ToString
            obj.Nome = sdr.Item("Nome").ToString
            obj.ROLES = sdr.Item("ROLES").ToString
            Integer.TryParse(sdr.Item("Software").ToString, obj.Software)
            Return obj
        End Function
        Function GetList(ISTAT As String) As List(Of EnteUtenteDati)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return GetList(cn, ISTAT)
            End Using
        End Function
        Friend Function GetList(UseCN As SqlConnection, ISTAT As String) As List(Of EnteUtenteDati)
            Dim EnteUtenteDati As List(Of EnteUtenteDati) = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiUtenti.GetListByISTAT, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", ISTAT)
                Using objdt As New SqlDataAdapter(cm)
                    Using sdr As SqlDataReader = cm.ExecuteReader
                        While sdr.Read
                            If EnteUtenteDati Is Nothing Then
                                EnteUtenteDati = New List(Of EnteUtenteDati)
                            End If
                            EnteUtenteDati.Add(GetDati(sdr))
                        End While
                    End Using
                End Using
            End Using
            Return EnteUtenteDati
        End Function
        Sub Insert(Dati As EnteUtenteDatiInsertArgs)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Insert(cn, Dati, ts)
                    ts.Commit()
                Catch ex As SqlException
                    If ex.Number = 2627 Then
                        Throw New ExceptionHelper.DatoGiaPresenteException(String.Format("L'Utente {0} è già presente", Dati.UserName))
                    End If
                    Throw ex
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub
        Friend Sub Insert(UseCN As SqlConnection, Dati As EnteUtenteDatiInsertArgs, Optional UseTS As SqlTransaction = Nothing)
            Dati.Valida()
            Using cm As New SqlCommand(My.Resources.QueryEntiUtenti.Insert, UseCN, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", Dati.ISTAT)
                cm.Parameters.AddWithValue("@UserName", Dati.UserName.Truncate(50))
                cm.Parameters.AddWithValue("@Password", Dati.Password.Truncate(50))
                cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                cm.Parameters.AddWithValue("@Cognome", Dati.Cognome.TruncateOrDBNullIfEmpty(50))
                cm.Parameters.AddWithValue("@Nome", Dati.Nome.TruncateOrDBNullIfEmpty(50))
                cm.Parameters.AddWithValue("@ROLES", AuthProviders.Groups.JoinRuoli(Dati.ROLES))
                cm.Parameters.AddWithValue("@Software", Dati.Software)
                cm.ExecuteNonQuery()
            End Using
        End Sub
        Sub Update(Utente As String, Dati As EnteUtenteDatiUpdateArgs)
            Dati.Valida()
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Using cm As New SqlCommand(My.Resources.QueryEntiUtenti.UpdateByUtente, cn, ts)
                        cm.Parameters.AddWithValue("@Password", Dati.Password.Truncate(50))
                        cm.Parameters.AddWithValue("@Disabilitato", Dati.Disabilitato)
                        cm.Parameters.AddWithValue("@Cognome", Dati.Cognome.TruncateOrDBNullIfEmpty(50))
                        cm.Parameters.AddWithValue("@Nome", Dati.Nome.TruncateOrDBNullIfEmpty(50))
                        cm.Parameters.AddWithValue("@ROLES", AuthProviders.Groups.JoinRuoli(Dati.ROLES))
                        cm.Parameters.AddWithValue("@Software", Dati.Software)
                        cm.Parameters.AddWithValue("@Utente", Utente)
                        cm.ExecuteNonQuery()
                    End Using
                    ts.Commit()
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Sub Delete(Utente As String)
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Using cm As New SqlCommand(My.Resources.QueryEntiUtenti.DeleteByUtente, cn, ts)
                        cm.Parameters.AddWithValue("@Utente", Utente)
                        cm.ExecuteNonQuery()
                    End Using
                    ts.Commit()
                Catch exs As SqlException
                    ts.Rollback()
                    If exs.Number = 547 Then
                        Throw New ExceptionHelper.DatoNonCancellabile("L'Utente non è possibile cancellarlo")
                    End If
                    Throw exs
                End Try
            End Using
        End Sub

    End Class
End Namespace



