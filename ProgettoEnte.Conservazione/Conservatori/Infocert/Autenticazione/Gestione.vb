Imports System.Text
Imports System.IO
Imports System.Net.Security
Imports System.Net
Imports ProgettoEnte.Conservazione.Conservatori.Infocert.Shared
Imports System.Xml
Imports System.Data.SqlClient

Namespace Conservatori.Infocert.Autenticazione
    Friend Class Gestione

        Friend Shared Sub Logout(sessione As InforcertLoginSession)
            Dim logModule As String = "Logout"
            LogSystem.Log(sessione, logModule, "Avvio Logout", True)

            Try
                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(SharedInfo.GetURISession(sessione.Ente), ProgettoEnte.Conservazione.Shared.MetodoHTTP.DELETE, ProgettoEnte.Conservazione.[Shared].Applicationxwwwformurlencoded)
                myRequest.Headers.Add("ldsessionid", sessione.ldSessionId)

                LogSystem.Log(sessione, logModule, "Rilevo Risposta", True)
                Using response As HttpWebResponse = myRequest.GetResponse()
                    Dim reader As New StreamReader(response.GetResponseStream())
                    LogSystem.Log(sessione, logModule, reader.ReadToEnd(), True)
                End Using
                Return
            Catch wex As System.Net.WebException
                Throw [Shared].Utility.ManageWebException(logModule, wex, Nothing)
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Sub

        Private Shared Function GetSessionInfo(Info As Autenthicate.LoginInfo, InfocertInfo As Data.EnteInfoINFOCERTBase, loginResponse As Xml.XmlDocument, ByVal u As Data.UnitaDocumentarie) As InforcertLoginSession
            Dim logModule As String = "GetSessionInfo"

            If loginResponse.DocumentElement.Name = "loginResponse" Then '
                LogSystem.Log(Nothing, logModule, "Rilevato loginResponse", True)
                Dim ses As New InforcertLoginSession(Info.Ente, Info.EnteUtente, InfocertInfo)
                ses.Code = loginResponse.SelectSingleNode("loginResponse/code").InnerText
                ses.ldSessionId = loginResponse.SelectSingleNode("loginResponse/LDSessionId").InnerText
                ses.PuntodiVersamento = loginResponse.SelectSingleNode("loginResponse/pdv").InnerText
                ses.Bucket = InfocertInfo.Bucket
                ses.InfocertLoginInfo = Info
                ses.Policy = u.Policy
                LogSystem.Log(Nothing, logModule, String.Format("Validato loginResponse su: {0}", ses.ToString), True)

                Return ses
            End If
            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)

        End Function


        Private _Bucket As String
        Public ReadOnly Property Bucket() As String
            Get
                Return _Bucket
            End Get
        End Property


        Protected Sub New()

        End Sub


        Public Shared Function Login(LoginInfo As InfocertLoginInfo, TipoOggetto As ProgettoEnte.Conservazione.Shared.TipoOggetto) As InforcertLoginSession

            If LoginInfo Is Nothing Then
                Return Nothing
            End If

            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()

                Dim e As New Data.EnteInfoINFOCERT(LoginInfo.EnteUtente.AuthicatedUser)
                e = e.READAttivo(cn)
                If e Is Nothing Then
                    Throw New Autenthicate.LoginException("ReadParametri", "Dati INFOCERT non trovati")
                End If

                Dim u As New Data.UnitaDocumentarie(LoginInfo.EnteUtente.AuthicatedUser)
                u = u.READAttivo(cn, Data.Enum.TipoConservatore.Infocert, TipoOggetto, LoginInfo.InfoLogin.Software)

                Return LoginExtracted(LoginInfo, e, u)
            End Using

        End Function

        Public Shared Function Login(LoginInfo As InfocertLoginInfo, TokenId As Integer) As InforcertLoginSession

            If LoginInfo Is Nothing Then
                Return Nothing
            End If


            Using cn As New SqlConnection(My.Settings.ConnectionString)
                cn.Open()

                Dim e As New Data.EnteInfoINFOCERT(LoginInfo.EnteUtente.AuthicatedUser)
                e = e.READAttivo(cn)
                If e Is Nothing Then
                    Throw New Autenthicate.LoginException("ReadParametri", "Dati INFOCERT non trovati")
                End If

                 
                Dim rb As New Data.Registro(LoginInfo.EnteUtente.AuthicatedUser)
                rb = rb.Read(cn, TokenId)

                If rb Is Nothing Then
                    Throw New ArgumentOutOfRangeException("TokenId", "TokenId non valido")
                End If


                Dim objTD As New Data.UnitaDocumentarie(LoginInfo.EnteUtente.AuthicatedUser)
                objTD = objTD.Read(cn, rb.IDUnitaDocumentaria)
                 
                Return LoginExtracted(LoginInfo, e, objTD)
            End Using


        End Function


        Private Shared Function LoginExtracted(ByVal LoginInfo As InfocertLoginInfo, ByVal e As Data.EnteInfoINFOCERT, ByVal u As Data.UnitaDocumentarie) As InforcertLoginSession
            Dim logModule As String = "Login"
            LogSystem.Log(Nothing, logModule, "Avvio Login", True)
            Dim postData As String = String.Format("userid={0}&password={1}", WebUtility.UrlEncode(u.VersanteUserName), WebUtility.UrlEncode(u.VersantePassword))
            Try


                Dim myRequest As HttpWebRequest = Utility.HTTPRest.CreateHttpWebRequest(SharedInfo.GetURISession(LoginInfo.Ente), ProgettoEnte.Conservazione.Shared.MetodoHTTP.POST, ProgettoEnte.Conservazione.[Shared].Applicationxwwwformurlencoded)
                Utility.HTTPRest.SetContent(myRequest, postData)

                LogSystem.Log(Nothing, logModule, "Rilevo Risposta", True)
                Using response As HttpWebResponse = myRequest.GetResponse()
                    Dim reader As New StreamReader(response.GetResponseStream())

                    Dim buffer As String = reader.ReadToEnd
                    LogSystem.Log(Nothing, logModule, String.Format("Rilevato e tento di caricare XML di: {0}", buffer), True)

                    Dim xml As New Xml.XmlDocument()
                    xml.LoadXml(buffer)

                    LogSystem.Log(Nothing, logModule, "Caricato", True)
                    If xml.DocumentElement.Name = "loginResponse" Then
                        Return GetSessionInfo(LoginInfo, e, xml, u)
                    ElseIf xml.DocumentElement.Name = "error" Then
                        Throw [Shared].Utility.GetErrorInfoException(logModule, buffer)
                    End If

                End Using

            Catch wex As System.Net.WebException
                Throw [Shared].Utility.ManageWebException(logModule & " " & postData, wex, Nothing, postData)
            Catch w As system.Exception
                LogSystem.LogException(Nothing, logModule, w.Message, w)
                Throw New ArgumentOutOfRangeException("LoginExtracted", "Login non valida")
            End Try

            Throw New Conservatori.Shared.Exception.RichiestaInconsistenteException(logModule)
        End Function
    End Class




End Namespace

