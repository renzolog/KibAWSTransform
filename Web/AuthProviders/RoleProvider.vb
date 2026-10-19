
Namespace AuthProviders

    Public Class RoleProvider
        Inherits System.Web.Security.RoleProvider

        Public Overrides Sub AddUsersToRoles(usernames() As String, roleNames() As String)
            Throw New NotImplementedException()
        End Sub

        Public Overrides Property ApplicationName As String

        Public Overrides Sub CreateRole(roleName As String)
            Throw New NotImplementedException()
        End Sub

        Public Overrides Function DeleteRole(roleName As String, throwOnPopulatedRole As Boolean) As Boolean
            Throw New NotImplementedException()
        End Function

        Public Overrides Function FindUsersInRole(roleName As String, usernameToMatch As String) As String()
            Throw New NotImplementedException()
        End Function

        Public Overrides Function GetAllRoles() As String()
            Throw New NotImplementedException()
        End Function

        Public Overrides Function GetRolesForUser(username As String) As String()
            Return New String() {}
        End Function

        Public Overrides Function GetUsersInRole(roleName As String) As String()
            Throw New NotImplementedException()
        End Function

        Public Overrides Function IsUserInRole(username As String, roleName As String) As Boolean
            Throw New NotImplementedException()
        End Function

        Public Overrides Sub RemoveUsersFromRoles(usernames() As String, roleNames() As String)
            Throw New NotImplementedException()
        End Sub

        Public Overrides Function RoleExists(roleName As String) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
