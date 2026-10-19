''' <summary>
''' Classe Proxy di puntamento ai vari conservatori riconosciuti
''' </summary>
''' <remarks>Da usare in caso di collegamento tramite limeria dinamica DLL</remarks>
Public Class Gestione
    Implements IDisposable

    Private _LoginSession As Autenthicate.LoginSession
    ''' <summary>
    ''' Oggetto LoginSession specializzato per il conservatore chiamato ed autenticato
    ''' </summary>   
    Public Property LoginSession() As Autenthicate.LoginSession
        Get
            Return _LoginSession
        End Get
        Set(value As Autenthicate.LoginSession)
            _LoginSession = value
        End Set
    End Property

    Public Function Login(Dati As Autenthicate.LoginManager, TokenID As Integer) As Autenthicate.LoginSession
        Const logModule As String = "Login"
        _LoginSession = Nothing

        Dim Info As Autenthicate.LoginInfo = Autenthicate.Login.Effettua(logModule, Dati)

        If TypeOf Info Is Conservatori.Infocert.Autenticazione.InfocertLoginInfo Then
            'LogSystem.Log(logModule, "Rilevato Infocert")
            _LoginSession = Conservatori.Infocert.Autenticazione.Gestione.Login(CType(Info, Conservatori.Infocert.Autenticazione.InfocertLoginInfo), TokenID)
            Return _LoginSession
        ElseIf TypeOf Info Is Conservatori.PARER.Autenticazione.PARERLoginInfo Then
            ' LogSystem.Log(logModule, "Rilevato PARER")
            _LoginSession = Conservatori.PARER.Autenticazione.Gestione.Login(Info)
            Return _LoginSession
        ElseIf TypeOf Info Is Conservatori.DAX.Autenticazione.DAXLoginInfo Then
            LogSystem.Log(logModule, "LOGIN", "Rilevato DAX")
            _LoginSession = Conservatori.DAX.Autenticazione.Gestione.Login(Info)
            Return _LoginSession

        ElseIf TypeOf Info Is Conservatori.PARVeneto.Autenticazione.PARVenetoLoginInfo Then
            LogSystem.Log(logModule, "LOGIN", "Rilevato PARVenento")
            _LoginSession = Conservatori.PARVeneto.Autenticazione.Gestione.Login(Info)
            Return _LoginSession
        Else
            Throw New UnhandledException("Login", New ArgumentOutOfRangeException("Conservatore non riconosciuto"))
        End If

    End Function


    Public Function Login(Dati As Autenthicate.LoginManager, TipoOggetto As ProgettoEnte.Conservazione.Shared.TipoOggetto) As Autenthicate.LoginSession
        Const logModule As String = "Login"
        _LoginSession = Nothing

        Dim Info As Autenthicate.LoginInfo = Autenthicate.Login.Effettua(logModule, Dati)

        If TypeOf Info Is Conservatori.Infocert.Autenticazione.InfocertLoginInfo Then
            'LogSystem.Log(logModule, "Rilevato Infocert")
            _LoginSession = Conservatori.Infocert.Autenticazione.Gestione.Login(CType(Info, Conservatori.Infocert.Autenticazione.InfocertLoginInfo), TipoOggetto)
            Return _LoginSession
        ElseIf TypeOf Info Is Conservatori.PARER.Autenticazione.PARERLoginInfo Then
            ' LogSystem.Log(logModule, "Rilevato PARER")
            _LoginSession = Conservatori.PARER.Autenticazione.Gestione.Login(Info)
            Return _LoginSession
        ElseIf TypeOf Info Is Conservatori.DAX.Autenticazione.DAXLoginInfo Then
            LogSystem.Log(logModule, "LOGIN", "Rilevato DAX")
            _LoginSession = Conservatori.DAX.Autenticazione.Gestione.Login(Info)
            Return _LoginSession
        ElseIf TypeOf Info Is Conservatori.PARVeneto.Autenticazione.PARVenetoLoginInfo Then
            ' LogSystem.Log(logModule, "Rilevato DAX")
            _LoginSession = Conservatori.PARVeneto.Autenticazione.Gestione.Login(Info)
            Return _LoginSession

        Else
            Throw New UnhandledException("Login", New ArgumentOutOfRangeException("Conservatore non riconosciuto"))
        End If

    End Function

    ''' <summary>
    ''' Metodo di Logout dal Conservatore
    ''' </summary>
    ''' <param name="Info">Oggetto LoginSession specializzato ottenuto dal Conservatore</param> 
    ''' <exception cref="ArgumentException">Nel caso in cui l'oggetto non sia valido o sconosciuto</exception>  
    Public Sub Logout(Info As Autenthicate.LoginSession)
        Const logModule As String = "Logout"

        If TypeOf Info Is Conservatori.Infocert.Autenticazione.InforcertLoginSession Then
            ' LogSystem.Log(logModule, "Rilevato Infocert")
            Dim lSessionInfo As Conservatori.Infocert.Autenticazione.InforcertLoginSession = CType(Info, Conservatori.Infocert.Autenticazione.InforcertLoginSession)
            Conservatori.Infocert.Autenticazione.Gestione.Logout(lSessionInfo)
        ElseIf TypeOf Info Is Conservatori.PARER.Autenticazione.PARERLoginSession Then

        ElseIf TypeOf Info Is Conservatori.PARVeneto.Autenticazione.PARVenetoLoginSession Then

        Else
            Throw New UnhandledException("Logout", New ArgumentOutOfRangeException("Conservatore non riconosciuto"))
        End If

    End Sub

    ''' <summary>
    ''' Metodo di Logout dal Conservatore
    ''' </summary> 
    ''' <exception cref="ArgumentException">Nel caso in cui l'oggetto non sia valido o sconosciuto</exception>  
    Friend Sub Logout()
        If _LoginSession IsNot Nothing Then
            Logout(_LoginSession)
        End If
        _LoginSession = Nothing
    End Sub


#Region "IDisposable Support"
    Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Try
                    Logout()
                Catch
                End Try
            End If

            _LoginSession = Nothing
        End If
        Me.disposedValue = True
    End Sub

    ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region "Conservazione"

    Private Sub ValidaConservazione(logModule As String)

        If _LoginSession Is Nothing Then
            Throw New Autenthicate.LoginException(logModule, New ArgumentNullException("LoginSession mancante"))
        End If
        If _LoginSession.EnteUtente Is Nothing Then
            Throw New Autenthicate.LoginException(logModule, New ArgumentNullException("LoginSession Corrotta e/o mancante in EnteUtente"))
        End If
        If _LoginSession.Ente Is Nothing Then
            Throw New Autenthicate.LoginException(logModule, New ArgumentNullException("LoginSession Corrotta e/o mancante in Ente"))
        End If
        If _LoginSession.EnteUtente.Roles.Contains(Data.EnteUtenteBase.RuoloConserva) = False Then
            Throw New Autenthicate.LoginException(logModule, "L'utente non è abilitato alla conservazione")
        End If

    End Sub


    Public Function Rettifica(RettificaInfo As [Shared].RettificaInfo) As [Shared].ConservationResponseInfo
        Const logModule As String = "Rettifica Allegati"
        ValidaConservazione(logModule)

        Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)



        If TypeOf _LoginSession Is Conservatori.Infocert.Autenticazione.InforcertLoginSession Then

                If String.IsNullOrEmpty(RettificaInfo.Hash) Then
                    Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("Hash", "Hash obbligatorio"))

                End If

                '     LogSystem.Log(logModule, "Rilevato Infocert")
                Dim a As New Conservatori.Infocert.Rettifica.Document(_LoginSession, RettificaInfo)


                Dim esibizioneargs As Conservatori.Infocert.Esibizione.EsibizioneArgs = r.GetChiave(RettificaInfo, _LoginSession)
                If esibizioneargs Is Nothing OrElse esibizioneargs.Tokens Is Nothing Then
                    Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("Token non rilevato"))
                End If


            Dim resToken As List(Of Data.HashedToken) = (From lstT In esibizioneargs.Tokens Where lstT.Hash = RettificaInfo.Hash Select lstT).ToList

            If resToken Is Nothing OrElse resToken.Count = 0 Then
                    Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("Associazione Hash Token non rilevata"))
                End If

                Return a.Rettifica(resToken)

            ElseIf TypeOf _LoginSession Is Conservatori.PARER.Autenticazione.PARERLoginSession Then
                Throw New NotImplementedException()
                'todo implementare
                'LogSystem.Log(logModule, "Rilevato PARER")
                'Dim a As New Conservatori.PARER.Conservazione.Document(_LoginSession, ConservationInfo)
                'Return a.Allega
            Else
                Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("_LoginSession", "Conservatore non riconosciuto"))
            End If


    End Function

    Public Function ConservaAllegati(ConservationInfo As [Shared].AggiuntaAllegatiInfo) As [Shared].ConservationResponseInfoExtended
        Const logModule As String = "Conserva Allegati"
        ValidaConservazione(logModule)


        If TypeOf _LoginSession Is Conservatori.Infocert.Autenticazione.InforcertLoginSession Then
            LogSystem.Log(_LoginSession, logModule, "Rilevato Infocert", True)
            Dim a As New Conservatori.Infocert.Conservazione.Document(_LoginSession, ConservationInfo)
            Return a.Conserva()
        ElseIf TypeOf _LoginSession Is Conservatori.PARER.Autenticazione.PARERLoginSession Then
            LogSystem.Log(_LoginSession, logModule, "Rilevato PARER", True)
            Dim a As New Conservatori.PARER.Conservazione.Document(_LoginSession, ConservationInfo)
            Return a.Allega
        Else
            Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("Conservatore non riconosciuto"))
        End If


    End Function

    Private Sub Valida(ConservationInfo As [Shared].ConservationInfo)
        If ConservationInfo Is Nothing Then
            Throw New ArgumentNullException("ConservationInfo", "Dati Mancanti")
        End If

        Conservatori.Shared.Attributi.ValidaDatiSpecifici(ConservationInfo)
    End Sub

    Public Function Conserva(ConservationInfo As [Shared].ConservationInfo) As [Shared].ConservationResponseInfoExtended
        Const logModule As String = "Conserva"


        ValidaConservazione(logModule)
        Valida(ConservationInfo)



        If ConservationInfo.Data.Year = 1 Then
            Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("Data non specificata"))
        End If


        If TypeOf _LoginSession Is Conservatori.Infocert.Autenticazione.InforcertLoginSession Then
            '   LogSystem.Log(logModule, "Rilevato Infocert")
            Dim a As New Conservatori.Infocert.Conservazione.Document(_LoginSession, ConservationInfo)
            Return a.Conserva()
        ElseIf TypeOf _LoginSession Is Conservatori.PARER.Autenticazione.PARERLoginSession Then
            '     LogSystem.Log(logModule, "Rilevato PARER")
            Dim a As New Conservatori.PARER.Conservazione.Document(_LoginSession, ConservationInfo)
            Return a.Conserva
        ElseIf TypeOf _LoginSession Is Conservatori.DAX.Autenticazione.DAXLoginSession Then
            Dim a As New Conservatori.DAX.Conservazione.Document(_LoginSession, ConservationInfo)
            Return a.Conserva
        ElseIf TypeOf _LoginSession Is Conservatori.PARVeneto.Autenticazione.PARVenetoLoginSession Then

            Dim a As New Conservatori.PARVeneto.Conservazione.Document(_LoginSession, ConservationInfo)
            Return a.Conserva

        Else
            Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("Conservatore non riconosciuto"))
        End If


    End Function


#End Region

    Public Function Esibisci(EsibisciInfo As [Shared].EsibisciArgs) As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo
        Const logModule As String = "Esibisci"
        If _LoginSession Is Nothing Then
            Throw New UnhandledException(logModule, New ArgumentNullException("LoginSession mancante"))
        End If

        If _LoginSession.EnteUtente Is Nothing Then
            Throw New Autenthicate.LoginException(logModule, New ArgumentNullException("LoginSession Corrotta e/o mancante in EnteUtente"))
        End If

        If _LoginSession.Ente Is Nothing Then
            Throw New Autenthicate.LoginException(logModule, New ArgumentNullException("LoginSession Corrotta e/o mancante in Ente"))
        End If


        If _LoginSession.EnteUtente.Roles.Contains(Data.EnteUtenteBase.RuoloEsibisci) = False Then
            Throw New Autenthicate.LoginException(logModule, "L'utente non è abilitato all'Esibizione di un Documento")
        End If

        Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)

        If TypeOf _LoginSession Is Conservatori.Infocert.Autenticazione.InforcertLoginSession Then
            Dim esibizioneargs As Conservatori.Infocert.Esibizione.EsibizioneArgs = r.GetChiave(EsibisciInfo, _LoginSession)
            LogSystem.Log(_LoginSession, logModule, "Rilevato Infocert")
            Dim a As New Conservatori.Infocert.Esibizione.Document(_LoginSession)
            Return a.Esibisci(esibizioneargs.Tokens, esibizioneargs.ReturnFlags)
        ElseIf TypeOf _LoginSession Is Conservatori.PARER.Autenticazione.PARERLoginSession Then
            LogSystem.Log(_LoginSession, logModule, "Rilevato PAPER")
            Dim esibizioneargs As Conservatori.PARER.Esibizione.EsibizioneArgs = r.GetChiave(EsibisciInfo, _LoginSession)

            Dim a As New Conservatori.PARER.Esibizione.Document(_LoginSession)
            Return a.Esibisci(esibizioneargs)

        ElseIf TypeOf _LoginSession Is Conservatori.DAX.Autenticazione.DAXLoginSession Then
            LogSystem.Log(_LoginSession, logModule, "Rilevato DAX")
            Dim esibizioneargs As Conservatori.DAX.Esibizione.EsibizioneArgs = r.GetChiave(EsibisciInfo, _LoginSession)

            Dim a As New Conservatori.DAX.Esibizione.Document(_LoginSession)
            Return a.Esibisci(esibizioneargs)

        ElseIf TypeOf _LoginSession Is Conservatori.PARVeneto.Autenticazione.PARVenetoLoginSession Then
            LogSystem.Log(_LoginSession, logModule, "Rilevato PARVeneto")
            Dim esibizioneargs As Conservatori.PARVeneto.Esibizione.EsibizioneArgs = r.GetChiave(EsibisciInfo, _LoginSession)

            Dim a As New Conservatori.PARVeneto.Esibizione.Document(_LoginSession)
            Return a.Esibisci(esibizioneargs)
        Else
            Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("Conservatore non riconosciuto"))
        End If


    End Function

    Public Function Elimina(EsibisciInfo As [Shared].EsibisciArgs) As ProgettoEnte.Conservazione.Shared.DeleteResponseInfo
        Const logModule As String = "Elimina"
        If _LoginSession Is Nothing Then
            Throw New UnhandledException(logModule, New ArgumentNullException("LoginSession mancante"))
        End If

        If _LoginSession.EnteUtente Is Nothing Then
            Throw New Autenthicate.LoginException(logModule, New ArgumentNullException("LoginSession Corrotta e/o mancante in EnteUtente"))
        End If

        If _LoginSession.Ente Is Nothing Then
            Throw New Autenthicate.LoginException(logModule, New ArgumentNullException("LoginSession Corrotta e/o mancante in Ente"))
        End If


        If _LoginSession.EnteUtente.Roles.Contains(Data.EnteUtenteBase.RuoloEsibisci) = False Then
            Throw New Autenthicate.LoginException(logModule, "L'utente non è abilitato all'Esibizione di un Documento")
        End If

        Dim r As New Data.Registro(_LoginSession.EnteUtente.AuthicatedUser)

        If TypeOf _LoginSession Is Conservatori.Infocert.Autenticazione.InforcertLoginSession Then
                Dim esibizioneargs As Conservatori.Infocert.Esibizione.EsibizioneArgs = r.GetChiave(EsibisciInfo, _LoginSession)
            LogSystem.Log(_LoginSession, logModule, "Rilevato Infocert")
            Dim a As New Conservatori.Infocert.Eliminazione.Document(_LoginSession)
                Return a.Elimina(esibizioneargs.Tokens, EsibisciInfo)
            ElseIf TypeOf _LoginSession Is Conservatori.PARER.Autenticazione.PARERLoginSession Then
                ' todo Implementare
                Throw New UnhandledException(logModule, New NotImplementedException())


                'LogSystem.Log(logModule, "Rilevato PAPER")
                'Dim esibizioneargs As Conservatori.PARER.Esibizione.EsibizioneArgs = r.GetChiave(EsibisciInfo, _LoginSession)

                'Dim a As New Conservatori.PARER.Esibizione.Document(_LoginSession)
                'Return a.Esibisci(esibizioneargs)
            Else
                Throw New UnhandledException(logModule, New ArgumentOutOfRangeException("Conservatore non riconosciuto"))
            End If

    End Function

End Class
 