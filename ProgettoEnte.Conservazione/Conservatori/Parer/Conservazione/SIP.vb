Imports System.Xml.Serialization
Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.PARER.Conservazione
    Friend Class SIP

        Public Shared Function Create(LoginSession As Autenticazione.PARERLoginSession,
                                      Info As ConservationInfo, IDDocumento As String) As Byte()

            Dim p As New Schemi.UnitaDocumentaria

            '-----------------------
            p.Intestazione = New Schemi.IntestazioneType
            p.Intestazione.Versione = LoginSession.PARERInfo.VersioneConservazione
            p.Intestazione.Versatore = New Schemi.VersatoreType
            p.Intestazione.Versatore.Ambiente = LoginSession.PARERInfo.Ambiente
            p.Intestazione.Versatore.Ente = LoginSession.PARERInfo.DenominazioneEnte
            p.Intestazione.Versatore.Struttura = LoginSession.PARERInfo.Struttura
            p.Intestazione.Versatore.UserID = LoginSession.UserName


            p.Intestazione.Chiave = New Schemi.ChiaveType
            p.Intestazione.Chiave.Anno = LoginSession.ChiaveRegistro.Anno
            p.Intestazione.Chiave.Numero = LoginSession.ChiaveRegistro.Numero
            p.Intestazione.Chiave.TipoRegistro = LoginSession.TipoRegistro

            p.Intestazione.TipologiaUnitaDocumentaria = LoginSession.TipologiaUnitaDocumentaria
            '-----------------------

            '-----------------------
            p.Configurazione = New Schemi.ConfigType
            If Info.Tipologia = TipoOggetto.Fattura Then
                p.Configurazione.TipoConservazione = Schemi.TipoConservazioneType.FISCALE
            Else
                p.Configurazione.TipoConservazione = Schemi.TipoConservazioneType.VERSAMENTO_ANTICIPATO
            End If
            p.Configurazione.TipoConservazioneSpecified = True
            p.Configurazione.ForzaAccettazione = True
            p.Configurazione.ForzaAccettazioneSpecified = True
            p.Configurazione.ForzaConservazione = True
            p.Configurazione.ForzaConservazioneSpecified = True
            p.Configurazione.ForzaCollegamento = True
            p.Configurazione.ForzaCollegamentoSpecified = True
            p.Configurazione.SimulaSalvataggioDatiInDB = False
            p.Configurazione.SimulaSalvataggioDatiInDBSpecified = True
            '-----------------------

            '-----------------------
            'p.ProfiloArchivistico = New Schemi.ProfiloArchivisticoType
            'p.ProfiloArchivistico.FascicoloPrincipale = New Schemi.CamiciaFascicoloType
            'p.ProfiloArchivistico.FascicoloPrincipale.Classifica = "1.2.2"
            'p.ProfiloArchivistico.FascicoloPrincipale.Fascicolo = New Schemi.FascicoloType
            'p.ProfiloArchivistico.FascicoloPrincipale.Fascicolo.Identificativo = "1.0/2014/10/12"
            'p.ProfiloArchivistico.FascicoloPrincipale.Fascicolo.Oggetto = "Oggetto"
            '-----------------------

            '-----------------------
            p.ProfiloUnitaDocumentaria = New Schemi.ProfiloUnitaDocumentariaType
            p.ProfiloUnitaDocumentaria.Oggetto = Info.Oggetto
            p.ProfiloUnitaDocumentaria.Data = Info.Data



            Try
                Dim extraTypes(8) As Type
                extraTypes(0) = GetType(Conservatori.Shared.AttributiDelibera)
                extraTypes(1) = GetType(Conservatori.Shared.AttributiDetermina)
                extraTypes(2) = GetType(Conservatori.Shared.AttributiAffissione)
                extraTypes(3) = GetType(Conservatori.Shared.AttributiContratto)
                extraTypes(4) = GetType(Conservatori.Shared.AttributiDocumentoGenerico)
                extraTypes(5) = GetType(Conservatori.Shared.AttributiFascicoloElettorale)
                extraTypes(6) = GetType(Conservatori.Shared.AttributiFatturaPassiva)
                extraTypes(7) = GetType(Conservatori.Shared.AttributiGenerici)
                extraTypes(8) = GetType(Conservatori.Shared.AttributiRegistroProtocollo)


                Dim debug As New XmlSerializer(GetType(ConservationInfo), extraTypes)

                Using writer As New IO.MemoryStream
                    debug.Serialize(writer, Info)
                    IO.File.WriteAllBytes("c:\temp\raf.txt", writer.GetBuffer)
                End Using
            Catch ex As Exception

            End Try

            If Info IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera Then
                Dim attr As Conservatori.Shared.AttributiDelibera = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDelibera)
                If attr.DataDocumento.Year > 1799 Then
                    p.ProfiloUnitaDocumentaria.Data = attr.DataDocumento
                End If
            ElseIf Info IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDetermina Then
                Dim attr As Conservatori.Shared.AttributiDetermina = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDetermina)
                If attr.DataDocumento.Year > 1799 Then
                    p.ProfiloUnitaDocumentaria.Data = attr.DataDocumento
                End If
            End If


            p.ProfiloUnitaDocumentaria.Cartaceo = False
            p.ProfiloUnitaDocumentaria.CartaceoSpecified = True
            '-----------------------


            '-----------------------
            If LoginSession.DatiSpecificiSpecified Then
                p.DatiSpecifici = New Schemi.DatiSpecificiType

                If LoginSession.Versione = Data.Versione.PARER_FATTURA11 Then
                    p.DatiSpecifici.VersioneDatiSpecifici = "1.1"
                Else
                    p.DatiSpecifici.VersioneDatiSpecifici = "1.0"
                End If

                Dim IsPea As Boolean = False
                If LoginSession.PARERLoginInfo IsNot Nothing AndAlso LoginSession.PARERLoginInfo.InfoLogin IsNot Nothing Then
                    If LoginSession.PARERLoginInfo.InfoLogin.Software = TipoSoftware.ProtocolloAtti Then
                        IsPea = True
                    End If
                End If

                p.DatiSpecifici.Any = [Shared].Helper.GetDatiSpeficifi(Info, IsPea)
            End If



            If Info IsNot Nothing AndAlso Info.AttributiSpecifici IsNot Nothing AndAlso Info.AttributiSpecifici.DocumentiCollegati IsNot Nothing Then
                If Info.AttributiSpecifici.DocumentiCollegati.Count > 0 Then
                    p.DocumentiCollegati = New Schemi.DocumentoCollegatoTypeDocumentoCollegato(Info.AttributiSpecifici.DocumentiCollegati.Count - 1) {}
                    Dim i As Integer = 0
                    For Each itm In Info.AttributiSpecifici.DocumentiCollegati
                        Dim dcCollegato As New Schemi.DocumentoCollegatoTypeDocumentoCollegato
                        dcCollegato.ChiaveCollegamento = New Schemi.ChiaveType
                        dcCollegato.ChiaveCollegamento.Anno = itm.Anno
                        dcCollegato.ChiaveCollegamento.Numero = itm.Numero
                        dcCollegato.ChiaveCollegamento.TipoRegistro = itm.TipoRegistro
                        dcCollegato.DescrizioneCollegamento = itm.Descrizione
                        p.DocumentiCollegati(i) = dcCollegato
                        i += 1

                    Next

                End If

            End If





            '-----------------------

            p.DocumentoPrincipale = New Schemi.DocumentoType
            p.DocumentoPrincipale.IDDocumento = IDDocumento & "-1"
            If String.IsNullOrEmpty(Info.TipoDocumentoPrincipale) Then
                p.DocumentoPrincipale.TipoDocumento = LoginSession.TipoDocumentoPrincipale
            Else
                p.DocumentoPrincipale.TipoDocumento = Info.TipoDocumentoPrincipale
            End If
            p.DocumentoPrincipale.StrutturaOriginale = New Schemi.StrutturaType
            p.DocumentoPrincipale.StrutturaOriginale.TipoStruttura = "DocumentoGenerico"



            Dim comp(Info.Files.Count - 1) As Schemi.ComponenteType
            Dim cnt As Integer = 0

            For Each f As ProgettoEnte.Conservazione.Shared.File In Info.Files
                comp(cnt) = New Schemi.ComponenteType
                comp(cnt).ID = IDDocumento & "-" & cnt + 1
                comp(cnt).OrdinePresentazione = cnt + 1

                If f.NomeFile.ToString.ToString = "segnatura.xml" Then
                    comp(cnt).TipoComponente = "Segnatura"
                Else
                    comp(cnt).TipoComponente = "Contenuto"
                End If



                comp(cnt).NomeComponente = f.NomeFile
                comp(cnt).FormatoFileVersato = Utility.Compute.getMimeString(f.Mime)
                If Info IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera Then
                    Dim attr As Conservatori.Shared.AttributiDelibera = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiDelibera)

                    If attr.AlboPretorioDataPubblicazione.Year > 1799 Then
                        comp(cnt).UtilizzoDataFirmaPerRifTemp = False
                        comp(cnt).UtilizzoDataFirmaPerRifTempSpecified = True
                        comp(cnt).RiferimentoTemporale = attr.AlboPretorioDataPubblicazione.Date
                        comp(cnt).RiferimentoTemporaleSpecified = True
                        comp(cnt).DescrizioneRiferimentoTemporale = "Data di pubblicazione"
                    End If
                ElseIf Info IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                    Dim attr As Conservatori.Shared.AttributiProtocollo = CType(Info.AttributiSpecifici, Conservatori.Shared.AttributiProtocollo)
                    If attr.DataDocumento.Year > 1799 Then
                        comp(cnt).RiferimentoTemporale = attr.DataDocumento.Date
                        comp(cnt).RiferimentoTemporaleSpecified = True
                        comp(cnt).DescrizioneRiferimentoTemporale = "Data di protocollazione"
                    End If
                End If
                cnt = cnt + 1
            Next



            p.DocumentoPrincipale.StrutturaOriginale.Componenti = comp

            Dim seeserUnit As New XmlSerializer(GetType(Schemi.UnitaDocumentaria))

            Using writer As New IO.MemoryStream
                seeserUnit.Serialize(writer, p)
                Return writer.ToArray
            End Using

        End Function


        Public Shared Function Createallegati(LoginSession As Autenticazione.PARERLoginSession,
                                      Info As AggiuntaAllegatiInfo, IDDocumento As String) As Byte()

            Dim p As New Schemi.UnitaDocAggAllegati
             
            '-----------------------
            p.Intestazione = New Schemi.IntestazioneAggAllType
            p.Intestazione.Versione = LoginSession.PARERInfo.VersioneConservazione
            p.Intestazione.Versatore = New Schemi.VersatoreType
            p.Intestazione.Versatore.Ambiente = LoginSession.PARERInfo.Ambiente
            p.Intestazione.Versatore.Ente = LoginSession.PARERInfo.DenominazioneEnte
            p.Intestazione.Versatore.Struttura = LoginSession.PARERInfo.Struttura
            p.Intestazione.Versatore.UserID = LoginSession.UserName


            p.Intestazione.Chiave = New Schemi.ChiaveType
            p.Intestazione.Chiave.Anno = LoginSession.ChiaveRegistro.Anno
            p.Intestazione.Chiave.Numero = LoginSession.ChiaveRegistro.Numero
            p.Intestazione.Chiave.TipoRegistro = LoginSession.TipoRegistro

            '-----------------------

            '-----------------------
            p.Configurazione = New Schemi.ConfigAggAllType
            Try
                p.Configurazione.TipoConservazione = Schemi.TipoConservazioneType.VERSAMENTO_ANTICIPATO

                If Info.AttributiSpecifici IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaPassiva Then
                    p.Configurazione.TipoConservazione = Schemi.TipoConservazioneType.FISCALE
                Else
                    p.Configurazione.TipoConservazione = Schemi.TipoConservazioneType.VERSAMENTO_ANTICIPATO
                End If
            Catch ex As Exception

            End Try


            p.Configurazione.TipoConservazioneSpecified = True
            p.Configurazione.ForzaAccettazione = True
            p.Configurazione.ForzaAccettazioneSpecified = True
            p.Configurazione.ForzaConservazione = True
            p.Configurazione.ForzaConservazioneSpecified = True
            p.Configurazione.SimulaSalvataggioDatiInDB = False
            p.Configurazione.SimulaSalvataggioDatiInDBSpecified = True

            If Info.TipoAllegato = TipoAllegato.Allegato Then
                p.ItemElementName = Schemi.ItemChoiceType.Allegato

                If Info.AttributiSpecifici IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera Then
                    Info.TipoDocumento = "GENERICO"
                ElseIf Info.AttributiSpecifici IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                    Info.TipoDocumento = "GENERICO"
                End If

            ElseIf Info.TipoAllegato = TipoAllegato.Annesso Then
                p.ItemElementName = Schemi.ItemChoiceType.Annesso
            ElseIf Info.TipoAllegato = TipoAllegato.Annotazione Then
                p.ItemElementName = Schemi.ItemChoiceType.Annotazione
            End If

            p.Item = New Schemi.DocumentoType
            p.Item.IDDocumento = IDDocumento

            If Info.TipoAllegato = TipoAllegato.Allegato AndAlso Info.AttributiSpecifici IsNot Nothing AndAlso TypeOf Info.AttributiSpecifici Is Conservatori.Shared.AttributiProtocollo Then
                p.Item.TipoDocumento = "GENERICO"
            Else
                If String.IsNullOrEmpty(Info.TipoDocumento) Then
                    p.Item.TipoDocumento = LoginSession.TipoDocumentoPrincipale
                Else
                    p.Item.TipoDocumento = Info.TipoDocumento
                End If

            End If


            p.Item.StrutturaOriginale = New Schemi.StrutturaType
            p.Item.StrutturaOriginale.TipoStruttura = "DocumentoGenerico"

            Dim comp(0) As Schemi.ComponenteType

             
            comp(0) = New Schemi.ComponenteType
            comp(0).ID = IDDocumento
            comp(0).OrdinePresentazione = 1
            comp(0).TipoComponente = "Contenuto"
            comp(0).NomeComponente = Info.File.NomeFile
            comp(0).FormatoFileVersato = Utility.Compute.getMimeString(Info.File.Mime)



            p.Item.StrutturaOriginale.Componenti = comp

            Dim seeserUnit As New XmlSerializer(GetType(Schemi.UnitaDocAggAllegati))

            Using writer As New IO.MemoryStream
                seeserUnit.Serialize(writer, p)
                Return writer.ToArray
            End Using

        End Function

    End Class
End Namespace

