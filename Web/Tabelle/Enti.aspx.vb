Imports DevExpress.Web
Public Class Enti
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            grdEnti.DataBind()
        End If
        grdEnti.Templates.EditForm = New tplEnti With {.Grid = grdEnti}
    End Sub

    Private Sub grdEnti_DataBinding(sender As Object, e As EventArgs) Handles grdEnti.DataBinding
        Dim obj As New Codifiche.Enti.Ente
        grdEnti.DataSource = obj.GetList()
    End Sub

    Private Sub grdEnti_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grdEnti.RowInserting
        Dim userControl As ucEnti = TryCast(grdEnti.FindEditFormTemplateControl(CType(grdEnti.Templates.EditForm, tplEnti).IdControl), ucEnti)
        Dim obj As New Codifiche.Enti.Ente
        obj.Insert(userControl.GetInsertDati)
        grdEnti.CancelEdit()
        e.Cancel = True
    End Sub

    Private Sub grdEnti_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grdEnti.RowUpdating
        Dim userControl As ucEnti = TryCast(grdEnti.FindEditFormTemplateControl(CType(grdEnti.Templates.EditForm, tplEnti).IdControl), ucEnti)
        Dim obj As New Codifiche.Enti.Ente
        obj.Update(userControl.Dati.ISTAT, userControl.GetUpdateDati)
        grdEnti.CancelEdit()
        e.Cancel = True
    End Sub
    Private Sub grdEnti_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grdEnti.RowDeleting
        Dim valore As System.Collections.Specialized.OrderedDictionary = e.Values
        Dim obj As New Codifiche.Enti.Ente
        obj.Delete(valore.Item("ISTAT"))
        grdEnti.CancelEdit()
        e.Cancel = True
    End Sub
    Private Sub grdEnti_CustomColumnDisplayText(sender As Object, e As ASPxGridViewColumnDisplayTextEventArgs) Handles grdEnti.CustomColumnDisplayText
        If e.Column.Name = "clmConservatore" Then
            e.DisplayText = Codifiche.UnitaDocumentarie.TipoConservatoreHelper.GetText(e.Value)
        End If
    End Sub
    Private Sub grdEnti_InitNewRow(sender As Object, e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles grdEnti.InitNewRow
        grdEnti.SettingsText.PopupEditFormCaption = "Nuovo"
    End Sub

    Private Sub grdEnti_CustomJSProperties(sender As Object, e As DevExpress.Web.ASPxGridViewClientJSPropertiesEventArgs) Handles grdEnti.CustomJSProperties
        e.Properties("cpRowCount") = grdEnti.VisibleRowCount
    End Sub

    Private Sub grdEnti_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs) Handles grdEnti.CustomErrorText
        e.ErrorText = e.Exception.Message
    End Sub

End Class