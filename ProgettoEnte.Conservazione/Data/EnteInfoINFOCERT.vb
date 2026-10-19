Imports ProgettoEnte.Conservazione.Autenthicate
Imports System.Data.SqlClient

Namespace Data

    Public MustInherit Class EnteInfoINFOCERTBase
        Inherits BaseProtect

        Property Id As Integer
        Property ISTAT As String
        Property Disabilitato As Boolean
        Property Bucket As String


        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

    End Class

    Friend Class EnteInfoINFOCERT
        Inherits EnteInfoINFOCERTBase

        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub
         
        Friend Function READAttivo(UseCN As SqlConnection) As EnteInfoINFOCERT
            Dim EnteInfoINFOCERT As EnteInfoINFOCERT = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoINFOCERT.ReadATTIVO, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteInfoINFOCERT = New EnteInfoINFOCERT(MyBase.User)
                        EnteInfoINFOCERT.Id = sdr.Item("Id")
                        EnteInfoINFOCERT.ISTAT = sdr.Item("ISTAT")
                        EnteInfoINFOCERT.Disabilitato = sdr.Item("Disabilitato")
                        EnteInfoINFOCERT.Bucket = sdr.Item("Bucket")
                    End While
                End Using
            End Using
            Return EnteInfoINFOCERT
        End Function
    End Class

End Namespace

