Imports System.Runtime.Serialization

Namespace Conservatori.Infocert.Shared
    <DataContract>
    Public Class ErrorInfo
        Property Code As String
        Property Description As String

        Sub New()
            Code = ""
            Description = "Errore non rilevato dal manager"
        End Sub

        Public Overrides Function ToString() As String
            Return String.Format("Code '{0}' - Description '{1}'", Code, Description)
        End Function
    End Class
End Namespace
