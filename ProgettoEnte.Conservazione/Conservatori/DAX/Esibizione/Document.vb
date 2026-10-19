

Imports System.IO
Imports System.Net

Namespace Conservatori.DAX.Esibizione
    Friend Class Document

        Private _LoginSession As Autenticazione.DAXLoginSession



        ''' <summary>
        ''' Crea una nuova classe per le funzioni di conservazione
        ''' </summary>
        ''' <param name="LoginSession"></param>
        Public Sub New(LoginSession As Autenticazione.DAXLoginSession)
            _LoginSession = LoginSession
            '   _LoginSession.Setextrainfo()


            If _LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginSession"))
            End If
            If _LoginSession.DAXLoginInfo Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginInfo"))
            End If

            'If String.IsNullOrEmpty(_LoginSession.UserNameEsibizione) Then
            '    Throw New UnhandledException("Create Document", New ArgumentNullException("UserNameEsibizione"))
            'End If
            'If String.IsNullOrEmpty(_LoginSession.PasswordEsibizione) Then
            '    Throw New UnhandledException("Create Document", New ArgumentNullException("PasswordEsibizione"))
            'End If

            LogSystem.Log(LoginSession, "Create Document", _LoginSession.ToString)
        End Sub

        Friend Function Esibisci(ByVal lEsibisciArgs As EsibizioneArgs) As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo
            Dim logModule As String = "Esibisci"
            LogSystem.Log(_LoginSession, logModule, "Avvio Esibisci")

            If lEsibisciArgs Is Nothing OrElse lEsibisciArgs.Token Is Nothing Then
                Throw New ArgumentNullException("Token", "Token Mancante")
            End If

            'If lEsibisciArgs.Token.Anno = 0 OrElse String.IsNullOrEmpty(lEsibisciArgs.Token.Numero) OrElse String.IsNullOrEmpty(lEsibisciArgs.Token.CodiceUnitaDocumentaria) Then
            '    Throw New ArgumentNullException("Token", "Token sconosciuto")
            'End If

            Try
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 Or SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                Dim url As String = DAX.Shared.SharedInfo.getURIBaseEsibizione(_LoginSession.Ente.InCollaudo)
                Dim myRequest As HttpWebRequest = WebRequest.Create(url)
                Dim crt As New Utility.CertificationManager
                myRequest.ServerCertificateValidationCallback = AddressOf crt.ValidateServerCertificate

                'user:APPLTEST
                'pwd:Test123

                'myRequest.Headers("H_P_APP_ID") = _LoginSession.UserNameEsibizione
                'myRequest.Headers("H_P_APP_PWD") = _LoginSession.PasswordEsibizione


                myRequest.Headers("H_P_APP_ID") = "APPLTEST"
                myRequest.Headers("H_P_APP_PWD") = "Test123"


                myRequest.ContentType = "text/xml;charset=utf-8"
                myRequest.Accept = "text/xml"
                myRequest.Method = "POST"


                Dim RequestEsibizione = Conservatori.DAX.Esibizione.Request.Create(_LoginSession, lEsibisciArgs)




                LogSystem.Log(_LoginSession, logModule, "Rilevo Risposta", True)
                Using streamWriter = New StreamWriter(myRequest.GetRequestStream())
                    streamWriter.Write(RequestEsibizione)
                End Using




                Using response As HttpWebResponse = myRequest.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", response.StatusCode))


                    If response.StatusCode = 200 Then
                        Using responseStream As New StreamReader(response.GetResponseStream())

                            Dim stringBuffer As String = responseStream.ReadToEnd
                            LogSystem.Log(_LoginSession, logModule, String.Format("Risposta: {0}", stringBuffer), True)
                            Stop

                        End Using
                        LogSystem.Log(_LoginSession, logModule, LogSystem.SeverityType.Warning, "Verifica Firma KO")
                    Else
                        Dim reader As New StreamReader(response.GetResponseStream())
                        Dim buffer As String = reader.ReadToEnd
                        'Throw [Shared].Utility.GetErrorInfoException(logModule, buffer)
                    End If


                    'If response.StatusCode = HttpStatusCode.OK Then
                    '    Dim st As IO.Stream = response.GetResponseStream

                    '    Dim Status As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile = ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile.Originale

                    '    Dim Changed As String = response.Headers.Get("X-Document-Status")
                    '    If Changed IsNot Nothing Then
                    '        If Changed.ToString = "D" Then
                    '            Status = ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile.Eliminato
                    '        ElseIf Changed.ToString = "R" Then
                    '            Status = ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile.Rettificato
                    '        End If
                    '    End If

                    '    Dim lst As New List(Of ProgettoEnte.Conservazione.Shared.FileBase)
                    '    LogSystem.Log(_LoginSession, logModule, "Apertura x-zip-compressed")

                    '    If ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.AllZip) Then

                    '        lst.Add(New ProgettoEnte.Conservazione.Shared.FileBase() With {.Buffer = ProgettoEnte.Conservazione.Utility.Compute.IOStreamToBytes(st), .NomeFile = "PacchettoVersato.zip"})


                    '        Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Files = lst, .StatusFiles = Status}


                    '    End If



                    '    Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Files = lst, .StatusFiles = Status}
                    'Else
                    '    Dim reader As New StreamReader(response.GetResponseStream())
                    '    Dim buffer As String = reader.ReadToEnd
                    '    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevato e tento di caricare XML di: {0}", buffer))
                    '    ' Throw [Shared].Utility.GetErrorInfoException(logModule, buffer)
                    'End If

                End Using
            Catch nt As NotImplementedException
                Throw nt
            Catch wex As System.Net.WebException
                Throw wex
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)




        End Function

    End Class

End Namespace
