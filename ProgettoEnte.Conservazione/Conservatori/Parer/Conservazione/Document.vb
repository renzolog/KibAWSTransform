Imports System.Net
Imports ProgettoEnte.Conservazione.Conservatori.PARER.Shared
Imports System.IO
Imports ProgettoEnte.Conservazione.Shared

Namespace Conservatori.PARER.Conservazione
    Friend Class Document

        Private _InfoConservazione As ConservationInfo
        Private _InfoConservazioneAllegati As AggiuntaAllegatiInfo

        Private _LoginSession As Autenticazione.PARERLoginSession

#Region "Creazione"


        Protected Sub New()

        End Sub

        ''' <summary>
        ''' Crea una nuova classe per le funzioni di conservazione
        ''' </summary>
        ''' <param name="LoginSession"></param>
        Public Sub New(LoginSession As Autenticazione.PARERLoginSession, Info As ConservationInfo)
            If Info Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            _InfoConservazione = Info

            _LoginSession = LoginSession
            _LoginSession.Setextrainfo(Info)
            NewExtracted(LoginSession)


        End Sub

        Public Sub New(LoginSession As Autenticazione.PARERLoginSession, Info As AggiuntaAllegatiInfo)
            If Info Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            _InfoConservazioneAllegati = Info

            _LoginSession = LoginSession
            _LoginSession.Setextrainfo(Info)
            NewExtracted(LoginSession)

        End Sub

#End Region
        Private Sub NewExtracted(ByVal LoginSession As Autenticazione.PARERLoginSession)
            If LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("Info"))
            End If
            If LoginSession.PARERInfo Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("PARERInfo"))
            End If

            If _LoginSession Is Nothing Then
                Throw New UnhandledException("Create Document", New ArgumentNullException("LoginSession"))
            End If
            If _LoginSession.PARERLoginInfo Is Nothing Then
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

        Friend Function Allega() As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended


            Dim logModule As String = "Allega"
            LogSystem.Log(_LoginSession, logModule, "Avvio Allega")

            Try
                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(SharedInfo.getURIBaseConservazioneAllegati(_LoginSession.Ente.InCollaudo),
                                                                                        ProgettoEnte.Conservazione.Shared.MetodoHTTP.POST,
                                                                                        ProgettoEnte.Conservazione.[Shared].MultipartFormData)


                Dim boundary As String = ProgettoEnte.Conservazione.Shared.GenericHTTP.Multi.Utility.CreateFormDataBoundary
                myRequest.ContentType = "multipart/form-data; boundary=" + boundary
                Dim requestStream As Stream = myRequest.GetRequestStream()

                _LoginSession.PARERInfo.VersioneConservazione.WriteMultipartFormData(requestStream, boundary, "VERSIONE")
                _LoginSession.UserName.WriteMultipartFormData(requestStream, boundary, "LOGINNAME")
                _LoginSession.Password.WriteMultipartFormData(requestStream, boundary, "PASSWORD")

                Dim IDDocumento As String = IO.Path.GetFileNameWithoutExtension(_InfoConservazioneAllegati.File.NomeFile)

                LogSystem.Log(_LoginSession, logModule, "Creo SIP")

                SIP.Createallegati(_LoginSession, _InfoConservazioneAllegati, IDDocumento).WriteMultipartFormData(requestStream, boundary, "XMLSIP")

                LogSystem.Log(_LoginSession, logModule, "Includo stream")


                _InfoConservazioneAllegati.File.Buffer.WriteMultipartFormData(requestStream, boundary, "binary/octet-stream", IDDocumento, _InfoConservazioneAllegati.File.NomeFile)

                Dim endBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(String.Format("--{0}--", boundary))
                requestStream.Write(endBytes, 0, endBytes.Length)


                LogSystem.Log(_LoginSession, logModule, "Rilevo Risposta")
                Using response As HttpWebResponse = myRequest.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", response.StatusCode))

                    Dim seeEsito As New Xml.Serialization.XmlSerializer(GetType(Schemi.Response.EsitoVersAggAllegatiType))
                    Dim Esito As Schemi.Response.EsitoVersAggAllegatiType
                    Try
                        Using reader As New StreamReader(response.GetResponseStream)
                            Esito = seeEsito.Deserialize(reader)
                        End Using
                    Catch ex As Exception
                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, ex.Message)
                    End Try

                    If Esito Is Nothing Then
                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, "Esito Nullo")
                    End If

                    Dim e As New Text.ASCIIEncoding
                    Dim Buffer As Byte()

                    Try
                        Using writer As New IO.MemoryStream
                            seeEsito.Serialize(writer, Esito)
                            Buffer = writer.ToArray
                            LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", e.GetString(Buffer)), True)
                        End Using
                    Catch ex As Exception
                    End Try

                    IO.File.WriteAllBytes("c:\temp\prova.xml", Buffer)

                    'Dim st As IO.Stream = response.GetResponseStream

                    'Dim buffer As Byte()

                    'Dim nb As Integer = 1024
                    'Dim pos As Integer = 0
                    'LogSystem.Log(_LoginSession, logModule, "Analisi Flusso")

                    'While nb > 1
                    '    ReDim Preserve buffer(pos + (nb - 1))
                    '    nb = st.Read(buffer, pos, nb)
                    '    pos = pos + nb
                    'End While


                    'IO.File.WriteAllBytes("c:\temp\prova.xml", buffer)


                    'Dim seeEsito As New Xml.Serialization.XmlSerializer(GetType(Schemi.Response.EsitoVersAggAllegatiType))

                    'Dim Esito As Schemi.Response.EsitoVersAggAllegatiType
                    'Try
                    '    Using reader As New MemoryStream(buffer)
                    '        Esito = seeEsito.Deserialize(reader)
                    '    End Using
                    'Catch ex As Exception
                    '    Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, ex.Message)
                    'End Try

                    'If Esito Is Nothing Then
                    '    Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, "Esito Nullo")
                    'End If

                    'Dim e As New Text.ASCIIEncoding

                    'Try
                    '    Using writer As New IO.MemoryStream
                    '        seeEsito.Serialize(writer, Esito)
                    '        buffer = writer.ToArray
                    '        LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", e.GetString(buffer)), True)
                    '    End Using
                    'Catch ex As Exception
                    'End Try

                    LogSystem.Log(_LoginSession, logModule, "Esito Deserializzato correttamente")
                    If Esito.EsitoGenerale.CodiceEsito = Schemi.Response.ECEsitoExtType.NEGATIVO Then
                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, Esito.EsitoGenerale.MessaggioErrore)
                    Else
                        Try
                            Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)
                            Dim Files As New List(Of ProgettoEnte.Conservazione.Shared.File)
                            Files.Add(_InfoConservazioneAllegati.File)
                            r.SetToken(_LoginSession.ChiaveRegistro.ID, Esito.UnitaDocumentaria.Item.ChiaveDoc, Files, "")

                        Catch ex As Exception
                            LogSystem.LogException(_LoginSession, logModule, "Errore su set token: " & ex.Message, ex)
                        End Try

                        Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended With {.TokenID = _LoginSession.ChiaveRegistro.ID,
                            .Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok,
                            .Descrizione = "Richiesta di conservazione inoltrata correttamente.",
                            .IdC = buffer, .IdCFileName = Esito.UnitaDocumentaria.Item.ChiaveDoc & "_IdC.xml"}
                    End If

                End Using
            Catch ex As Conservatori.[Shared].Exception.RichiestaInconsistenteException
                Throw ex
            Catch wex As Exception
                Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, wex.Message)
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function


        Friend Function Conserva() As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended


            Dim logModule As String = "Conserva"
            LogSystem.Log(_LoginSession, logModule, "Avvio Conserva", True)

            Try
                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(SharedInfo.getURIBaseConservazione(_LoginSession.Ente.InCollaudo),
                                                                                        ProgettoEnte.Conservazione.Shared.MetodoHTTP.POST,
                                                                                        ProgettoEnte.Conservazione.[Shared].MultipartFormData)


                Dim boundary As String = ProgettoEnte.Conservazione.Shared.GenericHTTP.Multi.Utility.CreateFormDataBoundary
                myRequest.ContentType = "multipart/form-data; boundary=" + boundary
                Dim requestStream As Stream = myRequest.GetRequestStream()

                _LoginSession.PARERInfo.VersioneConservazione.WriteMultipartFormData(requestStream, boundary, "VERSIONE")
                _LoginSession.UserName.WriteMultipartFormData(requestStream, boundary, "LOGINNAME")
                _LoginSession.Password.WriteMultipartFormData(requestStream, boundary, "PASSWORD")

                Dim IDDocumento As String = "ID"

                LogSystem.Log(_LoginSession, logModule, "Creo SIP")

                SIP.Create(_LoginSession, _InfoConservazione, IDDocumento).WriteMultipartFormData(requestStream, boundary, "XMLSIP")

                LogSystem.Log(_LoginSession, logModule, "Includo stream")

                Dim cnt As Integer
                For Each f As ProgettoEnte.Conservazione.Shared.File In _InfoConservazione.Files
                    f.Buffer.WriteMultipartFormData(requestStream, boundary, "binary/octet-stream", IDDocumento & "-" & cnt + 1, f.NomeFile)
                    cnt = cnt + 1
                Next


                Dim endBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(String.Format("--{0}--", boundary))
                requestStream.Write(endBytes, 0, endBytes.Length)


                LogSystem.Log(_LoginSession, logModule, "Rilevo Risposta")
                Using response As HttpWebResponse = myRequest.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", response.StatusCode))

                    Dim seeEsito As New Xml.Serialization.XmlSerializer(GetType(Schemi.Response.EsitoVersamentoType))

                    Dim Esito As Schemi.Response.EsitoVersamentoType
                    Try
                        Using reader As New StreamReader(response.GetResponseStream)
                            Esito = seeEsito.Deserialize(reader)
                        End Using
                    Catch ex As Exception
                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, ex.Message)
                    End Try

                    If Esito Is Nothing Then
                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, "Esito Nullo")
                    End If

                    Dim e As New Text.ASCIIEncoding
                    Dim Buffer As Byte()

                    Try
                        Using writer As New IO.MemoryStream
                            seeEsito.Serialize(writer, Esito)
                            Buffer = writer.ToArray
                            LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", e.GetString(Buffer)), True)
                        End Using
                    Catch ex As Exception
                    End Try

                    LogSystem.Log(_LoginSession, logModule, "Esito Deserializzato correttamente", True)
                    If Esito.EsitoGenerale.CodiceEsito = Schemi.Response.ECEsitoExtType.NEGATIVO Then
                        Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, Esito.EsitoGenerale.MessaggioErrore)
                    Else
                        Try

                            Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)
                            r.SetToken(_LoginSession.ChiaveRegistro.ID, Esito.UnitaDocumentaria.DocumentoPrincipale.ChiaveDoc, _InfoConservazione.Files, "")

                        Catch ex As Exception
                            LogSystem.LogException(_LoginSession, logModule, "Errore su set token: " & ex.Message, ex)
                        End Try

                        Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended With {.TokenID = _LoginSession.ChiaveRegistro.ID,
                            .Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok,
                            .Descrizione = "Richiesta di conservazione inoltrata correttamente.",
                            .IdC = Buffer, .IdCFileName = Esito.UnitaDocumentaria.DocumentoPrincipale.ChiaveDoc & "_IdC.xml"}
                    End If

                End Using
            Catch ex As Conservatori.[Shared].Exception.RichiestaInconsistenteException
                Throw ex
            Catch wex As Exception
                Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule, wex.Message)
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)


        End Function

    End Class
End Namespace

