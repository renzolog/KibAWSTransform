Imports DevExpress.Web
Imports Web.AuthProviders

Partial Public Class Root
    Inherits MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Context.User.Identity.IsAuthenticated AndAlso String.IsNullOrEmpty(Context.User.Identity.Name) = False Then
            ApplicationMenu.Items.FindByName("miEnti").Enabled = True
            ApplicationMenu.Items.FindByName("miUnitaDocumentarie").Enabled = True
            ApplicationMenu.Items.FindByName("miEntiUtenti").Enabled = True
            ApplicationMenu.Items.FindByName("miRegistro").Enabled = True
            ApplicationMenu.Items.FindByName("miLogEvent").Enabled = True
            ApplicationMenu.Items.FindByName("miLogEventSystem").Enabled = True
        Else
            UserLoader.ClearCache()
        End If


        If String.IsNullOrEmpty(Page.Header.Title) Then
            Page.Header.Title = "PEConserva"
        Else
            Page.Header.Title = "PEConserva - " & Page.Header.Title
        End If


        Page.Header.DataBind()
        UpdateUserMenuItemsVisible()
        HideUnusedContent()
        UpdateUserInfo()
    End Sub

    Protected Sub HideUnusedContent()
        LeftAreaMenu.Items(1).Visible = False
    End Sub

    Protected Function HasContent(ByVal ContentPlaceHolder As Control) As Boolean
        If ContentPlaceHolder Is Nothing Then
            Return False
        End If

        Dim childControls As ControlCollection = ContentPlaceHolder.Controls
        If childControls.Count = 0 Then
            Return False
        End If

        Return True
    End Function

    ' SignIn/Register

    Protected Sub UpdateUserMenuItemsVisible()
        RightAreaMenu.Items.FindByName("SignInItem").Visible = Not Context.User.Identity.IsAuthenticated
        RightAreaMenu.Items.FindByName("MyAccountItem").Visible = Context.User.Identity.IsAuthenticated
        RightAreaMenu.Items.FindByName("SignOutItem").Visible = Context.User.Identity.IsAuthenticated
    End Sub

    Protected Sub UpdateUserInfo()
        If Context.User.Identity.IsAuthenticated Then
            Dim user = UserLoader.GetUserObject(Context.User.Identity.Name)
            Dim myAccountItem = RightAreaMenu.Items.FindByName("MyAccountItem")
            Dim userName = CType(myAccountItem.FindControl("UserNameLabel"), ASPxLabel)
            Dim email = CType(myAccountItem.FindControl("EmailLabel"), ASPxLabel)
            Dim accountImage = CType(RightAreaMenu.Items(0).FindControl("AccountImage"), HtmlGenericControl)
            userName.Text = String.Format("{0} ({1} {2})", user.Utente, user.Cognome, user.Nome)
            email.Text = user.Email
            accountImage.Attributes("class") = "account-image"

            If String.IsNullOrEmpty(user.AvatarUrl) Then
                accountImage.InnerHtml = String.Format("{0}{1}", user.Cognome, user.Nome(0)).ToUpper()
            Else
                Dim avatarUrl = CType(myAccountItem.FindControl("AvatarUrl"), HtmlImage)
                avatarUrl.Attributes("src") = ResolveUrl(user.AvatarUrl)
                accountImage.Style("background-image") = ResolveUrl(user.AvatarUrl)
            End If
        End If
    End Sub

    Protected Sub RightAreaMenu_ItemClick(ByVal source As Object, ByVal e As DevExpress.Web.MenuItemEventArgs)
        If e.Item.Name = "SignOutItem" Then
            FormsAuthentication.SignOut()
            AuthProviders.UserLoader.ClearCache()
            Response.Redirect("~/Account/SignIn.aspx", True)
            ' ASPxWebControl.RedirectOnCallback("~/Account/Login.aspx")
        End If
    End Sub

    Protected Sub ApplicationMenu_ItemDataBound(ByVal source As Object, ByVal e As MenuItemEventArgs)
        e.Item.Image.Url = String.Format("Content/Images/{0}.svg", e.Item.Text)
        e.Item.Image.UrlSelected = String.Format("Content/Images/{0}-white.svg", e.Item.Text)
    End Sub
End Class