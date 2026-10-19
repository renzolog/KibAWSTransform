Imports System.IO
Imports System.Text


Public Module FileInfoExtensions
 
    ''' <summary>
    ''' Template for a file item in multipart/form-data format.
    ''' </summary>
    Public Const FileHeaderTemplate As String = "--{0}" & vbCr & vbLf & "Content-Disposition: form-data; name=""{1}""; filename=""{2}""" & vbCr & vbLf & "Content-Type: {3}" & vbCr & vbLf & vbCr & vbLf

    ''' <summary>
    ''' Template for a text item in multipart/form-data format.
    ''' </summary>
    Public Const HeaderTemplate As String = "--{0}" & vbCr & vbLf & "Content-Disposition: form-data; name=""{1}""" & vbCr & vbLf & vbCr & vbLf

    ''' <summary>
    ''' Writes a file to a stream in multipart/form-data format.
    ''' </summary> 
    ''' <param name="stream">The stream to which the file should be written.</param>
    ''' <param name="mimeBoundary">The MIME multipart form boundary string.</param>
    ''' <param name="mimeType">The MIME type of the file.</param>
    ''' <param name="formKey">The name of the form parameter corresponding to the file upload.</param>
    ''' <exception cref="System.ArgumentNullException">
    ''' Thrown if any parameter is <see langword="null" />.
    ''' </exception>
    ''' <exception cref="System.ArgumentException">
    ''' Thrown if <paramref name="mimeBoundary" />, <paramref name="mimeType" />,
    ''' or <paramref name="formKey" /> is empty.
    ''' </exception>
    ''' <exception cref="System.IO.FileNotFoundException">
    ''' Thrown if <paramref name="filename" /> does not exist.
    ''' </exception> 
    <System.Runtime.CompilerServices.Extension> _
    Public Sub WriteMultipartFormData(dataFile() As Byte, stream As Stream, mimeBoundary As String, mimeType As String, formKey As String, FileName As String)
        If stream Is Nothing Then
            Throw New ArgumentNullException("stream")
        End If
        If mimeBoundary Is Nothing Then
            Throw New ArgumentNullException("mimeBoundary")
        End If
        If mimeBoundary.Length = 0 Then
            Throw New ArgumentException("MIME boundary may not be empty.", "mimeBoundary")
        End If
        If mimeType Is Nothing Then
            Throw New ArgumentNullException("mimeType")
        End If
        If mimeType.Length = 0 Then
            Throw New ArgumentException("MIME type may not be empty.", "mimeType")
        End If
        If formKey Is Nothing Then
            Throw New ArgumentNullException("formKey")
        End If
        If formKey.Length = 0 Then
            Throw New ArgumentException("Form key may not be empty.", "formKey")
        End If
        Dim header As String = [String].Format(FileHeaderTemplate, mimeBoundary, formKey, FileName, mimeType)
        Dim headerbytes As Byte() = Encoding.UTF8.GetBytes(header)
        stream.Write(headerbytes, 0, headerbytes.Length)
         
        stream.Write(dataFile, 0, dataFile.Length)
         
        Dim newlineBytes As Byte() = Encoding.UTF8.GetBytes(vbCr & vbLf)
        stream.Write(newlineBytes, 0, newlineBytes.Length)
    End Sub

    <System.Runtime.CompilerServices.Extension> _
    Public Sub WriteMultipartFormData(data() As Byte, stream As Stream, mimeBoundary As String, formKey As String)

        If stream Is Nothing Then
            Throw New ArgumentNullException("stream")
        End If
        If mimeBoundary Is Nothing Then
            Throw New ArgumentNullException("mimeBoundary")
        End If
        If mimeBoundary.Length = 0 Then
            Throw New ArgumentException("MIME boundary may not be empty.", "mimeBoundary")
        End If
        If formKey Is Nothing Then
            Throw New ArgumentNullException("formKey")
        End If
        If formKey.Length = 0 Then
            Throw New ArgumentException("Form key may not be empty.", "formKey")
        End If
        Dim header As String = [String].Format(HeaderTemplate, mimeBoundary, formKey)
        Dim headerbytes As Byte() = Encoding.UTF8.GetBytes(header)
        stream.Write(headerbytes, 0, headerbytes.Length)

        stream.Write(data, 0, data.Length)

        Dim newlineBytes As Byte() = Encoding.UTF8.GetBytes(vbCr & vbLf)
        stream.Write(newlineBytes, 0, newlineBytes.Length)



    End Sub

    <System.Runtime.CompilerServices.Extension>
    Public Sub WriteMultipartFormData(data As String, stream As Stream, mimeBoundary As String, formKey As String)
        Dim e As New UTF8Encoding

        Dim dData As Byte() = e.GetBytes(data)

        If stream Is Nothing Then
            Throw New ArgumentNullException("stream")
        End If
        If mimeBoundary Is Nothing Then
            Throw New ArgumentNullException("mimeBoundary")
        End If
        If mimeBoundary.Length = 0 Then
            Throw New ArgumentException("MIME boundary may not be empty.", "mimeBoundary")
        End If
        If formKey Is Nothing Then
            Throw New ArgumentNullException("formKey")
        End If
        If formKey.Length = 0 Then
            Throw New ArgumentException("Form key may not be empty.", "formKey")
        End If
        Dim header As String = [String].Format(HeaderTemplate, mimeBoundary, formKey)
        Dim headerbytes As Byte() = Encoding.UTF8.GetBytes(header)
        stream.Write(headerbytes, 0, headerbytes.Length)

        stream.Write(dData, 0, dData.Length)

        Dim newlineBytes As Byte() = Encoding.UTF8.GetBytes(vbCr & vbLf)
        stream.Write(newlineBytes, 0, newlineBytes.Length)



    End Sub

    <System.Runtime.CompilerServices.Extension>
    Public Function PulisciNew(data As String) As String
        data = data.Replace("à", "a'")
        data = data.Replace("è", "e'")
        data = data.Replace("ì", "i'")
        data = data.Replace("ò", "o'")
        data = data.Replace("ù", "u'")
        Return data
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function Pulisci(data As String) As String

        data = data.Replace("à", "a")
        data = data.Replace("è", "e")
        data = data.Replace("ì", "i")
        data = data.Replace("ò", "o")
        data = data.Replace("ù", "u")

        data = data.Replace("À", "A")
        data = data.Replace("È", "E")
        data = data.Replace("Ì", "I")
        data = data.Replace("Ò", "O")
        data = data.Replace("Ù", "U")

        data = data.Replace("'", " ")
        data = data.Replace("ń", "n")

        data = data.Replace(" ", " ")

        data = data.Replace("°", " ")
        data = data.Replace("–", " ")
        data = data.Replace("@", " ")
        data = data.Replace("’", " ")

        data = data.Replace("+", " ")
        data = data.Replace(",", " ")
        data = data.Replace("^", " ")
        data = data.Replace("€", " ")

        data = data.Replace("?", " ")
        data = data.Replace("`", " ")
        data = data.Replace(vbCrLf, " ")
        data = data.Replace(vbCr, " ")
        data = data.Replace(vbLf, " ")

        For Each c In IO.Path.GetInvalidFileNameChars
            data = data.Replace(c, " ")
        Next

        Return data
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function Pulisci(data As String, MaxLenght As Integer) As String
        data = data.Pulisci
        If String.IsNullOrEmpty(data) = False AndAlso data.Length > MaxLenght Then
            data = data.Substring(0, MaxLenght - 1)
        End If
        Return data
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function PulisciWithRegEx(data As String, MaxLenght As Integer) As String
        data = data.Pulisci(MaxLenght)

        Try
            Dim r As New RegularExpressions.Regex("(?![A-Za-z\d\s\-_\.'])")
            Dim ff = r.Matches(data)
            If ff IsNot Nothing Then
                For Each f As RegularExpressions.Match In ff
                    If f.Index >= data.Length Then
                        Continue For
                    End If
                    data = Replace(data, data.Substring(f.Index, 1), " ")
                Next
            End If
        Catch ex As Exception

        End Try
        Return data
    End Function

    Private Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Module
