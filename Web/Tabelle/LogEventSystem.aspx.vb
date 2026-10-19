Imports DevExpress.Web

Public Class LogEventSystem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtDataDal.Value = Date.Now
            dtDataAl.Value = Date.Now
        End If

    End Sub

    Private Sub grdLogEventSystem_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles grdLogEventSystem.CustomCallback
        If e.Parameters = "Aggiorna" Then
            grdLogEventSystem.DataBind()
        End If
    End Sub

    Private Sub grdLogEventSystem_DataBinding(sender As Object, e As EventArgs) Handles grdLogEventSystem.DataBinding
        grdLogEventSystem.DataSource = Nothing
        Dim obj As New Codifiche.LogEvent.LogEvent
        Dim filtro As New Codifiche.LogEvent.LogEventDatiFilterArgs
        filtro.ISTAT = String.Empty
        filtro.Dal = dtDataDal.Date
        filtro.Al = dtDataAl.Date
        grdLogEventSystem.DataSource = obj.GetList(filtro)
    End Sub
    Private Sub grdLogEventSystem_CustomColumnDisplayText(sender As Object, e As ASPxGridViewColumnDisplayTextEventArgs) Handles grdLogEventSystem.CustomColumnDisplayText
        If e.Column.Name = "clmSeverity" Then
            e.DisplayText = Codifiche.LogEvent.TipoSeverityTypeHelper.GetText(e.Value)
        End If
    End Sub
    Private Sub grdLogEventSystem_InitNewRow(sender As Object, e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles grdLogEventSystem.InitNewRow
        grdLogEventSystem.SettingsText.PopupEditFormCaption = "Nuovo"
    End Sub

    Private Sub grdLogEventSystem_CustomJSProperties(sender As Object, e As DevExpress.Web.ASPxGridViewClientJSPropertiesEventArgs) Handles grdLogEventSystem.CustomJSProperties
        e.Properties("cpRowCount") = grdLogEventSystem.VisibleRowCount
    End Sub

    Private Sub grdLogEventSystem_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs) Handles grdLogEventSystem.CustomErrorText
        e.ErrorText = e.Exception.Message
    End Sub
End Class