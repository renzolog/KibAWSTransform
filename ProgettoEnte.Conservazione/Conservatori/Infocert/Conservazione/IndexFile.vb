Imports System.Xml
Imports System.Text
Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.Infocert.Conservazione
    Public Class IndexFile

        Public Shared name As String = "index.xml"
        Public Shared mimetype As String = "text/xml;1.0"

        Public Function GetHash() As String
            Return ProgettoEnte.Conservazione.Utility.Compute.GetHash(_Value)
        End Function

        Public Function GetBuffer() As Byte()
            Dim encoding As New UTF8Encoding()
            Return encoding.GetBytes(_Value)
        End Function

        Private ReadOnly _Value As String
        Private ReadOnly _CodiceUnitaDocumentaria As String

        Private Function CreateNoventa() As String

            Dim doc As New XmlDocument

            doc.CreateXmlDeclaration("1.0", "UTF-8", "no")

            Dim DocIndex As XmlNode = doc.AppendChild(doc.CreateNode(XmlNodeType.Element, "legaldocIndex", ""))

            Dim att As XmlAttribute = doc.CreateNode(XmlNodeType.Attribute, "documentClass", "")
            att.InnerText = _CodiceUnitaDocumentaria

            DocIndex.Attributes.Append(att)
            att = doc.CreateNode(XmlNodeType.Attribute, "label", "")
            If String.IsNullOrEmpty(Info.Oggetto) Then
                att.InnerText = Info.Tipologia.ToString
            Else
                att.InnerText = Info.Oggetto.PulisciWithRegEx(255)
            End If
            DocIndex.Attributes.Append(att)


            Dim fld As XmlNode = doc.CreateNode(XmlNodeType.Element, "field", "")
            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_documento_dt"
            fld.InnerText = Info.Data.Date.ToString("dd-MM-yyyy")
            DocIndex.AppendChild(fld)


            'If String.IsNullOrEmpty(Info.Oggetto) = False Then
            '    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
            '    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
            '    fld.InnerText = Info.Oggetto
            '    DocIndex.AppendChild(fld)
            'End If


            If Info.AttributiSpecifici IsNot Nothing Then

                If String.IsNullOrEmpty(Info.AttributiSpecifici.CodiceIdentificativoAmministrazione) = False Then
                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "cod_amm_s"
                    fld.InnerText = Info.AttributiSpecifici.CodiceIdentificativoAmministrazione
                    DocIndex.AppendChild(fld)
                End If

                If String.IsNullOrEmpty(Info.AttributiSpecifici.CodiceIdentificativoAOO) = False Then
                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "cod_aoo_s"
                    fld.InnerText = Info.AttributiSpecifici.CodiceIdentificativoAOO
                    DocIndex.AppendChild(fld)
                End If

                If String.IsNullOrEmpty(Info.AttributiSpecifici.IndiceDiClassificazione) = False Then
                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "id_class_s"
                    fld.InnerText = Info.AttributiSpecifici.IndiceDiClassificazione
                    DocIndex.AppendChild(fld)
                End If

                If String.IsNullOrEmpty(Info.AttributiSpecifici.IDUnivocoDocumento) = False Then
                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "id_s"
                    fld.InnerText = Info.AttributiSpecifici.IDUnivocoDocumento
                    DocIndex.AppendChild(fld)
                End If


                If TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                    Dim lProt = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiProtocollo)
                    If String.IsNullOrEmpty(lProt.DescrizioneDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "descr_doc_s"
                        fld.InnerText = lProt.DescrizioneDocumento.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lProt.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dest_s"
                        fld.InnerText = lProt.Destinatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If lProt.Fascicoli IsNot Nothing AndAlso lProt.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lProt.Fascicoli.Item(0).Anno, lProt.Fascicoli.Item(0).Numero, lProt.Fascicoli.Item(0).Titolario)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lProt.Mittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "mitt_s"
                        fld.InnerText = lProt.Mittente.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(Info.IndiceRegistro.Numero) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "protocollo_s"
                        fld.InnerText = Info.IndiceRegistro.Numero
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lProt.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lProt.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lProt.DataArrivo.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "prot_data_dt"
                        fld.InnerText = lProt.DataArrivo.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lProt.Responsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "responsabile_s"
                        fld.InnerText = lProt.Responsabile.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lProt.TipoProtocollo) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipo_s"
                        fld.InnerText = lProt.TipoProtocollo.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDocumentoGenerico Then
                    Dim lDocGen = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDocumentoGenerico)

                    If String.IsNullOrEmpty(lDocGen.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dest_s"
                        fld.InnerText = lDocGen.Destinatario.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lDocGen.Fascicoli IsNot Nothing AndAlso lDocGen.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lDocGen.Fascicoli.Item(0).Anno, lDocGen.Fascicoli.Item(0).Numero, lDocGen.Fascicoli.Item(0).Titolario)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDocGen.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lDocGen.Oggetto.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDocGen.QualificaGenerica) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "qualgen_s"
                        fld.InnerText = lDocGen.QualificaGenerica.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDocGen.Responsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "responsabile_s"
                        fld.InnerText = lDocGen.Responsabile.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDocGen.UO) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "proponente_s"
                        fld.InnerText = lDocGen.UO.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDetermina Then
                    Dim lDet = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDetermina)

                    If String.IsNullOrEmpty(lDet.Dirigente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dirigente_s"
                        fld.InnerText = lDet.Dirigente.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If lDet.Fascicoli IsNot Nothing AndAlso lDet.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lDet.Fascicoli.Item(0).Anno, lDet.Fascicoli.Item(0).Numero, lDet.Fascicoli.Item(0).Titolario)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.NumeroRegistroParticolare) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nr_reg_s"
                        fld.InnerText = lDet.NumeroRegistroParticolare
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.NumeroDiRepertorio) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "repertorio_s"
                        fld.InnerText = lDet.NumeroDiRepertorio
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lDet.Oggetto.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.TipoAtto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipo_atto_s"
                        fld.InnerText = lDet.TipoAtto.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.UO) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "proponente_s"
                        fld.InnerText = lDet.UO.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiAffissione Then
                    Dim Aff = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiAffissione)

                    If Aff.DataFine.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datafine_dt"
                        fld.InnerText = Aff.DataFine.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If
                    If Aff.DataInizio.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datainizo_dt"
                        fld.InnerText = Aff.DataInizio.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dest_s"
                        fld.InnerText = Aff.Destinatario.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If Aff.Fascicoli IsNot Nothing AndAlso Aff.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", Aff.Fascicoli.Item(0).Anno, Aff.Fascicoli.Item(0).Numero, Aff.Fascicoli.Item(0).Titolario)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.Intestatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "intestatario_s"
                        fld.InnerText = Aff.Intestatario.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.Note) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "note_s"
                        fld.InnerText = Aff.Note.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.NumeroRegistroParticolare) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nr_reg_s"
                        fld.InnerText = Aff.NumeroRegistroParticolare.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(Aff.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = Aff.Oggetto.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.Responsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "responsabile_s"
                        fld.InnerText = Aff.Responsabile.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.TipoDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipodocumento_s"
                        fld.InnerText = Aff.TipoDocumento.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera Then
                    Dim lDel = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDelibera)
                    If lDel.Fascicoli IsNot Nothing AndAlso lDel.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lDel.Fascicoli.Item(0).Anno, lDel.Fascicoli.Item(0).Numero, lDel.Fascicoli.Item(0).Titolario)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDel.NumeroDiRepertorio) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "repertorio_s"
                        fld.InnerText = lDel.NumeroDiRepertorio.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(lDel.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lDel.Oggetto.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(lDel.OrganoDeliberante) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "organo_delib_s"
                        fld.InnerText = lDel.OrganoDeliberante.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(lDel.ResponsabileProcedimento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "resp_proced_s"
                        fld.InnerText = lDel.ResponsabileProcedimento.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(lDel.TipoAtto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipo_atto_s"
                        fld.InnerText = lDel.TipoAtto.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDel.UO) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "proponente_s"
                        fld.InnerText = lDel.UO.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiContratto Then
                    Dim lContr = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiContratto)

                    If String.IsNullOrEmpty(lContr.Contraente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "contraente_s"
                        fld.InnerText = lContr.Contraente.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lContr.DataStipula.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_stipula_dt"
                        fld.InnerText = lContr.DataStipula.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If lContr.Fascicoli IsNot Nothing AndAlso lContr.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lContr.Fascicoli.Item(0).Anno, lContr.Fascicoli.Item(0).Numero, lContr.Fascicoli.Item(0).Titolario)
                        DocIndex.AppendChild(fld)
                    End If

                    If lContr.ImportoRegistrazione > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "importo_d"
                        fld.InnerText = lContr.ImportoRegistrazione.ToString.Replace(".", "").Replace(",", ".")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lContr.NumeroDiRepertorio) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "repertorio_s"
                        fld.InnerText = lContr.NumeroDiRepertorio.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lContr.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lContr.Oggetto.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lContr.DataRegistrazione.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_registrazione_dt"
                        fld.InnerText = lContr.DataRegistrazione.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lContr.NumeroRegistrazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "numero_s"
                        fld.InnerText = lContr.NumeroRegistrazione.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lContr.SerieRegistrazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "serie_s"
                        fld.InnerText = lContr.SerieRegistrazione.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiRegistroProtocollo Then
                    Dim lreg = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiRegistroProtocollo)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "registro_s"
                    fld.InnerText = "Registro Protocollo"
                    DocIndex.AppendChild(fld)

                    If String.IsNullOrEmpty(lreg.Oggetto) = False OrElse String.IsNullOrEmpty(Info.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = IIf(String.IsNullOrEmpty(lreg.Oggetto) = False, lreg.Oggetto.Pulisci(255), Info.Oggetto.Pulisci(255))
                        DocIndex.AppendChild(fld)
                    End If

                    If lreg.Anno > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "anno_i"
                        fld.InnerText = lreg.Anno
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceFiscaleDestinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale__destinatario_s"
                        fld.InnerText = lreg.CodiceFiscaleDestinatario.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceFiscaleResponsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale__responsabile_s"
                        fld.InnerText = lreg.CodiceFiscaleResponsabile.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceFiscaleSoggettoproduttore) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale__soggetto_prod_s"
                        fld.InnerText = lreg.CodiceFiscaleSoggettoproduttore.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceFiscaleSoggettoProduttore2) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale__soggetto_prod_2_s"
                        fld.InnerText = lreg.CodiceFiscaleSoggettoProduttore2.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lreg.DataPrimaRegistrazione.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_prima_reg_dt"
                        fld.InnerText = lreg.DataPrimaRegistrazione.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If lreg.DataUltimaRegistrazione.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_ultima_reg_dt"
                        fld.InnerText = lreg.DataUltimaRegistrazione.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.DenominazioneAmministrazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "denominazione_amm_s"
                        fld.InnerText = lreg.DenominazioneAmministrazione.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "destinatario_s"
                        fld.InnerText = lreg.Destinatario.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceIdentificativoRegistro) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "id_registro_s"
                        fld.InnerText = lreg.CodiceIdentificativoRegistro.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.Note) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "note_s"
                        fld.InnerText = lreg.Note.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.NumeroProgressivoDelRegistro) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "progr_registro_i"
                        fld.InnerText = lreg.NumeroProgressivoDelRegistro
                        DocIndex.AppendChild(fld)
                    End If

                    If lreg.NumeroUltimaRegistrazione > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "prot_fine_i"
                        fld.InnerText = lreg.NumeroUltimaRegistrazione
                        DocIndex.AppendChild(fld)
                    End If

                    If lreg.NumeroPrimaRegistrazione > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "prot_inizio_i"
                        fld.InnerText = lreg.NumeroPrimaRegistrazione
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.Responsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "responsabile_s"
                        fld.InnerText = lreg.Responsabile.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.SoggettoProduttore2) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "soggetto_prod_2_s"
                        fld.InnerText = lreg.SoggettoProduttore2.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.SoggettoProduttore) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "soggetto_prod_s"
                        fld.InnerText = lreg.SoggettoProduttore.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFascicoloElettorale Then
                    Dim lFele = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiFascicoloElettorale)

                    If lFele.DataDocumento.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_documento_dt"
                        fld.InnerText = lFele.DataDocumento.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFele.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dest_s"
                        fld.InnerText = lFele.Destinatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFele.CognomeNome) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "el_cne_s"
                        fld.InnerText = lFele.CognomeNome.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lFele.DataCancellazione.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "el_dce_dt"
                        fld.InnerText = lFele.DataCancellazione.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If lFele.DataNascita.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "el_dne_dt"
                        fld.InnerText = lFele.DataNascita.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lFele.IDUnivocoDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "id_s"
                        fld.InnerText = lFele.IDUnivocoDocumento.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lFele.Mittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "mitt_s"
                        fld.InnerText = lFele.Mittente.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFele.NumeroProtocollo) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "num_prot_s"
                        fld.InnerText = lFele.NumeroProtocollo.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFele.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lFele.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If lFele.DataProtocollo.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "prot_data_dt"
                        fld.InnerText = lFele.DataProtocollo.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If


                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaPassiva Then
                    Dim lFat = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiFatturaPassiva)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__anno_fiscale_i"
                    fld.InnerText = lFat.DataDocumento.Year
                    DocIndex.AppendChild(fld)

                    If lFat.DataDocumento.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_documento_dt"
                        fld.InnerText = lFat.DataDocumento.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CIG) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_cig_s"
                        fld.InnerText = lFat.CIG.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CUP) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_cup_s"
                        fld.InnerText = lFat.CUP.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceFiscaleEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale_emittente_s"
                        fld.InnerText = lFat.CodiceFiscaleEmittente.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceFiscale) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale_s"
                        fld.InnerText = lFat.CodiceFiscale.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceUfficioIPA) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_pa_s"
                        fld.InnerText = lFat.CodiceUfficioIPA.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If lFat.DataProtocollo.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_protocollo_dt"
                        fld.InnerText = lFat.DataProtocollo.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.DenominazioneEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "denominazione_emittente_s"
                        fld.InnerText = lFat.DenominazioneEmittente.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.Denominazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "denominazione_s"
                        fld.InnerText = lFat.Denominazione.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.IDSDI) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "identificativoSdi_s"
                        fld.InnerText = lFat.IDSDI
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.NomeFileSOGEI) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nome_file_sogei_s"
                        fld.InnerText = lFat.NomeFileSOGEI.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lFat.NumeroFattura) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "numero_documento_s"
                        fld.InnerText = lFat.NumeroFattura.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lFat.NumeroProtocollo > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "numero_protocollo_s"
                        fld.InnerText = lFat.NumeroProtocollo
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.PartitaIVAEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "partita_iva_emittente_s"
                        fld.InnerText = lFat.PartitaIVAEmittente.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If



                    If String.IsNullOrEmpty(lFat.PartitaIVA) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "partita_iva_s"
                        fld.InnerText = lFat.PartitaIVA.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.StatoDellaFattura) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "stato_fattura_s"
                        fld.InnerText = lFat.StatoDellaFattura.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.IDUnivocoDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "token_flusso_s"
                        fld.InnerText = lFat.IDUnivocoDocumento.Pulisci(255)
                        DocIndex.AppendChild(fld)
                    End If


                End If


            End If




            Return doc.InnerXml

        End Function


        Private Function Create(TipoFile As String) As String

            Dim doc As New XmlDocument

            doc.CreateXmlDeclaration("1.0", "UTF-8", "no")

            Dim DocIndex As XmlNode = doc.AppendChild(doc.CreateNode(XmlNodeType.Element, "legaldocIndex", ""))

            Dim att As XmlAttribute = doc.CreateNode(XmlNodeType.Attribute, "documentClass", "")
            att.InnerText = _CodiceUnitaDocumentaria

            DocIndex.Attributes.Append(att)
            att = doc.CreateNode(XmlNodeType.Attribute, "label", "")
            If String.IsNullOrEmpty(Info.Oggetto) Then
                att.InnerText = Info.Tipologia.ToString
            Else
                att.InnerText = Info.Oggetto.PulisciWithRegEx(255)
            End If
            DocIndex.Attributes.Append(att)


            Dim fld As XmlNode = doc.CreateNode(XmlNodeType.Element, "field", "")
            If Info.AttributiSpecifici Is Nothing OrElse
                (TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaPassiva Or
                 TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaAttiva Or
                  TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFascicoli) = False Then
                fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_documento_dt"
                fld.InnerText = Info.Data.Date.ToString("dd-MM-yyyy")
                DocIndex.AppendChild(fld)
            End If


            If String.IsNullOrEmpty(TipoFile) = False Then
                fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipo_file_s"
                fld.InnerText = TipoFile
                DocIndex.AppendChild(fld)
            End If


            If Info.AttributiSpecifici IsNot Nothing Then
                Try
                    If String.IsNullOrEmpty(Info.AttributiSpecifici.IdentificativoSistemaGestionale) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "iddocid_s"
                        fld.InnerText = Info.AttributiSpecifici.IdentificativoSistemaGestionale
                        DocIndex.AppendChild(fld)
                    End If

                    If Info.Files IsNot Nothing AndAlso Info.Files.Count > 0 Then
                        If String.IsNullOrEmpty(Info.Files(0).Hash) = False Then
                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "iddocimp_s"
                            fld.InnerText = Info.Files(0).Hash
                            DocIndex.AppendChild(fld)

                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "iddocalg_s"
                            fld.InnerText = "SHA-256"
                            DocIndex.AppendChild(fld)
                        End If
                    End If


                    If TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                        Dim lProt = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiProtocollo)
                        Dim Testo As String = ""
                        If lProt.DataArrivo.Year > 1 AndAlso String.IsNullOrEmpty(Info.IndiceRegistro.Numero) = False Then
                            Testo = $"Protocollo {Info.IndiceRegistro.Numero} del {lProt.DataArrivo.Date.ToString("dd-MM-yyyy")}"
                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "segnatura_s"
                            fld.InnerText = Testo
                            DocIndex.AppendChild(fld)
                        End If
                    End If


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "modform_s"
                    If Info.AttributiSpecifici.ModalitaFormazione = TipoModalitaFormazione.AcquisizioneTelematica Then
                        fld.InnerText = "b"
                    ElseIf Info.AttributiSpecifici.ModalitaFormazione = TipoModalitaFormazione.Creazione Then
                        fld.InnerText = "a"
                    ElseIf Info.AttributiSpecifici.ModalitaFormazione = TipoModalitaFormazione.ProcessiInformatici Then
                        fld.InnerText = "c"
                    ElseIf Info.AttributiSpecifici.ModalitaFormazione = TipoModalitaFormazione.RegistrazioneBancaDati Then
                        fld.InnerText = "d"
                    Else
                        fld.InnerText = "b"
                    End If
                    DocIndex.AppendChild(fld)


                    If String.IsNullOrEmpty(Info.AttributiSpecifici.CodiceIdentificativoAmministrazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "cod_amm_s"
                        fld.InnerText = Info.AttributiSpecifici.CodiceIdentificativoAmministrazione
                        DocIndex.AppendChild(fld)
                    End If

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipdoc_s"
                    fld.InnerText = Info.Tipologia.ToString
                    DocIndex.AppendChild(fld)


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datregflusso_s"
                    If Info.Tipologia = TipoOggetto.Protocollo AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                        Dim lProt = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiProtocollo)
                        If lProt.TipoProtocollo.ToLower = "entrata" Or lProt.TipoProtocollo.ToLower = "e" Then
                            fld.InnerText = "E"
                        ElseIf lProt.TipoProtocollo.ToLower = "uscita" Or lProt.TipoProtocollo.ToLower = "u" Then
                            fld.InnerText = "U"
                        Else
                            fld.InnerText = "I"
                        End If
                    ElseIf Info.Tipologia = TipoOggetto.Fattura Then
                        fld.InnerText = "E"
                    ElseIf Info.Tipologia = TipoOggetto.FatturaAttiva Then
                        fld.InnerText = "U"
                    ElseIf Info.Tipologia = TipoOggetto.Affissione Then
                        fld.InnerText = "U"
                    ElseIf Info.Tipologia = TipoOggetto.Generico Then
                        fld.InnerText = "U"
                    ElseIf Info.Tipologia = TipoOggetto.GiornaleCassa Then
                        fld.InnerText = "E"
                    ElseIf Info.Tipologia = TipoOggetto.OPI Then
                        fld.InnerText = "U"
                    Else
                        fld.InnerText = "I"
                    End If
                    DocIndex.AppendChild(fld)


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datregtipreg_s"
                    If Info.Tipologia = TipoOggetto.Protocollo Then
                        fld.InnerText = "Protocollo Ordinario/Protocollo Emergenza"
                    Else
                        fld.InnerText = "Repertorio/Registro"
                    End If
                    DocIndex.AppendChild(fld)


                    If TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                        Dim lProt = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiProtocollo)
                        Dim Testo As String = ""
                        If lProt.DataArrivo.Year > 1 AndAlso String.IsNullOrEmpty(Info.IndiceRegistro.Numero) = False Then
                            Testo = $"Protocollo {Info.IndiceRegistro.Numero} del {lProt.DataArrivo.Date.ToString("dd-MM-yyyy")}"
                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "segnatura_s"
                            fld.InnerText = Testo
                            DocIndex.AppendChild(fld)
                        End If
                    End If


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datregdata_dt"
                    fld.InnerText = Info.Data.Date.ToString("dd-MM-yyyy")
                    If TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                        Dim lProt = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiProtocollo)
                        If lProt.DataArrivo.Year > 1 Then
                            fld.InnerText = lProt.DataArrivo.Date.ToString("dd-MM-yyyy")
                        End If
                    End If
                    DocIndex.AppendChild(fld)


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datregnum_s"
                    fld.InnerText = Info.IndiceRegistro.Numero
                    DocIndex.AppendChild(fld)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datregid_s"
                    If String.IsNullOrEmpty(Info.IndiceRegistro.IdRegistro) Then
                        fld.InnerText = "1"
                    Else
                        fld.InnerText = Info.IndiceRegistro.IdRegistro
                    End If
                    DocIndex.AppendChild(fld)


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "ogg_s"
                    If String.IsNullOrEmpty(Info.Oggetto) Then
                        fld.InnerText = Info.Tipologia.ToString
                    Else
                        fld.InnerText = Info.Oggetto.PulisciWithRegEx(255)
                    End If
                    DocIndex.AppendChild(fld)

                    If Info.Files IsNot Nothing AndAlso Info.Files.Count > 0 Then
                        If Info.Files(0).ProgressivoAllegato > 0 AndAlso Info.Files(0).IdFile > 0 Then
                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "alleg_i"
                            fld.InnerText = Info.Files(0).ProgressivoAllegato
                            DocIndex.AppendChild(fld)

                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "allegiddoc_s"
                            fld.InnerText = Info.Files(0).IdFile
                            DocIndex.AppendChild(fld)
                        End If

                        If String.IsNullOrEmpty(Info.Files(0).Descrizione) = False Then
                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "allegdesc_s"
                            fld.InnerText = Info.Files(0).Descrizione
                            DocIndex.AppendChild(fld)
                        End If
                    End If

                    If String.IsNullOrEmpty(Info.AttributiSpecifici.IndiceDiClassificazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "indclass_s"
                        fld.InnerText = Info.AttributiSpecifici.IndiceDiClassificazione
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Info.AttributiSpecifici.DescrizioneDiClassificazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "descrclass_s"
                        fld.InnerText = Info.AttributiSpecifici.DescrizioneDiClassificazione.PulisciNew
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Info.AttributiSpecifici.URLPianoDiClassificazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "pianoclass_s"
                        fld.InnerText = Info.AttributiSpecifici.URLPianoDiClassificazione
                        DocIndex.AppendChild(fld)
                    End If


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "riservato_b"
                    If TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                        Dim lProt = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiProtocollo)
                        If lProt.ProtocolloRiservato = "Si" Then
                            fld.InnerText = "true"
                        Else
                            fld.InnerText = "false"
                        End If
                    Else
                        fld.InnerText = "false"
                    End If
                    DocIndex.AppendChild(fld)


                    If Info.Files IsNot Nothing AndAlso Info.Files.Count > 0 Then
                        If String.IsNullOrEmpty(Info.Files(0).Descrizione) = False Then
                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "formid_s"
                            fld.InnerText = Info.Files(0).Mime.ToString
                            DocIndex.AppendChild(fld)
                        End If

                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "formid_s"
                        fld.InnerText = Info.Files(0).Mime.ToString
                        DocIndex.AppendChild(fld)

                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nomefile_s"
                        fld.InnerText = Info.Files(0).NomeFile.Pulisci
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Info.AttributiSpecifici.IDUnivocoDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "idagg_s"
                        fld.InnerText = Info.AttributiSpecifici.IDUnivocoDocumento
                        DocIndex.AppendChild(fld)
                    End If

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "vers_i"
                    fld.InnerText = "1"
                    DocIndex.AppendChild(fld)

                Catch ex As System.Exception
                    Try
                        IO.File.WriteAllText("c:\temp\newvers.txt", ex.Message & " - " & ex.StackTrace)
                    Catch exs As System.Exception

                    End Try
                End Try

                If String.IsNullOrEmpty(Info.AttributiSpecifici.CodiceIdentificativoAOO) = False Then
                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "cod_aoo_s"
                    fld.InnerText = Info.AttributiSpecifici.CodiceIdentificativoAOO
                    DocIndex.AppendChild(fld)
                End If

                If String.IsNullOrEmpty(Info.AttributiSpecifici.IndiceDiClassificazione) = False Then
                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "id_class_s"
                    fld.InnerText = Info.AttributiSpecifici.IndiceDiClassificazione
                    DocIndex.AppendChild(fld)
                End If

                If String.IsNullOrEmpty(Info.AttributiSpecifici.IDUnivocoDocumento) = False Then
                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "id_s"
                    fld.InnerText = Info.AttributiSpecifici.IDUnivocoDocumento
                    DocIndex.AppendChild(fld)
                End If


                If TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                    Dim lProt = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiProtocollo)
                    If String.IsNullOrEmpty(lProt.DescrizioneDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "descr_doc_s"
                        fld.InnerText = lProt.DescrizioneDocumento.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lProt.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dest_s"
                        fld.InnerText = lProt.Destinatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If lProt.Fascicoli IsNot Nothing AndAlso lProt.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lProt.Fascicoli.Item(0).Anno, lProt.Fascicoli.Item(0).Numero, lProt.Fascicoli.Item(0).Titolario.Pulisci)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lProt.Mittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "mitt_s"
                        fld.InnerText = lProt.Mittente.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(Info.IndiceRegistro.Numero) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "num_prot_s"
                        fld.InnerText = Info.IndiceRegistro.Numero.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If



                    If String.IsNullOrEmpty(lProt.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lProt.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lProt.DataArrivo.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "prot_data_dt"
                        fld.InnerText = lProt.DataArrivo.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lProt.Responsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "responsabile_s"
                        fld.InnerText = lProt.Responsabile.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lProt.TipoProtocollo) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipo_prot_s"
                        fld.InnerText = lProt.TipoProtocollo.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFascicoloElettorale Then
                    Dim lFele = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiFascicoloElettorale)

                    If lFele.DataDocumento.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_documento_dt"
                        fld.InnerText = lFele.DataDocumento.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFele.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dest_s"
                        fld.InnerText = lFele.Destinatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFele.CognomeNome) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "el_cne_s"
                        fld.InnerText = lFele.CognomeNome.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lFele.DataCancellazione.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "el_dce_dt"
                        fld.InnerText = lFele.DataCancellazione.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If lFele.DataNascita.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "el_dne_dt"
                        fld.InnerText = lFele.DataNascita.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lFele.IDUnivocoDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "id_s"
                        fld.InnerText = lFele.IDUnivocoDocumento.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lFele.Mittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "mitt_s"
                        fld.InnerText = lFele.Mittente.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFele.NumeroProtocollo) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "num_prot_s"
                        fld.InnerText = lFele.NumeroProtocollo.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFele.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lFele.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If lFele.DataProtocollo.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "prot_data_dt"
                        fld.InnerText = lFele.DataProtocollo.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If



                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDocumentoGenerico Then
                    Dim lDocGen = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDocumentoGenerico)

                    If String.IsNullOrEmpty(lDocGen.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dest_s"
                        fld.InnerText = lDocGen.Destinatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lDocGen.Fascicoli IsNot Nothing AndAlso lDocGen.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lDocGen.Fascicoli.Item(0).Anno, lDocGen.Fascicoli.Item(0).Numero, lDocGen.Fascicoli.Item(0).Titolario.Pulisci)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDocGen.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lDocGen.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDocGen.QualificaGenerica) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "qualgen_s"
                        fld.InnerText = lDocGen.QualificaGenerica.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDocGen.Responsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "responsabile_s"
                        fld.InnerText = lDocGen.Responsabile.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDocGen.UO) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "uo_s"
                        fld.InnerText = lDocGen.UO.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDetermina Then
                    Dim lDet = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDetermina)

                    If String.IsNullOrEmpty(lDet.Dirigente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dirigente_s"
                        fld.InnerText = lDet.Dirigente.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If lDet.Fascicoli IsNot Nothing AndAlso lDet.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lDet.Fascicoli.Item(0).Anno, lDet.Fascicoli.Item(0).Numero, lDet.Fascicoli.Item(0).Titolario.Pulisci)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.NumeroRegistroParticolare) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nr_reg_s"
                        fld.InnerText = lDet.NumeroRegistroParticolare
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.NumeroDiRepertorio) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "num_repertorio_s"
                        fld.InnerText = lDet.NumeroDiRepertorio
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lDet.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.TipoAtto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipo_atto_s"
                        fld.InnerText = lDet.TipoAtto
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDet.UO) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "uo_s"
                        fld.InnerText = lDet.UO.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiAffissione Then
                    Dim Aff = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiAffissione)

                    If Aff.DataFine.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datafine_dt"
                        fld.InnerText = Aff.DataFine.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If
                    If Aff.DataInizio.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "datainizo_dt"
                        fld.InnerText = Aff.DataInizio.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "dest_s"
                        fld.InnerText = Aff.Destinatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If Aff.Fascicoli IsNot Nothing AndAlso Aff.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", Aff.Fascicoli.Item(0).Anno, Aff.Fascicoli.Item(0).Numero, Aff.Fascicoli.Item(0).Titolario.Pulisci)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.Intestatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "intestatario_s"
                        fld.InnerText = Aff.Intestatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.Note) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "note_s"
                        fld.InnerText = Aff.Note.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.NumeroRegistroParticolare) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nr_reg_s"
                        fld.InnerText = Aff.NumeroRegistroParticolare
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(Aff.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = Aff.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.Responsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "responsabile_s"
                        fld.InnerText = Aff.Responsabile.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(Aff.TipoDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipodocumento_s"
                        fld.InnerText = Aff.TipoDocumento
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera Then
                    Dim lDel = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDelibera)
                    If lDel.Fascicoli IsNot Nothing AndAlso lDel.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lDel.Fascicoli.Item(0).Anno, lDel.Fascicoli.Item(0).Numero, lDel.Fascicoli.Item(0).Titolario.Pulisci)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDel.NumeroDiRepertorio) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "num_repertorio_s"
                        fld.InnerText = lDel.NumeroDiRepertorio
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(lDel.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lDel.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(lDel.OrganoDeliberante) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "organo_delib_s"
                        fld.InnerText = lDel.OrganoDeliberante.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(lDel.ResponsabileProcedimento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "resp_proced_s"
                        fld.InnerText = lDel.ResponsabileProcedimento.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(lDel.TipoAtto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipo_atto_s"
                        fld.InnerText = lDel.TipoAtto
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lDel.UO) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "uo_s"
                        fld.InnerText = lDel.UO.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiContratto Then
                    Dim lContr = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiContratto)

                    If String.IsNullOrEmpty(lContr.Contraente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "contraente_s"
                        fld.InnerText = lContr.Contraente.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lContr.DataStipula.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_stipula_dt"
                        fld.InnerText = lContr.DataStipula.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If lContr.Fascicoli IsNot Nothing AndAlso lContr.Fascicoli.Count > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "fasc_s"
                        fld.InnerText = String.Format("{0}/{1} {2}", lContr.Fascicoli.Item(0).Anno, lContr.Fascicoli.Item(0).Numero, lContr.Fascicoli.Item(0).Titolario.Pulisci)
                        DocIndex.AppendChild(fld)
                    End If

                    If lContr.ImportoRegistrazione > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "importo_registrazione_d"
                        fld.InnerText = lContr.ImportoRegistrazione.ToString.Replace(".", "").Replace(",", ".")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lContr.NumeroDiRepertorio) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "num_repertorio_s"
                        fld.InnerText = lContr.NumeroDiRepertorio
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lContr.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = lContr.Oggetto.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If lContr.DataRegistrazione.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "reg_data_dt"
                        fld.InnerText = lContr.DataRegistrazione.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lContr.NumeroRegistrazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "reg_num_s"
                        fld.InnerText = lContr.NumeroRegistrazione
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lContr.SerieRegistrazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "reg_serie_s"
                        fld.InnerText = lContr.SerieRegistrazione
                        DocIndex.AppendChild(fld)
                    End If
                    'ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiOrdinativiSIOPE Then
                    '    Dim ord = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiOrdinativiSIOPE)
                    '    If ord.Anno > 0 Then
                    '        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    '        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "anno_i"
                    '        fld.InnerText = ord.Anno
                    '        DocIndex.AppendChild(fld)
                    '    End If
                    'ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiGiornaleCassa Then
                    '    Dim gc = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiGiornaleCassa)
                    '    If gc.Anno > 0 Then
                    '        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    '        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "anno_i"
                    '        fld.InnerText = gc.Anno
                    '        DocIndex.AppendChild(fld)
                    '    End If
                    '    If gc.DataInizioPeriodo.Year > 1799 Then
                    '        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    '        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_inizio_rif_dt"
                    '        fld.InnerText = gc.DataInizioPeriodo.Date.ToString("dd-MM-yyyy")
                    '        DocIndex.AppendChild(fld)
                    '    End If
                    '    If gc.DataFinePeriodo.Year > 1799 Then
                    '        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    '        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_fine_rif_dt"
                    '        fld.InnerText = gc.DataFinePeriodo.Date.ToString("dd-MM-yyyy")
                    '        DocIndex.AppendChild(fld)
                    '    End If

                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiRegistroProtocollo Then
                    Dim lreg = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiRegistroProtocollo)


                    If String.IsNullOrEmpty(lreg.Oggetto) = False OrElse String.IsNullOrEmpty(Info.Oggetto) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_s"
                        fld.InnerText = IIf(String.IsNullOrEmpty(lreg.Oggetto) = False, lreg.Oggetto, Info.Oggetto)
                        DocIndex.AppendChild(fld)
                    End If

                    If lreg.Anno > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "anno_i"
                        fld.InnerText = lreg.Anno
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceFiscaleDestinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale__destinatario_s"
                        fld.InnerText = lreg.CodiceFiscaleDestinatario
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceFiscaleResponsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale__responsabile_s"
                        fld.InnerText = lreg.CodiceFiscaleResponsabile
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceFiscaleSoggettoproduttore) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale__soggetto_prod_s"
                        fld.InnerText = lreg.CodiceFiscaleSoggettoproduttore
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceFiscaleSoggettoProduttore2) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale__soggetto_prod_2_s"
                        fld.InnerText = lreg.CodiceFiscaleSoggettoProduttore2
                        DocIndex.AppendChild(fld)
                    End If

                    If lreg.DataPrimaRegistrazione.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_prima_reg_dt"
                        fld.InnerText = lreg.DataPrimaRegistrazione.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If lreg.DataUltimaRegistrazione.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_ultima_reg_dt"
                        fld.InnerText = lreg.DataUltimaRegistrazione.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.DenominazioneAmministrazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "denominazione_amm_s"
                        fld.InnerText = lreg.DenominazioneAmministrazione.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.Destinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "destinatario_s"
                        fld.InnerText = lreg.Destinatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.CodiceIdentificativoRegistro) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "id_registro_s"
                        fld.InnerText = lreg.CodiceIdentificativoRegistro.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.Note) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "note_s"
                        fld.InnerText = lreg.Note.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.NumeroProgressivoDelRegistro) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "progr_registro_i"
                        fld.InnerText = lreg.NumeroProgressivoDelRegistro
                        DocIndex.AppendChild(fld)
                    End If


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "prot_fine_i"
                    fld.InnerText = lreg.NumeroUltimaRegistrazione
                    DocIndex.AppendChild(fld)



                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "prot_inizio_i"
                    fld.InnerText = lreg.NumeroPrimaRegistrazione
                    DocIndex.AppendChild(fld)


                    If String.IsNullOrEmpty(lreg.Responsabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "responsabile_s"
                        fld.InnerText = lreg.Responsabile.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.SoggettoProduttore2) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "soggetto_prod_2_s"
                        fld.InnerText = lreg.SoggettoProduttore2.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lreg.SoggettoProduttore) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "soggetto_prod_s"
                        fld.InnerText = lreg.SoggettoProduttore.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaPassiva Then
                    Dim lFat = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiFatturaPassiva)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__anno_fiscale_i"
                    If lFat.DataRegistrazioneRUF.Year > 1 Then
                        fld.InnerText = lFat.DataRegistrazioneRUF.Year
                    Else
                        fld.InnerText = lFat.DataDocumento.Year
                    End If
                    DocIndex.AppendChild(fld)

                    If lFat.DataRegistrazioneRUF.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "Data_Registrazione_RUF_dt" ' OK
                        fld.InnerText = lFat.DataRegistrazioneRUF.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.NumeroRUF) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "Numero_RUF_s" ' OK
                        fld.InnerText = lFat.NumeroRUF
                        DocIndex.AppendChild(fld)
                    End If

                    If lFat.DataDocumento.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_documento_dt" ' OK
                        fld.InnerText = lFat.DataDocumento.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CIG) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_cig_s" ' OK
                        fld.InnerText = lFat.CIG.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CUP) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_cup_s" ' OK
                        fld.InnerText = lFat.CUP.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceFiscaleEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale_emittente_s" ' OK
                        fld.InnerText = lFat.CodiceFiscaleEmittente
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceFiscale) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale_s"
                        fld.InnerText = lFat.CodiceFiscale
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceUfficioIPA) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_pa_s" ' OK
                        fld.InnerText = lFat.CodiceUfficioIPA
                        DocIndex.AppendChild(fld)
                    End If


                    If lFat.DataProtocollo.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_protocollo_dt" ' OK
                        fld.InnerText = lFat.DataProtocollo.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.DenominazioneEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "denominazione_emittente_s" ' OK
                        fld.InnerText = lFat.DenominazioneEmittente.PulisciWithRegEx(255) '.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.Denominazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "denominazione_s"
                        fld.InnerText = lFat.Denominazione.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.IDSDI) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "identificativoSdi_s" ' OK
                        fld.InnerText = lFat.IDSDI
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.NomeFileSOGEI) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nome_file_sogei_s"
                        fld.InnerText = lFat.NomeFileSOGEI.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lFat.NumeroFattura) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "numero_documento_s" ' OK
                        fld.InnerText = lFat.NumeroFattura
                        DocIndex.AppendChild(fld)
                    End If

                    If lFat.NumeroProtocollo > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "numero_protocollo_s" ' OK
                        fld.InnerText = lFat.NumeroProtocollo
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.PartitaIVAEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "partita_iva_emittente_s" ' OK
                        fld.InnerText = lFat.PartitaIVAEmittente
                        DocIndex.AppendChild(fld)
                    End If



                    If String.IsNullOrEmpty(lFat.PartitaIVA) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "partita_iva_s"
                        fld.InnerText = lFat.PartitaIVA
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.StatoDellaFattura) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "stato_fattura_s" ' OK
                        fld.InnerText = lFat.StatoDellaFattura
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.IDUnivocoDocumento) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "token_flusso_s"
                        fld.InnerText = lFat.IDUnivocoDocumento
                        DocIndex.AppendChild(fld)
                    End If


                    If lFat.ImportoTotale > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "importo_totale_d" ' OK
                        fld.InnerText = lFat.ImportoTotale.ToString.Replace(".", "").Replace(",", ".")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.TipoRifContabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipo_rif_contabile_s" ' OK
                        fld.InnerText = lFat.TipoRifContabile
                        DocIndex.AppendChild(fld)
                    End If

                    If lFat.Scadenza.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_scadenza_dt" ' OK
                        fld.InnerText = lFat.Scadenza.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.RiferimentoContabile) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "riferimento_contabile_s" ' OK
                        fld.InnerText = lFat.RiferimentoContabile
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.RegistroIVADescrizione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "registro_iva_descrizione_s"
                        fld.InnerText = lFat.RegistroIVADescrizione
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.RegistroIVAProtocollo) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "registro_iva_protocollo_s"
                        fld.InnerText = lFat.RegistroIVAProtocollo
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.OggettoFornitura) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "oggetto_fornitura_s"
                        fld.InnerText = lFat.OggettoFornitura.Pulisci
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaAttiva Then
                    Dim lFat = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiFatturaAttiva)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__anno_fiscale_i"
                    fld.InnerText = lFat.DataDocumento.Year
                    DocIndex.AppendChild(fld)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_inizio_numerazione_dt" ' OK
                    fld.InnerText = New Date(lFat.DataDocumento.Year, 1, 1).ToString("dd-MM-yyyy")
                    DocIndex.AppendChild(fld)

                    If String.IsNullOrEmpty(lFat.RegistroIVADescrizione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__serie_s" ' OK
                        fld.InnerText = lFat.RegistroIVADescrizione
                        DocIndex.AppendChild(fld)
                    End If

                    If lFat.DataDocumento.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_documento_dt" ' OK
                        fld.InnerText = lFat.DataDocumento.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CIG) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_cig_s" ' OK
                        fld.InnerText = lFat.CIG.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CUP) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_cup_s" ' OK
                        fld.InnerText = lFat.CUP.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceFiscaleEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale_emittente_s" ' OK
                        fld.InnerText = lFat.CodiceFiscaleEmittente
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceFiscale) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_fiscale_s"
                        fld.InnerText = lFat.CodiceFiscale
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.CodiceUfficioIPA) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "codice_pa_s" ' OK
                        fld.InnerText = lFat.CodiceUfficioIPA
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.DenominazioneEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "denominazione_emittente_s" ' OK
                        fld.InnerText = lFat.DenominazioneEmittente.PulisciWithRegEx(255) '.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.Denominazione) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "denominazione_s"
                        fld.InnerText = lFat.Denominazione.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.IndirizzoEmailDestinatario) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "email_destinatario_em"
                        fld.InnerText = lFat.IndirizzoEmailDestinatario.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.IDSDI) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "identificativoSdi_s" ' OK
                        fld.InnerText = lFat.IDSDI
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.Localita) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "localita_s" ' OK
                        fld.InnerText = lFat.Localita.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.NomeFileSOGEI) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nome_file_sogei_s"
                        fld.InnerText = lFat.NomeFileSOGEI.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.Note) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "note_s"
                        fld.InnerText = lFat.Note.PulisciWithRegEx(255)
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lFat.NumeroFattura) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "numero_documento_s" ' OK
                        fld.InnerText = lFat.NumeroFattura
                        DocIndex.AppendChild(fld)
                    End If


                    If String.IsNullOrEmpty(lFat.PartitaIVAEmittente) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "partita_iva_emittente_s" ' OK
                        fld.InnerText = lFat.PartitaIVAEmittente
                        DocIndex.AppendChild(fld)
                    End If



                    If String.IsNullOrEmpty(lFat.PartitaIVA) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "partita_iva_s"
                        fld.InnerText = lFat.PartitaIVA
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.Provincia) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "provincia_s"
                        fld.InnerText = lFat.Provincia
                        DocIndex.AppendChild(fld)
                    End If

                    If lFat.TotaleImporto > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "totale_importo_d" ' OK
                        fld.InnerText = lFat.TotaleImporto.ToString.Replace(".", "").Replace(",", ".")
                        DocIndex.AppendChild(fld)
                    End If

                    If String.IsNullOrEmpty(lFat.Via) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "via_s"
                        fld.InnerText = lFat.Via
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiOrdinativiSIOPE Then
                    Dim ord = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiOrdinativiSIOPE)
                    If ord.Anno > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "anno_i"
                        fld.InnerText = ord.Anno
                        DocIndex.AppendChild(fld)
                    End If
                    If String.IsNullOrEmpty(ord.AllegatiInclusi) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "allegati_s"
                        fld.InnerText = ord.AllegatiInclusi
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiGiornaleCassa Then
                    Dim gc = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiGiornaleCassa)
                    If gc.Anno > 0 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "anno_i"
                        fld.InnerText = gc.Anno
                        DocIndex.AppendChild(fld)
                    End If
                    If gc.DataInizioPeriodo.Year > 1799 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_inizio_rif_dt"
                        fld.InnerText = gc.DataInizioPeriodo.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If
                    If gc.DataFinePeriodo.Year > 1799 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "data_fine_rif_dt"
                        fld.InnerText = gc.DataFinePeriodo.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If
                ElseIf TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFascicoli Then
                    Dim gc = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiFascicoli)

                    If gc.DataDocumento.Year > 1 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "__data_documento_dt"
                        fld.InnerText = gc.DataDocumento.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "idaggtip_s"
                    fld.InnerText = "Fascicolo"
                    DocIndex.AppendChild(fld)



                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "tipofasc_s"
                    If gc.Fascicolo = Conservatori.Shared.TipologiaFascicolo.affare Then
                        fld.InnerText = "affare"
                    ElseIf gc.Fascicolo = Conservatori.Shared.TipologiaFascicolo.attivita Then
                        fld.InnerText = "attività"
                    ElseIf gc.Fascicolo = Conservatori.Shared.TipologiaFascicolo.personafisica Then
                        fld.InnerText = "persona fisica"
                    ElseIf gc.Fascicolo = Conservatori.Shared.TipologiaFascicolo.personagiuridica Then
                        fld.InnerText = "persona giuridica"
                    ElseIf gc.Fascicolo = Conservatori.Shared.TipologiaFascicolo.procedimentoamministrativo Then
                        fld.InnerText = "procedimento amministrativo"
                    Else
                        fld.InnerText = "non disponibile"
                    End If
                    DocIndex.AppendChild(fld)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "soggru_s"
                    fld.InnerText = "RUP"
                    DocIndex.AppendChild(fld)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "soggtip_s"
                    fld.InnerText = "RUP"
                    DocIndex.AppendChild(fld)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "soggnom_s"
                    fld.InnerText = "PF"
                    DocIndex.AppendChild(fld)


                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "cognome_s"
                    fld.InnerText = gc.RUPCognome
                    DocIndex.AppendChild(fld)
                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "nome_s"
                    fld.InnerText = gc.RUPNome
                    DocIndex.AppendChild(fld)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "assegntip_s"
                    fld.InnerText = "per competenza"
                    DocIndex.AppendChild(fld)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "assegnsoggtip_s"
                    fld.InnerText = "RUP"
                    DocIndex.AppendChild(fld)

                    If gc.DataApertura.Year > 1799 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "assegnin_dt"
                        fld.InnerText = gc.DataApertura.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If gc.DataChiusura.Year > 1799 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "assegnfin_dt"
                        fld.InnerText = gc.DataChiusura.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "apdata_dt"
                    fld.InnerText = gc.DataApertura.Date.ToString("dd-MM-yyyy")
                    DocIndex.AppendChild(fld)

                    fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                    fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "progress_s"
                    fld.InnerText = gc.Progressivo
                    DocIndex.AppendChild(fld)

                    If gc.DataChiusura.Year > 1799 Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "chiudata_dt"
                        fld.InnerText = gc.DataChiusura.Date.ToString("dd-MM-yyyy")
                        DocIndex.AppendChild(fld)
                    End If

                    If gc.IndiceDocumenti IsNot Nothing AndAlso gc.IndiceDocumenti.Count > 0 Then
                        Dim cnt As Int16 = 0
                        For Each s In gc.IndiceDocumenti
                            fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                            Dim Nome As String = "indicedoc_s"
                            If cnt > 0 Then
                                Nome = $"indicedoc{cnt.ToString}_s"
                            End If
                            fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = Nome
                            fld.InnerText = s
                            DocIndex.AppendChild(fld)
                            cnt = cnt + 1
                        Next
                    End If

                    If String.IsNullOrEmpty(gc.IdentificativoAggregazionePrimaria) = False Then
                        fld = doc.CreateNode(XmlNodeType.Element, "field", "")
                        fld.Attributes.Append(doc.CreateAttribute("name")).InnerText = "iddaggrprim_s"
                        fld.InnerText = gc.IdentificativoAggregazionePrimaria
                        DocIndex.AppendChild(fld)
                    End If

                End If

            End If

            Return doc.InnerXml

        End Function


        ReadOnly Info As ConservationInfo

        Public Sub New(Info As ConservationInfo, CodiceUnitaDocumentaria As String, TipoFile As String)
            Me.Info = Info
            If Info.Data.Year = 1 Then
                Throw New UnhandledException("IndexFile", New ArgumentOutOfRangeException("Data Documento", "La Data del Documento è obbligatoria"))
            End If
            If String.IsNullOrEmpty(CodiceUnitaDocumentaria) Then
                Throw New UnhandledException("IndexFile", New ArgumentOutOfRangeException("CodiceUnitaDocumentaria", "Il Codice Unita Documentaria è obbligatorio nella creazione di Index"))
            End If
            Me._CodiceUnitaDocumentaria = CodiceUnitaDocumentaria
            If CodiceUnitaDocumentaria.ToLower.StartsWith("kibernetes_") Then
                Try
                    _Value = Create(TipoFile)
                Catch ex As System.Exception
                    Throw New UnhandledException("IndexFile", ex) ' New ArgumentOutOfRangeException("Data Documento", "La Data del Documento è obbligatoria"))
                End Try
            ElseIf CodiceUnitaDocumentaria.ToLower.StartsWith("nv_") Then
                _Value = CreateNoventa()
            Else
                _Value = Create(TipoFile)
            End If

            Debug.Print(_Value)

        End Sub
    End Class
End Namespace
