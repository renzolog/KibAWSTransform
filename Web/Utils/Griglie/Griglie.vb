Imports DevExpress.Web

Public Class Griglie

    Public Shared Function SetButton(GridName As String, Optional SalvaContinua As Boolean = False, Optional SalvaNuovo As Boolean = False, Optional UseSubmitBehavior As Boolean = True) As ASPxButton
        Dim b As New ASPxButton
        b.AutoPostBack = False

        If SalvaContinua Then
            b.ClientSideEvents.Click = "function(s,e) {if(ASPxClientEdit.ValidateGroup('Validation'))  " & GridName & ".PerformCallback('SalvaContinua'); }"
            b.ImageUrl = "~/Content/Images/Menu/SaveTo_24x24.png"
            b.ID = String.Format("btnSalvaContinua{0}_", GridName)
            b.UseSubmitBehavior = UseSubmitBehavior
            b.Text = "Salva e Continua"
        ElseIf SalvaNuovo Then
            b.ClientSideEvents.Click = "function(s,e) {if(ASPxClientEdit.ValidateGroup('Validation'))  " & GridName & ".PerformCallback('SalvaNuovo'); }"
            b.ImageUrl = "~/Content/Images/Menu/SaveAndNew_24x24.png"
            b.ID = String.Format("btnSalvaNuovo{0}_", GridName)
            b.UseSubmitBehavior = UseSubmitBehavior
            b.Text = "Salva e Nuovo"
        Else
            b.ClientSideEvents.Click = "function(s,e) {if(ASPxClientEdit.ValidateGroup('Validation'))  " & GridName & ".UpdateEdit(); }"
            b.Image.Url = "~/Content/Images/Menu/Save_16x16.png"
            b.ID = String.Format("btnSalva{0}_", GridName)
            b.UseSubmitBehavior = UseSubmitBehavior
            b.Text = "Salva"
        End If
        Return b
    End Function

End Class
