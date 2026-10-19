Imports ProgettoEnte.Conservazione.Conservatori.PARER.Conservazione
Imports System.Data.SqlClient
Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.DAX.Autenticazione
    Friend Class DAXLoginSession
        Inherits Autenthicate.LoginSession

        Sub New(Ente As Data.EnteBase, User As Data.EnteUtenteBase)
            MyBase.New(Ente, User)
        End Sub

        Property DAXLoginInfo As DAXLoginInfo
        Property DAXInfo As Data.EnteInfoDAX

        Protected _UserName As String
        ReadOnly Property UserName As String
            Get
                Return _UserName
            End Get
        End Property

        Protected _Password As String
        ReadOnly Property Password As String
            Get
                Return _Password
            End Get
        End Property

        Protected _UserNameEsibizione As String
        ReadOnly Property UserNameEsibizione As String
            Get
                Return _UserNameEsibizione
            End Get
        End Property

        Protected _PasswordEsibizione As String
        ReadOnly Property PasswordEsibizione As String
            Get
                Return _PasswordEsibizione
            End Get
        End Property

        Protected _TipoDocumentoPrincipale As String
        ReadOnly Property TipoDocumentoPrincipale As String
            Get
                Return _TipoDocumentoPrincipale
            End Get
        End Property

        Protected _TipologiaUnitaDocumentaria As String
        ReadOnly Property TipologiaUnitaDocumentaria As String
            Get
                Return _TipologiaUnitaDocumentaria
            End Get
        End Property

        Protected _TipoRegistro As String
        ReadOnly Property TipoRegistro As String
            Get
                Return _TipoRegistro
            End Get
        End Property


        ReadOnly Property Versione As Data.Versione

        Sub Setextrainfo(objUD As Data.UnitaDocumentarie)
            Me._TipoRegistro = objUD.Codice
            Me._UserName = objUD.VersanteUserName
            Me._Password = objUD.VersantePassword
            Me._UserNameEsibizione = objUD.EsibizioneUserName
            Me._PasswordEsibizione = objUD.EsibizionePassword
            Me._TipologiaUnitaDocumentaria = objUD.DenominazioneTipologiaDocumento
            Me._TipoDocumentoPrincipale = objUD.DenominazioneTipoDocumentoPrincipale
            Me._Versione = objUD.Versione
        End Sub

        Sub setExtraInfo(ConservationInfo As ConservationInfo)


            Dim objUD As New Data.UnitaDocumentarie(MyBase.EnteUtente.AuthicatedUser)
            objUD = objUD.READAttivo(MyBase.Ente.Conservatore, ConservationInfo.Tipologia, DAXLoginInfo.InfoLogin.Software)
            If objUD Is Nothing Then
                Throw New Autenthicate.LoginException("Read UnitaDocumentarie", "Dati UnitaDocumentarie DAX non trovati per la tipologia " & ConservationInfo.Tipologia.ToString & " e Software " & DAXLoginInfo.InfoLogin.Software.ToString)
            End If

            Setextrainfo(objUD)

            Dim r As New Data.Registro(MyBase.EnteUtente.AuthicatedUser)

            If ConservationInfo.IndiceRegistro IsNot Nothing AndAlso ConservationInfo.IndiceRegistro.Anno > 0 Then
                If String.IsNullOrEmpty(ConservationInfo.IndiceRegistro.Numero) Then
                    Throw New Autenthicate.LoginException("IndiceRegistro", "Dati Indice non valorizzati correttamente")
                End If
                Me._ChiaveRegistro = r.Genera(ConservationInfo.IndiceRegistro, objUD.Id, objUD.Codice)
            Else
                Me._ChiaveRegistro = r.Genera(objUD.Id, objUD.Codice)
            End If

            If Me._ChiaveRegistro Is Nothing OrElse Me._ChiaveRegistro.Anno <= 0 OrElse String.IsNullOrEmpty(Me._ChiaveRegistro.Numero) OrElse Me._ChiaveRegistro.ID = 0 Then
                Throw New Autenthicate.LoginException("_ChiaveRegistro", "Dati _ChiaveRegistro non generati correttamente")
            End If


        End Sub

        Sub setExtraInfo(ConservationInfo As AggiuntaAllegatiInfo)


            Dim r As New Data.Registro(MyBase.EnteUtente.AuthicatedUser)

            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()
                r = r.Read(cn, ConservationInfo.TokenID)
                If r Is Nothing Then
                    Throw New ArgumentNullException("IDRegistro", "Token di registro non trovato")
                End If

                Dim objUD As New Data.UnitaDocumentarie(MyBase.EnteUtente.AuthicatedUser)
                objUD = objUD.Read(cn, r.IDUnitaDocumentaria)
                If objUD Is Nothing Then
                    Throw New ArgumentNullException("IDRegistro", "Token di registro non trovato")
                End If

                Setextrainfo(objUD)

                Me._ChiaveRegistro = New Data.ChiaveRegistro(New ProgettoEnte.Conservazione.Shared.Conservazione.Chiave With {.Anno = r.AnnoChiave, .Numero = r.NumeroChiave}, r.Id)
            End Using

        End Sub

    End Class
End Namespace

