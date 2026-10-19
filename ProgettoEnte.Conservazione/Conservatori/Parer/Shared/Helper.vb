Imports ProgettoEnte.Conservazione.Shared
Imports ProgettoEnte.Conservazione.Conservatori.Shared

Namespace Conservatori.PARER.Shared
    Friend Class Helper

        Friend Shared Function GetDatiSpeficifi(Info As ConservationInfo, isPEA As Boolean) As Xml.XmlElement()

            Dim n As Xml.XmlNode
            Dim x As New Xml.XmlDocument
            Dim el As New List(Of Xml.XmlElement)

            If Info.Tipologia = TipoOggetto.RegistroProtocollo Then
                If Info.AttributiSpecifici IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is AttributiRegistroProtocollo Then
                    Dim reg = CType(Info.AttributiSpecifici, AttributiRegistroProtocollo)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroIniziale", "")
                    n.InnerText = reg.NumeroPrimaRegistrazione
                    el.Add(n)


                    n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroFinale", "")
                    n.InnerText = reg.NumeroUltimaRegistrazione
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "DataInizioRegistrazioni", "")
                    n.InnerText = reg.DataPrimaRegistrazione.ToString("yyyy-MM-dd")
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "DataFineRegistrazioni", "")
                    n.InnerText = reg.DataUltimaRegistrazione.ToString("yyyy-MM-dd")
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "Originatore", "")
                    n.InnerText = reg.DenominazioneAmministrazione
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "Responsabile", "")
                    n.InnerText = reg.Responsabile
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "Operatore", "")
                    n.InnerText = "StorageManager"
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroDocumentiRegistrati", "")
                    n.InnerText = reg.NumeroUltimaRegistrazione - reg.NumeroPrimaRegistrazione
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroDocumentiAnnullati", "") ' TODO Chiadere a Marco
                    n.InnerText = 0
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "DenominazioneApplicativo", "")
                    n.InnerText = "Protocollo e Atti"
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "VersioneApplicativo", "")
                    n.InnerText = 1
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "ProduttoreApplicativo", "")
                    n.InnerText = "ProgettoEnte"
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "DenominazioneSistemaGestioneBaseDati", "")
                    n.InnerText = "-"
                    el.Add(n)
                    n = x.CreateNode(Xml.XmlNodeType.Element, "VersioneSistemaGestioneBaseDati", "")
                    n.InnerText = "-"
                    el.Add(n)
                    n = x.CreateNode(Xml.XmlNodeType.Element, "ProduttoreSistemaGestioneBaseDati", "")
                    n.InnerText = "-"
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "TempoConservazione", "")
                    n.InnerText = "ILLIMITATO"
                    el.Add(n)

                    Return el.ToArray

                End If

                Return Nothing
            ElseIf Info.Tipologia = TipoOggetto.Determina Then
                If Info.AttributiSpecifici Is Nothing OrElse Not TypeOf Info.AttributiSpecifici Is AttributiDetermina Then
                    Return Nothing

                End If
                Dim attr As AttributiDetermina = CType(Info.AttributiSpecifici, AttributiDetermina)


                If attr.DataEsecutivita.Year > 1799 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "EsecutivitaData", "")
                    n.InnerText = attr.DataEsecutivita.ToString("yyyy-MM-dd")
                    el.Add(n)
                End If

                Return el.ToArray

            ElseIf Info.Tipologia = TipoOggetto.Contratto Then
                If Info.AttributiSpecifici Is Nothing OrElse Not TypeOf Info.AttributiSpecifici Is AttributiContratto Then
                    Return Nothing

                End If
                Dim attr As AttributiContratto = CType(Info.AttributiSpecifici, AttributiContratto)

                If String.IsNullOrEmpty(attr.TipoContratto) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "FormaContratto", "")
                    If attr.TipoContratto.ToUpper = "ATTO PUBBLICO AMMINISTRATIVO" Then
                        n.InnerText = "Forma pubblica amministrativa"
                    ElseIf attr.TipoContratto.ToUpper = "SCRITTURA PRIVATA NON AUTENTICATA" Then
                        n.InnerText = "Scrittura privata"
                    Else
                        n.InnerText = attr.TipoContratto.PulisciWithRegEx(255)
                    End If
                    el.Add(n)
                End If
                If attr.DataStipula.Year > 1799 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "DataStipula", "")
                    n.InnerText = attr.DataStipula.ToString("yyyy-MM-dd")
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.LuogoStipula) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "LuogoStipula", "")
                    n.InnerText = attr.LuogoStipula.PulisciWithRegEx(255)
                    el.Add(n)
                End If
                If String.IsNullOrEmpty(attr.FirmatarioEnte) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "FirmatarioEnte", "")
                    n.InnerText = attr.FirmatarioEnte.PulisciWithRegEx(255)
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.Contraente) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Contraenti", "")
                    n.InnerText = attr.Contraente.PulisciWithRegEx(255)
                    el.Add(n)
                End If

                If attr.ImportoRegistrazione <> 0 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Valore", "")
                    n.InnerText = attr.ImportoRegistrazione.ToString
                    el.Add(n)
                End If


                If String.IsNullOrEmpty(attr.Registrazione) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Registrazione", "")
                    n.InnerText = attr.Registrazione.PulisciWithRegEx(255)
                    el.Add(n)
                End If

                If attr.DataRegistrazione.Year > 1799 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "AdEDataInvio", "")
                    n.InnerText = attr.DataRegistrazione.ToString("yyyy-MM-dd")
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.IdTelematico) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "AdEEstremiRegistrazione", "")
                    n.InnerText = attr.IdTelematico.PulisciWithRegEx(255)
                    el.Add(n)
                End If

                If attr.DataRegistrazione.Year > 1799 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "AdEDataRegistrazione", "")
                    n.InnerText = attr.DataRegistrazione.ToString("yyyy-MM-dd")
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.NumeroRegistrazione) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "RegistrazioneNumero", "")
                    n.InnerText = attr.NumeroRegistrazione.PulisciWithRegEx(255)
                    el.Add(n)
                End If

                Return el.ToArray
            ElseIf Info.Tipologia = TipoOggetto.Delibera Or Info.Tipologia = TipoOggetto.DeliberaConsiglio Or Info.Tipologia = TipoOggetto.DeliberaGiunta Then
                If Info.AttributiSpecifici Is Nothing OrElse Not TypeOf Info.AttributiSpecifici Is AttributiDelibera Then
                    Return Nothing

                End If
                Dim attr As AttributiDelibera = CType(Info.AttributiSpecifici, AttributiDelibera)
                If String.IsNullOrEmpty(attr.ResponsabileProcedimento) = False Then 'OK
                    n = x.CreateNode(Xml.XmlNodeType.Element, "ResponsabileProcedimento", "")
                    n.InnerText = attr.ResponsabileProcedimento
                    el.Add(n)
                End If

                If attr.DataEsecutivita.Year > 1799 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "DataEsecutivita", "") 'OK
                    n.InnerText = attr.DataEsecutivita.ToString("yyyy-MM-dd")
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.RiferimentiAlboPretorio) = False Then 'OK
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Pubblicato", "")
                    n.InnerText = "SI"
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "PubblicazioneRegistro", "") 'OK
                    n.InnerText = "Albo Pretorio"
                    el.Add(n)


                    If attr.RiferimentiAlboPretorio.Length > 5 Then

                        n = x.CreateNode(Xml.XmlNodeType.Element, "PubblicazioneAnno", "")
                        n.InnerText = attr.RiferimentiAlboPretorio.Substring(0, 4)
                        el.Add(n)


                        n = x.CreateNode(Xml.XmlNodeType.Element, "PubblicazioneNumero", "")
                        n.InnerText = attr.RiferimentiAlboPretorio.Substring(5).Trim
                        el.Add(n)
                    End If

                Else
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Pubblicato", "")
                    n.InnerText = "NO"
                    el.Add(n)
                End If





                If attr.AlboPretorioDataPubblicazione.Year > 1799 Then 'OK
                    n = x.CreateNode(Xml.XmlNodeType.Element, "PubblicazioneInizio", "")
                    n.InnerText = attr.AlboPretorioDataPubblicazione.ToString("yyyy-MM-dd")
                    el.Add(n)
                End If

                Return el.ToArray

            ElseIf Info.Tipologia = TipoOggetto.Protocollo Then
                If Info.AttributiSpecifici Is Nothing OrElse Not TypeOf Info.AttributiSpecifici Is AttributiProtocollo Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Annullato", "")
                    n.InnerText = "NO"
                    el.Add(n)
                    Return el.ToArray
                End If

                Dim attr As AttributiProtocollo = CType(Info.AttributiSpecifici, AttributiProtocollo)


                If String.IsNullOrEmpty(attr.Mittente) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Mittente", "")
                    n.InnerText = attr.Mittente
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.Destinatario) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Destinatario", "")
                    n.InnerText = attr.Destinatario
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.TipoProtocollo) = False Then
                    If attr.TipoProtocollo.ToUpper.StartsWith("E") Then
                        n = x.CreateNode(Xml.XmlNodeType.Element, "Movimento", "")
                        n.InnerText = "ENTRATA"
                        el.Add(n)
                    ElseIf attr.TipoProtocollo.ToUpper.StartsWith("U") Then
                        n = x.CreateNode(Xml.XmlNodeType.Element, "Movimento", "")
                        n.InnerText = "USCITA"
                        el.Add(n)
                    ElseIf attr.TipoProtocollo.ToUpper.StartsWith("I") Then
                        n = x.CreateNode(Xml.XmlNodeType.Element, "Movimento", "")
                        n.InnerText = "INTERNO"
                        el.Add(n)
                    End If
                End If

                If String.IsNullOrEmpty(attr.NumeroDocumentoMittente) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroDocumentoMittente", "")
                    n.InnerText = attr.NumeroDocumentoMittente
                    el.Add(n)
                ElseIf String.IsNullOrEmpty(attr.TipoProtocollo) = False AndAlso attr.TipoProtocollo.ToUpper.StartsWith("E") AndAlso isPEA Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroDocumentoMittente", "")
                    n.InnerText = Info.IndiceRegistro.Numero ' forzato per Pea se non c'è visto che parer è obbligatorio
                    el.Add(n)
                End If

                If attr.DataDocumento.Year > 1 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "DataDocumentoMittente", "")
                    n.InnerText = attr.DataDocumento.ToString("yyyy-MM-dd")
                    el.Add(n)
                ElseIf String.IsNullOrEmpty(attr.TipoProtocollo) = False AndAlso attr.TipoProtocollo.ToUpper.StartsWith("E") AndAlso isPEA AndAlso Info.Data.Year > 1 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "DataDocumentoMittente", "")
                    n.InnerText = Info.Data.ToString("yyyy-MM-dd") ' forzato per Pea se non c'è visto che parer è obbligatorio
                    el.Add(n)
                End If

                'If attr.DataArrivo.Year > 1 Then
                '    n = x.CreateNode(Xml.XmlNodeType.Element, "DataArrivo", "")
                '    n.InnerText = attr.DataArrivo.ToString("yyyy-MM-dd")
                '    el.Add(n)
                'End If
                If String.IsNullOrEmpty(attr.ModalitaTrasmissione) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "ModalitaTrasmissione", "")
                    n.InnerText = attr.ModalitaTrasmissione
                    el.Add(n)
                End If

                'If String.IsNullOrEmpty(attr.StrutturaProtocollante) = False Then
                '    n = x.CreateNode(Xml.XmlNodeType.Element, "StrutturaProtocollante", "")
                '    n.InnerText = attr.StrutturaProtocollante
                '    el.Add(n)
                'End If
                If String.IsNullOrEmpty(attr.DescrizioneDocumento) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "DescrizioneDocumento", "")
                    n.InnerText = attr.DescrizioneDocumento
                    el.Add(n)
                End If

                'If String.IsNullOrEmpty(attr.FirmatarioDocumento) = False Then
                '    n = x.CreateNode(Xml.XmlNodeType.Element, "FirmatarioDocumento", "")
                '    n.InnerText = attr.FirmatarioDocumento
                '    el.Add(n)
                'End If
                'If String.IsNullOrEmpty(attr.StrutturaAssegnataria) = False Then
                '    n = x.CreateNode(Xml.XmlNodeType.Element, "StrutturaAssegnataria", "")
                '    n.InnerText = attr.StrutturaAssegnataria
                '    el.Add(n)
                'End If

                'If String.IsNullOrEmpty(attr.ResponsabileIncaricato) = False Then
                '    n = x.CreateNode(Xml.XmlNodeType.Element, "ResponsabileIncaricato", "")
                '    n.InnerText = attr.ResponsabileIncaricato
                '    el.Add(n)
                'End If

                'n = x.CreateNode(Xml.XmlNodeType.Element, "Annullato", "")
                'n.InnerText = "NO"
                'el.Add(n)

                'If String.IsNullOrEmpty(attr.Note) = False Then
                '    n = x.CreateNode(Xml.XmlNodeType.Element, "Note", "")
                '    n.InnerText = attr.Note
                '    el.Add(n)
                'End If

                'If String.IsNullOrEmpty(attr.ProtocolloRiservato) = False Then
                '    n = x.CreateNode(Xml.XmlNodeType.Element, "ProtocolloRiservato", "")
                '    n.InnerText = attr.ProtocolloRiservato
                '    el.Add(n)
                'End If


                Return el.ToArray
            ElseIf Info.Tipologia = TipoOggetto.Fattura Then


                If Info.AttributiSpecifici Is Nothing OrElse Not TypeOf Info.AttributiSpecifici Is AttributiFatturaPassiva Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Annullato", "")
                    n.InnerText = "NO"
                    el.Add(n)
                    Return el.ToArray
                End If

                Dim attr As AttributiFatturaPassiva = CType(Info.AttributiSpecifici, AttributiFatturaPassiva)
                n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroProtocollo", "")
                n.InnerText = attr.NumeroProtocollo
                el.Add(n)

                n = x.CreateNode(Xml.XmlNodeType.Element, "DataProtocollo", "")
                n.InnerText = attr.DataProtocollo.ToString("yyyy-MM-dd")
                el.Add(n)

                n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroRUF", "")
                n.InnerText = attr.NumeroRUF
                el.Add(n)

                n = x.CreateNode(Xml.XmlNodeType.Element, "DataRegistrazioneRUF", "")
                n.InnerText = attr.DataRegistrazioneRUF.ToString("yyyy-MM-dd")
                el.Add(n)

                If String.IsNullOrEmpty(attr.RegistroIVADescrizione) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "CodiceRegistroIVA", "")
                    n.InnerText = attr.RegistroIVADescrizione
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.RegistroIVAProtocollo) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroRegistroIVA", "")
                    n.InnerText = attr.RegistroIVAProtocollo
                    el.Add(n)
                End If


                If String.IsNullOrEmpty(attr.RegistroIVAData) = False Then
                    Try
                        Dim dt As Date
                        Date.TryParse(attr.RegistroIVAData, dt)
                        n = x.CreateNode(Xml.XmlNodeType.Element, "DataRegistrazioneIVA", "")
                        n.InnerText = dt.ToString("yyyy-MM-dd")
                        el.Add(n)
                    Catch ex As System.Exception

                    End Try
                End If

                If String.IsNullOrEmpty(attr.IVACodiceRegistroNumeroData) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "IVACodiceRegistroNumeroData", "")
                    n.InnerText = attr.IVACodiceRegistroNumeroData
                    el.Add(n)
                End If



                n = x.CreateNode(Xml.XmlNodeType.Element, "NumeroEmissione", "")
                n.InnerText = attr.NumeroFattura
                el.Add(n)

                n = x.CreateNode(Xml.XmlNodeType.Element, "DataEmissione", "")
                n.InnerText = attr.DataDocumento.ToString("yyyy-MM-dd")
                el.Add(n)

                n = x.CreateNode(Xml.XmlNodeType.Element, "DenominazioneMittente", "")
                n.InnerText = attr.DenominazioneEmittente
                el.Add(n)

                n = x.CreateNode(Xml.XmlNodeType.Element, "IdentificativoMittente", "")
                n.InnerText = attr.PartitaIVAEmittente
                el.Add(n)

                If String.IsNullOrEmpty(attr.TipoIdentificativoMittente) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "TipoIdentificativoMittente", "")
                    n.InnerText = attr.TipoIdentificativoMittente
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.OggettoFornitura) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "OggettoFornitura", "")
                    n.InnerText = attr.OggettoFornitura
                    el.Add(n)
                End If



                n = x.CreateNode(Xml.XmlNodeType.Element, "ImportoTotale", "")
                n.InnerText = attr.ImportoTotale.ToString
                el.Add(n)

                If attr.Scadenza.Year > 1799 Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "Scadenza", "")
                    n.InnerText = attr.Scadenza.ToString("yyyy-MM-dd")
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.RiferimentoContabile) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "RiferimentoContabile", "")
                    n.InnerText = attr.RiferimentoContabile
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.TipoRifContabile) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "TipoRifContabile", "")
                    n.InnerText = attr.TipoRifContabile
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.CIG) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "CIG", "")
                    n.InnerText = attr.CIG
                    el.Add(n)
                End If

                If String.IsNullOrEmpty(attr.CUP) = False Then
                    n = x.CreateNode(Xml.XmlNodeType.Element, "CUP", "")
                    n.InnerText = attr.CUP
                    el.Add(n)
                End If




                Return el.ToArray



            ElseIf Info.Tipologia = TipoOggetto.GiornaleCassa Then
                If Info.AttributiSpecifici IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is AttributiGiornaleCassa Then
                    Dim reg = CType(Info.AttributiSpecifici, AttributiGiornaleCassa)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "Data_inizio_periodo_riferimento", "")
                    n.InnerText = reg.DataInizioPeriodo.ToString("yyyy-MM-dd")
                    el.Add(n)

                    n = x.CreateNode(Xml.XmlNodeType.Element, "Data_fine_periodo_riferimento", "")
                    n.InnerText = reg.DataFinePeriodo.ToString("yyyy-MM-dd")
                    el.Add(n)

                    If reg.PagineTotali > 0 Then
                        n = x.CreateNode(Xml.XmlNodeType.Element, "PagineTotali", "")
                        n.InnerText = reg.PagineTotali
                        el.Add(n)
                    End If





                    Return el.ToArray

                End If
                Return Nothing

            Else
                Return Nothing
            End If

        End Function


    End Class
    'Public Class Xtest
    '    Public Shared Function GetDatiSpeficifi(Info As ConservationInfo, isPEA As Boolean) As Xml.XmlElement()
    '        Return Helper.GetDatiSpeficifi(Info, isPEA)
    '    End Function

    'End Class
End Namespace

