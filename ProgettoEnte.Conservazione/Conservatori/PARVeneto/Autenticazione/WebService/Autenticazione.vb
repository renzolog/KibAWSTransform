
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Namespace Conservatori.PARVeneto.Autenticazione.WebService
    Public Class Autenticazione

        Shared Function Request(Login As UserLogin, url As String) As Response
            If Login Is Nothing Then
                Throw New Autenthicate.LoginException("UserLogin", "Parametri  non valorizzati")
            End If

            If String.IsNullOrEmpty(url) Then
                Throw New Autenthicate.LoginException("UserLogin", "Url inesistente")
            End If

            Dim userlogin As String = Newtonsoft.Json.JsonConvert.SerializeObject(Login)
            Dim bt As Byte() = Encoding.UTF8.GetBytes(userlogin)
            System.Net.ServicePointManager.ServerCertificateValidationCallback = AddressOf CertificateHandler
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 Or SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
            Dim wr As HttpWebRequest = WebRequest.Create(url)
            wr.ServerCertificateValidationCallback = AddressOf CertificateHandler
            wr.ContentType = "text/xml;charset=utf-8"
            wr.Accept = "application/json"
            wr.Method = "POST"
            wr.ContentLength = userlogin.Length
            Using streamWriter = New StreamWriter(wr.GetRequestStream())
                streamWriter.Write(userlogin)
            End Using
            Dim response As New Response
            Using rsp As HttpWebResponse = wr.GetResponse()
                Using responseStream As New StreamReader(rsp.GetResponseStream())
                    Dim t = responseStream.ReadToEnd
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Response)(t)
                End Using
            End Using
            Return response
        End Function
        Private Shared Function CertificateHandler(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
            Return True
        End Function

    End Class
End Namespace

