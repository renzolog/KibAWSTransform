Imports System.Net
Imports System.IO
Imports System.IO.Compression

Namespace Conservatori.PARER.Esibizione
    Friend Class Document


        Private _LoginSession As Autenticazione.PARERLoginSession


        Protected Sub New()

        End Sub

        ''' <summary>
        ''' Crea una nuova classe per le funzioni di conservazione
        ''' </summary>
        ''' <param name="LoginSession"></param>
        Public Sub New(LoginSession As Autenticazione.PARERLoginSession)
            _LoginSession = LoginSession

            If _LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginSession"))
            End If
            If _LoginSession.PARERLoginInfo Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginInfo"))
            End If

            If String.IsNullOrEmpty(_LoginSession.UserNameEsibizione) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("UserNameEsibizione"))
            End If
            If String.IsNullOrEmpty(_LoginSession.PasswordEsibizione) Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("PasswordEsibizione"))
            End If

            LogSystem.Log(LoginSession, "Create Document", _LoginSession.ToString)
        End Sub
 

        Friend Function Esibisci(ByVal lEsibisciArgs As EsibizioneArgs) As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo
            Dim logModule As String = "Esibisci"
            LogSystem.Log(_LoginSession, logModule, "Avvio Esibisci")

            If lEsibisciArgs Is Nothing OrElse lEsibisciArgs.Token Is Nothing Then
                Throw New ArgumentNullException("Token", "Token Mancante")
            End If

            If lEsibisciArgs.Token.Anno = 0 OrElse String.IsNullOrEmpty(lEsibisciArgs.Token.Numero) OrElse String.IsNullOrEmpty(lEsibisciArgs.Token.CodiceUnitaDocumentaria) Then
                Throw New ArgumentNullException("Token", "Token sconosciuto")
            End If

            Try

                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(Conservatori.PARER.Shared.getURIBaseEsibizione(_LoginSession.Ente.InCollaudo),
                                                                        ProgettoEnte.Conservazione.Shared.MetodoHTTP.POST,
                                                                        ProgettoEnte.Conservazione.[Shared].MultipartFormData)

                myRequest.Timeout = 1900000
                Dim boundary As String = ProgettoEnte.Conservazione.Shared.GenericHTTP.Multi.Utility.CreateFormDataBoundary
                myRequest.ContentType = "multipart/form-data; boundary=" + boundary
                Dim requestStream As Stream = myRequest.GetRequestStream()

                Conservatori.PARER.Shared.VersioneEsibizione.WriteMultipartFormData(requestStream, boundary, "VERSIONE")
                _LoginSession.UserNameEsibizione.WriteMultipartFormData(requestStream, boundary, "LOGINNAME")
                _LoginSession.PasswordEsibizione.WriteMultipartFormData(requestStream, boundary, "PASSWORD")

                LogSystem.Log(_LoginSession, logModule, "Creo Request")

                Request.Create(_LoginSession, lEsibisciArgs).WriteMultipartFormData(requestStream, boundary, "XMLSIP")

                Dim endBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(String.Format("--{0}--", boundary))
                requestStream.Write(endBytes, 0, endBytes.Length)

                LogSystem.Log(_LoginSession, logModule, "Rilevo Risposta")
                Using response As HttpWebResponse = myRequest.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", response.StatusCode))



                    Dim archive As Compression.ZipArchive = Nothing



                    Dim a As Compression.ZipArchive = Nothing




                    Try
                        LogSystem.Log(_LoginSession, logModule, "Lettura Flusso Risposta")


                        Dim st As IO.Stream = response.GetResponseStream


                        Dim buffer As Byte() = Nothing
                        Dim nb As Integer = My.Settings.ByteOffSet
                        Dim pos As Integer = 0
                        LogSystem.Log(_LoginSession, logModule, "Analisi Flusso")


                        While nb > 0
                            nb = My.Settings.ByteOffSet
                            ReDim Preserve buffer(pos + (nb - 1))
                            LogSystem.Log(_LoginSession, logModule, "Posizione " & pos)

                            nb = st.Read(buffer, pos, nb)
                            ' LogSystem.Log(logModule, "---> Byte Risposta " & nb)

                            pos = pos + nb
                        End While


                        Try
                            archive = New Compression.ZipArchive(New MemoryStream(buffer))
                            If archive IsNot Nothing AndAlso lEsibisciArgs.ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.AllZip) Then
                                Dim lst As New List(Of ProgettoEnte.Conservazione.Shared.FileBase)

                                lst.Add(New ProgettoEnte.Conservazione.Shared.FileBase() With {.Buffer = buffer,
                                                                                                    .NomeFile = "PacchettoVersato.zip"})
                                Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Files = lst}
                            End If
                        Catch ex As Exception

                        End Try

                        If archive IsNot Nothing Then
                            LogSystem.Log(_LoginSession, logModule, "Apertura x-zip-compressed")
                            Dim lst As New List(Of ProgettoEnte.Conservazione.Shared.FileBase)
                            For Each entry As ZipArchiveEntry In archive.Entries
                                LogSystem.Log(_LoginSession, logModule, String.Format("Rilevato File: {0}", entry.FullName))

                                If lEsibisciArgs.ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.All) _
                                    OrElse (lEsibisciArgs.ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.Signed) AndAlso entry.FullName.ToLower.EndsWith(".p7m")) _
                                    OrElse (lEsibisciArgs.ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.Original) AndAlso ( _
                                            entry.Name.ToLower.StartsWith(_LoginSession.PARERInfo.Ambiente.ToLower & "_" & _LoginSession.PARERInfo.DenominazioneEnte.ToLower & "_" & _LoginSession.PARERInfo.Struttura.ToLower))) Then
                                    lst.Add(New ProgettoEnte.Conservazione.Shared.FileBase() With {.Buffer = ProgettoEnte.Conservazione.Utility.Compute.IOStreamToBytes(entry.Open),
                                                                                                    .NomeFile = IO.Path.GetFileName(entry.FullName),
                                                                                                    .Cartella = IO.Path.GetDirectoryName(entry.FullName)})

                                    'Dim path As String = IO.Path.Combine(LogSystem.Folder, entry.FullName)

                                    'If IO.Directory.Exists(IO.Path.GetDirectoryName(path)) = False Then
                                    '    IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(path))
                                    'End If

                                    'IO.File.WriteAllBytes(path, ProgettoEnte.Conservazione.Utility.Compute.IOStreamToBytes(entry.Open))
                                    LogSystem.Log(_LoginSession, logModule, "Stato File: -----> Accettato")
                                Else
                                    LogSystem.Log(_LoginSession, logModule, "Stato File: -----> Scartato")
                                End If
                            Next
                            Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Files = lst}
                        Else
                            LogSystem.Log(_LoginSession, logModule, "Analisi Risposta")

                            If Buffer IsNot Nothing AndAlso Buffer.Length > 0 Then

                                Dim seeEsito As New Xml.Serialization.XmlSerializer(GetType(Schemi.Response.StatoConservazione))
                                Dim Esito As Schemi.Response.StatoConservazione
                                Try
                                    Using reader As New MemoryStream(Buffer)
                                        Esito = seeEsito.Deserialize(reader)




                                        LogSystem.Log(_LoginSession, logModule, String.Format("Rilevato  {0}", Esito.EsitoGenerale.MessaggioErrore))

                                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, Esito.EsitoGenerale.MessaggioErrore)


                                        LogSystem.Log(_LoginSession, logModule, String.Format("Rilevato e tento di caricare XML di: {0}", buffer))
                                    End Using
                                Catch ri As Conservatori.Shared.Exception.RichiestaInconsistenteException
                                    LogSystem.LogFile(_LoginSession, logModule, "Risposta.xml", buffer)
                                    Throw ri
                                Catch ex As Exception
                                    LogSystem.LogFile(_LoginSession, logModule, "Risposta.xml", buffer)
                                    Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, ex.Message)
                                End Try


                            Else
                                LogSystem.Log(_LoginSession, logModule, "Nesuna Risposta")

                            End If
                        End If


                    Catch ri As Conservatori.Shared.Exception.RichiestaInconsistenteException
                        Throw ri

                    Catch ex As Exception
                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)
                    Finally
                        If archive IsNot Nothing Then
                            archive.Dispose()
                        End If
                    End Try
                End Using
                Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

            Catch ri As Conservatori.Shared.Exception.RichiestaInconsistenteException
                Throw ri

            Catch ex As Exception
                Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, ex.Message)
            End Try

        End Function
    End Class



End Namespace
