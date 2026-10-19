Namespace Conservatori.Shared
    Public Class AttributiFatturaPassiva
        Inherits Attributi

        Property PeriodoDiImposta As Integer
        Property CIG As String
        Property CUP As String
        Property CodiceFiscaleEmittente As String
        Property CodiceFiscale As String
        Property CodiceUfficioIPA As String
        Property DataProtocollo As Date
        Property DenominazioneEmittente As String
        Property Denominazione As String
        Property IDSDI As Long
        Property NomeFileSOGEI As String
        Property NumeroFattura As String
        Property NumeroProtocollo As Integer
        Property PartitaIVAEmittente As String
        Property PartitaIVA As String
        Property StatoDellaFattura As String

        Property NumeroRUF As String
        Property DataRegistrazioneRUF As Date

        Property ImportoTotale As Double
        Property Scadenza As Date
        Property RiferimentoContabile As String
        Property TipoRifContabile As String

        Property RegistroIVADescrizione As String
        Property RegistroIVAProtocollo As String
        Property RegistroIVAData As String

        Property IVACodiceRegistroNumeroData As String

        Property OggettoFornitura As String

        Property TipoIdentificativoMittente As String

        Property ImportoIVA As String
    End Class
End Namespace
