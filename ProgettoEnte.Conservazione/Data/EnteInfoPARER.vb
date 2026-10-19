Imports ProgettoEnte.Conservazione.Autenthicate
Imports System.Data.SqlClient

Namespace Data

    Public MustInherit Class EnteInfoPARERBase
        Inherits BaseProtect

        Property Id As Integer
        Property ISTAT As String
        Property Disabilitato As Boolean
        Property Ambiente As String
        Property DenominazioneEnte As String
        Property VersioneConservazione As String
        Property Struttura As String


        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

    End Class


    Friend Class EnteInfoPARER
        Inherits EnteInfoPARERBase

        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

        Public Function READAttivo() As EnteInfoPARER
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return READAttivo(cn)
            End Using
        End Function

        Private Function READAttivo(UseCN As SqlConnection) As EnteInfoPARER
            Dim EnteInfoPARER As EnteInfoPARER = Nothing
            Using cm As New SqlCommand(My.Resources.QueryEntiInfoPARER.READAttivo, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        EnteInfoPARER = New EnteInfoPARER(MyBase.User)
                        EnteInfoPARER.Id = sdr.Item("Id")
                        EnteInfoPARER.ISTAT = sdr.Item("ISTAT")
                        EnteInfoPARER.Disabilitato = sdr.Item("Disabilitato")
                        EnteInfoPARER.Ambiente = sdr.Item("Ambiente")
                        EnteInfoPARER.DenominazioneEnte = sdr.Item("DenominazioneEnte")
                        EnteInfoPARER.VersioneConservazione = sdr.Item("VersioneConservazione")
                        EnteInfoPARER.Struttura = sdr.Item("Struttura")
                    End While
                End Using
            End Using
            Return EnteInfoPARER
        End Function

    End Class
End Namespace

