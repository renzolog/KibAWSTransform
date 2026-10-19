Imports System.Net
Imports ProgettoEnte.Conservazione.Conservatori.Infocert.Shared
Imports System.IO
Imports System.Text

Namespace Conservatori.Infocert.Conservazione
    ''' <summary>
    ''' Conserva un Documento in Infocert
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Document

        Private _InfoConservazione As ProgettoEnte.Conservazione.Shared.ConservationInfo

        Private _LoginSession As Autenticazione.InforcertLoginSession
        Public ReadOnly Property LoginSession() As Autenticazione.InforcertLoginSession
            Get
                Return _LoginSession
            End Get
        End Property

#Region "Creazione"
        Protected Sub New()

        End Sub

 
        Friend Sub New(LoginSession As Autenticazione.InforcertLoginSession, Info As ProgettoEnte.Conservazione.Shared.ConservationInfo)
            _LoginSession = LoginSession
            Valida()
            _LoginSession.setExtraInfo(Info)

            If _LoginSession.ChiaveRegistro Is Nothing OrElse _LoginSession.ChiaveRegistro.ID = 0 Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("ChiaveRegistro", "Chiave di registro non valorizzata"))
            End If
            If Info.IndiceRegistro Is Nothing Then
                Info.IndiceRegistro = _LoginSession.ChiaveRegistro
            End If

            _InfoConservazione = Info


            LogSystem.Log(LoginSession, "Create Document", LoginSession.ToString)
        End Sub
#End Region
        Friend Sub New(LoginSession As Autenticazione.InforcertLoginSession, Info As ProgettoEnte.Conservazione.[Shared].AggiuntaAllegatiInfo)
            _LoginSession = LoginSession
            Valida()

            _InfoConservazione = New ProgettoEnte.Conservazione.Shared.ConservationInfo
            _LoginSession.setExtraInfo(Info.TokenID, _InfoConservazione.Tipologia)

            If _LoginSession.ChiaveRegistro Is Nothing OrElse _LoginSession.ChiaveRegistro.ID = 0 Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("ChiaveRegistro", "Chiave di registro non valorizzata"))
            End If

            _InfoConservazione.Data = Now.Date
            _InfoConservazione.Files = New List(Of ProgettoEnte.Conservazione.[Shared].File)
            _InfoConservazione.Files.Add(Info.File)
            _InfoConservazione.IndiceRegistro = _LoginSession.ChiaveRegistro
            _InfoConservazione.AttributiSpecifici = Info.AttributiSpecifici
            _InfoConservazione.TipoDocumentoPrincipale = Info.TipoDocumento
            LogSystem.Log(LoginSession, "Create Document", LoginSession.ToString)
        End Sub

        Private Sub Valida()
            If _LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginSession"))
            End If
            If String.IsNullOrEmpty(_LoginSession.ldSessionId) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LDSessionId"))
            End If
            If String.IsNullOrEmpty(_LoginSession.Bucket) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Bucket"))
            End If
            If String.IsNullOrEmpty(_LoginSession.Policy) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Policy"))
            End If
        End Sub



        ''' <summary>
        ''' Chiamata a Conservazione del Documento
        ''' </summary> 
        ''' <returns>Un oggetto <seealso cref="ProgettoEnte.Conservazione.Shared.ConservationResponseInfo">ConservationResponseInfo</seealso></returns> 
        Friend Function Conserva() As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended
            Dim logModule As String = "Conserva"
            LogSystem.Log(_LoginSession, logModule, "Avvio Conserva", True)

            If _InfoConservazione.Files.Count <> 1 Then
                Throw New ArgumentOutOfRangeException("Files", "Impossibile conservare più di un file contemporaneamente per Inforcert")
            End If

            Dim File As ProgettoEnte.Conservazione.Shared.File = _InfoConservazione.Files(0)
            Dim PARAMFILE As ParametersFile = Nothing
            Dim INDEXFILE As IndexFile = Nothing
            Dim nomelog As String = ""

            Try
                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(SharedInfo.URIDocument(_LoginSession.Ente, _LoginSession.Bucket), ProgettoEnte.Conservazione.Shared.MetodoHTTP.POST, ProgettoEnte.Conservazione.[Shared].MultipartFormData)
                myRequest.Headers.Add("ldsessionid", _LoginSession.ldSessionId)



                Dim boundary As String = ProgettoEnte.Conservazione.Shared.GenericHTTP.Multi.Utility.CreateFormDataBoundary
                myRequest.ContentType = "multipart/form-data; boundary=" + boundary
                Dim requestStream As Stream = myRequest.GetRequestStream()

                Dim Path As String

                If _InfoConservazione.Tipologia = ProgettoEnte.Conservazione.Shared.TipoOggetto.Determina AndAlso _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso
                    TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiDetermina AndAlso String.IsNullOrEmpty(CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDetermina).TipoAtto) = False Then
                    Dim lDet = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDetermina)
                    Path = String.Format("/{0}/{1}/{2}/{3}/{4}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, _InfoConservazione.Tipologia, lDet.TipoAtto.PulisciWithRegEx(25).Replace(" ", ""), _InfoConservazione.IndiceRegistro.Anno, _InfoConservazione.IndiceRegistro.Numero)
                ElseIf _InfoConservazione.Tipologia = ProgettoEnte.Conservazione.Shared.TipoOggetto.Delibera AndAlso _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso
                    TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera AndAlso String.IsNullOrEmpty(CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDelibera).TipoAtto) = False Then
                    Dim lDet = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDelibera)
                    Path = String.Format("/{0}/{1}/{2}/{3}/{4}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, _InfoConservazione.Tipologia, lDet.TipoAtto.PulisciWithRegEx(25).Replace(" ", ""), _InfoConservazione.IndiceRegistro.Anno, _InfoConservazione.IndiceRegistro.Numero)
                ElseIf _InfoConservazione.Tipologia = ProgettoEnte.Conservazione.Shared.TipoOggetto.DeliberaConsiglio AndAlso _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso
                    TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera AndAlso String.IsNullOrEmpty(CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDelibera).TipoAtto) = False Then
                    Dim lDet = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDelibera)
                    Path = String.Format("/{0}/{1}/{2}/{3}/{4}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, _InfoConservazione.Tipologia, lDet.TipoAtto.PulisciWithRegEx(25).Replace(" ", ""), _InfoConservazione.IndiceRegistro.Anno, _InfoConservazione.IndiceRegistro.Numero)
                ElseIf _InfoConservazione.Tipologia = ProgettoEnte.Conservazione.Shared.TipoOggetto.DeliberaGiunta AndAlso _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso
                    TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiDelibera AndAlso String.IsNullOrEmpty(CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDelibera).TipoAtto) = False Then
                    Dim lDet = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDelibera)
                    Path = String.Format("/{0}/{1}/{2}/{3}/{4}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, _InfoConservazione.Tipologia, lDet.TipoAtto.PulisciWithRegEx(25).Replace(" ", ""), _InfoConservazione.IndiceRegistro.Anno, _InfoConservazione.IndiceRegistro.Numero)
                Else
                    Path = String.Format("/{0}/{1}/{2}/{3}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, _InfoConservazione.Tipologia, _InfoConservazione.IndiceRegistro.Anno, _InfoConservazione.IndiceRegistro.Numero)
                End If


                Try
                    nomelog = _LoginSession.Ente.ISTAT + "_" + _InfoConservazione.Tipologia.ToString
                    nomelog = nomelog + "_" + _InfoConservazione.IndiceRegistro.Anno.ToString + "_" + _InfoConservazione.IndiceRegistro.Numero.ToString
                Catch ex As System.Exception

                End Try

                Path = Path.Replace("#", "_")
                File.NomeFile = File.NomeFile.PulisciWithRegEx(512)

                Dim TipoFile As String = ""
                If _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiFatturaPassiva _
                    AndAlso _LoginSession.EnteUtente.Software = ProgettoEnte.Conservazione.Shared.TipoSoftware.Contabilita Then
                    If String.IsNullOrEmpty(_InfoConservazione.TipoDocumentoPrincipale) = False Then
                        TipoFile = _InfoConservazione.TipoDocumentoPrincipale
                    Else
                        TipoFile = "Principale"
                    End If
                End If



                INDEXFILE = New IndexFile(_InfoConservazione, _LoginSession.ChiaveRegistro.CodiceUnitaDocumentaria, TipoFile)



                PARAMFILE = New ParametersFile(_LoginSession.Policy, File, INDEXFILE, Path)
                PARAMFILE.GetBuffer.WriteMultipartFormData(requestStream, boundary, Utility.Compute.getMimeEncoded(ProgettoEnte.Conservazione.Shared.MimeType.XML), "PARAMFILE", "conserve.xml")

                INDEXFILE.GetBuffer.WriteMultipartFormData(requestStream, boundary, Conservatori.Infocert.Conservazione.IndexFile.mimetype, "INDEXFILE", "index.xml")



                File.Buffer.WriteMultipartFormData(requestStream, boundary, Utility.Compute.getMimeEncoded(File.Mime), "DATAFILE", File.NomeFile)


                Dim endBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(String.Format("--{0}--", boundary))
                requestStream.Write(endBytes, 0, endBytes.Length)

                LogSystem.Log(_LoginSession, logModule, "Rilevo Risposta", True)

                Using response As HttpWebResponse = myRequest.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", response.StatusCode), True)

                    If response.StatusCode = HttpStatusCode.Created Then

                        Dim data() As Byte
                        Using ms As New MemoryStream()
                            Using reader As New StreamReader(response.GetResponseStream)
                                reader.BaseStream.CopyTo(ms)
                                data = ms.ToArray
                            End Using
                        End Using

                        Dim a As New Kibernetes.Certificate.Manager
                        Dim c As New Kibernetes.Certificate.Cms.CmsSignedData(data)

                        If a.Verifica(c) Then
                            LogSystem.Log(_LoginSession, logModule, "Verifica Firma: OK", True)
                            If c.SignedContent IsNot Nothing Then
                                Dim GC As Object = c.SignedContent.GetContent
                                If GC IsNot Nothing AndAlso TypeOf GC Is Byte() Then
                                    Using ms As New MemoryStream(CType(GC, Byte()))
                                        Using sr As New StreamReader(ms)
                                            Dim Buffer As String = sr.ReadToEnd
                                            LogSystem.Log(_LoginSession, logModule, String.Format("Risposta: {0}", Buffer), True)
                                            Return GetConservationInfo(Buffer, data)
                                        End Using
                                    End Using
                                End If
                            End If
                        Else
                            LogSystem.Log(_LoginSession, logModule, LogSystem.SeverityType.Warning, "Verifica Firma KO")
                        End If
                    Else

                        Dim reader As New StreamReader(response.GetResponseStream())
                        Dim buffer As String = reader.ReadToEnd

                        'If String.IsNullOrEmpty(buffer) = False AndAlso buffer.Contains("Data file mime-type") = False Then
                        '    Try
                        '        IO.File.WriteAllBytes($"c:\temp\rafPARAMFILE_{nomelog}.txt", PARAMFILE.GetBuffer)
                        '        IO.File.WriteAllBytes($"c:\temp\rafINDEXFILE_{nomelog}.txt", INDEXFILE.GetBuffer)

                        '        If File IsNot Nothing Then
                        '            IO.File.WriteAllText($"c:\temp\rafNomeFile_{nomelog}.txt", File.NomeFile)
                        '        End If
                        '    Catch exs As System.Exception

                        '    End Try

                        '    Try
                        '        IO.File.WriteAllText($"c:\temp\rafEXEC_{nomelog}.txt", buffer)
                        '    Catch ex As System.Exception

                        '    End Try
                        'End If


                        Throw [Shared].Utility.GetErrorInfoException(logModule, buffer)
                    End If

                End Using

            Catch wex As System.Net.WebException
                Try
                    IO.File.WriteAllBytes($"c:\temp\rafPARAMFILE_{nomelog}.txt", PARAMFILE.GetBuffer)
                    IO.File.WriteAllBytes($"c:\temp\rafINDEXFILE_{nomelog}.txt", INDEXFILE.GetBuffer)

                    If File IsNot Nothing Then
                        IO.File.WriteAllText($"c:\temp\rafNomeFile_{nomelog}.txt", File.NomeFile)
                    End If
                Catch exs As System.Exception

                End Try
                Throw [Shared].Utility.ManageWebException(logModule, wex, _LoginSession)
            Catch f As System.Exception
                Try
                    IO.File.WriteAllBytes($"c:\temp\raf3_{nomelog}.txt", PARAMFILE.GetBuffer)
                Catch exs As System.Exception

                End Try
                LogSystem.LogException(_LoginSession, logModule, f.Message, f)
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function

        ''' <summary>
        ''' Elabora XML di risposta e crea il relativo oggetto <seealso cref="ProgettoEnte.Conservazione.Shared.ConservationResponseInfo">InfocertConservationResponseInfo</seealso>
        ''' </summary>
        ''' <param name="BufferXML">Xml ricevuto</param>
        ''' <returns>Un Oggetto <seealso cref="ProgettoEnte.Conservazione.Shared.ConservationResponseInfo">InfocertConservationResponseInfo</seealso></returns> 
        Private Function GetConservationInfo(BufferXML As String, IdC As Byte()) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended
            Dim logModule As String = "GetConservationInfo"

            Dim Response As New Xml.XmlDocument()
            Response.LoadXml(BufferXML)

            If Response.DocumentElement.Name = "IdC" Then '
                LogSystem.Log(_LoginSession, logModule, "Rilevato Identificatore di Versamento", True)

                Dim CO As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.TokenID = _LoginSession.ChiaveRegistro.ID,
                    .Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok,
                    .Descrizione = "Richiesta di conservazione inoltrata correttamente.",
                    .IdC = IdC}

                Dim EmbeddedMetadata As Xml.XmlNode = Response.SelectSingleNode("IdC/VdC/MoreInfo/EmbeddMetadata")
                Dim token = (From f As Xml.XmlNode In EmbeddedMetadata.ChildNodes Where f.Attributes.GetNamedItem("key").Value = "token" Select f.InnerText).SingleOrDefault

                If String.IsNullOrEmpty(token) Then
                    Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, "Impossibile trovare il token nella risposta")
                End If

                Try

                    Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)
                    r.SetToken(_LoginSession.ChiaveRegistro.ID, token, _InfoConservazione.Files, token)

                    CO.IdCFileName = token & ".xml.p7m"

                Catch ex As System.Exception
                    LogSystem.LogException(_LoginSession, logModule, "Errore su set token: " & ex.Message, ex)
                End Try

                LogSystem.Log(_LoginSession, logModule, String.Format("Identificatore di Versamento: {0}", CO.ToString), True)

                Return CO
            ElseIf Response.DocumentElement.Name = "ns1:PIndex" Then '

                LogSystem.Log(_LoginSession, logModule, "Rilevato Identificatore di Versamento V2", True)

                Dim CO As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.TokenID = _LoginSession.ChiaveRegistro.ID,
                    .Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok,
                    .Descrizione = "Richiesta di conservazione inoltrata correttamente.",
                    .IdC = IdC}

                Dim EmbeddedMetadata As Xml.XmlNode = Response.ChildNodes(1).ChildNodes(0).ChildNodes(0)
                Dim token As String = EmbeddedMetadata.InnerText

                If String.IsNullOrEmpty(token) Then
                    Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, "Impossibile trovare il token nella risposta")
                End If

                Try

                    Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)
                    r.SetToken(_LoginSession.ChiaveRegistro.ID, token, _InfoConservazione.Files, token)

                    CO.IdCFileName = token & ".xml.p7m"

                Catch ex As System.Exception
                    LogSystem.LogException(_LoginSession, logModule, "Errore su set token: " & ex.Message, ex)
                End Try

                LogSystem.Log(_LoginSession, logModule, String.Format("Identificatore di Versamento: {0}", CO.ToString), True)


                Return CO
            End If
            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function


    End Class
End Namespace
