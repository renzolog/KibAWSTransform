Imports ProgettoEnte.Conservazione.Shared
Imports System.Data.SqlClient

Namespace Conservatori.Infocert.Autenticazione
    ''' <summary>
    ''' Classe di Gestione delle Sessioni avviate presso Infocert contenente l'ID della Sessione se avviata e il relativo Punto di Versamento
    ''' </summary>
    ''' <remarks></remarks>
    Public Class InforcertLoginSession
        Inherits Autenthicate.LoginSession
        ''' <summary>
        ''' Codice di ritorno da Infocert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Code As String
        ''' <summary>
        ''' Sessione autenticata presso Infocert
        ''' </summary>
        Public Property ldSessionId As String
        ''' <summary>
        ''' Punto di Versiamento
        ''' </summary> 
        Public Property PuntodiVersamento As String

        Public Property InfocertInfo As Data.EnteInfoINFOCERTBase
        Public Property InfocertLoginInfo As InfocertLoginInfo

        Public Overrides Function ToString() As String
            Return String.Format("Code '{0}' - LDSessioneID '{1}' - PuntodiVersamento '{2}' - Bucket '{3}'", Code, ldSessionId, PuntodiVersamento, Bucket)
        End Function

        Public Property Bucket() As String

        Public Property Policy As String

        Sub New(Ente As Data.EnteBase, EnteUtente As Data.EnteUtenteBase, InfocertInfo As Data.EnteInfoINFOCERTBase)
            MyBase.New(Ente, EnteUtente)
            Me.InfocertInfo = InfocertInfo
        End Sub

        Sub setExtraInfo(ConservationInfo As ConservationInfo)


            Dim objUD As New Data.UnitaDocumentarie(MyBase.EnteUtente.AuthicatedUser)
            objUD = objUD.READAttivo(MyBase.Ente.Conservatore, ConservationInfo.Tipologia, InfocertLoginInfo.InfoLogin.Software)
            If objUD Is Nothing Then
                Throw New Autenthicate.LoginException("Read UnitaDocumentarie", String.Format("Dati UnitaDocumentarie PARER non trovati per la tipologia {0} e Software {1}", ConservationInfo.Tipologia, InfocertLoginInfo.InfoLogin.Software))
            End If


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

        Sub setExtraInfo(TokenId As Integer, ByRef Tipo As TipoOggetto)

            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()

                Dim r As New Data.Registro(MyBase.EnteUtente.AuthicatedUser)
                r = r.Read(cn, TokenId)

                If r Is Nothing Then
                    Throw New ArgumentNullException("Registro", "Impossibile leggere il registro")
                End If

                Dim objUD As New Data.UnitaDocumentarie(MyBase.EnteUtente.AuthicatedUser)
                objUD = objUD.Read(cn, r.IDUnitaDocumentaria)

                If objUD Is Nothing Then
                    Throw New ArgumentNullException("UnitaDocumentarie", "Impossibile leggere l'Unita Documentaria")
                End If

                Tipo = objUD.Tipo

                Dim c As New ProgettoEnte.Conservazione.Shared.Conservazione.Chiave
                c.Anno = r.AnnoChiave
                c.Numero = r.NumeroChiave

                Me._ChiaveRegistro = New Data.ChiaveRegistro(c, TokenId, objUD.Codice)
            End Using
             
        End Sub
    End Class
End Namespace
