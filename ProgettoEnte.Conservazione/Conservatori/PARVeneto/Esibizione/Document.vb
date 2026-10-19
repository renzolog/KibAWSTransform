Imports System.IO
Imports System.Net
Imports System.Text

Namespace Conservatori.PARVeneto.Esibizione


    Friend Class Document
        Private _LoginSession As Autenticazione.PARVenetoLoginSession
        Public ReadOnly Property LoginSession() As Autenticazione.PARVenetoLoginSession
            Get
                Return _LoginSession
            End Get
        End Property

#Region "Creazione"
        Protected Sub New()

        End Sub

        ''' <summary>
        ''' Crea una nuova classe per le funzioni di conservazione
        ''' </summary>
        ''' <param name="LoginSession"></param>
        ''' <remarks>E' obbligatorio specificare il LDSessionId ed il Bucket</remarks>
        Public Sub New(LoginSession As Autenticazione.PARVenetoLoginSession)
            _LoginSession = LoginSession

            If _LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginSession"))
            End If
            'If String.IsNullOrEmpty(_LoginSession.ldSessionId) Then
            '    Throw New UnhandledException("Create Document", New ArgumentNullException("LDSessionId"))
            'End If
            'If String.IsNullOrEmpty(_LoginSession.Bucket) Then
            '    Throw New UnhandledException("Create Document", New ArgumentNullException("Bucket"))
            'End If

            LogSystem.Log(_LoginSession, "Create Document", LoginSession.ToString)
        End Sub
#End Region

        Friend Function Esibisci(ByVal lEsibisciArgs As EsibizioneArgs) As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo
            Dim logModule As String = "Esibisci"
            LogSystem.Log(_LoginSession, logModule, "Avvio Esibisci")

            Try
                Dim UserLogin As New Autenticazione.WebService.UserLogin With {.username = _LoginSession.UserName, .password = _LoginSession.Password}
                Dim Response As Conservatori.PARVeneto.Autenticazione.WebService.Response = Autenticazione.WebService.Autenticazione.Request(UserLogin, PARVeneto.Shared.SharedInfo.getURIBaseAutenticazione(_LoginSession.Ente.InCollaudo))
                Dim crt As New Utility.CertificationManager
                System.Net.ServicePointManager.ServerCertificateValidationCallback = AddressOf crt.ValidateServerCertificate
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 Or SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                Dim wr As HttpWebRequest = WebRequest.Create(PARVeneto.Shared.SharedInfo.getURIBaseEsibizione(_LoginSession.Ente.InCollaudo))
                wr.ServerCertificateValidationCallback = AddressOf crt.ValidateServerCertificate

                wr.Headers.Add("Authorization", Response.token)
                wr.PreAuthenticate = True
                wr.ContentType = "application/json"
                wr.Method = "POST"

                Dim str As String = String.Format("|""pdvid"": ""{0}""£", lEsibisciArgs.Token).Replace("|", "{").Replace("£", "}")
                Dim bt As Byte() = Encoding.UTF8.GetBytes(str)

                wr.ContentLength = bt.Length
                Using StreamUpload As IO.Stream = wr.GetRequestStream()
                    StreamUpload.Write(bt, 0, bt.Length)
                End Using
                Try
                    Using rsp As HttpWebResponse = wr.GetResponse()
                        Using responseStream As New IO.StreamReader(rsp.GetResponseStream())
                            Dim btResp As Byte() = Nothing
                            Using Data As IO.Stream = rsp.GetResponseStream()
                                Using ms As New IO.MemoryStream
                                    Data.CopyTo(ms)
                                    btResp = ms.ToArray
                                End Using
                            End Using
                            If btResp IsNot Nothing Then


                                Dim lst As New List(Of ProgettoEnte.Conservazione.Shared.FileBase)

                                lst.Add(New ProgettoEnte.Conservazione.Shared.FileBase() With {.Buffer = btResp,
                                                                                                        .NomeFile = "PacchettoVersato.zip"})
                                Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Files = lst}

                            Else
                                Dim reader As New StreamReader(rsp.GetResponseStream())
                                Dim buffer As String = reader.ReadToEnd
                                LogSystem.Log(_LoginSession, logModule, String.Format("Rilevato e tento di caricare XML di: {0}", buffer))
                                '      Throw GetErrorInfoException(logModule, buffer)
                            End If

                        End Using
                    End Using


                Catch ex As Exception

                    Throw ex
                End Try

            Catch ex As Exception

                Throw ex
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function
    End Class
End Namespace