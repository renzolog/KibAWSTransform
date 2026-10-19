Imports System.Security.Cryptography
Namespace Utility
    Public Class Compute




        Shared Function GetHashSHA256toHEXString(Buffer As Byte()) As String
            Dim sha = Security.Cryptography.SHA256.Create()
            Dim hash = sha.ComputeHash(Buffer)
            Return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant()
        End Function



        Shared Function GetHash(Buffer As Byte()) As String

            Dim mySHA256 As SHA256 = SHA256Managed.Create()
            Dim hashValue() As Byte = mySHA256.ComputeHash(Buffer)
            mySHA256.Clear()
            Dim oSb As New System.Text.StringBuilder()
            For Each b As Byte In hashValue
                oSb.Append(b.ToString("x2"))
            Next
            Return oSb.ToString

        End Function

        Shared Function GetHash(Buffer As String) As String

            Dim bytValue As Byte() = System.Text.Encoding.UTF8.GetBytes(Buffer)

            Dim mySHA256 As SHA256 = SHA256Managed.Create()
            Dim hashValue As Byte() = mySHA256.ComputeHash(bytValue)
            mySHA256.Clear()
            Dim oSb As New System.Text.StringBuilder()
            For Each b As Byte In hashValue
                oSb.Append(b.ToString("x2"))
            Next
            Return oSb.ToString

        End Function

        Shared Function IOStreamToBytes(BaseStream As IO.Stream) As Byte()
            Dim bytes(1023) As Byte

            Dim numBytesRead As Integer = BaseStream.Read(bytes, 0, 1024)
            Dim numBytesReaded As Integer
            While numBytesRead > 0
                numBytesReaded = numBytesReaded + numBytesRead
                ReDim Preserve bytes(bytes.Length + numBytesRead - 1)
                numBytesRead = BaseStream.Read(bytes, numBytesReaded, 1024)
            End While

            ReDim Preserve bytes(numBytesReaded)

            Return bytes

        End Function

        Shared Function getMimeEncoded(Mime As [Shared].MimeType) As String

            If Mime = [Shared].MimeType.XML Then
                Return "text/xml;1.0"
            ElseIf Mime = [Shared].MimeType.XML_P7M Then
                Return "application/pkcs7;NA|text/xml;1.0"
            ElseIf Mime = [Shared].MimeType.PDF Then
                Return "application/pdf;NA"
            ElseIf Mime = [Shared].MimeType.PDF_P7M Then
                Return "application/pkcs7;NA|application/pdf;NA"
            ElseIf Mime = [Shared].MimeType.TXT Then
                Return "text/plain;NA"
            ElseIf Mime = [Shared].MimeType.DOC Then
                Return "application/msword;NA"
            ElseIf Mime = [Shared].MimeType.DOCX Or Mime = [Shared].MimeType.DOT Then
                Return "application/msword;2007"
            ElseIf Mime = [Shared].MimeType.XLS Then
                Return "application/vnd.ms-excel"
            ElseIf Mime = Mime = [Shared].MimeType.XLSX Then
                Return "application/vnd.ms-excel;2007"
            ElseIf Mime = [Shared].MimeType.P7M Then
                Return "application/pkcs7;NA|application/pdf;NA"
            ElseIf Mime = [Shared].MimeType.PDF_P7M Then
                Return "application/pkcs7;NA|application/pdf;NA"
            ElseIf Mime = [Shared].MimeType.DOCX_P7M Then
                Return "application/pkcs7;NA|application/msword;2007"
            ElseIf Mime = [Shared].MimeType.DOC_P7M Then
                Return "application/pkcs7;NA|application/msword;NA"
            ElseIf Mime = [Shared].MimeType.TXT_P7M Then
                Return "application/pkcs7;NA|text/plain;NA"
            ElseIf Mime = [Shared].MimeType.GIF Then
                Return "image/gif;NA"
            ElseIf Mime = [Shared].MimeType.ODT Then
                Return "application/vnd.oasis.opendocument.text;NA"
            ElseIf Mime = [Shared].MimeType.EML Then
                Return "message/rfc822;NA"
            ElseIf Mime = [Shared].MimeType.JPEG Then
                Return "image/jpeg;NA"
            ElseIf Mime = [Shared].MimeType.TIF Or Mime = [Shared].MimeType.TIFF Then
                Return "image/tiff;NA"
            End If

            Return "text/plain;NA"

            LogSystem.LogException(Nothing, "getMimeEncoded", "Mime non gestito:" & Mime.ToString, Nothing)

            Return ""
        End Function

        Shared Function getMimeString(Mime As [Shared].MimeType) As String
            Return Mime.ToString.Replace("_", ".")
        End Function
    End Class
End Namespace
