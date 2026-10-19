Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports Web.AuthProviders

Partial Public Class [Default]
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Context.User.Identity.IsAuthenticated AndAlso String.IsNullOrEmpty(Context.User.Identity.Name) = False Then
            Response.Redirect("~/Tabelle/UnitaDocumentarie.aspx", True)
        Else
            UserLoader.ClearCache()
            Response.Redirect("~/Account/SignIn.aspx", True)
        End If
    End Sub
End Class