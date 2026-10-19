Namespace [Shared]
    Public Class RettificaInfo
        Implements [Shared].IRiferimentiArgs

        Public Property File As File

        Public Property TokenID As Integer Implements IRiferimentiArgs.TokenID
        Protected Property ReturnFlags As FileFlags Implements IRiferimentiArgs.ReturnFlags
        Public Property Hash As String Implements IRiferimentiArgs.Hash
        Public Property AttributiSpecifici As ProgettoEnte.Conservazione.Conservatori.Shared.Attributi

    End Class
End Namespace
