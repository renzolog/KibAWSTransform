
Namespace Conservatori.Shared
    Public Class AttributiOrdinativiPagamenti
        Inherits Attributi

        Property bancaTesoriere As String '	Banca Tesoriere (ABI)	S
        Property ibanEnte As String '	IBAN Ente	S
        Property esercizioFinanziario As String '	Esercizio Finanziario	S
        Property importoOrdinativo As String '	Importo Ordinativo	S
        Property capitoloSpesa As String '	Capitolo di Spesa	S
        Property descrCapitolo As String 'Descrizione Capitolo di Spesa	S
        Property gestione As String '	Gestione(Competenza / Residuo)	S
        Property denominazioneBeneficiario As String '	Denominazione del Beneficario	S
        Property importoBeneficiario As String '	Importo del Beneficario	S
        Property ibanBeneficiario As String '	IBAN del Beneficario	S

    End Class

End Namespace
