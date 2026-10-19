Imports System.IO

Public Module DictionaryExtensions
     
    ''' <summary>
    ''' Template for a multipart/form-data item.
    ''' </summary>
    Public Const FormDataTemplate As String = "--{0}" & vbCr & vbLf & "Content-Disposition: form-data; name=""{1}""" & vbCr & vbLf & vbCr & vbLf & "{2}" & vbCr & vbLf

    ''' <summary>
    ''' Writes a dictionary to a stream as a multipart/form-data set.
    ''' </summary>
    ''' <param name="dictionary">The dictionary of form values to write to the stream.</param>
    ''' <param name="stream">The stream to which the form data should be written.</param>
    ''' <param name="mimeBoundary">The MIME multipart form boundary string.</param>
    ''' <exception cref="System.ArgumentNullException">
    ''' Thrown if <paramref name="stream" /> or <paramref name="mimeBoundary" /> is <see langword="null" />.
    ''' </exception>
    ''' <exception cref="System.ArgumentException">
    ''' Thrown if <paramref name="mimeBoundary" /> is empty.
    ''' </exception>
    ''' <remarks>
    ''' If <paramref name="dictionary" /> is <see langword="null" /> or empty,
    ''' nothing wil be written to the stream.
    ''' </remarks>
    <System.Runtime.CompilerServices.Extension> _
    Public Sub WriteMultipartFormData(dictionary As Dictionary(Of String, String), stream As Stream, mimeBoundary As String)
        If dictionary Is Nothing OrElse dictionary.Count = 0 Then
            Return
        End If
        If stream Is Nothing Then
            Throw New ArgumentNullException("stream")
        End If
        If mimeBoundary Is Nothing Then
            Throw New ArgumentNullException("mimeBoundary")
        End If
        If mimeBoundary.Length = 0 Then
            Throw New ArgumentException("MIME boundary may not be empty.", "mimeBoundary")
        End If
        For Each key As String In dictionary.Keys
            Dim item As String = [String].Format(FormDataTemplate, mimeBoundary, key, dictionary(key))
            Dim itemBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(item)
            stream.Write(itemBytes, 0, itemBytes.Length)
        Next
    End Sub
End Module

