Imports ProgettoEnte.Conservazione
Imports ProgettoEnte.Conservazione.Autenthicate
Imports ProgettoEnte.Conservazione.Shared

' NOTA: è possibile utilizzare il comando "Rinomina" del menu di scelta rapida per modificare il nome di classe "Conserva" nel codice, nel file svc e nel file di configurazione contemporaneamente.
Public Class Conserva
    Implements IConserva



    ''' <summary>
    ''' Richiesta astratta di esibizione
    ''' </summary>
    ''' <param name="InfoLogin">Parametri di Login dell'ente</param>
    ''' <param name="EsibisciInfo">Un'oggetto EsibisciInfo contenete di dati da richiedere</param>
    ''' <returns>Una lista di FileBase</returns> 
    Public Function Esibisci(InfoLogin As Autenthicate.LoginManager,
                                   EsibisciInfo As ProgettoEnte.Conservazione.Shared.EsibisciArgs) As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo Implements IConserva.Esibisci
        Try
            Using obj As New ProgettoEnte.Conservazione.Gestione
                obj.Login(InfoLogin, EsibisciInfo.TokenID)
                Return obj.Esibisci(EsibisciInfo)
            End Using

        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrEmpty(ex.InnerException.Message) = False Then
                Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo() With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Errore, .Descrizione = ex.InnerException.Message}
            Else
                Return New ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo() With {.Status = ProgettoEnte.Conservazione.Shared.ResponseStatusCode.Errore, .Descrizione = ex.Message}
            End If
        End Try
    End Function

    ''' <summary>
    ''' Richiesta astratta di conservazione
    ''' </summary>
    ''' <param name="InfoLogin">Parametri di Login dell'ente</param>
    ''' <param name="ConservationInfo">Un'oggetto ConservationInfo contenete di dati da conservare</param>
    ''' <returns>Un'oggetto ConservationResponseInfo</returns> 
    Public Function Conserva(InfoLogin As Autenthicate.LoginManager, ConservationInfo As ProgettoEnte.Conservazione.Shared.ConservationInfo) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfo Implements IConserva.Conserva
        Try
            Using obj As New ProgettoEnte.Conservazione.Gestione
                obj.Login(InfoLogin, ConservationInfo.Tipologia)

                Dim res = obj.Conserva(ConservationInfo)
                Dim c As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo
                c.Status = res.Status
                c.Descrizione = res.Descrizione
                c.TokenID = res.TokenID
                Return c
            End Using
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrEmpty(ex.InnerException.Message) = False Then
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.InnerException.Message}
            Else
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.Message}
            End If
        End Try
    End Function

    Public Function ConservaAllegati(InfoLogin As Autenthicate.LoginManager, ConservationInfo As ProgettoEnte.Conservazione.[Shared].AggiuntaAllegatiInfo) As ProgettoEnte.Conservazione.[Shared].ConservationResponseInfo Implements IConserva.ConservaAllegati
        Try
            Using obj As New ProgettoEnte.Conservazione.Gestione
                obj.Login(InfoLogin, ConservationInfo.TokenID)

                Dim res = obj.ConservaAllegati(ConservationInfo)
                Dim c As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo
                c.Status = res.Status
                c.Descrizione = res.Descrizione
                c.TokenID = res.TokenID
                Return c

            End Using
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrEmpty(ex.InnerException.Message) = False Then
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.InnerException.Message}
            Else
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.Message}
            End If
        End Try
    End Function

    Public Function Elimina(InfoLogin As Autenthicate.LoginManager, EsibisciInfo As ProgettoEnte.Conservazione.[Shared].EsibisciArgs) As ProgettoEnte.Conservazione.[Shared].DeleteResponseInfo Implements IConserva.Elimina
        Try
            Using obj As New ProgettoEnte.Conservazione.Gestione
                obj.Login(InfoLogin, EsibisciInfo.TokenID)
                Return obj.Elimina(EsibisciInfo)
            End Using

        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrEmpty(ex.InnerException.Message) = False Then
                Return New ProgettoEnte.Conservazione.Shared.DeleteResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.InnerException.Message}
            Else
                Return New ProgettoEnte.Conservazione.Shared.DeleteResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.Message}
            End If
        End Try
    End Function

    Public Function Rettifica(InfoLogin As Autenthicate.LoginManager, ConservationInfo As ProgettoEnte.Conservazione.[Shared].RettificaInfo) As ProgettoEnte.Conservazione.[Shared].ConservationResponseInfo Implements IConserva.Rettifica
        Try
            Using obj As New ProgettoEnte.Conservazione.Gestione
                obj.Login(InfoLogin, ConservationInfo.TokenID)
                Return obj.Rettifica(ConservationInfo)
            End Using
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrEmpty(ex.InnerException.Message) = False Then
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.InnerException.Message}
            Else
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.Message}
            End If
        End Try
    End Function

    Public Function Conserva2(InfoLogin As LoginManager, ConservationInfo As ConservationInfo) As ConservationResponseInfoExtended Implements IConserva.Conserva2
        Try
            Using obj As New ProgettoEnte.Conservazione.Gestione
                obj.Login(InfoLogin, ConservationInfo.Tipologia)
                Return obj.Conserva(ConservationInfo)
            End Using
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrEmpty(ex.InnerException.Message) = False Then
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.InnerException.Message}
            Else
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.Message}
            End If
        End Try
    End Function

    Public Function ConservaAllegati2(InfoLogin As LoginManager, ConservationInfo As AggiuntaAllegatiInfo) As ConservationResponseInfoExtended Implements IConserva.ConservaAllegati2
        Try
            Using obj As New ProgettoEnte.Conservazione.Gestione
                obj.Login(InfoLogin, ConservationInfo.TokenID)
                Return obj.ConservaAllegati(ConservationInfo)
            End Using
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrEmpty(ex.InnerException.Message) = False Then
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.InnerException.Message}
            Else
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.Message}
            End If
        End Try
    End Function

    Public Function TestParametri(InfoLogin As LoginManager, TestParametriInfo As TestParametriInfo) As ConservationResponseInfo Implements IConserva.TestParametri


        Try
            Using obj As New ProgettoEnte.Conservazione.Gestione
                Dim ls = obj.Login(InfoLogin, TestParametriInfo.Tipologia)

                Dim c As New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo

                If ls IsNot Nothing Then
                    c.Status = ResponseStatusCode.Ok
                    c.Descrizione = "Test parametri ok"
                Else
                    c.Status = ResponseStatusCode.Errore
                    c.Descrizione = "Impossibile autenticarsi, ricontrollare i parametri"
                End If

                Return c
            End Using
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrEmpty(ex.InnerException.Message) = False Then
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.InnerException.Message}
            Else
                Return New ProgettoEnte.Conservazione.Shared.ConservationResponseInfo() With {.Status = ProgettoEnte.Conservazione.[Shared].ResponseStatusCode.Errore, .Descrizione = ex.Message}
            End If
        End Try





    End Function
End Class
