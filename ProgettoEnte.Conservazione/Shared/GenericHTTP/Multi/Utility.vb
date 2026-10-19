Namespace [Shared].GenericHTTP.Multi
    Friend Class Utility

        Public Shared Function CreateFormDataBoundary() As String
            Return DateTime.Now.Ticks.ToString("x")
        End Function

    End Class
End Namespace
