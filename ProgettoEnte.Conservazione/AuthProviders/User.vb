Imports System.Data.SqlClient

Namespace AuthProviders
    Public Class User
        Public Shared Function GetUserObject(UserName As String) As AuthProviders.User
            If UserName.ToString.ToLower = "amministratore" OrElse UserName.ToString.ToLower = "espolaore" OrElse UserName.ToString.ToLower = "faleccia" OrElse UserName.ToString.ToLower = "atramonti" OrElse UserName.ToString.ToLower = "mdellatorre" Then
                'HttpContext.Current.Session("User") = CreateDefualtUser() ' Mock user data
                Dim u As New User With {
                        ._Utente = UserName,
                        ._Cognome = "SOLUZIONI",
                        ._Nome = "DIGITALI",
                        ._Email = "",
                        ._AvatarUrl = "~/Content/Photo/User.png"}
                Return u
            Else
                Return Nothing
            End If
        End Function

        Public Shared Function Validate(username As String, password As String) As Boolean
            If (username.ToString.ToLower = "amministratore" AndAlso password.ToString = "Password123") OrElse (username.ToString.ToLower = "espolaore" AndAlso password.ToString = "Password456") OrElse (username.ToString.ToLower = "faleccia" AndAlso password.ToString = "Password789") OrElse (username.ToString.ToLower = "atramonti" AndAlso password.ToString = "Password012") OrElse (username.ToString.ToLower = "mdellatorre" AndAlso password.ToString = "Password345") Then
                Return True
            Else
                Return False
            End If

        End Function

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

        Protected Friend _Cognome As String
        ReadOnly Property Cognome As String
            Get
                Return _Cognome
            End Get
        End Property

        Protected Friend _Nome As String
        ReadOnly Property Nome As String
            Get
                Return _Nome
            End Get
        End Property
        Protected Friend _Email As String
        ReadOnly Property Email As String
            Get
                Return _Email
            End Get
        End Property
        Protected Friend _AvatarUrl As String
        ReadOnly Property AvatarUrl As String
            Get
                Return _AvatarUrl
            End Get
        End Property
    End Class
End Namespace
