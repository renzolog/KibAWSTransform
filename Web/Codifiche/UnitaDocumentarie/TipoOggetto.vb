Namespace Codifiche.UnitaDocumentarie
    Public Enum TipoOggetto
        Generico
        Protocollo
        Delibera
        Determina
        Contratto
        Affissione
        RegistroProtocollo
        FatturaPassiva
        FascicoloElettorale
        OPI
        GiornaleCassa
        DeliberaConsiglio
        DeliberaGiunta
        UsoInterno
        FatturaAttiva
        Fascicolo
    End Enum


    Public Class TipoOggettoHelper
        Public Shared Function GetList() As List(Of Object)
            Dim r = New List(Of Object)
            Dim items As Array = System.Enum.GetValues(GetType(TipoOggetto))
            For Each i In items
                If i = TipoOggetto.UsoInterno Then
                    Continue For
                End If
                r.Add(New With {.Id = i, .Descrizione = GetText(i)})
            Next
            Return r
        End Function

        Shared Function GetText(Tipo As TipoOggetto) As String
            If Tipo = TipoOggetto.Generico Then
                Return "Generico"
            ElseIf Tipo = TipoOggetto.Protocollo Then
                Return "Protocollo"
            ElseIf Tipo = TipoOggetto.Delibera Then
                Return "Delibera"
            ElseIf Tipo = TipoOggetto.Determina Then
                Return "Determina"
            ElseIf Tipo = TipoOggetto.Contratto Then
                Return "Contratto"
            ElseIf Tipo = TipoOggetto.Affissione Then
                Return "Affissione"
            ElseIf Tipo = TipoOggetto.RegistroProtocollo Then
                Return "Registro Protocollo"
            ElseIf Tipo = TipoOggetto.FatturaPassiva Then
                Return "Fattura Passiva"
            ElseIf Tipo = TipoOggetto.FascicoloElettorale Then
                Return "Fascicolo Elettorale"
            ElseIf Tipo = TipoOggetto.OPI Then
                Return "OPI"
            ElseIf Tipo = TipoOggetto.GiornaleCassa Then
                Return "Giornale Cassa"
            ElseIf Tipo = TipoOggetto.DeliberaConsiglio Then
                Return "Delibera Consiglio"
            ElseIf Tipo = TipoOggetto.DeliberaGiunta Then
                Return "Delibera Giunta"
            ElseIf Tipo = TipoOggetto.FatturaAttiva Then
                Return "Fattura Attiva"
            ElseIf Tipo = TipoOggetto.Fascicolo Then
                Return "Aggregazione Documentale"
            Else
                Return Tipo.ToString
            End If
        End Function
    End Class

End Namespace



