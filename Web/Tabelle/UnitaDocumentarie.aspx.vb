Imports DevExpress.Web

Public Class UnitaDocumentarie
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim obj As New Codifiche.Enti.Ente
            cmbEnte.DataSource = obj.GetList()
            cmbEnte.DataBind()
        End If
        grdUnitaDocumentarie.Templates.EditForm = New tplUnitaDocumentarie With {.Grid = grdUnitaDocumentarie, .ISTAT = cmbEnte.Value}
    End Sub

    Private Sub grdUnitaDocumentarie_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles grdUnitaDocumentarie.CustomCallback
        If e.Parameters = "Aggiorna" Then
            grdUnitaDocumentarie.DataBind()
        End If
    End Sub

    Private Sub grdUnitaDocumentarie_DataBinding(sender As Object, e As EventArgs) Handles grdUnitaDocumentarie.DataBinding
        If cmbEnte.Value IsNot Nothing Then
            grdUnitaDocumentarie.DataSource = Nothing
            Dim obj As New Codifiche.UnitaDocumentarie.UnitaDocumentario
            grdUnitaDocumentarie.DataSource = obj.GetList(cmbEnte.Value)
        End If
    End Sub

    Private Sub grdUnitaDocumentarie_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grdUnitaDocumentarie.RowInserting
        Dim userControl As ucUnitaDocumentarie = TryCast(grdUnitaDocumentarie.FindEditFormTemplateControl(CType(grdUnitaDocumentarie.Templates.EditForm, tplUnitaDocumentarie).IdControl), ucUnitaDocumentarie)
        Dim obj As New Codifiche.UnitaDocumentarie.UnitaDocumentario
        obj.Insert(userControl.GetInsertDati)
        grdUnitaDocumentarie.CancelEdit()
        e.Cancel = True
    End Sub

    Private Sub grdUnitaDocumentarie_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grdUnitaDocumentarie.RowUpdating
        Dim userControl As ucUnitaDocumentarie = TryCast(grdUnitaDocumentarie.FindEditFormTemplateControl(CType(grdUnitaDocumentarie.Templates.EditForm, tplUnitaDocumentarie).IdControl), ucUnitaDocumentarie)
        Dim obj As New Codifiche.UnitaDocumentarie.UnitaDocumentario
        obj.Update(userControl.Dati.Id, userControl.GetUpdateDati)
        grdUnitaDocumentarie.CancelEdit()
        e.Cancel = True
    End Sub
    Private Sub grdUnitaDocumentarie_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grdUnitaDocumentarie.RowDeleting
        Dim valore As System.Collections.Specialized.OrderedDictionary = e.Values
        Dim obj As New Codifiche.UnitaDocumentarie.UnitaDocumentario
        obj.Delete(valore.Item("Id"))
        grdUnitaDocumentarie.CancelEdit()
        e.Cancel = True
    End Sub
    Private Sub grdUnitaDocumentarie_CustomColumnDisplayText(sender As Object, e As ASPxGridViewColumnDisplayTextEventArgs) Handles grdUnitaDocumentarie.CustomColumnDisplayText
        If e.Column.Name = "clmConservatore" Then
            e.DisplayText = Codifiche.UnitaDocumentarie.TipoConservatoreHelper.GetText(e.Value)
        ElseIf e.Column.Name = "clmTipo" Then
            e.DisplayText = Codifiche.UnitaDocumentarie.TipoOggettoHelper.GetText(e.Value)
        ElseIf e.Column.Name = "clmVersione" Then
            e.DisplayText = Codifiche.UnitaDocumentarie.TipoVersioneHelper.GetText(e.Value)
        End If
    End Sub
    Private Sub grdUnitaDocumentarie_InitNewRow(sender As Object, e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles grdUnitaDocumentarie.InitNewRow
        grdUnitaDocumentarie.SettingsText.PopupEditFormCaption = "Nuovo"
    End Sub

    Private Sub grdUnitaDocumentarie_CustomJSProperties(sender As Object, e As DevExpress.Web.ASPxGridViewClientJSPropertiesEventArgs) Handles grdUnitaDocumentarie.CustomJSProperties
        e.Properties("cpRowCount") = grdUnitaDocumentarie.VisibleRowCount
    End Sub

    Private Sub grdUnitaDocumentarie_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs) Handles grdUnitaDocumentarie.CustomErrorText
        e.ErrorText = e.Exception.Message
    End Sub

    Private Sub cmbEnte_ItemRequestedByValue(source As Object, e As ListEditItemRequestedByValueEventArgs) Handles cmbEnte.ItemRequestedByValue
        Dim value As Long = 0
        If e.Value Is Nothing OrElse (Not Int64.TryParse(e.Value.ToString(), value)) Then
            Return
        End If
        Dim obj As New Codifiche.Enti.Ente
        CType(source, ASPxComboBox).DataSource = obj.ReadList(value)
        CType(source, ASPxComboBox).DataBind()
    End Sub

    Private Sub cmbEnte_ItemsRequestedByFilterCondition(source As Object, e As ListEditItemsRequestedByFilterConditionEventArgs) Handles cmbEnte.ItemsRequestedByFilterCondition
        Dim comboBox As ASPxComboBox = CType(source, ASPxComboBox)
        If e.Filter = "" Then
            comboBox.DataSource = Nothing
            comboBox.DataBind()
            Return
        End If

        Dim obj As New Codifiche.Enti.Ente
        comboBox.DataSource = obj.GetListLarge(e.Filter, e.BeginIndex + 1, e.EndIndex + 1)

        If comboBox.DataSource Is Nothing Then
            comboBox.Value = Nothing
            comboBox.SelectedIndex = -1
            comboBox.SelectedItem = Nothing
            comboBox.TextField = ""
            comboBox.Text = ""
        End If

        comboBox.DataBind()
    End Sub
End Class