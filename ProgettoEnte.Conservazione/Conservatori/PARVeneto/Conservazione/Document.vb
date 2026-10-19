

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml.Serialization
Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.PARVeneto.Conservazione
    Friend Class Document
        Private _InfoConservazione As ConservationInfo
        Private _InfoConservazioneAllegati As AggiuntaAllegatiInfo

        Private _LoginSession As Autenticazione.PARVenetoLoginSession

        Protected Sub New()

        End Sub

        ''' <summary>
        ''' Crea una nuova classe per le funzioni di conservazione
        ''' </summary>
        ''' <param name="LoginSession"></param>
        Public Sub New(LoginSession As Autenticazione.PARVenetoLoginSession, Info As ConservationInfo)
            If Info Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            _InfoConservazione = Info

            _LoginSession = LoginSession
            _LoginSession.setExtraInfo(Info)
            NewExtracted(LoginSession)


        End Sub

        Public Sub New(LoginSession As Autenticazione.PARVenetoLoginSession, Info As AggiuntaAllegatiInfo)
            If Info Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            _InfoConservazioneAllegati = Info

            _LoginSession = LoginSession
            _LoginSession.setExtraInfo(Info)
            NewExtracted(LoginSession)

        End Sub
        Private Sub NewExtracted(ByVal LoginSession As Autenticazione.PARVenetoLoginSession)
            If LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            If LoginSession.PARVenetoLoginInfo Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("DAXInfo"))
            End If

            If _LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginSession"))
            End If
            If _LoginSession.PARVenetoLoginInfo Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginInfo"))
            End If

            If String.IsNullOrEmpty(_LoginSession.UserName) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("UserName"))
            End If
            If String.IsNullOrEmpty(_LoginSession.Password) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Password"))
            End If

            If _LoginSession.ChiaveRegistro Is Nothing OrElse _LoginSession.ChiaveRegistro.ID = 0 Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("ChiaveRegistro", "Chiave di registro non valorizzata"))
            End If

            LogSystem.Log(_LoginSession, "Create Document", _LoginSession.ToString, True)
        End Sub


        Friend Function Conserva() As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended
            Dim logModule As String = "Conserva"
            LogSystem.Log(_LoginSession, logModule, "Avvio Conserva", False)


            Try

                Dim UserLogin As New Autenticazione.WebService.UserLogin With {.username = _LoginSession.UserName, .password = _LoginSession.Password}
                Dim Response As PARVeneto.Autenticazione.WebService.Response = Autenticazione.WebService.Autenticazione.Request(UserLogin, PARVeneto.Shared.SharedInfo.getURIBaseAutenticazione(_LoginSession.Ente.InCollaudo))
                Dim crt As New Utility.CertificationManager
                System.Net.ServicePointManager.ServerCertificateValidationCallback = AddressOf crt.ValidateServerCertificate
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 Or SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                Dim wr As HttpWebRequest = WebRequest.Create(PARVeneto.Shared.SharedInfo.getURIBaseConservazione(_LoginSession.Ente.InCollaudo))
                wr.ServerCertificateValidationCallback = AddressOf crt.ValidateServerCertificate
                wr.Headers.Add("Authorization", Response.token)
                wr.PreAuthenticate = True
                wr.ContentType = "multipart/form-data"
                wr.Method = "POST"
                Dim boundary As String = DateTime.Now.Ticks.ToString("x")
                wr.ContentType = "multipart/form-data; boundary=" + boundary
                Dim requestStream As Stream = wr.GetRequestStream()


                Dim btMetadati As Byte() = Getmetadati()



                For Each file In _InfoConservazione.Files
                    Dim btFile As Byte() = file.Buffer
                    btFile.WriteMultipartFormData(requestStream, boundary, Utility.Compute.getMimeEncoded(file.Mime), file.NomeFile, file.NomeFile)
                Next




                Dim HeaderTemplate As String = "--{0}" & vbCr & vbLf & "Content-Disposition: form-data; name=""{1}""; filename=""{1}""" & vbCr & vbLf & "Content-Type: text/xml; name=""metadati.xml""; charset=Cp1252;" & vbCr & vbLf & "Content-Transfer-Encoding: binary" & vbCr & vbLf & vbCr & vbLf
                Dim header As String = [String].Format(HeaderTemplate, boundary, "metadati.xml")
                Dim headerbytes As Byte() = Encoding.UTF8.GetBytes(header)
                requestStream.Write(headerbytes, 0, headerbytes.Length)
                requestStream.Write(btMetadati, 0, btMetadati.Length)
                Dim newlineBytes As Byte() = Encoding.UTF8.GetBytes(vbCr & vbLf)
                requestStream.Write(newlineBytes, 0, newlineBytes.Length)



                Dim endBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(String.Format("--{0}--", boundary))
                requestStream.Write(endBytes, 0, endBytes.Length)
                requestStream.Close()

                LogSystem.Log(_LoginSession, logModule, "Rilevo Risposta", False)
                Using resp As HttpWebResponse = wr.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", resp.StatusCode), False)

                    If resp.StatusCode = 200 Then
                        Using responseStream As New StreamReader(resp.GetResponseStream())

                            Dim stringBuffer As String = responseStream.ReadToEnd

                            LogSystem.Log(_LoginSession, logModule, String.Format("Risposta: {0}", stringBuffer), False)
                            Return GetConservationInfo(stringBuffer)

                        End Using
                        LogSystem.Log(_LoginSession, logModule, LogSystem.SeverityType.Warning, "Verifica Firma KO")
                    Else
                        Dim reader As New StreamReader(resp.GetResponseStream())
                        Dim buffer As String = reader.ReadToEnd
                        ' Throw [Shared].Utility.GetErrorInfoException(logModule, buffer)
                    End If
                End Using

            Catch wex As System.Net.WebException
                'Throw [Shared].Utility.ManageWebException(logModule, wex, _LoginSession)
            Catch f As System.Exception
                LogSystem.LogException(_LoginSession, logModule, f.Message, f)
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function


        Private Function GetConservationInfo(Buffer As String) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended
            Dim logModule As String = "GetConservationInfo"




            If String.IsNullOrEmpty(Buffer) = False Then

                Dim objResponse = Utility.Json.DeserializzaJson(Of Risposta)(Buffer)
                If objResponse.responseCode = "WS_OK" Then
                    LogSystem.Log(_LoginSession, logModule, "Rilevato Identificatore di Versamento", True)

                    Dim CO As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.TokenID = _LoginSession.ChiaveRegistro.ID,
                    .Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok,
                    .Descrizione = "Richiesta di conservazione inoltrata correttamente.",
                    .IdC = ASCIIEncoding.UTF8.GetBytes(Buffer)}

                    Dim token = objResponse.idConservazione
                    If String.IsNullOrEmpty(token) Then
                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, "Impossibile trovare il token nella risposta")
                    End If
                    Try
                        Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)
                        r.SetToken(_LoginSession.ChiaveRegistro.ID, token, _InfoConservazione.Files, token)
                        CO.IdCFileName = token
                    Catch ex As System.Exception
                        LogSystem.LogException(_LoginSession, logModule, "Errore su set token: " & ex.Message, ex)
                    End Try

                    LogSystem.Log(_LoginSession, logModule, String.Format("Identificatore di Versamento: {0}", CO.ToString), False)

                    Return CO
                Else
                    Dim CO As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.TokenID = _LoginSession.ChiaveRegistro.ID,
                    .Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Errore,
                    .Descrizione = objResponse.errorMessage,
                    .IdC = ASCIIEncoding.UTF8.GetBytes(Buffer)}
                    Return CO
                End If

            End If
            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function




        Private Function GetSingleMetadata(Name As String, Testo As String, mandatory As Boolean) As Schemi.singlemetadata
            Dim singleMetadata As New Schemi.singlemetadata
            singleMetadata.name = Name
            singleMetadata.mandatory = True
            singleMetadata.type = "TESTO"
            singleMetadata.values = New String() {Testo}
            Return singleMetadata
        End Function


        Private Function GetSingleMetadata(Name As String, Data As Date, mandatory As Boolean) As Schemi.singlemetadata
            Dim singleMetadata As New Schemi.singlemetadata
            singleMetadata.name = Name
            singleMetadata.mandatory = True
            singleMetadata.type = "DATA"
            singleMetadata.values = New String() {Data.ToString}
            Return singleMetadata
        End Function

        Private Function GetListMetadata(Attributi As Conservatori.Shared.AttributiRegistroProtocollo) As List(Of Schemi.singlemetadata)
            Dim lstMetadata As New List(Of Schemi.singlemetadata)
            If Attributi IsNot Nothing Then
                If Not String.IsNullOrEmpty(Attributi.Oggetto) Then
                    lstMetadata.Add(GetSingleMetadata("oggettodocumento", Attributi.Oggetto, False))    'Oggetto del documento	N
                End If

                'lstMetadata.Add(GetSingleMetadata("numeroProtocollo", Attributi., False))     'Numero di Protocollo	N

                If Attributi.DataDocumento.Year > 1799 Then
                    lstMetadata.Add(GetSingleMetadata("dataRegistrazioneProtocollo", Attributi.DataDocumento, False)) 'Data di Registrazione di Protocollo	N
                End If

                'lstMetadata.Add(GetSingleMetadata("oggettoProcedimento", Attributi.oggettoProcedimento, False)) 'Oggetto del Procedimento	N
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAmministrazione) Then
                    lstMetadata.Add(GetSingleMetadata("amministrazioneTitolareDelProcedimento", Attributi.CodiceIdentificativoAmministrazione, False)) 'Amministrazione Titolare del Procedimento (Codice IPA presente nel sito indicePA)	S
                End If
                ' lstMetadata.Add(GetSingleMetadata("responsabileProcedimento", Attributi., False))      'Responsabile del Procedimento	N
                ' lstMetadata.Add(GetSingleMetadata("documentiContenutiNelProcedimento", Attributi., False))   documentiContenutiNelProcedimento   'Documenti Contenuti nel Procedimento	N
                'lstMetadata.Add(GetSingleMetadata("amministrazioniPartecipanti", Attributi., False)) 'Amministrazioni Partecipanti	N
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAOO) Then
                    lstMetadata.Add(GetSingleMetadata("aooDiRiferimento", Attributi.CodiceIdentificativoAOO, False))    'AOO di riferimento (Codice AOO presente nel sito indicePA)	S
                End If
                'lstMetadata.Add(GetSingleMetadata("idFascicolo", Attributi., False)) 'ID Fascicolo (come definito al punto 4 dell'allegato 5 DPCM 3/12/2013)	N
                'lstMetadata.Add(GetSingleMetadata("esistenzaOriginaleAnalogico", Attributi., False)) 'Esistenza Originale Analogico	N
                'lstMetadata.Add(GetSingleMetadata("idSistemaVersante", Attributi., False))   'ID del sistema/applicativo versante	N
                'lstMetadata.Add(GetSingleMetadata("numeroAltraRegistrazione", Attributi., False))    'Numero Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("cfTitolareFirma", Attributi., False)) 'Codice Fiscale del Titolare Firma	N
                'lstMetadata.Add(GetSingleMetadata("livelloRiservatezza", Attributi., False)) 'Livello di Riservatezza	N
                'lstMetadata.Add(GetSingleMetadata("repertorio", Attributi., False))  'Repertorio	N
                'lstMetadata.Add(GetSingleMetadata("idDocumentoOriginale", Attributi.IDUnivocoDocumento, False))    'ID documento nel siistema di origine	N
                'lstMetadata.Add(GetSingleMetadata("idUnitaArchivistica", Attributi., False)) 'ID Unita Archivistica	N
                'lstMetadata.Add(GetSingleMetadata("applicativoProduzione", Attributi., False))   'Codice Applicativo/Sistema di Produzione	N
                'lstMetadata.Add(GetSingleMetadata("annesso", Attributi., False)) 'Annesso	N
                'lstMetadata.Add(GetSingleMetadata("pid", Attributi., False)) 'pid	N
                'lstMetadata.Add(GetSingleMetadata("registro", Attributi., False))    'Registro	N
                'lstMetadata.Add(GetSingleMetadata("annotazione", Attributi., False)) 'Annotazione sul Tempo di Conservazione	N
                'lstMetadata.Add(GetSingleMetadata("ufficioProduttore", Attributi., False))   'Struttura/Ufficio produttore	N
                'lstMetadata.Add(GetSingleMetadata("note1", Attributi.Note, False))   'Campo Note 1	N
                'lstMetadata.Add(GetSingleMetadata("allegato2", Attributi., False))   'Campo allegato 2	N
                'lstMetadata.Add(GetSingleMetadata("dataAltraRegistrazione", Attributi., False))  'Data Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("allegato1", Attributi., False))   'Campo allegato 1	N
                'lstMetadata.Add(GetSingleMetadata("condizioniAccesso", Attributi., False))   'Condizioni di Accesso	N
                'lstMetadata.Add(GetSingleMetadata("serie", Attributi., False))   'Serie Archivistica	N
                'lstMetadata.Add(GetSingleMetadata("note2", Attributi., False))   'Campo Note 2	N
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoRegistro) Then
                    lstMetadata.Add(GetSingleMetadata("Codice_identificativo_del_registro", Attributi.CodiceIdentificativoRegistro, False))  'Codice identificativo del Registro (Sigla Registro)	N

                End If
                If Not String.IsNullOrEmpty(Attributi.CognomeResponsabile) Then
                    lstMetadata.Add(GetSingleMetadata("Cognome_responsabile_gestione_documentale", Attributi.CognomeResponsabile, False))   'Cognome Responsabile UTP DG	S

                End If
                If Not String.IsNullOrEmpty(Attributi.NomeResponsabile) Then
                    lstMetadata.Add(GetSingleMetadata("Nome_responsabile_gestione_documentale", Attributi.NomeResponsabile, False))  'Nome Responsabile UTP DG	S

                End If
                If Not String.IsNullOrEmpty(Attributi.CodiceFiscaleResponsabile) Then
                    lstMetadata.Add(GetSingleMetadata("Codice_fiscale_responsabile_gestione_documentale", Attributi.CodiceFiscaleResponsabile, False))    'Codice Fiscale Responsabile UTP DG	S

                End If
                If Not String.IsNullOrEmpty(Attributi.NumeroPrimaRegistrazione) Then
                    lstMetadata.Add(GetSingleMetadata("Numero_prima_registrazione_effettuata_sul_registro", Attributi.NumeroPrimaRegistrazione, False))  'Numero prima registrazione effettuata sul registro	N

                End If
                If Not String.IsNullOrEmpty(Attributi.NumeroUltimaRegistrazione) Then
                    lstMetadata.Add(GetSingleMetadata("Numero_ultima_registrazione_effettuata_sul_registro", Attributi.NumeroUltimaRegistrazione, False)) 'Numero ultima registrazione effettuata sul registro	N

                End If
                If Not String.IsNullOrEmpty(Attributi.DataPrimaRegistrazione) Then
                    lstMetadata.Add(GetSingleMetadata("Data_prima_registrazione_effettuata_sul_registro", Attributi.DataPrimaRegistrazione, False))    'Data prima registrazione effettuata sul registro	N

                End If
                If Not String.IsNullOrEmpty(Attributi.DataUltimaRegistrazione) Then
                    lstMetadata.Add(GetSingleMetadata("Data_ultima_registrazione_effettuata_sul_registro", Attributi.DataUltimaRegistrazione, False))   'Data ultima registrazione effettuata sul registro	N

                End If
                If Not String.IsNullOrEmpty(Attributi.NumeroProgressivoDelRegistro) Then
                    lstMetadata.Add(GetSingleMetadata("Numero_progressivo_del_registro", Attributi.NumeroProgressivoDelRegistro, False)) 'Numero progressivo del registro	N

                End If
                If Attributi.Anno > 0 Then
                    lstMetadata.Add(GetSingleMetadata("Anno", Attributi.Anno, False))   ' Anno del Registro di Protocollo	N

                End If
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAmministrazione) Then
                    lstMetadata.Add(GetSingleMetadata("Codice_identificativo_amministrazione_", Attributi.CodiceIdentificativoAmministrazione, False)) '  Codice identificativo della Amministrazione (IPA)	N

                End If
                If Not String.IsNullOrEmpty(Attributi.DenominazioneAmministrazione) Then
                    lstMetadata.Add(GetSingleMetadata("Denominazione_dellamministrazione", Attributi.DenominazioneAmministrazione, False))   'Denominazione della Amministrazione	N

                End If
                If Not String.IsNullOrEmpty(Attributi.CodiceFiscaleSoggettoProduttore2) Then
                    lstMetadata.Add(GetSingleMetadata("Codice_fiscale_soggetto_produttore_2", Attributi.CodiceFiscaleSoggettoProduttore2, False))    'Codice Fiscale soggetto produttore 2	N


                End If
                'lstMetadata.Add(GetSingleMetadata("Cognome_soggetto_produttore_2", Attributi., False))   'Cognome soggetto produttore 2	N
                'lstMetadata.Add(GetSingleMetadata("Nome_soggetto_produttore_2", Attributi., False)) ' Nome soggetto produttore 2	N




            End If
                Return lstMetadata
        End Function
        Private Function GetListMetadata(Attributi As Conservatori.Shared.AttributiOrdinativiPagamenti) As List(Of Schemi.singlemetadata)
            Dim lstMetadata As New List(Of Schemi.singlemetadata)
            If Attributi IsNot Nothing Then
                '    'Oggetto del documento	N
                'lstMetadata.Add(GetSingleMetadata("numeroProtocollo", Attributi., False))     'Numero di Protocollo	N
                ' lstMetadata.Add(GetSingleMetadata("dataRegistrazioneProtocollo", Attributi.DataDocumento, False)) 'Data di Registrazione di Protocollo	N
                'lstMetadata.Add(GetSingleMetadata("oggettoProcedimento", Attributi.oggettoProcedimento, False)) 'Oggetto del Procedimento	N

                If Not String.IsNullOrEmpty(Attributi.Oggetto) Then
                    lstMetadata.Add(GetSingleMetadata("oggettodocumento", Attributi.Oggetto, False))
                End If
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAmministrazione) Then
                    lstMetadata.Add(GetSingleMetadata("amministrazioneTitolareDelProcedimento", Attributi.CodiceIdentificativoAmministrazione, False)) 'Amministrazione Titolare del Procedimento (Codice IPA presente nel sito indicePA)	S

                End If
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAOO) Then
                    lstMetadata.Add(GetSingleMetadata("aooDiRiferimento", Attributi.CodiceIdentificativoAOO, False))    'AOO di riferimento (Codice AOO presente nel sito indicePA)	S

                End If
                ' lstMetadata.Add(GetSingleMetadata("responsabileProcedimento", Attributi., False))      'Responsabile del Procedimento	N
                ' lstMetadata.Add(GetSingleMetadata("documentiContenutiNelProcedimento", Attributi., False))   documentiContenutiNelProcedimento   'Documenti Contenuti nel Procedimento	N
                'lstMetadata.Add(GetSingleMetadata("amministrazioniPartecipanti", Attributi., False)) 'Amministrazioni Partecipanti	N
                'lstMetadata.Add(GetSingleMetadata("idFascicolo", Attributi., False)) 'ID Fascicolo (come definito al punto 4 dell'allegato 5 DPCM 3/12/2013)	N
                'lstMetadata.Add(GetSingleMetadata("esistenzaOriginaleAnalogico", Attributi., False)) 'Esistenza Originale Analogico	N
                'lstMetadata.Add(GetSingleMetadata("idSistemaVersante", Attributi., False))   'ID del sistema/applicativo versante	N
                'lstMetadata.Add(GetSingleMetadata("numeroAltraRegistrazione", Attributi., False))    'Numero Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("cfTitolareFirma", Attributi., False)) 'Codice Fiscale del Titolare Firma	N
                'lstMetadata.Add(GetSingleMetadata("livelloRiservatezza", Attributi., False)) 'Livello di Riservatezza	N
                'lstMetadata.Add(GetSingleMetadata("repertorio", Attributi., False))  'Repertorio	N
                'lstMetadata.Add(GetSingleMetadata("idDocumentoOriginale", Attributi.IDUnivocoDocumento, False))    'ID documento nel siistema di origine	N
                'lstMetadata.Add(GetSingleMetadata("idUnitaArchivistica", Attributi., False)) 'ID Unita Archivistica	N
                'lstMetadata.Add(GetSingleMetadata("applicativoProduzione", Attributi., False))   'Codice Applicativo/Sistema di Produzione	N
                'lstMetadata.Add(GetSingleMetadata("annesso", Attributi., False)) 'Annesso	N
                'lstMetadata.Add(GetSingleMetadata("pid", Attributi., False)) 'pid	N
                'lstMetadata.Add(GetSingleMetadata("registro", Attributi., False))    'Registro	N
                'lstMetadata.Add(GetSingleMetadata("annotazione", Attributi., False)) 'Annotazione sul Tempo di Conservazione	N
                'lstMetadata.Add(GetSingleMetadata("ufficioProduttore", Attributi., False))   'Struttura/Ufficio produttore	N
                'lstMetadata.Add(GetSingleMetadata("note1", Attributi., False))   'Campo Note 1	N
                'lstMetadata.Add(GetSingleMetadata("allegato2", Attributi., False))   'Campo allegato 2	N
                'lstMetadata.Add(GetSingleMetadata("dataAltraRegistrazione", Attributi., False))  'Data Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("allegato1", Attributi., False))   'Campo allegato 1	N
                'lstMetadata.Add(GetSingleMetadata("condizioniAccesso", Attributi., False))   'Condizioni di Accesso	N
                'lstMetadata.Add(GetSingleMetadata("serie", Attributi., False))   'Serie Archivistica	N
                If Not String.IsNullOrEmpty(Attributi.esercizioFinanziario) Then
                    lstMetadata.Add(GetSingleMetadata("esercizioFinanziario ", Attributi.esercizioFinanziario, False)) '	Esercizio Finanziario	S
                End If
                If Not String.IsNullOrEmpty(Attributi.bancaTesoriere) Then
                    lstMetadata.Add(GetSingleMetadata("bancaTesoriere ", Attributi.bancaTesoriere, False)) '	Banca Tesoriere (ABI)	S

                End If
                If Not String.IsNullOrEmpty(Attributi.ibanEnte) Then
                    lstMetadata.Add(GetSingleMetadata("ibanEnte ", Attributi.ibanEnte, False)) '	IBAN Ente	S

                End If
                If Not String.IsNullOrEmpty(Attributi.importoOrdinativo) Then
                    lstMetadata.Add(GetSingleMetadata("importoOrdinativo ", Attributi.importoOrdinativo, False))    '	Importo Ordinativo	S

                End If
                If Not String.IsNullOrEmpty(Attributi.capitoloSpesa) Then
                    lstMetadata.Add(GetSingleMetadata("capitoloSpesa ", Attributi.capitoloSpesa, False)) '	Capitolo di Spesa	S

                End If
                If Not String.IsNullOrEmpty(Attributi.descrCapitolo) Then
                    lstMetadata.Add(GetSingleMetadata("descrCapitolo ", Attributi.descrCapitolo, False)) '	Descrizione Capitolo di Spesa	S

                End If
                If Not String.IsNullOrEmpty(Attributi.gestione) Then
                    lstMetadata.Add(GetSingleMetadata("gestione ", Attributi.gestione, False)) '	Gestione(Competenza / Residuo)	S

                End If
                If Not String.IsNullOrEmpty(Attributi.denominazioneBeneficiario) Then
                    lstMetadata.Add(GetSingleMetadata("denominazioneBeneficiario ", Attributi.denominazioneBeneficiario, False)) 'Denominazione del Beneficario	S

                End If
                If Not String.IsNullOrEmpty(Attributi.importoBeneficiario) Then
                    lstMetadata.Add(GetSingleMetadata("importoBeneficiario ", Attributi.importoBeneficiario, False)) '	Importo del Beneficario	S

                End If
                If Not String.IsNullOrEmpty(Attributi.ibanBeneficiario) Then
                    lstMetadata.Add(GetSingleMetadata("ibanBeneficiario ", Attributi.ibanBeneficiario, False)) 'IBAN del Beneficario	S

                End If









            End If
            Return lstMetadata
        End Function

        Private Function GetListMetadata(Attributi As Conservatori.Shared.AttributiOrdinativiIncasso) As List(Of Schemi.singlemetadata)
            Dim lstMetadata As New List(Of Schemi.singlemetadata)
            If Attributi IsNot Nothing Then
                ' lstMetadata.Add(GetSingleMetadata("oggettodocumento", Attributi.Oggetto, False))    'Oggetto del documento	N
                'lstMetadata.Add(GetSingleMetadata("numeroProtocollo", Attributi., False))     'Numero di Protocollo	N
                ' lstMetadata.Add(GetSingleMetadata("dataRegistrazioneProtocollo", Attributi.DataDocumento, False)) 'Data di Registrazione di Protocollo	N
                'lstMetadata.Add(GetSingleMetadata("oggettoProcedimento", Attributi.oggettoProcedimento, False)) 'Oggetto del Procedimento	N

                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAmministrazione) Then
                    lstMetadata.Add(GetSingleMetadata("amministrazioneTitolareDelProcedimento", Attributi.CodiceIdentificativoAmministrazione, False)) 'Amministrazione Titolare del Procedimento (Codice IPA presente nel sito indicePA)	S

                End If
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAOO) Then
                    lstMetadata.Add(GetSingleMetadata("aooDiRiferimento", Attributi.CodiceIdentificativoAOO, False))    'AOO di riferimento (Codice AOO presente nel sito indicePA)	S

                End If
                ' lstMetadata.Add(GetSingleMetadata("responsabileProcedimento", Attributi., False))      'Responsabile del Procedimento	N
                ' lstMetadata.Add(GetSingleMetadata("documentiContenutiNelProcedimento", Attributi., False))   documentiContenutiNelProcedimento   'Documenti Contenuti nel Procedimento	N
                'lstMetadata.Add(GetSingleMetadata("amministrazioniPartecipanti", Attributi., False)) 'Amministrazioni Partecipanti	N
                'lstMetadata.Add(GetSingleMetadata("idFascicolo", Attributi., False)) 'ID Fascicolo (come definito al punto 4 dell'allegato 5 DPCM 3/12/2013)	N
                'lstMetadata.Add(GetSingleMetadata("esistenzaOriginaleAnalogico", Attributi., False)) 'Esistenza Originale Analogico	N
                'lstMetadata.Add(GetSingleMetadata("idSistemaVersante", Attributi., False))   'ID del sistema/applicativo versante	N
                'lstMetadata.Add(GetSingleMetadata("numeroAltraRegistrazione", Attributi., False))    'Numero Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("cfTitolareFirma", Attributi., False)) 'Codice Fiscale del Titolare Firma	N
                'lstMetadata.Add(GetSingleMetadata("livelloRiservatezza", Attributi., False)) 'Livello di Riservatezza	N
                'lstMetadata.Add(GetSingleMetadata("repertorio", Attributi., False))  'Repertorio	N
                'lstMetadata.Add(GetSingleMetadata("idDocumentoOriginale", Attributi.IDUnivocoDocumento, False))    'ID documento nel siistema di origine	N
                'lstMetadata.Add(GetSingleMetadata("idUnitaArchivistica", Attributi., False)) 'ID Unita Archivistica	N
                'lstMetadata.Add(GetSingleMetadata("applicativoProduzione", Attributi., False))   'Codice Applicativo/Sistema di Produzione	N
                'lstMetadata.Add(GetSingleMetadata("annesso", Attributi., False)) 'Annesso	N
                'lstMetadata.Add(GetSingleMetadata("pid", Attributi., False)) 'pid	N
                'lstMetadata.Add(GetSingleMetadata("registro", Attributi., False))    'Registro	N
                'lstMetadata.Add(GetSingleMetadata("annotazione", Attributi., False)) 'Annotazione sul Tempo di Conservazione	N
                'lstMetadata.Add(GetSingleMetadata("ufficioProduttore", Attributi., False))   'Struttura/Ufficio produttore	N
                'lstMetadata.Add(GetSingleMetadata("note1", Attributi., False))   'Campo Note 1	N
                'lstMetadata.Add(GetSingleMetadata("allegato2", Attributi., False))   'Campo allegato 2	N
                'lstMetadata.Add(GetSingleMetadata("dataAltraRegistrazione", Attributi., False))  'Data Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("allegato1", Attributi., False))   'Campo allegato 1	N
                'lstMetadata.Add(GetSingleMetadata("condizioniAccesso", Attributi., False))   'Condizioni di Accesso	N
                'lstMetadata.Add(GetSingleMetadata("serie", Attributi., False))   'Serie Archivistica	N
                If Not String.IsNullOrEmpty(Attributi.EsercizioFinanziario) Then
                    lstMetadata.Add(GetSingleMetadata("esercizioFinanziario ", Attributi.EsercizioFinanziario, False)) '	Esercizio Finanziario	S

                End If
                If Not String.IsNullOrEmpty(Attributi.BancaTesoriere) Then
                    lstMetadata.Add(GetSingleMetadata("bancaTesoriere ", Attributi.BancaTesoriere, False)) '	Banca Tesoriere (ABI)	S

                End If
                If Not String.IsNullOrEmpty(Attributi.IbanEnte) Then
                    lstMetadata.Add(GetSingleMetadata("ibanEnte ", Attributi.IbanEnte, False)) '	IBAN Ente	S

                End If
                If Not String.IsNullOrEmpty(Attributi.ImportoReversale) Then
                    lstMetadata.Add(GetSingleMetadata("importoReversale ", Attributi.ImportoReversale, False)) '	Importo Reversale	S

                End If
                If Not String.IsNullOrEmpty(Attributi.CapitoloBilancio) Then
                    lstMetadata.Add(GetSingleMetadata("capitoloBilancio ", Attributi.CapitoloBilancio, False)) '	Capitolo di Bilancio	S

                End If
                If Not String.IsNullOrEmpty(Attributi.DescCapitoloBilancio) Then
                    lstMetadata.Add(GetSingleMetadata("descCapitoloBilancio ", Attributi.DescCapitoloBilancio, False)) '	Descrizione Capitolo di Bilancio	S

                End If
                If Not String.IsNullOrEmpty(Attributi.Gestione) Then
                    lstMetadata.Add(GetSingleMetadata("gestione ", Attributi.Gestione, False)) '	Gestione(Competenza / Residuo)	S

                End If
                If Not String.IsNullOrEmpty(Attributi.AnagraficaVersante) Then
                    lstMetadata.Add(GetSingleMetadata("anagraficaVersante ", Attributi.AnagraficaVersante, False)) 'Anagrafica Versante	S

                End If
                If Not String.IsNullOrEmpty(Attributi.ImportoVersante) Then
                    lstMetadata.Add(GetSingleMetadata("importoVersante ", Attributi.ImportoVersante, False)) '	Importo Versante	S

                End If
                If Not String.IsNullOrEmpty(Attributi.CausaleVersante) Then
                    lstMetadata.Add(GetSingleMetadata("causaleVersante ", Attributi.CausaleVersante, False)) '	Causale Versante	S

                End If
                If Not String.IsNullOrEmpty(Attributi.ImportoPagamento) Then
                    lstMetadata.Add(GetSingleMetadata("importoPagamento ", Attributi.ImportoPagamento, False)) '	Importo di Pagamento	S

                End If
                If Not String.IsNullOrEmpty(Attributi.IbanPagamento) Then
                    lstMetadata.Add(GetSingleMetadata("ibanPagamento ", Attributi.IbanPagamento, False)) '	IBAN di Pagamento	S

                End If



            End If
            Return lstMetadata
        End Function

        Private Function GetListMetadata(Attributi As Conservatori.Shared.AttributiFatturaAttiva) As List(Of Schemi.singlemetadata)
            Dim lstMetadata As New List(Of Schemi.singlemetadata)
            If Attributi IsNot Nothing Then

                'lstMetadata.Add(GetSingleMetadata("oggettodocumento", Attributi.Oggetto, False))    'Oggetto del documento	N
                'lstMetadata.Add(GetSingleMetadata("numeroProtocollo", Attributi., False))     'Numero di Protocollo	N
                ' lstMetadata.Add(GetSingleMetadata("dataRegistrazioneProtocollo", Attributi.DataDocumento, False)) 'Data di Registrazione di Protocollo	N
                'lstMetadata.Add(GetSingleMetadata("oggettoProcedimento", Attributi.oggettoProcedimento, False)) 'Oggetto del Procedimento	N
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAmministrazione) Then
                    lstMetadata.Add(GetSingleMetadata("amministrazioneTitolareDelProcedimento", Attributi.CodiceIdentificativoAmministrazione, False)) 'Amministrazione Titolare del Procedimento (Codice IPA presente nel sito indicePA)	S

                End If
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAOO) Then
                    lstMetadata.Add(GetSingleMetadata("aooDiRiferimento", Attributi.CodiceIdentificativoAOO, False))    'AOO di riferimento (Codice AOO presente nel sito indicePA)	S

                End If

                ' lstMetadata.Add(GetSingleMetadata("responsabileProcedimento", Attributi., False))      'Responsabile del Procedimento	N
                ' lstMetadata.Add(GetSingleMetadata("documentiContenutiNelProcedimento", Attributi., False))   documentiContenutiNelProcedimento   'Documenti Contenuti nel Procedimento	N
                'lstMetadata.Add(GetSingleMetadata("amministrazioniPartecipanti", Attributi., False)) 'Amministrazioni Partecipanti	N
                'lstMetadata.Add(GetSingleMetadata("idFascicolo", Attributi., False)) 'ID Fascicolo (come definito al punto 4 dell'allegato 5 DPCM 3/12/2013)	N
                'lstMetadata.Add(GetSingleMetadata("esistenzaOriginaleAnalogico", Attributi., False)) 'Esistenza Originale Analogico	N
                'lstMetadata.Add(GetSingleMetadata("idSistemaVersante", Attributi., False))   'ID del sistema/applicativo versante	N
                'lstMetadata.Add(GetSingleMetadata("numeroAltraRegistrazione", Attributi., False))    'Numero Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("cfTitolareFirma", Attributi., False)) 'Codice Fiscale del Titolare Firma	N
                'lstMetadata.Add(GetSingleMetadata("livelloRiservatezza", Attributi., False)) 'Livello di Riservatezza	N
                'lstMetadata.Add(GetSingleMetadata("repertorio", Attributi., False))  'Repertorio	N
                'lstMetadata.Add(GetSingleMetadata("idDocumentoOriginale", Attributi.IDUnivocoDocumento, False))    'ID documento nel siistema di origine	N
                'lstMetadata.Add(GetSingleMetadata("idUnitaArchivistica", Attributi., False)) 'ID Unita Archivistica	N
                'lstMetadata.Add(GetSingleMetadata("applicativoProduzione", Attributi., False))   'Codice Applicativo/Sistema di Produzione	N
                'lstMetadata.Add(GetSingleMetadata("annesso", Attributi., False)) 'Annesso	N
                'lstMetadata.Add(GetSingleMetadata("pid", Attributi., False)) 'pid	N
                'lstMetadata.Add(GetSingleMetadata("registro", Attributi., False))    'Registro	N
                'lstMetadata.Add(GetSingleMetadata("annotazione", Attributi., False)) 'Annotazione sul Tempo di Conservazione	N
                'lstMetadata.Add(GetSingleMetadata("ufficioProduttore", Attributi., False))   'Struttura/Ufficio produttore	N
                'lstMetadata.Add(GetSingleMetadata("note1", Attributi., False))   'Campo Note 1	N
                'lstMetadata.Add(GetSingleMetadata("allegato2", Attributi., False))   'Campo allegato 2	N
                'lstMetadata.Add(GetSingleMetadata("dataAltraRegistrazione", Attributi., False))  'Data Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("allegato1", Attributi., False))   'Campo allegato 1	N
                'lstMetadata.Add(GetSingleMetadata("condizioniAccesso", Attributi., False))   'Condizioni di Accesso	N
                'lstMetadata.Add(GetSingleMetadata("serie", Attributi., False))   'Serie Archivistica	N
                If Not String.IsNullOrEmpty(Attributi.NumeroFattura) Then
                    lstMetadata.Add(GetSingleMetadata("numeroFattura", Attributi.NumeroFattura, False))   ' Numero della Fattura	S
                End If
                If Attributi.DataDocumento.Year > 0 Then
                    lstMetadata.Add(GetSingleMetadata("dataEmissioneFattura", Attributi.DataDocumento, False))   '    Data Emissione Fattura	S
                End If
                If Not String.IsNullOrEmpty(Attributi.TotaleImporto) Then
                    lstMetadata.Add(GetSingleMetadata("importoImponibile", Attributi.TotaleImporto, False))   '   Importo Imponibile	S
                End If
                If Not String.IsNullOrEmpty(Attributi.ImportoIVA) Then
                    lstMetadata.Add(GetSingleMetadata("importoIva", Attributi.ImportoIVA, False))   '  Importo Iva	S
                End If

                'lstMetadata.Add(GetSingleMetadata("soggTribNome", Attributi., False))   '    Nome Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribCognome", Attributi., False))   ' Cognome Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribRagioneSociale", Attributi., False))   '  agione Sociale Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribCF", Attributi., False))   '  Codice Fiscale Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribPIVA", Attributi., False))   '    Partita IVA Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribIndirizzo", Attributi., False))   '   Indirizzo Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribNCivico", Attributi., False))   ' Numero Civico Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribComune", Attributi., False))   '  Comune Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribProvincia", Attributi., False))   '   Provincia Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribStato", Attributi., False))   '   Stato Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("denomStruttDestinataria", Attributi., False))   ' Denominazione Struttura Destinataria	N
                'lstMetadata.Add(GetSingleMetadata("codIPAunivoco", Attributi.CodiceUfficioIPA, False))   '   Codice IPA Univoco Ufficio	N


            End If
            Return lstMetadata
        End Function
        Private Function GetListMetadata(Attributi As Conservatori.Shared.AttributiFatturaPassiva) As List(Of Schemi.singlemetadata)
            Dim lstMetadata As New List(Of Schemi.singlemetadata)
            If Attributi IsNot Nothing Then

                'lstMetadata.Add(GetSingleMetadata("oggettodocumento", Attributi.Oggetto, False))    'Oggetto del documento	N
                'lstMetadata.Add(GetSingleMetadata("numeroProtocollo", Attributi., False))     'Numero di Protocollo	N
                ' lstMetadata.Add(GetSingleMetadata("dataRegistrazioneProtocollo", Attributi.DataDocumento, False)) 'Data di Registrazione di Protocollo	N
                'lstMetadata.Add(GetSingleMetadata("oggettoProcedimento", Attributi.oggettoProcedimento, False)) 'Oggetto del Procedimento	N
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAmministrazione) Then
                    lstMetadata.Add(GetSingleMetadata("amministrazioneTitolareDelProcedimento", Attributi.CodiceIdentificativoAmministrazione, False)) 'Amministrazione Titolare del Procedimento (Codice IPA presente nel sito indicePA)	S

                End If
                If Not String.IsNullOrEmpty(Attributi.CodiceIdentificativoAOO) Then
                    lstMetadata.Add(GetSingleMetadata("aooDiRiferimento", Attributi.CodiceIdentificativoAOO, False))    'AOO di riferimento (Codice AOO presente nel sito indicePA)	S

                End If

                ' lstMetadata.Add(GetSingleMetadata("responsabileProcedimento", Attributi., False))      'Responsabile del Procedimento	N
                ' lstMetadata.Add(GetSingleMetadata("documentiContenutiNelProcedimento", Attributi., False))   documentiContenutiNelProcedimento   'Documenti Contenuti nel Procedimento	N
                'lstMetadata.Add(GetSingleMetadata("amministrazioniPartecipanti", Attributi., False)) 'Amministrazioni Partecipanti	N
                'lstMetadata.Add(GetSingleMetadata("idFascicolo", Attributi., False)) 'ID Fascicolo (come definito al punto 4 dell'allegato 5 DPCM 3/12/2013)	N
                'lstMetadata.Add(GetSingleMetadata("esistenzaOriginaleAnalogico", Attributi., False)) 'Esistenza Originale Analogico	N
                'lstMetadata.Add(GetSingleMetadata("idSistemaVersante", Attributi., False))   'ID del sistema/applicativo versante	N
                'lstMetadata.Add(GetSingleMetadata("numeroAltraRegistrazione", Attributi., False))    'Numero Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("cfTitolareFirma", Attributi., False)) 'Codice Fiscale del Titolare Firma	N
                'lstMetadata.Add(GetSingleMetadata("livelloRiservatezza", Attributi., False)) 'Livello di Riservatezza	N
                'lstMetadata.Add(GetSingleMetadata("repertorio", Attributi., False))  'Repertorio	N
                'lstMetadata.Add(GetSingleMetadata("idDocumentoOriginale", Attributi.IDUnivocoDocumento, False))    'ID documento nel siistema di origine	N
                'lstMetadata.Add(GetSingleMetadata("idUnitaArchivistica", Attributi., False)) 'ID Unita Archivistica	N
                'lstMetadata.Add(GetSingleMetadata("applicativoProduzione", Attributi., False))   'Codice Applicativo/Sistema di Produzione	N
                'lstMetadata.Add(GetSingleMetadata("annesso", Attributi., False)) 'Annesso	N
                'lstMetadata.Add(GetSingleMetadata("pid", Attributi., False)) 'pid	N
                'lstMetadata.Add(GetSingleMetadata("registro", Attributi., False))    'Registro	N
                'lstMetadata.Add(GetSingleMetadata("annotazione", Attributi., False)) 'Annotazione sul Tempo di Conservazione	N
                'lstMetadata.Add(GetSingleMetadata("ufficioProduttore", Attributi., False))   'Struttura/Ufficio produttore	N
                'lstMetadata.Add(GetSingleMetadata("note1", Attributi., False))   'Campo Note 1	N
                'lstMetadata.Add(GetSingleMetadata("allegato2", Attributi., False))   'Campo allegato 2	N
                'lstMetadata.Add(GetSingleMetadata("dataAltraRegistrazione", Attributi., False))  'Data Altra Registrazione	N
                'lstMetadata.Add(GetSingleMetadata("allegato1", Attributi., False))   'Campo allegato 1	N
                'lstMetadata.Add(GetSingleMetadata("condizioniAccesso", Attributi., False))   'Condizioni di Accesso	N
                'lstMetadata.Add(GetSingleMetadata("serie", Attributi., False))   'Serie Archivistica	N
                If Not String.IsNullOrEmpty(Attributi.NumeroFattura) Then
                    lstMetadata.Add(GetSingleMetadata("numeroFattura", Attributi.NumeroFattura, False))   ' Numero della Fattura	S
                End If
                If Not String.IsNullOrEmpty(Attributi.NumeroFattura) Then
                    lstMetadata.Add(GetSingleMetadata("cig", Attributi.CIG, False))   ' CIG	S
                End If
                If Not String.IsNullOrEmpty(Attributi.DataRegistrazioneRUF) Then
                    lstMetadata.Add(GetSingleMetadata("dataEmissioneFattura", Attributi.DataRegistrazioneRUF, False))   '    Data Emissione Fattura	S
                End If
                If Not String.IsNullOrEmpty(Attributi.ImportoTotale) Then
                    lstMetadata.Add(GetSingleMetadata("importoImponibile", Attributi.ImportoTotale, False))   '   Importo Imponibile	S
                End If
                If Not String.IsNullOrEmpty(Attributi.ImportoIVA) Then
                    lstMetadata.Add(GetSingleMetadata("importoIva", Attributi.ImportoIVA, False))   '  Importo Iva	S
                End If

                'lstMetadata.Add(GetSingleMetadata("soggTribNome", Attributi., False))   '    Nome Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribCognome", Attributi., False))   ' Cognome Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribRagioneSociale", Attributi., False))   '  agione Sociale Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribCF", Attributi., False))   '  Codice Fiscale Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribPIVA", Attributi., False))   '    Partita IVA Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribIndirizzo", Attributi., False))   '   Indirizzo Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribNCivico", Attributi., False))   ' Numero Civico Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribComune", Attributi., False))   '  Comune Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribProvincia", Attributi., False))   '   Provincia Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("soggTribStato", Attributi., False))   '   Stato Soggetto Tributario	N
                'lstMetadata.Add(GetSingleMetadata("denomStruttDestinataria", Attributi., False))   ' Denominazione Struttura Destinataria	N
                'lstMetadata.Add(GetSingleMetadata("codIPAunivoco", Attributi.CodiceUfficioIPA, False))   '   Codice IPA Univoco Ufficio	N


            End If
            Return lstMetadata
        End Function

        Private Function Getmetadati() As Byte()
            Dim metadati As New Schemi.versamento

            metadati.docType = _LoginSession.TipologiaUnitaDocumentaria
            Dim lst As List(Of Schemi.singlemetadata) = Nothing
            If _InfoConservazione.Tipologia = TipoOggetto.RegistroProtocollo Then
                If _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiRegistroProtocollo Then
                    Dim attributi = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiRegistroProtocollo)
                    If attributi IsNot Nothing Then
                        lst = GetListMetadata(attributi)
                    End If
                End If
            ElseIf _InfoConservazione.Tipologia = TipoOggetto.FatturaAttiva Then

                If _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaAttiva Then
                    Dim attributi = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiFatturaAttiva)
                    If attributi IsNot Nothing Then
                        lst = GetListMetadata(attributi)
                    End If
                End If
            ElseIf _InfoConservazione.Tipologia = TipoOggetto.FATTURA Then

                If _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaPassiva Then
                    Dim attributi = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiFatturaPassiva)
                    If attributi IsNot Nothing Then
                        lst = GetListMetadata(attributi)
                    End If
                End If
                'ElseIf _InfoConservazione.Tipologia = TipoOggetto.Then Then

                '    If _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiOrdinativiIncasso Then
                '        Dim attributi = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiOrdinativiIncasso)
                '        If attributi IsNot Nothing Then
                '            lst = GetListMetadata(attributi)
                '        End If
                '    End If
            ElseIf _InfoConservazione.Tipologia = TipoOggetto.OPI Then

                If _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiOrdinativiPagamenti Then
                    Dim attributi = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiOrdinativiPagamenti)
                    If attributi IsNot Nothing Then
                        lst = GetListMetadata(attributi)
                    End If
                End If
            End If
            If lst IsNot Nothing AndAlso lst.Count > 0 Then

                metadati.metadata = lst.ToArray
            End If



            metadati.files = New Schemi.file(_InfoConservazione.Files.Count - 1) {}
            Dim i As Integer = 0
            For Each fl In _InfoConservazione.Files
                Dim file As New Schemi.file
                file.filename = fl.NomeFile
                file.mimetype = fl.Mime
                file.hash = fl.Hash
                metadati.files(i) = file
                i += 1
            Next


            Dim seeserUnit As New XmlSerializer(GetType(Schemi.versamento))
            Dim bt As Byte() = Nothing
            Using writer As New IO.MemoryStream
                seeserUnit.Serialize(writer, metadati)
                bt = writer.ToArray
            End Using

            Return bt
        End Function
    End Class

End Namespace

