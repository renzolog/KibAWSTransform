Imports ProgettoEnte.Conservazione.Autenthicate
Imports System.Data.SqlClient

Namespace Data

    Public Class HashedToken
        Property Token As String
        Property Hash As String

        Property TokenID As Integer
    End Class

    Public Class ChiaveRegistro
        Inherits [Shared].Conservazione.Chiave

        Private _ID As Integer
        ReadOnly Property ID As Integer
            Get
                Return _ID
            End Get
        End Property

        Private _CodiceUnitaDocumentaria As String
        ReadOnly Property CodiceUnitaDocumentaria As String
            Get
                Return _CodiceUnitaDocumentaria
            End Get
        End Property

        Sub New(Chiave As [Shared].Conservazione.Chiave, ID As Integer, CodiceUnitaDocumentaria As String)
            MyBase.New()
            MyBase.Anno = Chiave.Anno
            MyBase.Numero = Chiave.Numero
            _ID = ID
            _CodiceUnitaDocumentaria = CodiceUnitaDocumentaria
        End Sub

        Sub New(Chiave As [Shared].Conservazione.Chiave, ID As Integer)
            Me.New(Chiave, ID, Nothing)
        End Sub

    End Class

    Public MustInherit Class RegistroBase
        Inherits BaseProtect

        Property Id As Integer
        Property IDUnitaDocumentaria As Integer
        Property ISTAT As String
        Property Data As Date 
        Property AnnoChiave As Integer
        Property NumeroChiave As String
        Property Token As String
        Property Tokens As List(Of HashedToken)

        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

    End Class


    Friend Class Registro
        Inherits RegistroBase

        Public Sub SetToken(IDRegistro As Integer, Token As String, Files As List(Of ProgettoEnte.Conservazione.Shared.File), ReplaceToken As String)

            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim ts As SqlTransaction = cn.BeginTransaction

                Try
                    Using cm As New SqlCommand(My.Resources.QueryRegistro.SetToken, cn, ts)
                        cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                        cm.Parameters.AddWithValue("@Id", IDRegistro)
                        cm.Parameters.AddWithValue("@Token", Token)
                        cm.Parameters.AddWithValue("@ReplaceToken", ReplaceToken)
                        cm.ExecuteNonQuery()
                    End Using

                    For Each f As ProgettoEnte.Conservazione.Shared.File In Files
                        Using cm As New SqlCommand("INSERT INTO RegistroDettaglio (IdRegistro, NomeFile, Hash, Token) VALUES (@IdRegistro, @NomeFile, @Hash, @Token)", cn, ts)
                            cm.Parameters.AddWithValue("@IdRegistro", IDRegistro)
                            cm.Parameters.AddWithValue("@NomeFile", f.NomeFile)
                            cm.Parameters.AddWithValue("@Hash", f.Hash)
                            cm.Parameters.AddWithValue("@Token", Token)
                            cm.ExecuteNonQuery()
                        End Using
                    Next


                    ts.Commit()
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try

            End Using

        End Sub


        Public Function GetChiave(EsibisciInfo As [Shared].IRiferimentiArgs, LoginSession As Autenthicate.LoginSession) As [Shared].IRiferimentiArgs

            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()

                Dim r As Registro = Read(cn, EsibisciInfo.TokenID)
                If r Is Nothing Then
                    Throw New ArgumentException("Token ID non trovato")
                End If







                If r.Token = "" Then
                    Throw New ArgumentException("Documento non disponibile presso il conservatore")
                End If

                Dim ud As New UnitaDocumentarie(MyBase.User)
                ud = ud.Read(cn, r.IDUnitaDocumentaria)
                If ud Is Nothing Then
                    Throw New ArgumentException("Unita Documentarie non trovato")
                End If

                If ud.Conservatore = [Enum].TipoConservatore.PARER Then
                    Dim lPARERLoginSession As Conservatori.PARER.Autenticazione.PARERLoginSession = CType(LoginSession, Conservatori.PARER.Autenticazione.PARERLoginSession)
                    lPARERLoginSession.Setextrainfo(ud)
                    Dim cb As New Conservazione.Shared.Conservazione.Chiave
                    cb.Anno = r.AnnoChiave
                    cb.Numero = r.NumeroChiave
                    Dim c As New Conservatori.PARER.Esibizione.EsibizioneArgs(EsibisciInfo)
                    c.Token = New ChiaveRegistro(cb, r.Id, ud.Codice)
                    Return c
                ElseIf ud.Conservatore = [Enum].TipoConservatore.Infocert Then
                    Dim c As New Conservatori.Infocert.Esibizione.EsibizioneArgs()
                    c.Tokens = r.Tokens
                    c.TokenID = EsibisciInfo.TokenID
                    c.ReturnFlags = EsibisciInfo.ReturnFlags
                    Return c
                ElseIf ud.Conservatore = [Enum].TipoConservatore.DAX Then
                    Dim c As New Conservatori.DAX.Esibizione.EsibizioneArgs(EsibisciInfo)
                    'Dim cb As New Conservazione.Shared.Conservazione.Chiave
                    'cb.Anno = r.AnnoChiave
                    'cb.Numero = r.NumeroChiave
                    c.Token = r.Tokens(0).Token
                    Return c

                ElseIf ud.Conservatore = [Enum].TipoConservatore.PARVeneto Then
                    Dim PARVenetoLoginSession As Conservatori.PARVeneto.Autenticazione.PARVenetoLoginSession = CType(LoginSession, Conservatori.PARVeneto.Autenticazione.PARVenetoLoginSession)
                    PARVenetoLoginSession.Setextrainfo(ud)
                    Dim c As New Conservatori.PARVeneto.Esibizione.EsibizioneArgs(EsibisciInfo)
                    'Dim cb As New Conservazione.Shared.Conservazione.Chiave
                    'cb.Anno = r.AnnoChiave
                    'cb.Numero = r.NumeroChiave

                    c.Token = r.Token
                    Return c

                Else
                    ' TODO: Implementare
                    Throw New NotImplementedException("GetChiave " & ud.Conservatore.ToString)
                End If

            End Using

        End Function

        Public Function GetTipoByTokenId(TokenId As Integer) As Object




            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                Dim rb As Data.Registro = Read(cn, TokenId)

                If rb Is Nothing Then
                    Throw New ArgumentOutOfRangeException("TokenId", "TokenId non valido")
                End If


                Dim objTD As New Data.UnitaDocumentarie(MyBase.User)
                objTD = objTD.Read(cn, rb.IDUnitaDocumentaria)

                If objTD Is Nothing Then
                    Throw New ArgumentOutOfRangeException("IDUnitaDocumentaria", "TokenId non valido")
                End If


                Return objTD.EsibizioneUserName


            End Using



        End Function

        Friend Function Read(UseCN As SqlConnection, ID As Integer) As Registro

            Dim r As Registro = Nothing

            Using cm As New SqlCommand(My.Resources.QueryRegistro.Read, UseCN)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                cm.Parameters.AddWithValue("@Id", ID)

                Using sdr As SqlDataReader = cm.ExecuteReader
                    While sdr.Read
                        r = New Registro(MyBase.User)
                        r.Id = sdr.Item("Id")
                        r.IDUnitaDocumentaria = sdr.Item("IDUnitaDocumentaria")
                        r.ISTAT = sdr.Item("ISTAT")
                        r.Data = sdr.Item("Data")
                        r.AnnoChiave = sdr.Item("AnnoChiave")
                        r.NumeroChiave = sdr.Item("NumeroChiave")
                        r.Token = sdr.Item("Token").ToString
                    End While
                End Using
            End Using

            If r IsNot Nothing Then
                Using cm As New SqlCommand(My.Resources.QueryRegistro.ReadTokenDettaglio, UseCN)
                    cm.Parameters.AddWithValue("@IdRegistro", ID)
                    Using sdr As SqlDataReader = cm.ExecuteReader
                        While sdr.Read
                            If r.Tokens Is Nothing Then
                                r.Tokens = New List(Of HashedToken)
                            End If
                            r.Tokens.Add(New HashedToken With {.TokenID = ID, .Token = sdr.Item("Token").ToString, .Hash = sdr.Item("Hash").ToString})
                        End While
                    End Using
                End Using
            End If


            Return r

        End Function


        Public Sub New(ByVal User As User)
            MyBase.New(User)
        End Sub

        Public Function Genera(IDUnitaDocumentaria As Integer, CodiceUnitaDocumentaria As String) As ChiaveRegistro


            Dim Chiave As New [Shared].Conservazione.Chiave
            Chiave.Anno = Now.Year

            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()

                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Dim res As Object
                    Using cm As New SqlCommand(My.Resources.QueryRegistro.GetLastChiave, cn, ts)
                        cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                        cm.Parameters.AddWithValue("@IDUnitaDocumentaria", IDUnitaDocumentaria)
                        cm.Parameters.AddWithValue("@AnnoChiave", Chiave.Anno)
                        res = cm.ExecuteScalar
                    End Using
                    If res Is Nothing Then
                        Chiave.Numero = 1
                    Else
                        If Integer.TryParse(res.ToString, Chiave.Numero) Then
                            Chiave.Numero = Chiave.Numero + 1
                        Else
                            Throw New ArgumentOutOfRangeException("Numero Chiave", "Non è possibile ottenere il progressico di chiave per questo regsitro")
                        End If
                    End If

                    Dim c As ChiaveRegistro = Genera(cn, ts, Chiave, IDUnitaDocumentaria, CodiceUnitaDocumentaria)
                    ts.Commit()
                    Return c
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try

            End Using


        End Function


        Public Function Genera(Chiave As [Shared].Conservazione.Chiave, IDUnitaDocumentaria As Integer, CodiceUnitaDocumentaria As String) As ChiaveRegistro

            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()

                Dim ts As SqlTransaction = cn.BeginTransaction
                Try
                    Dim c As ChiaveRegistro = Genera(cn, ts, Chiave, IDUnitaDocumentaria, CodiceUnitaDocumentaria)
                    ts.Commit()
                    Return c
                Catch ex As Exception
                    ts.Rollback()
                    Throw ex
                End Try

            End Using

        End Function


        Private Function Genera(UseCn As SqlConnection, UseTS As SqlTransaction, Chiave As [Shared].Conservazione.Chiave, IDUnitaDocumentaria As Integer, CodiceUnitaDocumentaria As String) As ChiaveRegistro

            Using cm As New SqlCommand(My.Resources.QueryRegistro.INSERT, UseCn, UseTS)
                cm.Parameters.AddWithValue("@ISTAT", MyBase.User.Ente)
                cm.Parameters.AddWithValue("@IDUnitaDocumentaria", IDUnitaDocumentaria)
                cm.Parameters.AddWithValue("@Data", Now)
                cm.Parameters.AddWithValue("@AnnoChiave", Chiave.Anno)
                cm.Parameters.AddWithValue("@NumeroChiave", Chiave.Numero)
                Return New ChiaveRegistro(Chiave, cm.ExecuteScalar, CodiceUnitaDocumentaria)
            End Using

        End Function

    End Class
End Namespace
