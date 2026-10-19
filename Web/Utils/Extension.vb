
Module Extension

    <System.Runtime.CompilerServices.Extension()>
    Function DBNullIfEmpty(value As String) As Object
        If String.IsNullOrEmpty(value) Then
            Return DBNull.Value
        Else
            Return value
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function DBNullIfZero(value As Integer) As Object
        If value = 0 Then
            Return DBNull.Value
        Else
            Return value
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function DBNullIfZero(value As Double) As Object
        If value = 0 Then
            Return DBNull.Value
        Else
            Return value
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function DBNullIfZero(Valore As Date) As Object
        If Valore.Year <= 1799 Then
            Return DBNull.Value
        Else
            Return Valore
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function DBNullIfZero(Valore As TimeSpan?) As Object
        If Valore Is Nothing OrElse IsDBNull(Valore) Then
            Return DBNull.Value
        Else
            Return Valore
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function TruncateOrDBNullIfEmpty(value As String, MaxLenght As Integer) As Object
        If String.IsNullOrEmpty(value) Then
            Return DBNull.Value
        Else
            Return Truncate(value, MaxLenght)
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function Truncate(value As String, MaxLenght As Integer) As String
        If String.IsNullOrEmpty(value) Then
            Return ""
        Else
            If value.Length > MaxLenght Then
                Return String.Format("{0}...", value.Substring(0, MaxLenght - 4))
            Else
                Return value
            End If
        End If
    End Function


    <System.Runtime.CompilerServices.Extension()> Function ZeroIfDBNull(value As Object) As Integer
        If value Is Nothing OrElse IsDBNull(value) Then
            Return 0
        Else
            Dim res As Integer
            Integer.TryParse(value, res)
            Return res
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()> Function ToDouble00(value As String) As Double
        If String.IsNullOrEmpty(value) Then
            Return 0
        Else
            Dim res As Double
            Double.TryParse(value, res)
            Return res / 100
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function DBSQLMinIfZero(Valore As Date) As Date
        If Valore.Year <= 1799 Then
            Return New Date(1799, 12, 31)
        Else
            Return Valore
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function DBSQLMaxIfZero(Valore As Date) As Date
        If Valore.Year <= 1799 Then
            Return New Date(2999, 12, 31)
        Else
            Return Valore
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function EURORoundedValue(value As Double) As Double
        Return Math.Round(value, 2, MidpointRounding.AwayFromZero)
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function DobuleToString16(value As Double) As String

        Dim buffer As String = value.ToString("n2").Replace(".", "")

        Return buffer.PadLeft(16, " ")
    End Function

    ''' <summary>
    ''' Verifica se la stringa sembra essere un indirizzo email valido
    ''' </summary>
    ''' <param name="value">Indirizzo Email da verificare</param>
    ''' <returns>True se valido, altrimenti False</returns>
    <System.Runtime.CompilerServices.Extension()>
    Function IsValidEmail(value As String) As Boolean

        Dim r As New Text.RegularExpressions.Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        Return r.IsMatch(value)

    End Function


    <System.Runtime.CompilerServices.Extension()>
    Public Function MaxIfEmpty(Valore As Integer?) As Integer
        If Valore Is Nothing Then
            Return 9999999
        Else
            Dim res As Integer
            Integer.TryParse(Valore, res)
            Return res
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function DBNullIfZero(value As Double?) As Object
        If value Is Nothing Then
            Return DBNull.Value
        End If
        If value = 0 Then
            Return DBNull.Value
        Else
            Return value
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function DBNullIfEmpty(value As Byte()) As Object
        If value Is Nothing OrElse value.Length = 0 Then
            Return DBNull.Value
        Else
            Return value
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function DBNullIfZero(Valore As Date?) As Object
        If Valore Is Nothing Then
            Return DBNull.Value
        End If
        If CDate(Valore).Year <= 1799 Then
            Return DBNull.Value
        Else
            Return Valore
        End If
    End Function

    ''' <summary>
    ''' Ritorna DBNULL se vuoto altrimenti Liked (%) se valorizzato
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()>
    Function DBNullIfEmptyOrSQLLiked(value As String) As Object
        If String.IsNullOrEmpty(value) Then
            Return DBNull.Value
        Else
            Return value & "%"
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function DBNullIfZero(value As Integer?) As Object
        If value Is Nothing OrElse value = 0 Then
            Return DBNull.Value
        Else
            Return value
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function ToStringN2(value As Double, Optional DecimaliConPunto As Boolean = True) As String

        Dim Valore As String = String.Format("{0:n2}", value)

        Valore = Replace(Valore, ".", "")
        If DecimaliConPunto Then
            Valore = Replace(Valore, ",", ".")
        End If


        Return Valore
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function PrimaLetteraMaiuscola(value As String) As String
        If String.IsNullOrEmpty(value) Then
            Return ""
        ElseIf value.Length = 1 Then
            Return UCase(value)
        Else
            Return String.Format("{0}{1}", UCase(value.Substring(0, 1)), value.Substring(1))
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function FillOrTruncate(value As String, Lenght As Integer) As String
        If String.IsNullOrEmpty(value) Then
            value = ""
        End If

        If value.Length > Lenght Then
            value = value.Substring(0, Lenght)
        End If

        Return value.PadRight(Lenght, " ")

    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function FillOrTruncate(value As Integer, Lenght As Integer) As String

        Dim vs As String = value.ToString.Trim


        If vs.Length > Lenght Then
            Return vs.Substring(0, Lenght)
        End If

        Return vs.PadLeft(Lenght, "0")

    End Function

    Function BooleanToStringCB(value As Boolean) As String
        If value Then
            Return "1"
        Else
            Return "0"
        End If
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Function NothingIfZero(value As Integer) As Object
        If value = 0 Then
            Return Nothing
        Else
            Return value
        End If
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Function StringEmptyIfZero(value As Integer) As String
        If value = 0 Then
            Return String.Empty
        Else
            Return value
        End If
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Function StringEmptyIfZero(value As Date) As String
        If value.Year <= 1799 Then
            Return String.Empty
        Else
            Return value
        End If
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Function StringEmptyIfZero(value As Double) As String
        If value = 0 Then
            Return String.Empty
        Else
            Return value
        End If
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Function NothingIfZero(value As Short) As Object
        If value = 0 Then
            Return Nothing
        Else
            Return value
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function NothingIfZero(value As Double) As Object
        If value = 0 Then
            Return Nothing
        Else
            Return value
        End If
    End Function


    <System.Runtime.CompilerServices.Extension()>
    Function Deserializza(Of t)(value As String) As t
        If String.IsNullOrEmpty(value) Then
            Return Nothing
        End If
        Dim obj As t = Nothing
        Try
            Dim serConfigurazione As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(t))
            Dim buffer As Byte() = Text.ASCIIEncoding.UTF8.GetBytes(value)
            If buffer IsNot Nothing Then
                Using ms As New IO.MemoryStream(buffer)
                    obj = serConfigurazione.Deserialize(ms)
                End Using
            End If
        Catch ex As Exception

        End Try
        Return obj
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function Serializza(Of t)(value As Object) As String

        If value Is Nothing Then
            Return String.Empty
        End If

        Dim configurazione As String = String.Empty
        Try
            Dim ser As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(t))
            Using ms As New IO.MemoryStream
                ser.Serialize(ms, value)
                configurazione = System.Text.Encoding.UTF8.GetString(ms.ToArray())
            End Using
        Catch ex As Exception

        End Try
        Return configurazione

    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function FromStringToDouble(value As String) As Double

        If String.IsNullOrEmpty(value) Then
            Return 0
        End If

        value = Replace(value, ",", "")
        value = Replace(value, ".", ",")

        Dim rtValore As Double
        Double.TryParse(value.ToString, rtValore)

        Return rtValore
    End Function
End Module
