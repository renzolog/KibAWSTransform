Namespace Utility
    ''' <summary>
    ''' Gestore dei atutenticità dei Certificati Server
    ''' </summary> 
    Friend Class CertificationManager

        ''' <summary>
        ''' Delegato ad autorizzare i Certificati server ritenuti attendibili
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="certificate"></param>
        ''' <param name="chain"></param>
        ''' <param name="sslpolicyerror"></param>
        ''' <returns>TRUE se server attendibile</returns>
        ''' <remarks>per uso interno delle singole connessioni</remarks>
        Public Function ValidateServerCertificate(sender As Object, certificate As System.Security.Cryptography.X509Certificates.X509Certificate, _
                                                chain As System.Security.Cryptography.X509Certificates.X509Chain, sslpolicyerror As System.Net.Security.SslPolicyErrors) As Boolean
            Return True
        End Function

    End Class
End Namespace
