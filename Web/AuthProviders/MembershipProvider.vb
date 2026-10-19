Namespace AuthProviders

    Public Class MembershipProvider
        Inherits System.Web.Security.MembershipProvider

        Public Overrides Property ApplicationName As String

        Public Overrides Function ChangePassword(username As String, oldPassword As String, newPassword As String) As Boolean
            Throw New NotImplementedException
        End Function

        Public Overrides Function ChangePasswordQuestionAndAnswer(username As String, password As String, newPasswordQuestion As String, newPasswordAnswer As String) As Boolean
            Throw New NotImplementedException
        End Function

        Public Overrides Function CreateUser(username As String, password As String, email As String, passwordQuestion As String, passwordAnswer As String, isApproved As Boolean, providerUserKey As Object, ByRef status As MembershipCreateStatus) As MembershipUser
            Throw New NotImplementedException
        End Function

        Public Overrides Function DeleteUser(username As String, deleteAllRelatedData As Boolean) As Boolean
            Throw New NotImplementedException
        End Function

        Public Overrides ReadOnly Property EnablePasswordReset As Boolean
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides ReadOnly Property EnablePasswordRetrieval As Boolean
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides Function FindUsersByEmail(emailToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
            Throw New NotImplementedException
        End Function

        Public Overrides Function FindUsersByName(usernameToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
            Throw New NotImplementedException
        End Function

        Public Overrides Function GetAllUsers(pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
            Throw New NotImplementedException
        End Function

        Public Overrides Function GetNumberOfUsersOnline() As Integer
            Throw New NotImplementedException
        End Function

        Public Overrides Function GetPassword(username As String, answer As String) As String
            Throw New NotImplementedException
        End Function

        Public Overloads Overrides Function GetUser(providerUserKey As Object, userIsOnline As Boolean) As MembershipUser
            Throw New NotImplementedException
        End Function

        Public Overloads Overrides Function GetUser(username As String, userIsOnline As Boolean) As MembershipUser

            Throw New NotImplementedException
        End Function

        Public Overrides Function GetUserNameByEmail(email As String) As String
            Throw New NotImplementedException
        End Function

        Public Overrides ReadOnly Property MaxInvalidPasswordAttempts As Integer
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters As Integer
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides ReadOnly Property MinRequiredPasswordLength As Integer
            Get
                Return 8 '   Throw New NotImplementedException
            End Get
        End Property

        Public Overrides ReadOnly Property PasswordAttemptWindow As Integer
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides ReadOnly Property PasswordFormat As MembershipPasswordFormat
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides ReadOnly Property PasswordStrengthRegularExpression As String
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides ReadOnly Property RequiresQuestionAndAnswer As Boolean
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides ReadOnly Property RequiresUniqueEmail As Boolean
            Get
                Throw New NotImplementedException
            End Get
        End Property

        Public Overrides Function ResetPassword(username As String, answer As String) As String
            Throw New NotImplementedException
        End Function

        Public Overrides Function UnlockUser(userName As String) As Boolean
            Throw New NotImplementedException
        End Function

        Public Overrides Sub UpdateUser(user As MembershipUser)
            Throw New NotImplementedException
        End Sub

        Public Overrides Function ValidateUser(username As String, password As String) As Boolean
            AuthProviders.UserLoader.ClearCache()
            Return ProgettoEnte.Conservazione.AuthProviders.User.Validate(username, password)
        End Function
    End Class

End Namespace
