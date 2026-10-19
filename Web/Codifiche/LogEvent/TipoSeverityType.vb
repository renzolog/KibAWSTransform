Namespace Codifiche.LogEvent
    Public Enum TipoSeverityType
        Info
        Warning
        Exception
    End Enum

    Public Class TipoSeverityTypeHelper

        Public Shared Function GetList() As List(Of Object)
            Dim r = New List(Of Object)
            Dim items As Array
            items = System.Enum.GetValues(GetType(TipoSeverityType))
            For Each i In items
                r.Add(New With {.Id = i, .Descrizione = GetText(i)})
            Next
            Return r
        End Function
        Shared Function GetText(Tipo As TipoSeverityType) As String
            If Tipo = TipoSeverityType.Info Then
                Return "Info"
            ElseIf Tipo = TipoSeverityType.Warning Then
                Return "Warning"
            ElseIf Tipo = TipoSeverityType.Exception Then
                Return "Eccezione"
            Else
                Return Tipo.ToString
            End If
        End Function

    End Class
End Namespace
