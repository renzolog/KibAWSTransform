Namespace Codifiche.UnitaDocumentarie
    Public Enum TipoVersione
        Standard
        PARER_FATTURA11
    End Enum


    Public Class TipoVersioneHelper
        Public Shared Function GetList() As List(Of Object)
            Dim r = New List(Of Object)
            Dim items As Array = System.Enum.GetValues(GetType(TipoVersione))
            For Each i In items
                r.Add(New With {.Id = i, .Descrizione = GetText(i)})
            Next
            Return r
        End Function

        Shared Function GetText(Tipo As TipoVersione) As String
            If Tipo = TipoVersione.Standard Then
                Return "Standard"
            ElseIf Tipo = TipoVersione.PARER_FATTURA11 Then
                Return "PARER FATTURA11"
            Else
                Return Tipo.ToString
            End If
        End Function
    End Class

End Namespace



