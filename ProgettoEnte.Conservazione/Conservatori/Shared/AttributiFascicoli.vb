Namespace Conservatori.Shared
    Public Class AttributiFascicoli
        Inherits Attributi

        Property Fascicolo As TipologiaFascicolo
        Property RUPCognome As String
        Property RUPNome As String
        Property DataInizioAssegnazione As Date
        Property DataApertura As Date
        Property DescrizioneClassificazione As String
        Property Progressivo As String
        Property DataChiusura As Date
        Property IndiceDocumenti As List(Of String)
        Property IdentificativoAggregazionePrimaria As String

    End Class

    Public Enum TipologiaFascicolo
        affare
        attivita
        personafisica
        personagiuridica
        procedimentoamministrativo
    End Enum
End Namespace


