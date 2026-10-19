Namespace Codifiche.UnitaDocumentarie
    Public Enum TipoConservatore
        NonDefinito
        Infocert
        PARER
        DAX
        PARVeneto
    End Enum


    Public Class TipoConservatoreHelper
        Public Shared Function GetList() As List(Of Object)
            Dim r = New List(Of Object)
            Dim items As Array = System.Enum.GetValues(GetType(TipoConservatore))
            For Each i In items
                r.Add(New With {.Id = i, .Descrizione = GetText(i)})
            Next
            Return r
        End Function

        Shared Function GetText(Tipo As TipoConservatore) As String
            If Tipo = TipoConservatore.NonDefinito Then
                Return "Non Definito"
            ElseIf Tipo = TipoConservatore.Infocert Then
                Return "Infocert"
            ElseIf Tipo = TipoConservatore.PARER Then
                Return "PARER"
            ElseIf Tipo = TipoConservatore.DAX Then
                Return "DAX"
            ElseIf Tipo = TipoConservatore.PARVeneto Then
                Return "PAR Veneto"
            Else
                Return Tipo.ToString
            End If
        End Function
    End Class

End Namespace



