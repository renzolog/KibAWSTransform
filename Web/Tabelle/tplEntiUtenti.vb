Imports DevExpress.Web

Public Class tplEntiUtenti
    Implements ITemplate

    Private _User As String
    Public Property User() As String
        Get
            Return _User
        End Get
        Set(ByVal value As String)
            _User = value
        End Set
    End Property


    Private _gridView As ASPxGridView
    Public Property Grid() As ASPxGridView
        Get
            Return _gridView
        End Get

        Set(ByVal value As ASPxGridView)
            _gridView = value
        End Set
    End Property
    Property IdControl As String = "WbEntiUtenti"
    Property ISTAT As String
    Public Sub InstantiateIn(container As Control) Implements ITemplate.InstantiateIn
        If String.IsNullOrEmpty(ISTAT) Then
            container.Controls.Add(New LiteralControl("<h4><b>ISTAT mancante</b></h4>"))
            Return
        End If

        Dim index As Integer = (TryCast(container, GridViewEditFormTemplateContainer)).VisibleIndex
        Dim control As ucEntiUtenti = TryCast(container, GridViewEditFormTemplateContainer).Grid.Page.LoadControl("~/Tabelle/ucEntiUtenti.ascx")
        control.ID = IdControl
        control.ISTAT = ISTAT
        container.Controls.Add(control)

        If (Not _gridView.IsNewRowEditing) Then
            control.Dati = _gridView.GetRow(index)
        End If

        container.Controls.Add(Griglie.SetButton(_gridView.ClientInstanceName))
        container.Controls.Add(New ASPxGridViewTemplateReplacement() With {.ReplacementType = GridViewTemplateReplacementType.EditFormCancelButton})
    End Sub

End Class
