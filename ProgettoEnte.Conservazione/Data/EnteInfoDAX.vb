
Imports System.Data.SqlClient
Imports ProgettoEnte.Conservazione.Autenthicate

Namespace Data


    Public Class EnteInfoDAXbase
        Inherits Autenthicate.BaseProtect

        Property Id As Integer
        Property ISTAT As String
        Property Intestazione As String
        Property Label As String
        Property Disabilitato As Boolean




        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

    End Class

    Public Class EnteInfoDAX
        Inherits EnteInfoDAXbase

        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

        Friend Function READAttivo(UseCN As SqlConnection) As EnteInfoDAX
            Dim EnteInfoDAX As EnteInfoDAX = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoDAX.ReadAttivo, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteInfoDAX = New EnteInfoDAX(MyBase.User)
                        EnteInfoDAX.Id = sdr.Item("Id")
                        EnteInfoDAX.ISTAT = sdr.Item("Istat")
                        EnteInfoDAX.Intestazione = sdr.Item("Intestazione")
                        EnteInfoDAX.Label = sdr.Item("Label").ToString
                        Boolean.TryParse(sdr.Item("Disabilitato").ToString, EnteInfoDAX.Disabilitato)

                    End While
                End Using
            End Using
            Return EnteInfoDAX
        End Function


    End Class

End Namespace
