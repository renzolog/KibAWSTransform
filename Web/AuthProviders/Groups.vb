Namespace AuthProviders
    Public Class Groups

        Public Const WSCONSERVA As String = "CONSERVA"
        Public Const WSESIBISCI As String = "ESIBISCI"

        Public Shared Function GetBaseGroups() As List(Of Group)
            Dim lst As New List(Of Group)
            lst.Add(New Group() With {.Codice = WSCONSERVA, .Descrizione = "CONSERVA"})
            lst.Add(New Group() With {.Codice = WSESIBISCI, .Descrizione = "ESIBISCI"})
            Return lst
        End Function

        Public Shared Function JoinRuoli(Ruoli As List(Of String)) As String
            Dim ruolo As String = ""
            For Each r As String In Ruoli
                ruolo = ruolo & ";" & r
            Next
            If ruolo.StartsWith(";") Then
                ruolo = Mid(ruolo, 2)
            End If
            Return ruolo
        End Function

        Public Shared Function GetRuoli(Ruolo As String) As List(Of String)
            Dim lst As New List(Of String)
            lst = New List(Of String)
            lst.AddRange(Ruolo.Split(";"))
            Return lst
        End Function

    End Class

    Public Class Group
        Property Codice As String
        Property Descrizione As String
    End Class

End Namespace