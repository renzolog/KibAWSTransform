Imports ProgettoEnte.Conservazione.Autenthicate
Imports System.Data.SqlClient
Imports ProgettoEnte.Conservazione.Shared

Namespace Data

    Public MustInherit Class UnitaDocumentarieBase
        Inherits BaseProtect

        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

        Property Id As Integer
        Property ISTAT As String
        Property Conservatore As [Enum].TipoConservatore
        Property Disabilitato As Boolean
        Property Codice As String
        Property DenominazioneTipologiaDocumento As String
        Property DenominazioneTipoDocumentoPrincipale As String
        Property VersanteUserName As String
        Property VersantePassword As String
        Property EsibizioneUserName As String
        Property EsibizionePassword As String
        Property Tipo As TipoOggetto
        Property Policy As String
        Property Versione As Versione


    End Class

    Public Enum Versione
        Standard
        PARER_FATTURA11
    End Enum


    Friend Class UnitaDocumentarie
        Inherits UnitaDocumentarieBase

        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

        Public Function READAttivo(Conservatore As [Enum].TipoConservatore, Tipo As TipoOggetto, Software As TipoSoftware) As UnitaDocumentarie
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Return READAttivo(cn, Conservatore, Tipo, Software)
            End Using
        End Function

        Friend Function READAttivo(UseCN As SqlConnection, Conservatore As [Enum].TipoConservatore, Tipo As TipoOggetto, Software As TipoSoftware) As UnitaDocumentarie

            ' Se Arriva da portal il Tipo DeliberaConsiglio oppure DeliberaGiunta
            ' Viene forzata il tipo Delibera
            If Tipo = TipoOggetto.DeliberaConsiglio Or Tipo = TipoOggetto.DeliberaGiunta Then
                Tipo = TipoOggetto.Delibera
            End If

            Using cm As New SqlCommand(My.Resources.QueryUnitaDocumentarie.READAttivo, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                cm.Parameters.AddWithValue("@Conservatore", CInt(Conservatore))
                cm.Parameters.AddWithValue("@Tipo", CInt(Tipo))

                cm.Parameters.AddWithValue("@Contabilita", IIf(Software = TipoSoftware.Contabilita, 1, 2))
                cm.Parameters.AddWithValue("@Demografici", IIf(Software = TipoSoftware.Demografici, 1, 2))
                cm.Parameters.AddWithValue("@Segreteria", IIf(Software = TipoSoftware.ProtocolloAtti, 1, 2))

                Dim res = cm.ExecuteScalar
                If res Is Nothing OrElse CInt(res) = 0 Then
                    Throw New ArgumentNullException("UnitaDocumentarie", String.Format("Dati UnitaDocumentarie non trovati per la tipologia {0} e Software {1}", Tipo, Software))

                End If

                Return Read(UseCN, CInt(res))

            End Using
        End Function

        Friend Function Read(UseCN As SqlConnection, ID As Integer) As UnitaDocumentarie

            Dim UnitaDocumentarie As UnitaDocumentarie = Nothing

            Using cm As New SqlCommand(My.Resources.QueryUnitaDocumentarie.Read, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                cm.Parameters.AddWithValue("@Id", ID)


                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        UnitaDocumentarie = New UnitaDocumentarie(MyBase.User)
                        UnitaDocumentarie.Id = sdr.Item("Id")
                        UnitaDocumentarie.ISTAT = sdr.Item("ISTAT")
                        UnitaDocumentarie.Conservatore = sdr.Item("Conservatore")
                        UnitaDocumentarie.Disabilitato = sdr.Item("Disabilitato")
                        UnitaDocumentarie.Codice = sdr.Item("Codice")
                        UnitaDocumentarie.DenominazioneTipologiaDocumento = sdr.Item("DenominazioneTipologiaDocumento")
                        UnitaDocumentarie.DenominazioneTipoDocumentoPrincipale = sdr.Item("DenominazioneTipoDocumentoPrincipale")
                        UnitaDocumentarie.VersanteUserName = sdr.Item("VersanteUserName")
                        UnitaDocumentarie.VersantePassword = sdr.Item("VersantePassword")
                        UnitaDocumentarie.EsibizioneUserName = sdr.Item("EsibizioneUserName").ToString
                        UnitaDocumentarie.EsibizionePassword = sdr.Item("EsibizionePassword").ToString
                        UnitaDocumentarie.Tipo = sdr.Item("Tipo")
                        UnitaDocumentarie.Policy = sdr.Item("Policy").ToString
                        UnitaDocumentarie.Versione = sdr.Item("Versione")
                    End While
                End Using
            End Using

            Return UnitaDocumentarie

        End Function

    End Class
End Namespace
