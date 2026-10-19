Imports DevExpress.Web

Public Class ucUnitaDocumentarie
    Inherits GridEditFormControl

    Property Dati As Codifiche.UnitaDocumentarie.UnitaDocumentarioDati
    Property ISTAT As String
    Public Overrides ReadOnly Property HeaderText As String
        Get
            If Dati IsNot Nothing Then
                Return String.Format("ISTAT: {0}", Dati.ISTAT)
            End If
            Return String.Empty
        End Get
    End Property
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        cmbConservatore.ValueType = GetType(Codifiche.UnitaDocumentarie.TipoConservatore)
        cmbConservatore.DataSource = Codifiche.UnitaDocumentarie.TipoConservatoreHelper.GetList
        cmbConservatore.DataBind()

        cmbTipo.ValueType = GetType(Codifiche.UnitaDocumentarie.TipoOggetto)
        cmbTipo.DataSource = Codifiche.UnitaDocumentarie.TipoOggettoHelper.GetList
        cmbTipo.DataBind()

        cmbVersione.ValueType = GetType(Codifiche.UnitaDocumentarie.TipoVersione)
        cmbVersione.DataSource = Codifiche.UnitaDocumentarie.TipoVersioneHelper.GetList
        cmbVersione.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Dati IsNot Nothing AndAlso Dati.Id > 0 Then
            cmbConservatore.Value = Dati.Conservatore
            ckDisabilitato.Checked = Dati.Disabilitato
            txtCodice.Text = Dati.Codice
            txtDenominazioneTipologiaDocumento.Text = Dati.DenominazioneTipologiaDocumento
            txtDenominazioneTipoDocumentoPrincipale.Text = Dati.DenominazioneTipoDocumentoPrincipale
            txtVersanteUserName.Text = Dati.VersanteUserName
            txtVersantePassword.Text = Dati.VersantePassword
            txtEsibizioneUserName.Text = Dati.EsibizioneUserName
            txtEsibizionePassword.Text = Dati.EsibizionePassword
            cmbTipo.Value = Dati.Tipo
            ckDemografici.Checked = Dati.Demografici
            ckContabilita.Checked = Dati.Contabilita
            txtPolicy.Text = Dati.Policy
            cmbVersione.Value = Dati.Versione
        End If
    End Sub

    Public Function GetInsertDati() As Codifiche.UnitaDocumentarie.UnitaDocumentarioDatiInsertArgs
        Dim b As New Codifiche.UnitaDocumentarie.UnitaDocumentarioDatiInsertArgs
        b.ISTAT = ISTAT
        Integer.TryParse(cmbConservatore.Value, b.Conservatore)
        Boolean.TryParse(ckDisabilitato.Checked, b.Disabilitato)
        b.Codice = txtCodice.Text
        b.DenominazioneTipologiaDocumento = txtDenominazioneTipologiaDocumento.Text
        b.DenominazioneTipoDocumentoPrincipale = txtDenominazioneTipoDocumentoPrincipale.Text
        b.VersanteUserName = txtVersanteUserName.Text
        b.VersantePassword = txtVersantePassword.Text
        b.EsibizioneUserName = txtEsibizioneUserName.Text
        b.EsibizionePassword = txtEsibizionePassword.Text
        Integer.TryParse(cmbTipo.Value, b.Tipo)
        Boolean.TryParse(ckDemografici.Checked, b.Demografici)
        Boolean.TryParse(ckContabilita.Checked, b.Contabilita)
        b.Policy = txtPolicy.Text
        Integer.TryParse(cmbVersione.Value, b.Versione)
        Return b
    End Function

    Public Function GetUpdateDati() As Codifiche.UnitaDocumentarie.UnitaDocumentarioDatiUpdateArgs
        Dim b As New Codifiche.UnitaDocumentarie.UnitaDocumentarioDatiUpdateArgs
        Integer.TryParse(cmbConservatore.Value, b.Conservatore)
        Boolean.TryParse(ckDisabilitato.Checked, b.Disabilitato)
        b.Codice = txtCodice.Text
        b.DenominazioneTipologiaDocumento = txtDenominazioneTipologiaDocumento.Text
        b.DenominazioneTipoDocumentoPrincipale = txtDenominazioneTipoDocumentoPrincipale.Text
        b.VersanteUserName = txtVersanteUserName.Text
        b.VersantePassword = txtVersantePassword.Text
        b.EsibizioneUserName = txtEsibizioneUserName.Text
        b.EsibizionePassword = txtEsibizionePassword.Text
        Integer.TryParse(cmbTipo.Value, b.Tipo)
        Boolean.TryParse(ckDemografici.Checked, b.Demografici)
        Boolean.TryParse(ckContabilita.Checked, b.Contabilita)
        b.Policy = txtPolicy.Text
        Integer.TryParse(cmbVersione.Value, b.Versione)
        Return b
    End Function
End Class