Imports System.Net
Imports System.Net.Security
Imports System.IO
Imports System.Text

Namespace Utility
    Friend Class HTTPRest

        Public Shared Function CreateHttpWebRequest(Uri As String, Method As [Shared].MetodoHTTP, ContentType As String) As HttpWebRequest

            If ServicePointManager.ServerCertificateValidationCallback Is Nothing Then
                ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf [Shared].Info.cert.ValidateServerCertificate)
            End If

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 Or SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12


            LogSystem.Log(Nothing, "CreateHttpWebRequest", String.Format("Creo oggetto su {0} Metodo {1} con ContentType {2}", Uri, Method, ContentType), True)
            Dim myRequest As HttpWebRequest = WebRequest.Create(Uri)
            myRequest.ContentType = ContentType
            myRequest.Method = Method.ToString
            LogSystem.Log(Nothing, "CreateHttpWebRequest", "Creato oggetto", True)

            Return myRequest
        End Function

        Public Shared Sub SetContent(Request As HttpWebRequest, postData As String)

            LogSystem.Log(Nothing, "SetContent", String.Format("Encoding di: {0}", postData), True)

            Dim encoding As New UTF8Encoding()
            Dim data() As Byte = encoding.GetBytes(postData)

            Request.ContentLength = data.Length

            LogSystem.Log(Nothing, "SetContent", String.Format("Scrivo {0} byte", data.Length), True)

            Using newStream As Stream = Request.GetRequestStream()
                newStream.Write(data, 0, data.Length)
                newStream.Close()
            End Using

            LogSystem.Log(Nothing, "SetContent", String.Format("Content scritto"), True)

        End Sub


    End Class
End Namespace
