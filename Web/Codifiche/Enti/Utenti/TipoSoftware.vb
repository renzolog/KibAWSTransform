Namespace Codifiche.Enti.Utenti
    Public Enum TipoSoftware
        Nessuno = 0
        Demografici = 1
        ProtocolloAtti = 2
        Contabilita = 3
    End Enum


    Public Class TipoSoftwareHelper
        Public Shared Function GetList() As List(Of Object)
            Dim r = New List(Of Object)
            Dim items As Array = System.Enum.GetValues(GetType(TipoSoftware))
            For Each i In items
                r.Add(New With {.Id = i, .Descrizione = GetText(i)})
            Next
            Return r
        End Function

        Shared Function GetText(Tipo As TipoSoftware) As String
            If Tipo = TipoSoftware.Nessuno Then
                Return "Nessuno"
            ElseIf Tipo = TipoSoftware.Demografici Then
                Return "PEDemografici"
            ElseIf Tipo = TipoSoftware.ProtocolloAtti Then
                Return "Protocollo e Atti"
            ElseIf Tipo = TipoSoftware.Contabilita Then
                Return "Portale KSD"
            Else
                Return Tipo.ToString
            End If
        End Function
    End Class

End Namespace



