Imports ProgettoEnte.Conservazione.Data.Enum
Imports System.Data.SqlClient
Imports ProgettoEnte.Conservazione.Autenthicate

Namespace Data

    Public MustInherit class EnteBase
        Inherits BaseProtect

        Property ISTAT As String
        Property Denominazione As String
        Property Disattivo As Boolean
        Property Conservatore As TipoConservatore
        Property InCollaudo As Boolean


        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub
    End Class
     
    Friend Class Ente
        Inherits EnteBase

        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub
         

        Public Function Read() As Ente
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return Read(cn)
            End Using
        End Function
        Friend Function Read(UseCN As SqlConnection) As Ente
            Dim Ente As Ente = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEnti.Read, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        Ente = New Ente(MyBase.User)
                        Ente.ISTAT = sdr.Item("ISTAT").ToString
                        Ente.Denominazione = sdr.Item("Denominazione").ToString
                        Ente.Disattivo = sdr.Item("Disattivo")
                        Ente.Conservatore = sdr.Item("Conservatore")
                        Ente.InCollaudo = sdr.Item("InCollaudo")
                    End While
                End Using
            End Using
            Return Ente
        End Function
    End Class
End Namespace

