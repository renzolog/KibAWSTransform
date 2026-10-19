Imports System.Net
Imports ProgettoEnte.Conservazione.Conservatori.Infocert.Shared
Imports System.IO
Imports System.Text

Namespace Conservatori.Infocert.Rettifica
    Public Class Document

        Private _InfoConservazione As ProgettoEnte.Conservazione.Shared.ConservationInfo

        Private _LoginSession As Autenticazione.InforcertLoginSession
        Public ReadOnly Property LoginSession() As Autenticazione.InforcertLoginSession
            Get
                Return _LoginSession
            End Get
        End Property

        Friend Sub New(LoginSession As Autenticazione.InforcertLoginSession, Info As ProgettoEnte.Conservazione.[Shared].RettificaInfo)
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
        End Sub


        Friend Function Rettifica(Tokens As List(Of Data.HashedToken)) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfo
            Dim logModule As String = "Rettifica"
            LogSystem.Log(_LoginSession, logModule, "Avvio Rettifica")

            If _InfoConservazione.Files.Count <> 1 Or Tokens.Count > 1 Then
                Throw New ArgumentOutOfRangeException("Files", "Impossibile Rettificare più di un file contemporaneamente per Inforcert")
            End If

            Dim token As Data.HashedToken = Tokens(0)

            Dim File As ProgettoEnte.Conservazione.Shared.File = _InfoConservazione.Files(0)


            Try
                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(SharedInfo.URIDocument(_LoginSession.Ente, _LoginSession.Bucket, token.Token), ProgettoEnte.Conservazione.Shared.MetodoHTTP.PUT, ProgettoEnte.Conservazione.[Shared].MultipartFormData)
                myRequest.Headers.Add("ldsessionid", _LoginSession.ldSessionId)



                Dim boundary As String = ProgettoEnte.Conservazione.Shared.GenericHTTP.Multi.Utility.CreateFormDataBoundary
                myRequest.ContentType = "multipart/form-data; boundary=" + boundary
                Dim requestStream As Stream = myRequest.GetRequestStream()


                Dim Path As String

                If _InfoConservazione.Tipologia = ProgettoEnte.Conservazione.Shared.TipoOggetto.Determina AndAlso _InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso
                    TypeOf _InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiDetermina AndAlso String.IsNullOrEmpty(CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDetermina).TipoAtto) = False Then
                    Dim lDet = CType(_InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDetermina)
                    Path = String.Format("/{0}/{1}/{2}/{3}/{4}/{5}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, _InfoConservazione.Tipologia, lDet.TipoAtto.PulisciWithRegEx(25).Replace(" ", ""), _InfoConservazione.IndiceRegistro.Anno, _InfoConservazione.IndiceRegistro.Numero, Now.Ticks)
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
                    Path = String.Format("/{0}/{1}/{2}/{3}/{4}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, _InfoConservazione.Tipologia, _InfoConservazione.IndiceRegistro.Anno, _InfoConservazione.IndiceRegistro.Numero, Now.Ticks)
                End If

                Path = Path.Replace("#", "_")

                Dim INDEXFILE As New Conservazione.IndexFile(_InfoConservazione, _LoginSession.ChiaveRegistro.CodiceUnitaDocumentaria, "")

                Dim PARAMFILE As New Conservazione.ParametersFile(_LoginSession.Policy, File, INDEXFILE, Path)
                PARAMFILE.GetBuffer.WriteMultipartFormData(requestStream, boundary, Utility.Compute.getMimeEncoded(ProgettoEnte.Conservazione.Shared.MimeType.XML), "PARAMFILE", "conserve.xml")

                INDEXFILE.GetBuffer.WriteMultipartFormData(requestStream, boundary, Conservatori.Infocert.Conservazione.IndexFile.mimetype, "INDEXFILE", "index.xml")


                File.Buffer.WriteMultipartFormData(requestStream, boundary, Utility.Compute.getMimeEncoded(File.Mime), "DATAFILE", File.NomeFile)


                Dim endBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(String.Format("--{0}--", boundary))
                requestStream.Write(endBytes, 0, endBytes.Length)


                'IO.File.WriteAllBytes(IO.Path.Combine(LogSystem.Folder, "conserve.xml"), PARAMFILE.GetBuffer)
                'IO.File.WriteAllBytes(IO.Path.Combine(LogSystem.Folder, "index.xml"), INDEXFILE.GetBuffer)
                'IO.File.WriteAllBytes(IO.Path.Combine(LogSystem.Folder, File.NomeFile), File.Buffer)

                LogSystem.Log(_LoginSession, logModule, "Rilevo Risposta")
                Using response As HttpWebResponse = myRequest.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", response.StatusCode))

                    If response.StatusCode = HttpStatusCode.Created Then
                        Dim data(response.ContentLength) As Byte
                        If response.ContentLength <= 0 Then
                            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, "ContentLength = 0")
                        End If
                        response.GetResponseStream().Read(data, 0, data.Length)
                        Dim a As New Kibernetes.Certificate.Manager
                        Dim c As New Kibernetes.Certificate.Cms.CmsSignedData(data)

                        If a.Verifica(c) Then
                            LogSystem.Log(_LoginSession, logModule, "Verifica Firma: OK")
                            If c.SignedContent IsNot Nothing Then
                                Dim GC As Object = c.SignedContent.GetContent
                                If GC IsNot Nothing AndAlso TypeOf GC Is Byte() Then
                                    Using ms As New MemoryStream(CType(GC, Byte()))
                                        Using sr As New StreamReader(ms)
                                            Dim Buffer As String = sr.ReadToEnd
                                            LogSystem.Log(_LoginSession, logModule, String.Format("Risposta: {0}", Buffer))
                                            Return GetConservationInfo(Buffer, token.Token)
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
                        LogSystem.Log(_LoginSession, logModule, String.Format("Rilevato e tento di caricare XML di: {0}", buffer))
                        Throw [Shared].Utility.GetErrorInfoException(logModule, buffer)
                    End If

                End Using

            Catch wex As System.Net.WebException
                Throw [Shared].Utility.ManageWebException(logModule, wex, _LoginSession)
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function

        Private Function GetConservationInfo(BufferXML As String, ReplaceToken As String) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfo
            Dim logModule As String = "GetConservationInfo"

            Dim Response As New Xml.XmlDocument()
            Response.LoadXml(BufferXML)

            If Response.DocumentElement.Name = "IdC" Then '
                LogSystem.Log(_LoginSession, logModule, "Rilevato Identificatore di Versamento")

                Dim CO As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.TokenID = _LoginSession.ChiaveRegistro.ID, .Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Descrizione = "Richiesta di conservazione inoltrata correttamente."} ' Response.SelectSingleNode("IdC/VdC/ID").InnerText

                Dim EmbeddedMetadata As Xml.XmlNode = Response.SelectSingleNode("IdC/VdC/MoreInfo/EmbeddMetadata")
                Dim token = (From f As Xml.XmlNode In EmbeddedMetadata.ChildNodes Where f.Attributes.GetNamedItem("key").Value = "token" Select f.InnerText).SingleOrDefault

                If String.IsNullOrEmpty(token) Then
                    Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, "Impossibile trovare il token nella risposta")
                End If



                Try

                    Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)
                    r.SetToken(_LoginSession.ChiaveRegistro.ID, token, _InfoConservazione.Files, ReplaceToken)

                Catch ex As System.Exception
                    LogSystem.LogException(_LoginSession, logModule, "Errore su set token: " & ex.Message, ex)
                End Try

                LogSystem.Log(_LoginSession, logModule, String.Format("Identificatore di Versamento: {0}", CO.ToString))

                Return CO
            End If
            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function

    End Class

End Namespace
