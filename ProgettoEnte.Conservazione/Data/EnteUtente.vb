Imports System.Data.SqlClient
Imports ProgettoEnte.Conservazione.Autenthicate

Namespace Data


    Public MustInherit Class EnteUtenteBase

        Public Const RuoloConserva As String = "CONSERVA"
        Public Const RuoloEsibisci As String = "ESIBISCI"

        Property ISTAT As String
        Property Username As String
        Property Disabilitato As Boolean
        Property Cognome As String
        Property Nome As String
        Property Roles As List(Of String)
        Property Software As [Shared].TipoSoftware

        Property AuthicatedUser As Autenthicate.User

    End Class


    Friend Class EnteUtente
        Inherits EnteUtenteBase

        Property Ente As Ente
        Property Password As String


        Public Shared Function Read(Utente As String, Optional InfoLogin As LoginManager = Nothing) As EnteUtente
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return Read(cn, Utente, InfoLogin)
            End Using
        End Function


        Friend Shared Function Read(UseCN As SqlConnection, Utente As String, Optional InfoLogin As LoginManager = Nothing) As EnteUtente
            Dim EnteUtenti As EnteUtente = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEnti.ReadUtente, UseCN)
                cm.Parameters.AddWithValue("@UserName", Utente)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteUtenti = New EnteUtente()
                        EnteUtenti.ISTAT = sdr.Item("ISTAT").ToString
                        EnteUtenti.Username = sdr.Item("Username").ToString
                        EnteUtenti.Password = sdr.Item("Password").ToString
                        EnteUtenti.Disabilitato = sdr.Item("Disabilitato")
                        EnteUtenti.Cognome = sdr.Item("Cognome").ToString
                        EnteUtenti.Nome = sdr.Item("Nome").ToString

                        EnteUtenti.Roles = New List(Of String)
                        EnteUtenti.Roles.AddRange(sdr.Item("ROLES").ToString.Split(";"))

                        EnteUtenti.Software = sdr.Item("Software")

                        If InfoLogin IsNot Nothing Then
                            If InfoLogin.Password <> sdr.Item("Password") Then
                                Return Nothing
                            End If

                            If EnteUtenti.Disabilitato Then
                                Return Nothing
                            End If

                            If InfoLogin.Software <> EnteUtenti.Software Then
                                Return Nothing
                            End If

                        End If
                    End While

                End Using
                If EnteUtenti Is Nothing Then
                    Return Nothing
                End If


                EnteUtenti.AuthicatedUser = New Autenthicate.User With {._Ente = EnteUtenti.ISTAT, ._Utente = EnteUtenti.Username, ._Roles = EnteUtenti.Roles}

                Dim obj As New Ente(EnteUtenti.AuthicatedUser)
                EnteUtenti.Ente = obj.Read(UseCN)
                If EnteUtenti.Ente Is Nothing Then
                    Return Nothing
                End If

                If InfoLogin IsNot Nothing Then
                    If EnteUtenti.ISTAT.ToLower <> InfoLogin.ISTAT.ToLower Then
                        Return Nothing
                    End If
                End If


                If InfoLogin IsNot Nothing AndAlso EnteUtenti.Ente.Disattivo = True Then
                    Return Nothing
                End If

            End Using
            Return EnteUtenti
        End Function
    End Class
End Namespace
