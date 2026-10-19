Public MustInherit Class GridEditFormControl
    Inherits System.Web.UI.UserControl
    MustOverride ReadOnly Property HeaderText As String

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Try
            If String.IsNullOrEmpty(HeaderText) = False Then
                Dim d As DevExpress.Web.GridViewEditFormTemplateContainer = Me.DataItemContainer
                CType(d.NamingContainer.NamingContainer, DevExpress.Web.Rendering.GridViewEditFormPopup).HeaderText = HeaderText.Truncate(60)
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class