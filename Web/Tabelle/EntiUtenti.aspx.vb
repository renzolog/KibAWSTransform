Imports DevExpress.Web

Public Class EntiUtenti
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim obj As New Codifiche.Enti.Ente
            cmbEnte.DataSource = obj.GetList()
            cmbEnte.DataBind()
        End If
        grdEntiUtenti.Templates.EditForm = New tplEntiUtenti With {.Grid = grdEntiUtenti, .ISTAT = cmbEnte.Value}
    End Sub

    Private Sub grdEntiUtenti_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles grdEntiUtenti.CustomCallback
        If e.Parameters = "Aggiorna" Then
            grdEntiUtenti.DataBind()
        End If
    End Sub

    Private Sub grdEntiUtenti_DataBinding(sender As Object, e As EventArgs) Handles grdEntiUtenti.DataBinding
        If cmbEnte.Value IsNot Nothing Then
            grdEntiUtenti.DataSource = Nothing
            Dim obj As New Codifiche.Enti.Utenti.EnteUtente
            grdEntiUtenti.DataSource = obj.GetList(cmbEnte.Value)
        End If
    End Sub

    Private Sub grdEntiUtenti_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grdEntiUtenti.RowInserting
        Dim userControl As ucEntiUtenti = TryCast(grdEntiUtenti.FindEditFormTemplateControl(CType(grdEntiUtenti.Templates.EditForm, tplEntiUtenti).IdControl), ucEntiUtenti)
        Dim obj As New Codifiche.Enti.Utenti.EnteUtente
        obj.Insert(userControl.GetInsertDati)
        grdEntiUtenti.CancelEdit()
        e.Cancel = True
    End Sub

    Private Sub grdEntiUtenti_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grdEntiUtenti.RowUpdating
        Dim userControl As ucEntiUtenti = TryCast(grdEntiUtenti.FindEditFormTemplateControl(CType(grdEntiUtenti.Templates.EditForm, tplEntiUtenti).IdControl), ucEntiUtenti)
        Dim obj As New Codifiche.Enti.Utenti.EnteUtente
        obj.Update(userControl.Dati.UserName, userControl.GetUpdateDati)
        grdEntiUtenti.CancelEdit()
        e.Cancel = True
    End Sub
    Private Sub grdEntiUtenti_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grdEntiUtenti.RowDeleting
        Dim valore As System.Collections.Specialized.OrderedDictionary = e.Values
        Dim obj As New Codifiche.Enti.Utenti.EnteUtente
        obj.Delete(valore.Item("UserName"))
        grdEntiUtenti.CancelEdit()
        e.Cancel = True
    End Sub
    Private Sub grdEntiUtenti_CustomColumnDisplayText(sender As Object, e As ASPxGridViewColumnDisplayTextEventArgs) Handles grdEntiUtenti.CustomColumnDisplayText
        If e.Column.Name = "clmRuolo" Then
            If e.Value = AuthProviders.Groups.WSCONSERVA Then
                e.DisplayText = "CONSERVA"
            ElseIf e.Value = AuthProviders.Groups.WSESIBISCI Then
                e.DisplayText = "ESIBISCI"
            End If
        ElseIf e.Column.Name = "clmSoftware" Then
            e.DisplayText = Codifiche.Enti.Utenti.TipoSoftwareHelper.GetText(e.Value)
        End If
    End Sub
    Private Sub grdEntiUtenti_InitNewRow(sender As Object, e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles grdEntiUtenti.InitNewRow
        grdEntiUtenti.SettingsText.PopupEditFormCaption = "Nuovo Utente"
    End Sub

    Private Sub grdEntiUtenti_CustomJSProperties(sender As Object, e As DevExpress.Web.ASPxGridViewClientJSPropertiesEventArgs) Handles grdEntiUtenti.CustomJSProperties
        e.Properties("cpRowCount") = grdEntiUtenti.VisibleRowCount
    End Sub

    Private Sub grdEntiUtenti_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs) Handles grdEntiUtenti.CustomErrorText
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