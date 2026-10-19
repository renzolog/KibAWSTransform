Imports System.Net
Imports ProgettoEnte.Conservazione.Conservatori.Infocert.Shared
Imports System.IO

Namespace Conservatori.Infocert.Eliminazione
    Public Class Document
        '    Private _InfoConservazione As ProgettoEnte.Conservazione.Shared.ConservationInfo

        Private _LoginSession As Autenticazione.InforcertLoginSession
        Public ReadOnly Property LoginSession() As Autenticazione.InforcertLoginSession
            Get
                Return _LoginSession
            End Get
        End Property

        Public Sub New(LoginSession As Autenticazione.InforcertLoginSession)
            _LoginSession = LoginSession

            If _LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginSession"))
            End If
            If String.IsNullOrEmpty(_LoginSession.ldSessionId) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LDSessionId"))
            End If
            If String.IsNullOrEmpty(_LoginSession.Bucket) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Bucket"))
            End If




            LogSystem.Log(_LoginSession, "Create Document", LoginSession.ToString)


        End Sub

        Friend Function Elimina(Tokens As List(Of Data.HashedToken), EsibisciInfo As ProgettoEnte.Conservazione.Shared.EsibisciArgs) As ProgettoEnte.Conservazione.Shared.DeleteResponseInfo

            ' todo ricontrollare

            For Each t As Data.HashedToken In Tokens

                If String.IsNullOrEmpty(EsibisciInfo.Hash) OrElse EsibisciInfo.Hash = t.Hash Then
                    Dim InfoConservazione As New ProgettoEnte.Conservazione.Shared.ConservationInfo
                    _LoginSession.setExtraInfo(t.TokenID, InfoConservazione.Tipologia)

                    InfoConservazione.IndiceRegistro = _LoginSession.ChiaveRegistro
                    Return Elimina(t.Token, InfoConservazione)
                End If

            Next

        End Function

        Friend Function Elimina(Token As String, InfoConservazione As ProgettoEnte.Conservazione.Shared.ConservationInfo) As ProgettoEnte.Conservazione.Shared.DeleteResponseInfo
            Dim logModule As String = "Elimina"
            LogSystem.Log(_LoginSession, logModule, "Avvio Elimina")

            Try
                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(SharedInfo.URIDocument(_LoginSession.Ente, _LoginSession.Bucket, Token), ProgettoEnte.Conservazione.Shared.MetodoHTTP.DELETE, ProgettoEnte.Conservazione.[Shared].MultipartFormData)
                myRequest.Headers.Add("ldsessionid", _LoginSession.ldSessionId)

                Dim boundary As String = ProgettoEnte.Conservazione.Shared.GenericHTTP.Multi.Utility.CreateFormDataBoundary
                myRequest.ContentType = "multipart/form-data; boundary=" + boundary
                Dim requestStream As Stream = myRequest.GetRequestStream()

                Dim Path As String

                If InfoConservazione.Tipologia = ProgettoEnte.Conservazione.Shared.TipoOggetto.Determina AndAlso InfoConservazione.AttributiSpecifici IsNot Nothing AndAlso
                    TypeOf InfoConservazione.AttributiSpecifici Is Conservatori.Shared.AttributiDetermina AndAlso String.IsNullOrEmpty(CType(InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDetermina).TipoAtto) = False Then
                    Dim lDet = CType(InfoConservazione.AttributiSpecifici, Conservatori.Shared.AttributiDetermina)
                    Path = String.Format("/{0}/{1}/{2}/{3}/{4}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, InfoConservazione.Tipologia, lDet.TipoAtto.PulisciWithRegEx(25).Replace(" ", ""), InfoConservazione.IndiceRegistro.Anno, InfoConservazione.IndiceRegistro.Numero)
                Else
                    Path = String.Format("/{0}/{1}/{2}/{3}", _LoginSession.InfocertLoginInfo.InfoLogin.Software.ToString, InfoConservazione.Tipologia, InfoConservazione.IndiceRegistro.Anno, InfoConservazione.IndiceRegistro.Numero)
                End If


                Dim PARAMFILE As New Conservazione.ParametersFile(_LoginSession.Policy, Path)
                PARAMFILE.GetBuffer.WriteMultipartFormData(requestStream, boundary, Utility.Compute.getMimeEncoded(ProgettoEnte.Conservazione.Shared.MimeType.XML), "PARAMFILE", "delete.xml")

                Dim endBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(String.Format("--{0}--", boundary))
                requestStream.Write(endBytes, 0, endBytes.Length)

                'IO.File.WriteAllBytes(IO.Path.Combine(LogSystem.Folder, "delete.xml"), PARAMFILE.GetBuffer)


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
                                            Return GetDeleteInfo(Buffer)
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
            Catch nt As NotImplementedException
                Throw nt
            Catch wex As System.Net.WebException
                Throw [Shared].Utility.ManageWebException(logModule, wex, _LoginSession)
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)


        End Function

        Private Function GetDeleteInfo(BufferXML As String) As ProgettoEnte.Conservazione.Shared.DeleteResponseInfo
            Dim logModule As String = "GetDeleteInfo"

            Dim Response As New Xml.XmlDocument()
            Response.LoadXml(BufferXML)

            If Response.DocumentElement.Name = "IdC" Then '
                LogSystem.Log(Nothing, logModule, "Rilevato Identificatore di Eliminazione")
                Return New ProgettoEnte.Conservazione.Shared.DeleteResponseInfo With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Descrizione = "Documento Eliminato"}

            End If
            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function

    End Class
End Namespace

