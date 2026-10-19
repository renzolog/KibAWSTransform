Imports DevExpress.Web

Public Class LogEvent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim obj As New Codifiche.Enti.Ente
            cmbEnte.DataSource = obj.GetList()
            cmbEnte.DataBind()

            dtDataDal.Value = Date.Now
            dtDataAl.Value = Date.Now
        End If

    End Sub

    Private Sub grdLogEvent_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles grdLogEvent.CustomCallback
        If e.Parameters = "Aggiorna" Then
            grdLogEvent.DataBind()
        End If
    End Sub

    Private Sub grdLogEvent_DataBinding(sender As Object, e As EventArgs) Handles grdLogEvent.DataBinding
        grdLogEvent.DataSource = Nothing
        Dim obj As New Codifiche.LogEvent.LogEvent
        Dim filtro As New Codifiche.LogEvent.LogEventDatiFilterArgs
        filtro.ISTAT = cmbEnte.Value
        filtro.Dal = dtDataDal.Date
        filtro.Al = dtDataAl.Date
        grdLogEvent.DataSource = obj.GetList(filtro)
    End Sub
    Private Sub grdLogEvent_CustomColumnDisplayText(sender As Object, e As ASPxGridViewColumnDisplayTextEventArgs) Handles grdLogEvent.CustomColumnDisplayText
        If e.Column.Name = "clmSeverity" Then
            e.DisplayText = Codifiche.LogEvent.TipoSeverityTypeHelper.GetText(e.Value)
        End If
    End Sub
    Private Sub grdLogEvent_InitNewRow(sender As Object, e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles grdLogEvent.InitNewRow
        grdLogEvent.SettingsText.PopupEditFormCaption = "Nuovo"
    End Sub

    Private Sub grdLogEvent_CustomJSProperties(sender As Object, e As DevExpress.Web.ASPxGridViewClientJSPropertiesEventArgs) Handles grdLogEvent.CustomJSProperties
        e.Properties("cpRowCount") = grdLogEvent.VisibleRowCount
    End Sub

    Private Sub grdLogEvent_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs) Handles grdLogEvent.CustomErrorText
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