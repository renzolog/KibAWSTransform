Namespace [Shared]

    Public Class FileBase

        Public Property Cartella As String
        Public Property NomeFile As String
        Public Property Buffer As Byte()

        Private _Hash As String
        Public Property Hash As String
            Get
                If String.IsNullOrEmpty(_Hash) Then
                    Return GetHash()
                End If
                Return _Hash
            End Get
            Set(value As String)
                _Hash = value
            End Set
        End Property

        Public Function GetHash() As String
            Return ProgettoEnte.Conservazione.Utility.Compute.GetHash(_Buffer)
        End Function

        Property ProgressivoAllegato As Integer
        Property IdFile As Integer
        Property Descrizione As String
        Property FirmatoDigitalmente As Boolean
    End Class

End Namespace
