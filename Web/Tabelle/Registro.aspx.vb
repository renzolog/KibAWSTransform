Imports DevExpress.Web

Public Class Registro
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

    Private Sub grdRegistro_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles grdRegistro.CustomCallback
        If e.Parameters = "Aggiorna" Then
            grdRegistro.DataBind()
        End If
    End Sub

    Private Sub grdRegistro_DataBinding(sender As Object, e As EventArgs) Handles grdRegistro.DataBinding
        grdRegistro.DataSource = Nothing
        Dim obj As New Codifiche.Registri.Registro
        Dim filtro As New Codifiche.Registri.RegistroDatiFilterArgs
        filtro.ISTAT = cmbEnte.Value
        filtro.Dal = dtDataDal.Date
        filtro.Al = dtDataAl.Date
        grdRegistro.DataSource = obj.GetList(filtro)
    End Sub
    Private Sub grdRegistro_InitNewRow(sender As Object, e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles grdRegistro.InitNewRow
        grdRegistro.SettingsText.PopupEditFormCaption = "Nuovo"
    End Sub

    Private Sub grdRegistro_CustomJSProperties(sender As Object, e As DevExpress.Web.ASPxGridViewClientJSPropertiesEventArgs) Handles grdRegistro.CustomJSProperties
        e.Properties("cpRowCount") = grdRegistro.VisibleRowCount
    End Sub

    Private Sub grdRegistro_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs) Handles grdRegistro.CustomErrorText
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

    Protected Sub grdRegistroDettaglio_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim grdRegistroDettaglio As ASPxGridView = TryCast(sender, ASPxGridView)
        Dim IdRegistro As Integer
        Dim DataItem As Object = CType(grdRegistroDettaglio.DataItemContainer, DevExpress.Web.GridViewDetailRowTemplateContainer).DataItem
        If DataItem IsNot Nothing Then
            If TypeOf DataItem Is DevExpress.Web.Data.WebDataRow Then
                DataItem = CType(grdRegistroDettaglio.DataItemContainer, DevExpress.Web.GridViewDetailRowTemplateContainer).DataItem
                Integer.TryParse(DataItem.Item("Id"), IdRegistro)
            Else
                DataItem = CType(grdRegistroDettaglio.DataItemContainer, DevExpress.Web.GridViewDetailRowTemplateContainer).DataItem
                Integer.TryParse(DataItem.Item("Id"), IdRegistro)
            End If

            Dim obj As New Codifiche.Registri.Dettagli.RegistroDettaglio
            Dim Res As List(Of Codifiche.Registri.Dettagli.RegistroDettaglioDati) = obj.GetList(IdRegistro)
            If Res IsNot Nothing AndAlso Res.Count > 0 Then
                grdRegistroDettaglio.DataSource = Res
            Else
                grdRegistroDettaglio.DataSource = New List(Of Codifiche.Registri.Dettagli.RegistroDettaglioDati)
            End If
        End If
    End Sub
    Protected Sub grdRegistroDettaglio_CustomJSProperties(sender As Object, e As ASPxGridViewClientJSPropertiesEventArgs)
        Dim grdRegistroDettaglio As ASPxGridView = TryCast(sender, ASPxGridView)
        e.Properties("cpRowCount") = grdRegistroDettaglio.VisibleRowCount
    End Sub
    Protected Sub grdRegistroDettaglio_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs)
        e.ErrorText = e.Exception.Message
    End Sub


End Class