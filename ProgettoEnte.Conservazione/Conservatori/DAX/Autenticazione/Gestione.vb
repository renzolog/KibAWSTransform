Imports System.Text
Imports System.IO
Imports System.Net.Security
Imports System.Net
Imports ProgettoEnte.Conservazione.Conservatori.Infocert.Shared
Imports System.Xml
Imports System.Data.SqlClient
Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.DAX.Autenticazione
    Friend Class Gestione


        Private _InfoConservazione As ProgettoEnte.Conservazione.Shared.ConservationInfo
        Private _LoginSession As Autenticazione.DAXLoginSession
        Public ReadOnly Property LoginSession() As Autenticazione.DAXLoginSession
            Get
                Return _LoginSession
            End Get
        End Property

        Public Shared Function Login(LoginInfo As DAXLoginInfo) As DAXLoginSession
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()



                If LoginInfo Is Nothing Then
                    Return Nothing
                End If



                Dim l As New DAXLoginSession(LoginInfo.Ente, LoginInfo.EnteUtente)
                l.DAXLoginInfo = LoginInfo

                Dim e As New Data.EnteInfoDAX(LoginInfo.EnteUtente.AuthicatedUser)
                e = e.READAttivo(cn)
                If e Is Nothing Then
                    Throw New Autenthicate.LoginException("ReadParametri", "Dati DAX non trovati " & LoginInfo.EnteUtente.AuthicatedUser.Ente)
                End If
                l.DAXInfo = e
                Return l
            End Using
        End Function

        Private Sub New(Info As ProgettoEnte.Conservazione.Shared.ConservationInfo)

            _InfoConservazione = Info
        End Sub




        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class




End Namespace

