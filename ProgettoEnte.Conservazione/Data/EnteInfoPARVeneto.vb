

Imports System.Data.SqlClient
Imports ProgettoEnte.Conservazione.Autenthicate



Namespace Data


    Public Class EnteInfoPARVenetobase
        Inherits Autenthicate.BaseProtect

        Property Id As Integer
        Property ISTAT As String
        Property Intestazione As String
        Property Label As String
        Property Disabilitato As Boolean
        Property IdentificativoEnte As String





        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

    End Class

    Public Class EnteInfoPARVeneto
        Inherits EnteInfoPARVenetobase

        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

        Friend Function READAttivo(UseCN As SqlConnection) As EnteInfoPARVeneto
            Dim EnteInfoPARVeneto As EnteInfoPARVeneto = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoPARVeneto.ReadAttivo, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteInfoPARVeneto = New EnteInfoPARVeneto(MyBase.User)
                        EnteInfoPARVeneto.Id = sdr.Item("Id")
                        EnteInfoPARVeneto.ISTAT = sdr.Item("Istat")
                        EnteInfoPARVeneto.Intestazione = sdr.Item("Intestazione")
                        EnteInfoPARVeneto.Label = sdr.Item("Label").ToString
                        Boolean.TryParse(sdr.Item("Disabilitato").ToString, EnteInfoPARVeneto.Disabilitato)
                        EnteInfoPARVeneto.IdentificativoEnte = sdr.Item("IdentificativoEnte")
                    End While
                End Using
            End Using
            Return EnteInfoPARVeneto
        End Function


    End Class

End Namespace
