Imports System.ServiceModel
Imports ProgettoEnte.Conservazione.Shared

' NOTA: è possibile utilizzare il comando "Rinomina" del menu di scelta rapida per modificare il nome di interfaccia "IConserva" nel codice e nel file di configurazione contemporaneamente.
<ServiceKnownType("GetKnownTypes", GetType(Helper)), ServiceContract(namespace:="http://www.kibernetes.it/ws/progettoenteconservazione")>
Public Interface IConserva
    'ServiceKnownType("GetKnownTypes", GetType(Helper)),
    ''' <summary>
    ''' Richiesta astratta di esibizione
    ''' </summary>
    ''' <param name="InfoLogin">Parametri di Login dell'ente</param>
    ''' <param name="EsibisciInfo">Un'oggetto EsibisciInfo contenete di dati da richiedere</param>
    ''' <returns>Una lista di FileBase</returns> 
    <OperationContract()> _
    Function Esibisci(ByVal InfoLogin As ProgettoEnte.Conservazione.Autenthicate.LoginManager, ByVal EsibisciInfo As ProgettoEnte.Conservazione.Shared.EsibisciArgs) As ProgettoEnte.Conservazione.Shared.EsibitionResponseInfo

    ''' <summary>
    ''' Richiesta astratta di conservazione
    ''' </summary>
    ''' <param name="InfoLogin">Parametri di Login dell'ente</param>
    ''' <param name="ConservationInfo">Un'oggetto ConservationInfo contenete di dati da conservare</param>
    ''' <returns>Un'oggetto ConservationResponseInfo</returns> 
    <OperationContract()> _
    Function Conserva(ByVal InfoLogin As ProgettoEnte.Conservazione.Autenthicate.LoginManager, ByVal ConservationInfo As ProgettoEnte.Conservazione.Shared.ConservationInfo) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfo

    ''' <summary>
    ''' Richiesta astratta di conservazione
    ''' </summary>
    ''' <param name="InfoLogin">Parametri di Login dell'ente</param>
    ''' <param name="ConservationInfo">Un'oggetto ConservationInfo contenete di dati da conservare</param>
    ''' <returns>Un'oggetto ConservationResponseInfo</returns> 
    <OperationContract()> _
    Function ConservaAllegati(ByVal InfoLogin As ProgettoEnte.Conservazione.Autenthicate.LoginManager, ByVal ConservationInfo As ProgettoEnte.Conservazione.Shared.AggiuntaAllegatiInfo) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfo

    ''' <summary>
    ''' Richiesta astratta di esibizione
    ''' </summary>
    ''' <param name="InfoLogin">Parametri di Login dell'ente</param>
    ''' <param name="EsibisciInfo">Un'oggetto EsibisciInfo contenete di dati da richiedere</param>
    ''' <returns>Una lista di FileBase</returns> 
    <OperationContract()> _
    Function Elimina(ByVal InfoLogin As ProgettoEnte.Conservazione.Autenthicate.LoginManager, ByVal EsibisciInfo As ProgettoEnte.Conservazione.Shared.EsibisciArgs) As ProgettoEnte.Conservazione.Shared.DeleteResponseInfo

    <OperationContract()> _
    Function Rettifica(ByVal InfoLogin As ProgettoEnte.Conservazione.Autenthicate.LoginManager, ByVal ConservationInfo As ProgettoEnte.Conservazione.Shared.RettificaInfo) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfo


    <OperationContract()>
    Function Conserva2(ByVal InfoLogin As ProgettoEnte.Conservazione.Autenthicate.LoginManager, ByVal ConservationInfo As ProgettoEnte.Conservazione.Shared.ConservationInfo) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended

    <OperationContract()>
    Function ConservaAllegati2(ByVal InfoLogin As ProgettoEnte.Conservazione.Autenthicate.LoginManager, ByVal ConservationInfo As ProgettoEnte.Conservazione.Shared.AggiuntaAllegatiInfo) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfoExtended

    <OperationContract()>
    Function TestParametri(ByVal InfoLogin As ProgettoEnte.Conservazione.Autenthicate.LoginManager, ByVal TestParametriInfo As ProgettoEnte.Conservazione.Shared.TestParametriInfo) As ProgettoEnte.Conservazione.Shared.ConservationResponseInfo

End Interface
