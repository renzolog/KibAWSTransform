Imports System.Net
Imports ProgettoEnte.Conservazione.Conservatori.Infocert.Shared
Imports System.IO
Imports System.IO.Compression

Namespace Conservatori.Infocert.Esibizione
    Public Class Document

        Private _LoginSession As Autenticazione.InforcertLoginSession
        Public ReadOnly Property LoginSession() As Autenticazione.InforcertLoginSession
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
#End Region
        Friend Function Esibisci(Tokens As List(Of Data.HashedToken), ReturnFlags As ProgettoEnte.Conservazione.Shared.FileFlags) As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo
            Dim a As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo = Nothing


            Dim Eliminati As New List(Of Integer)
            Dim Rettificati As New List(Of Integer)

            Dim cnt As Integer
            For Each t As Data.HashedToken In Tokens
                Dim res As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo = Esibisci(t.Token, ReturnFlags)
                If res IsNot Nothing Then
                    cnt = cnt + 1
                    If res.StatusFiles = ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile.Eliminato Then
                        Eliminati.Add(cnt)
                    ElseIf res.StatusFiles = ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile.Rettificato Then
                        Rettificati.Add(cnt)
                    End If

                    If a Is Nothing Then
                        a = New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo
                        a.Descrizione = res.Descrizione
                        a.Status = res.Status
                        a.Files = res.Files
                        a.StatusFiles = res.StatusFiles
                    Else
                        a.Files.AddRange(res.Files)
                    End If
                End If
            Next



            If a IsNot Nothing AndAlso a.Files IsNot Nothing AndAlso a.Files.Count > 1 AndAlso ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.AllZip) Then
                'Dim path = "c:\temp\" & Tokens(0).TokenID

                Dim path = IO.Path.GetTempPath
                path = IO.Path.Combine(path, "PEConserva_" & Tokens(0).TokenID)

                If IO.Directory.Exists(path) Then
                    IO.Directory.Delete(path, True)
                End If
                IO.Directory.CreateDirectory(path)

                Dim File As String = String.Format("{0}\PacchettoVersato.zip", IO.Path.GetTempPath)
                If IO.File.Exists(File) Then
                    Try
                        IO.File.Delete(File)
                    Catch ex As System.Exception

                    End Try
                End If

                ZipFile.CreateFromDirectory(path, File)

                Using zipToOpen As FileStream = New FileStream(File, FileMode.Open)
                    Using archive As ZipArchive = New ZipArchive(zipToOpen, ZipArchiveMode.Update)
                        cnt = 0
                        For Each f In a.Files
                            cnt = cnt + 1
                            IO.File.WriteAllBytes(String.Format("{0}\PacchettoVersato{1}.zip", path, cnt), f.Buffer)

                            If Eliminati.Contains(cnt) Then
                                archive.CreateEntryFromFile(String.Format("{0}\PacchettoVersato{1}.zip", path, cnt), String.Format("ELIMINATO-PacchettoVersato{0}.zip", cnt), CompressionLevel.Fastest)
                            ElseIf Rettificati.Contains(cnt) Then
                                archive.CreateEntryFromFile(String.Format("{0}\PacchettoVersato{1}.zip", path, cnt), String.Format("RETTIFICATO-PacchettoVersato{0}.zip", cnt), CompressionLevel.Fastest)
                            Else
                                archive.CreateEntryFromFile(String.Format("{0}\PacchettoVersato{1}.zip", path, cnt), String.Format("PacchettoVersato{0}.zip", cnt), CompressionLevel.Fastest)
                            End If
                        Next
                    End Using
                End Using


                a.Files = New List(Of ProgettoEnte.Conservazione.Shared.FileBase)
                a.Files.Add(New ProgettoEnte.Conservazione.Shared.FileBase With {.NomeFile = "PacchettoVersato.zip", .Buffer = IO.File.ReadAllBytes(File)})

                Try
                    IO.Directory.Delete(path, True)
                Catch ex As System.Exception

                End Try

                Try
                    IO.File.Delete(File)
                Catch ex As System.Exception

                End Try

            End If



            Return a

        End Function

        Friend Function Esibisci(Token As String, ReturnFlags As ProgettoEnte.Conservazione.Shared.FileFlags) As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo
            Dim logModule As String = "Esibisci"
            LogSystem.Log(_LoginSession, logModule, "Avvio Esibisci")

            Try
                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(SharedInfo.URIDocument(_LoginSession.Ente, _LoginSession.Bucket, Token), ProgettoEnte.Conservazione.Shared.MetodoHTTP.GET, ProgettoEnte.Conservazione.[Shared].MultipartFormData)
                myRequest.Headers.Add("ldsessionid", _LoginSession.ldSessionId)
                myRequest.Accept = "application/x-zip-compressed"

                Using response As HttpWebResponse = myRequest.GetResponse()
                    LogSystem.Log(_LoginSession, logModule, String.Format("Rilevata Risposta HTTP {0}", response.StatusCode))

                    If response.StatusCode = HttpStatusCode.OK Then
                        Dim st As IO.Stream = response.GetResponseStream

                        Dim Status As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile = ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile.Originale

                        Dim Changed As String = response.Headers.Get("X-Document-Status")
                        If Changed IsNot Nothing Then
                            If Changed.ToString = "D" Then
                                Status = ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile.Eliminato
                            ElseIf Changed.ToString = "R" Then
                                Status = ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo.TipoStatusFile.Rettificato
                            End If
                        End If

                        Dim lst As New List(Of ProgettoEnte.Conservazione.Shared.FileBase)
                        LogSystem.Log(_LoginSession, logModule, "Apertura x-zip-compressed")

                        If ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.AllZip) Then

                            lst.Add(New ProgettoEnte.Conservazione.Shared.FileBase() With {.Buffer = ProgettoEnte.Conservazione.Utility.Compute.IOStreamToBytes(st), .NomeFile = "PacchettoVersato.zip"})


                            Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Files = lst, .StatusFiles = Status}


                        End If

                        Using archive As New Compression.ZipArchive(st)
                            For Each entry As ZipArchiveEntry In archive.Entries
                                LogSystem.Log(_LoginSession, logModule, String.Format("Rilevato File: {0}", entry.FullName))

                                If ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.All) _
                                    OrElse (ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.Signed) AndAlso entry.FullName.ToLower.Contains(Token.ToLower) AndAlso entry.FullName.ToLower.EndsWith(".p7m")) _
                                    OrElse (ReturnFlags.HasFlag(ProgettoEnte.Conservazione.Shared.FileFlags.Original) AndAlso ( _
                                            entry.FullName.ToLower <> "conserve.xml" And entry.FullName.ToLower <> "index.xml" And entry.FullName.ToLower.Contains(Token.ToLower) = False)) Then
                                    lst.Add(New ProgettoEnte.Conservazione.Shared.FileBase() With {.Buffer = ProgettoEnte.Conservazione.Utility.Compute.IOStreamToBytes(entry.Open), .NomeFile = entry.FullName})

                                    'IO.File.WriteAllBytes(IO.Path.Combine(LogSystem.Folder, entry.FullName), ProgettoEnte.Conservazione.Utility.Compute.IOStreamToBytes(entry.Open))
                                    LogSystem.Log(_LoginSession, logModule, "Stato File: -----> Accettato")
                                Else
                                    LogSystem.Log(_LoginSession, logModule, "Stato File: -----> Scartato")
                                End If
                            Next
                        End Using

                        Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Ok, .Files = lst, .StatusFiles = Status}
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
    End Class
End Namespace
