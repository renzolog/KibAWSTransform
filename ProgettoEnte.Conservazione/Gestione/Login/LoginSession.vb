Namespace Autenthicate
    Public MustInherit Class LoginSession

        Private _Ente As Data.EnteBase
         ReadOnly Property Ente As Data.EnteBase
             Get
                Return _ente
             End Get
         End Property

        Private _EnteUtente As Data.EnteUtenteBase
          readonly Property EnteUtente As Data.EnteUtenteBase
              Get
                Return _EnteUtente
              End Get
          End Property

        Protected _ChiaveRegistro As Data.ChiaveRegistro
        ReadOnly Property ChiaveRegistro As Data.ChiaveRegistro
            Get
                Return _ChiaveRegistro
            End Get
        End Property

        Sub New(Ente As Data.EnteBase,EnteUtente As Data.EnteUtenteBase)
            _Ente=Ente
            _EnteUtente=EnteUtente
        End Sub
 

    End Class

End Namespace
