Namespace Autenthicate
    Public Class User

        Friend Shared Function GetInternalUser(Ente As String) As User

            Dim u As New User
            u._Ente = Ente
            Return u

        End Function



        'Shared Function ValidateUser(username As String, password As String) As Boolean

        '    Dim objUser As Data.EnteUtente = Data.EnteUtente.Read(username, password)
        '    If objUser IsNot Nothing Then
        '        Return True
        '    Else
        '        Return False
        '    End If

        'End Function

        Protected Friend _Roles As List(Of String)
        ReadOnly Property Roles As List(Of String)
            Get
                Return _Roles
            End Get
        End Property

        Protected Friend _Utente As String
        ReadOnly Property Utente As String
            Get
                Return _Utente
            End Get
        End Property

        Protected Friend _Ente As String
        ReadOnly Property Ente As String
            Get
                Return _Ente
            End Get
        End Property

        Protected Friend _DenominazioneEnte As String
        ReadOnly Property DenominazioneEnte As String
            Get
                Return _DenominazioneEnte
            End Get
        End Property

        Public Shared Function GetUser(UserName As String) As User

            Try
                Dim objUser As Data.EnteUtente = Data.EnteUtente.Read(UserName)
                If objUser IsNot Nothing Then
                    Dim u As New User
                    u._Ente = objUser.ISTAT
                    u._Roles = objUser.Roles
                    u._DenominazioneEnte = objUser.Ente.Denominazione
                    u._Utente = UserName
                    Return u
                Else
                    Return Nothing
                End If
            Catch ex As System.Exception
                Return Nothing
            End Try

        End Function
    End Class
End Namespace

