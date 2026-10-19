Namespace Autenthicate
    Public MustInherit Class LoginInfo

        Private _InfoLogin As LoginManager
        ReadOnly Property InfoLogin As LoginManager
            Get
                Return _InfoLogin
            End Get
        End Property

        Private _Ente As Data.EnteBase
        ReadOnly Property Ente As Data.EnteBase
            Get
                Return _Ente
            End Get
        End Property

        Private _EnteUtente As  Data.EnteUtenteBase
        ReadOnly Property EnteUtente As  Data.EnteUtenteBase
            Get
                Return _EnteUtente
            End Get
        End Property
         
        Sub New(InfoLogin As LoginManager, Ente As Data.EnteBase, User As Data.EnteUtenteBase)
            _Ente = Ente
            _EnteUtente = User
            _InfoLogin = InfoLogin
        End Sub
         
    End Class
End Namespace