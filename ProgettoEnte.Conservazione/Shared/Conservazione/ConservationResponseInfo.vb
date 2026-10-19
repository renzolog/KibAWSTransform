Namespace [Shared]

    Public Enum ResponseStatusCode
        Ok
        Errore
    End Enum

    Public Class ConservationResponseInfo

        ''' <summary>
        ''' ID Richiesta
        ''' </summary> 
        Property TokenID As Integer

        Property Status As ResponseStatusCode
        Property Descrizione As String

        Public Overrides Function ToString() As String
            Return String.Format("Token ID {0}", TokenID)
        End Function

    End Class

    Public Class ConservationResponseInfoExtended
        Inherits ConservationResponseInfo

        Property IdC As Byte()

        Property IdCFileName As String


    End Class

    Public Class EsibitionResponseInfo
         
        Property Files As List(Of ProgettoEnte.Conservazione.Shared.FileBase)

        Property Status As ResponseStatusCode
        Property Descrizione As String

        Property StatusFiles As TipoStatusFile

        Public Enum TipoStatusFile
            Originale
            Rettificato
            Eliminato
        End Enum

    End Class

    Public Class DeleteResponseInfo
        Property Status As ResponseStatusCode
        Property Descrizione As String
    End Class


End Namespace