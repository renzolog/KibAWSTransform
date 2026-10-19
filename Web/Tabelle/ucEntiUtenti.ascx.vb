Imports DevExpress.Web

Public Class ucEntiUtenti
    Inherits GridEditFormControl

    Property Dati As Codifiche.Enti.Utenti.EnteUtenteDati
    Property ISTAT As String
    Public Overrides ReadOnly Property HeaderText As String
        Get
            If Dati IsNot Nothing Then
                Return Dati.UserName
            End If
            Return String.Empty
        End Get
    End Property
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        cmbSoftware.ValueType = GetType(Codifiche.Enti.Utenti.TipoSoftware)
        cmbSoftware.DataSource = Codifiche.Enti.Utenti.TipoSoftwareHelper.GetList
        cmbSoftware.DataBind()

        grdRuolo.GridView.DataSource = AuthProviders.Groups.GetBaseGroups()
        grdRuolo.DataBind()
        grdRuolo.GridView.Width = grdRuolo.Width
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Dati IsNot Nothing AndAlso String.IsNullOrEmpty(Dati.UserName) = False Then
            txtUtente.ClientEnabled = False
            txtUtente.Text = Dati.UserName
            txtPassword.Text = Dati.Password
            ckDisabilitato.Checked = Dati.Disabilitato
            If Not grdRuolo.GridView.IsNewRowEditing AndAlso String.IsNullOrEmpty(grdRuolo.Text) Then
                grdRuolo.Text = Dati.ROLES
            End If
            cmbSoftware.Value = Dati.Software
        End If
    End Sub

    Public Function GetInsertDati() As Codifiche.Enti.Utenti.EnteUtenteDatiInsertArgs
        Dim b As New Codifiche.Enti.Utenti.EnteUtenteDatiInsertArgs
        b.ISTAT = ISTAT
        b.UserName = txtUtente.Text
        b.Password = txtPassword.Text
        Boolean.TryParse(ckDisabilitato.Checked, b.Disabilitato)
        b.ROLES = AuthProviders.Groups.GetRuoli(grdRuolo.Text)
        Integer.TryParse(cmbSoftware.Value, b.Software)
        Return b
    End Function

    Public Function GetUpdateDati() As Codifiche.Enti.Utenti.EnteUtenteDatiUpdateArgs
        Dim b As New Codifiche.Enti.Utenti.EnteUtenteDatiUpdateArgs
        b.Password = txtPassword.Text
        Boolean.TryParse(ckDisabilitato.Checked, b.Disabilitato)
        b.ROLES = AuthProviders.Groups.GetRuoli(grdRuolo.Text)
        Integer.TryParse(cmbSoftware.Value, b.Software)
        Return b
    End Function

    'Private Sub cmbISTAT_ItemRequestedByValue(source As Object, e As ListEditItemRequestedByValueEventArgs) Handles cmbISTAT.ItemRequestedByValue
    '    Dim value As Long = 0
    '    If e.Value Is Nothing OrElse (Not Int64.TryParse(e.Value.ToString(), value)) Then
    '        Return
    '    End If
    '    Dim obj As New Codifiche.Enti.Ente
    '    CType(source, ASPxComboBox).DataSource = obj.ReadList(value)
    '    CType(source, ASPxComboBox).DataBind()
    'End Sub

    'Private Sub cmbISTAT_ItemsRequestedByFilterCondition(source As Object, e As ListEditItemsRequestedByFilterConditionEventArgs) Handles cmbISTAT.ItemsRequestedByFilterCondition
    '    Dim comboBox As ASPxComboBox = CType(source, ASPxComboBox)
    '    If e.Filter = "" Then
    '        comboBox.DataSource = Nothing
    '        comboBox.DataBind()
    '        Return
    '    End If

    '    Dim obj As New Codifiche.Enti.Ente
    '    comboBox.DataSource = obj.GetListLarge(e.Filter, e.BeginIndex + 1, e.EndIndex + 1)

    '    If comboBox.DataSource Is Nothing Then
    '        comboBox.Value = Nothing
    '        comboBox.SelectedIndex = -1
    '        comboBox.SelectedItem = Nothing
    '        comboBox.TextField = ""
    '        comboBox.Text = ""
    '    End If

    '    comboBox.DataBind()
    'End Sub
End Class