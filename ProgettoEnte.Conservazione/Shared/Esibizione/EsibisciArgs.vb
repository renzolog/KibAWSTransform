Namespace [Shared]
 
    Public Interface IRiferimentiArgs
        Property TokenID As Integer
        Property ReturnFlags As ProgettoEnte.Conservazione.Shared.FileFlags
        Property Hash As String
    End Interface

    Public Class EsibisciArgs
        Implements IRiferimentiArgs


        Public Property TokenID As Integer Implements IRiferimentiArgs.TokenID
        Public Property ReturnFlags As ProgettoEnte.Conservazione.Shared.FileFlags Implements IRiferimentiArgs.ReturnFlags
        Public Property Hash As String Implements IRiferimentiArgs.Hash

        Public Sub New()

        End Sub

        Public Sub New(TokenID As Integer, ReturnFlags As ProgettoEnte.Conservazione.Shared.FileFlags)
            Me.TokenID = TokenID
            Me.ReturnFlags = ReturnFlags
        End Sub


    End Class

End Namespace
