Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web
Imports Web.Model

Partial Public Class SignInModule
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub SignInButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        FormLayout.FindItemOrGroupByName("GeneralError").Visible = False

        If ASPxEdit.ValidateEditorsInContainer(Me) Then
            If Membership.ValidateUser(UserNameTextBox.Text, PasswordButtonEdit.Text) Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                    FormsAuthentication.SetAuthCookie(UserNameTextBox.Text, False)
                    Response.Redirect("~/")
                Else
                    FormLayout.FindItemOrGroupByName("GeneralError").Visible = True
                    FormsAuthentication.RedirectFromLoginPage(UserNameTextBox.Text, False)
                End If
            Else
                Response.Redirect("~/")
            End If
        End If





        'If ASPxEdit.ValidateEditorsInContainer(Me) Then
        '    ' DXCOMMENT: You Authentication logic
        '    If (Not AuthHelper.SignIn(UserNameTextBox.Text, PasswordButtonEdit.Text)) Then
        '        GeneralErrorDiv.InnerText = "Invalid login attempt."
        '        FormLayout.FindItemOrGroupByName("GeneralError").Visible = True
        '    Else
        '        Response.Redirect("~/")
        '    End If
        'End If
    End Sub
End Class