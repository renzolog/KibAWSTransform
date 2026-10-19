Namespace Conservatori.Infocert.Shared
    Module SharedInfo

        Public Function GetURISession(Ente As Data.EnteBase) As String
            Return GetURIBase(Ente) & "/session"
        End Function


        Private Function GetURIBase(Ente As Data.EnteBase) As String

            If Ente.InCollaudo Then
                Return "https://conservazionecl.infocert.it/ws"
            Else
                Return "https://conservazione.infocert.it/ws"
            End If

        End Function

        Public Function URIDocument(Ente As Data.EnteBase, Bucket As String) As String
            Return String.Format("{0}/{1}/document", GetURIBase(Ente), Bucket)
        End Function

        Public Function URIDocument(Ente As Data.EnteBase, Bucket As String, Token As String) As String
            Return String.Format("{0}/{1}/document/{2}", GetURIBase(Ente), Bucket, Token)
        End Function
    End Module
End Namespace
