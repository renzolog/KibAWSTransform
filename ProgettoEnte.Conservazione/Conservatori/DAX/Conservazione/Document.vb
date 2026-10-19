Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Text
Imports System.Xml
Imports ProgettoEnte.Conservazione.Conservatori.DAX
Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.DAX.Conservazione
    Friend Class Document

        Private _InfoConservazione As ConservationInfo
        Private _InfoConservazioneAllegati As AggiuntaAllegatiInfo

        Private _LoginSession As Autenticazione.DAXLoginSession

        Protected Sub New()

        End Sub

        ''' <summary>
        ''' Crea una nuova classe per le funzioni di conservazione
        ''' </summary>
        ''' <param name="LoginSession"></param>
        Public Sub New(LoginSession As Autenticazione.DAXLoginSession, Info As ConservationInfo)
            If Info Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            _InfoConservazione = Info

            _LoginSession = LoginSession
            _LoginSession.setExtraInfo(Info)
            NewExtracted(LoginSession)


        End Sub

        Public Sub New(LoginSession As Autenticazione.DAXLoginSession, Info As AggiuntaAllegatiInfo)
            If Info Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            _InfoConservazioneAllegati = Info

            _LoginSession = LoginSession
            _LoginSession.setExtraInfo(Info)
            NewExtracted(LoginSession)

        End Sub
        Private Sub NewExtracted(ByVal LoginSession As Autenticazione.DAXLoginSession)
            If LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            If LoginSession.DAXInfo Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("DAXInfo"))
            End If

            If _LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginSession"))
            End If
            If _LoginSession.DAXLoginInfo Is Nothing Then
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


            Dim PacchettoSip As Byte() = CreaSIP()


            Try


                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 Or SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                Dim url As String = DAX.Shared.SharedInfo.getURIBaseConservazione(_LoginSession.Ente.InCollaudo)
                Dim myRequest As HttpWebRequest = WebRequest.Create(url)




                Dim crt As New Utility.CertificationManager
                myRequest.ServerCertificateValidationCallback = AddressOf crt.ValidateServerCertificate

                'user:APPLTEST
                'pwd:Test123

                myRequest.Headers("H_P_APP_ID") = _LoginSession.UserName
                myRequest.Headers("H_P_APP_PWD") = _LoginSession.Password

                myRequest.ContentType = "text/xml;charset=utf-8"
                myRequest.Accept = "text/xml"
                myRequest.Method = "POST"
                Dim str = GetXmlDataSoap(PacchettoSip)

                LogSystem.Log(_LoginSession, logModule, "Rilevo Risposta", False)
                Using streamWriter = New StreamWriter(myRequest.GetRequestStream())
                    streamWriter.Write(str)
                End Using

                Dim obj As New Conservazione.Schemi.receiveSipResponse




                Using response As HttpWebResponse = myRequest.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", response.StatusCode), False)

                    If response.StatusCode = 200 Then
                        Using responseStream As New StreamReader(response.GetResponseStream())

                            Dim stringBuffer As String = responseStream.ReadToEnd
                            LogSystem.Log(_LoginSession, logModule, String.Format("Risposta: {0}", stringBuffer), False)
                            Return GetConservationInfo(stringBuffer)

                        End Using
                        LogSystem.Log(_LoginSession, logModule, LogSystem.SeverityType.Warning, "Verifica Firma KO")
                    Else
                        Dim reader As New StreamReader(response.GetResponseStream())
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

        Private Function CreaSIP() As Byte()
            If _InfoConservazione.Files Is Nothing OrElse _InfoConservazione.Files.Count = 0 Then
                Throw New ArgumentOutOfRangeException("Files", "Errore, nessun file selezionato da conservare")
            End If

            Dim IdSip As String = String.Format("{0}_{1}", _LoginSession.DAXInfo.Label, Guid.NewGuid.ToString)
            Dim manifest As New Conservazione.Schemi.SIP

            manifest.SelfDescription = New Schemi.SIPSelfDescription
            manifest.SelfDescription.Id = IdSip
            manifest.SelfDescription.CreatoDaApplicazione = New Schemi.Applicazione
            manifest.SelfDescription.CreatoDaApplicazione.nome = "APPLTEST" 'todo
            manifest.SelfDescription.CreatoDaApplicazione.Descrizione = New Schemi.Description
            manifest.SelfDescription.CreatoDaApplicazione.Descrizione.lang = "it"
            manifest.SelfDescription.CreatoDaApplicazione.Descrizione.Value = "APPLTEST" 'todo
            manifest.SelfDescription.Produttore = New Schemi.ProduttoreSIP
            manifest.SelfDescription.Produttore.Tipo = Schemi.FormaGiuridica.PA
            manifest.SelfDescription.Produttore.Intestazione = _LoginSession.DAXInfo.Intestazione
            manifest.SelfDescription.Label = String.Format("{0}_{1}", _InfoConservazione.Tipologia.ToString(), _LoginSession.DAXInfo.Label)
            manifest.SelfDescription.TsGenerazione = Date.Now.ToString("s")

            '_InfoConservazione.Tipologia.ToString()-- registro


            manifest.Contenuti = New Schemi.SIPContenuti
            manifest.Contenuti.CustomInfoSchemas = New Schemi.SIPContenutiCustomInfoSchemas
            ' manifest.Contenuti.CustomInfoSchemas.DigDoc = New 

            manifest.Contenuti.Item = New Schemi.SIPContenutiItem(1) {}
            Dim itm As New Schemi.SIPContenutiItem
            itm.type = Schemi.ItemType.SD

            itm.Id = _LoginSession.ChiaveRegistro.ID

            Dim SDInfo = New Schemi.SDStdInfo
            SDInfo.Identificativo = New Schemi.SDStdInfoIdentificativo
            SDInfo.Identificativo.FormaNativa = String.Format("{0}.{1}", _InfoConservazione.Tipologia.ToString(), Date.Now.ToString("dd-MM-yyyy"))
            SDInfo.RifCronologici = New Schemi.DateRefTipizzato(1) {}
            SDInfo.RifCronologici(0) = New Schemi.DateRefTipizzato With {.Data = _InfoConservazione.Data}
            SDInfo.DesOgg = New Schemi.LongDescription With {.Value = _InfoConservazione.Oggetto}
            SDInfo.DigDocs = New Schemi.SDStdInfoDigDocs(_InfoConservazione.Files.Count - 1) {}
            SDInfo.Conservazione = New Schemi.DatiConservazione
            SDInfo.Conservazione.Item = Schemi.FlagOn.Item1

            Dim i As Integer = 0
            For Each File In _InfoConservazione.Files
                Dim flConservazione As New Schemi.SDStdInfoDigDocs
                flConservazione.Id = String.Format("ID-{0}", IO.Path.GetFileNameWithoutExtension(File.NomeFile))
                flConservazione.RelVsSD = Schemi.RelVsSD.P
                flConservazione.SupportoFisico = New Schemi.RifDizionario
                flConservazione.SupportoFisico.Item = "D"
                flConservazione.SupportoFisico.ItemElementName = Schemi.ItemChoiceType1.Codice
                flConservazione.Tipo = New Schemi.RifEntitaContesto
                flConservazione.Tipo.ItemElementName = Schemi.ItemChoiceType.Intestazione
                flConservazione.Tipo.Item = _LoginSession.TipologiaUnitaDocumentaria


                'ATTRIBUTI CUSTOM

                If _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiRegistroProtocollo Then

                    Dim attributi = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiRegistroProtocollo)

                    flConservazione.AttributoCustom = New Schemi.ValoriAttributo(6) {}

                    flConservazione.AttributoCustom(0) = New Schemi.ValoriAttributo With {.Item = attributi.DataPrimaRegistrazione.ToString("yyyy-MM-dd"), .NomeAttributo = "REGISTRAZIONI_DAL"}
                    flConservazione.ComponentiDigitali = New Schemi.ComponentiDigitaliDoc



                    flConservazione.AttributoCustom(1) = New Schemi.ValoriAttributo With {.Item = attributi.DataUltimaRegistrazione.ToString("yyyy-MM-dd"), .NomeAttributo = "REGISTRAZIONI_AL"}
                    flConservazione.ComponentiDigitali = New Schemi.ComponentiDigitaliDoc


                    flConservazione.AttributoCustom(2) = New Schemi.ValoriAttributo With {.Item = attributi.NumeroPrimaRegistrazione.ToString, .NomeAttributo = "MIN_NRO_IN_REGISTRO"}
                    flConservazione.ComponentiDigitali = New Schemi.ComponentiDigitaliDoc



                    flConservazione.AttributoCustom(3) = New Schemi.ValoriAttributo With {.Item = attributi.NumeroUltimaRegistrazione.ToString, .NomeAttributo = "MAX_NRO_IN_REGISTRO"}
                    flConservazione.ComponentiDigitali = New Schemi.ComponentiDigitaliDoc


                    flConservazione.AttributoCustom(4) = New Schemi.ValoriAttributo With {.Item = attributi.DataUltimaRegistrazione.ToString("yyyy-MM-ddTHH:mm:ss"), .NomeAttributo = "MIN_DT_ORA_IN_REGISTRO"}
                    flConservazione.ComponentiDigitali = New Schemi.ComponentiDigitaliDoc



                    flConservazione.AttributoCustom(5) = New Schemi.ValoriAttributo With {.Item = attributi.DataUltimaRegistrazione.ToString("yyyy-MM-ddTHH:mm:ss"), .NomeAttributo = "MAX_DT_ORA_IN_REGISTRO"}
                    flConservazione.ComponentiDigitali = New Schemi.ComponentiDigitaliDoc
                End If
                '------------------------

                flConservazione.ComponentiDigitali.FilePrincipale = New Schemi.File
                flConservazione.ComponentiDigitali.FilePrincipale.Path = String.Format("{0}", File.NomeFile)
                flConservazione.ComponentiDigitali.FilePrincipale.Hash = New Schemi.FileHash
                flConservazione.ComponentiDigitali.FilePrincipale.Hash.encoding = Schemi.DigestEncoding.hex
                flConservazione.ComponentiDigitali.FilePrincipale.Hash.func = Schemi.HashFunc.SHA256
                flConservazione.ComponentiDigitali.FilePrincipale.Hash.Value = Utility.Compute.GetHashSHA256toHEXString(File.Buffer)
                SDInfo.DigDocs(i) = flConservazione

            Next
            itm.Item = SDInfo
            manifest.Contenuti.Item(i) = itm


            Dim flTemp = System.IO.Path.GetTempFileName()
            Using st = New System.IO.FileStream(flTemp, System.IO.FileMode.OpenOrCreate)
                Dim S = New System.Xml.Serialization.XmlSerializer(manifest.GetType())
                S.Serialize(st, manifest)

            End Using


            Dim dc = New XmlDocument()
            'dc.PreserveWhitespace = True
            dc.Load(flTemp)
            System.IO.File.Delete(flTemp)


            Dim ByteManifest As Byte() = Nothing
            Using ms As New MemoryStream
                dc.Save(ms)
                ByteManifest = ms.ToArray
            End Using

            Dim PacchettoDAX As Byte() = GetDAXZipFile(ByteManifest, _InfoConservazione.Files)
            Return PacchettoDAX
        End Function



        Friend Function GetDAXZipFile(ByteManifest As Byte(), files As List(Of ProgettoEnte.Conservazione.Shared.File)) As Byte()
            Dim compressedBytes As Byte()
            Using outStream = New MemoryStream()
                Using archive = New ZipArchive(outStream, ZipArchiveMode.Create, True)
                    Dim fileInArchive1 = archive.CreateEntry("SIPManifest.xml", CompressionLevel.Optimal)
                    Using entryStream = fileInArchive1.Open()
                        Using fileToCompressStream = New MemoryStream(ByteManifest)
                            fileToCompressStream.CopyTo(entryStream)
                        End Using
                    End Using
                    For Each file In files
                        Dim fileInArchive = archive.CreateEntry(String.Format("{0}", file.NomeFile), CompressionLevel.Optimal)
                        Using entryStream = fileInArchive.Open()
                            Using fileToCompressStream = New MemoryStream(file.Buffer)
                                fileToCompressStream.CopyTo(entryStream)
                            End Using
                        End Using
                    Next
                End Using
                compressedBytes = outStream.ToArray()
            End Using
            '  System.IO.File.WriteAllBytes("C:\\output\\pacchetto.zip", compressedBytes)
            Return compressedBytes
        End Function

        Private Function GetConservationInfo(BufferXML As String) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended
            Dim logModule As String = "GetConservationInfo"

            Dim resp As New Xml.XmlDocument()
            resp.LoadXml(BufferXML)
            Dim objResponse As Conservazione.Schemi.receiveSipResponse

            Dim writer As Serialization.XmlSerializer = New Serialization.XmlSerializer(GetType(Conservazione.Schemi.receiveSipResponse))

            Dim respNode = resp.GetElementsByTagName("ns2:receiveSipResponse")
            Dim xmlString As String = respNode.Item(0).OuterXml
            Dim buffer As Byte() = ASCIIEncoding.UTF8.GetBytes(xmlString)
            Dim ms As MemoryStream = New MemoryStream(buffer)
            Dim rd1 As StreamReader = New StreamReader(ms)
            objResponse = writer.Deserialize(ms)



            If objResponse IsNot Nothing Then


                LogSystem.Log(_LoginSession, logModule, "Rilevato Identificatore di Versamento", True)

                Dim CO As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.TokenID = _LoginSession.ChiaveRegistro.ID,
                    .Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok,
                    .Descrizione = "Richiesta di conservazione inoltrata correttamente.",
                    .IdC = ASCIIEncoding.UTF8.GetBytes(BufferXML)}

                Dim token = objResponse.sipReceiveResponse.idSip

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
            End If
            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function



        Friend Function GetXmlDataSoap(PacchettoSip As Byte()) As String


            Dim att As New Schemi.attachment
            att.dh = PacchettoSip
            Dim allegati = New Schemi.attachment(0) {}
            allegati(0) = att

            Dim sipReceive As New Schemi.receiveSipSipReceive
            sipReceive.improntaAlgoritmo = "SHA-256"
            sipReceive.improntaCodifica = "hex"
            sipReceive.impronta = Utility.Compute.GetHashSHA256toHEXString(PacchettoSip)
            Dim sipFile As New Schemi.receiveSip
            sipFile.arg1 = allegati
            sipFile.sipReceive = sipReceive
            Dim File = System.IO.Path.GetTempFileName()
            Using i = New System.IO.FileStream(File, System.IO.FileMode.OpenOrCreate)
                Dim S = New System.Xml.Serialization.XmlSerializer(sipFile.GetType())
                S.Serialize(i, sipFile)

            End Using
            Dim dc = New XmlDocument()
            dc.PreserveWhitespace = True
            dc.Load(File)
            System.IO.File.Delete(File)

            Dim str As String = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sip=""http://sip.esito.core.iris.eng.it"">
                                   <soapenv:Header />                                
                                   <soapenv:Body>" &
                                        dc.ChildNodes(2).OuterXml & "
                                   </soapenv:Body>
                               </soapenv:Envelope>"

            'Dim resp As New XmlDocument
            'resp.PreserveWhitespace = True
            'resp.LoadXml(str)
            Return str


        End Function





    End Class
End Namespace