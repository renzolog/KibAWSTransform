
Imports System.Data.SqlClient

Namespace Conservatori.PARVeneto.Autenticazione
    Friend Class Gestione
        Private _InfoConservazione As ProgettoEnte.Conservazione.Shared.ConservationInfo
        Private _LoginSession As Autenticazione.PARVenetoLoginSession
        Public ReadOnly Property LoginSession() As Autenticazione.PARVenetoLoginSession
            Get
                Return _LoginSession
            End Get
        End Property

        Public Shared Function Login(LoginInfo As PARVenetoLoginInfo) As PARVenetoLoginSession
            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()



                If LoginInfo Is Nothing Then
                    Return Nothing
                End If



                Dim l As New PARVenetoLoginSession(LoginInfo.Ente, LoginInfo.EnteUtente)
                l.PARVenetoLoginInfo = LoginInfo

                Dim e As New Data.EnteInfoPARVeneto(LoginInfo.EnteUtente.AuthicatedUser)
                e = e.READAttivo(cn)
                If e Is Nothing Then
                    Throw New Autenthicate.LoginException("ReadParametri", "Dati ParVeneto non trovati")
                End If
                'l..PARERInfo = e
                l.PARVenetoInfo = e

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

