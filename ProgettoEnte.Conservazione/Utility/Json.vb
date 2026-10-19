
Namespace Utility
    Public Class Json

        Sub New()

        End Sub


        Shared Function DeserializzaJson(Of T)(Value As String) As T
            Dim obj = Newtonsoft.Json.JsonConvert.DeserializeObject(Of T)(Value)
            Return obj
        End Function

    End Class

End Namespace
