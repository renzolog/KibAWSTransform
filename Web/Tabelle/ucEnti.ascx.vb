Public Class ucEnti
    Inherits GridEditFormControl

    Property Dati As Codifiche.Enti.EnteDati

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
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Dati IsNot Nothing AndAlso String.IsNullOrEmpty(Dati.ISTAT) = False Then
            txtISTAT.ClientEnabled = False
            cmbConservatore.ClientEnabled = False
            txtISTAT.Value = Dati.ISTAT
            txtDenominazione.Text = Dati.Denominazione
            cmbConservatore.Value = Dati.Conservatore
            ckDisattivo.Checked = Dati.Disattivo
            ckInCollado.Checked = Dati.InCollaudo

            If Dati.Conservatore = Codifiche.UnitaDocumentarie.TipoConservatore.Infocert Then
                flEnte.FindItemOrGroupByName("lgInfoCert").ClientVisible = True
                If Dati.DatiAggiuntivi IsNot Nothing Then
                    With CType(Dati.DatiAggiuntivi, Codifiche.Enti.InfoCERT.EnteInfoCERTDati)
                        txtCERTBucket.Text = .Bucket
                        ckCERTDsiabilitato.Checked = .Disabilitato
                    End With
                End If
            ElseIf Dati.Conservatore = Codifiche.UnitaDocumentarie.TipoConservatore.PARER Then
                flEnte.FindItemOrGroupByName("lgInfoPARER").ClientVisible = True
                If Dati.DatiAggiuntivi IsNot Nothing Then
                    With CType(Dati.DatiAggiuntivi, Codifiche.Enti.InfoPARER.EnteInfoPARERDati)
                        txtPARERDenominazioneEnte.Text = .DenominazioneEnte
                        txtPARERAmbiente.Text = .Ambiente
                        txtPARERVersioneConservazione.Text = .VersioneConservazione
                        txtPARERStruttura.Text = .Struttura
                        ckPARERDisabilitato.Checked = .Disabilitato
                    End With
                End If
            ElseIf Dati.Conservatore = Codifiche.UnitaDocumentarie.TipoConservatore.DAX Then
                flEnte.FindItemOrGroupByName("lgInfoDAX").ClientVisible = True
                If Dati.DatiAggiuntivi IsNot Nothing Then
                    With CType(Dati.DatiAggiuntivi, Codifiche.Enti.InfoDAX.EnteInfoDAXDati)
                        txtDAXIntestazione.Text = .Intestazione
                        txtDAXLabel.Text = .Label
                        ckDAXDisabilitato.Checked = .Disabilitato
                    End With
                End If
            ElseIf Dati.Conservatore = Codifiche.UnitaDocumentarie.TipoConservatore.PARVeneto Then
                flEnte.FindItemOrGroupByName("lgInfoPARVeneto").ClientVisible = True
                If Dati.DatiAggiuntivi IsNot Nothing Then
                    With CType(Dati.DatiAggiuntivi, Codifiche.Enti.InfoPARVENETO.EnteInfoPARVenetoDati)
                        txtPARVenetoIdentificativoEnte.Text = .IdentificativoEnte
                        txtPARVenetoIntestazione.Text = .Intestazione
                        txtPARVenetoLabel.Text = .Label
                        ckPARVenetoDisabilitato.Checked = .Disabilitato
                    End With
                End If
            End If
        End If
    End Sub

    Public Function GetInsertDati() As Codifiche.Enti.EnteDatiInsertArgs
        Dim b As New Codifiche.Enti.EnteDatiInsertArgs
        b.ISTAT = txtISTAT.Text
        b.Denominazione = txtDenominazione.Text
        Integer.TryParse(cmbConservatore.Value, b.Conservatore)
        Boolean.TryParse(ckDisattivo.Checked, b.Disattivo)
        Boolean.TryParse(ckInCollado.Checked, b.InCollaudo)

        If cmbConservatore.Value = Codifiche.UnitaDocumentarie.TipoConservatore.Infocert Then
            b.DatiAggiuntivi = GetInsertInfoCERTDati()
        ElseIf cmbConservatore.Value = Codifiche.UnitaDocumentarie.TipoConservatore.PARER Then
            b.DatiAggiuntivi = GetInsertInfoPARERDati()
        ElseIf cmbConservatore.Value = Codifiche.UnitaDocumentarie.TipoConservatore.DAX Then
            b.DatiAggiuntivi = GetInsertInfoDAXDati()
        ElseIf cmbConservatore.Value = Codifiche.UnitaDocumentarie.TipoConservatore.PARVeneto Then
            b.DatiAggiuntivi = GetInsertInfoPARVENETODati()
        End If
        Return b
    End Function

    Public Function GetUpdateDati() As Codifiche.Enti.EnteDatiUpdateArgs
        Dim b As New Codifiche.Enti.EnteDatiUpdateArgs
        b.Denominazione = txtDenominazione.Text
        Integer.TryParse(cmbConservatore.Value, b.Conservatore)
        Boolean.TryParse(ckDisattivo.Checked, b.Disattivo)
        Boolean.TryParse(ckInCollado.Checked, b.InCollaudo)
        If cmbConservatore.Value = Codifiche.UnitaDocumentarie.TipoConservatore.Infocert Then
            b.DatiAggiuntivi = GetUpdateInfoCERTDati()
        ElseIf cmbConservatore.Value = Codifiche.UnitaDocumentarie.TipoConservatore.PARER Then
            b.DatiAggiuntivi = GetUpdateInfoPARERDati()
        ElseIf cmbConservatore.Value = Codifiche.UnitaDocumentarie.TipoConservatore.DAX Then
            b.DatiAggiuntivi = GetUpdateInfoDAXDati()
        ElseIf cmbConservatore.Value = Codifiche.UnitaDocumentarie.TipoConservatore.PARVeneto Then
            b.DatiAggiuntivi = GetUpdateInfoPARVENETODati()
        End If
        Return b
    End Function


#Region "DatiAggiuntivi"
    Public Function GetInsertInfoCERTDati() As Codifiche.Enti.InfoCERT.EnteInfoCERTDatiInsertArgs
        Dim b As New Codifiche.Enti.InfoCERT.EnteInfoCERTDatiInsertArgs
        b.Bucket = txtCERTBucket.Text
        Boolean.TryParse(ckCERTDsiabilitato.Checked, b.Disabilitato)
        Return b
    End Function

    Public Function GetInsertInfoPARERDati() As Codifiche.Enti.InfoPARER.EnteInfoPARERDatiInsertArgs
        Dim b As New Codifiche.Enti.InfoPARER.EnteInfoPARERDatiInsertArgs
        b.DenominazioneEnte = txtPARERDenominazioneEnte.Text
        b.Ambiente = txtPARERAmbiente.Text
        b.VersioneConservazione = txtPARERVersioneConservazione.Text
        b.Struttura = txtPARERStruttura.Text
        Boolean.TryParse(ckPARERDisabilitato.Checked, b.Disabilitato)
        Return b
    End Function

    Public Function GetInsertInfoDAXDati() As Codifiche.Enti.InfoDAX.EnteInfoDAXDatiInsertArgs
        Dim b As New Codifiche.Enti.InfoDAX.EnteInfoDAXDatiInsertArgs
        b.Intestazione = txtDAXIntestazione.Text
        b.Label = txtDAXLabel.Text
        Boolean.TryParse(ckDAXDisabilitato.Checked, b.Disabilitato)
        Return b
    End Function
    Public Function GetInsertInfoPARVENETODati() As Codifiche.Enti.InfoPARVENETO.EnteInfoPARVenetoDatiInsertArgs
        Dim b As New Codifiche.Enti.InfoPARVENETO.EnteInfoPARVenetoDatiInsertArgs
        b.IdentificativoEnte = txtPARVenetoIdentificativoEnte.Text
        b.Intestazione = txtPARVenetoIntestazione.Text
        b.Label = txtPARVenetoLabel.Text
        Boolean.TryParse(ckPARVenetoDisabilitato.Checked, b.Disabilitato)
        Return b
    End Function

    Public Function GetUpdateInfoCERTDati() As Codifiche.Enti.InfoCERT.EnteInfoCERTDatiiUpdateArgs
        Dim b As New Codifiche.Enti.InfoCERT.EnteInfoCERTDatiiUpdateArgs
        b.Bucket = txtCERTBucket.Text
        Boolean.TryParse(ckCERTDsiabilitato.Checked, b.Disabilitato)
        Return b
    End Function

    Public Function GetUpdateInfoPARERDati() As Codifiche.Enti.InfoPARER.EnteInfoPARERDatiUpdateArgs
        Dim b As New Codifiche.Enti.InfoPARER.EnteInfoPARERDatiUpdateArgs
        b.DenominazioneEnte = txtPARERDenominazioneEnte.Text
        b.Ambiente = txtPARERAmbiente.Text
        b.VersioneConservazione = txtPARERVersioneConservazione.Text
        b.Struttura = txtPARERStruttura.Text
        Boolean.TryParse(ckPARERDisabilitato.Checked, b.Disabilitato)
        Return b
    End Function

    Public Function GetUpdateInfoDAXDati() As Codifiche.Enti.InfoDAX.EnteInfoDAXDatiUpdateArgs
        Dim b As New Codifiche.Enti.InfoDAX.EnteInfoDAXDatiUpdateArgs
        b.Intestazione = txtDAXIntestazione.Text
        b.Label = txtDAXLabel.Text
        Boolean.TryParse(ckDAXDisabilitato.Checked, b.Disabilitato)
        Return b
    End Function
    Public Function GetUpdateInfoPARVENETODati() As Codifiche.Enti.InfoPARVENETO.EnteInfoPARVenetoDatiUpdateArgs
        Dim b As New Codifiche.Enti.InfoPARVENETO.EnteInfoPARVenetoDatiUpdateArgs
        b.IdentificativoEnte = txtPARVenetoIdentificativoEnte.Text
        b.Intestazione = txtPARVenetoIntestazione.Text
        b.Label = txtPARVenetoLabel.Text
        Boolean.TryParse(ckPARVenetoDisabilitato.Checked, b.Disabilitato)
        Return b
    End Function


#End Region


End Class