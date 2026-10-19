Imports System.ServiceModel
Imports ProgettoEnte.Conservazione
Imports System.Reflection


Friend Class Helper
    Public Shared Function GetKnownTypes(provider As ICustomAttributeProvider) _
     As IEnumerable(Of Type)
        Dim knownTypes As List(Of Type) = New List(Of Type)

        knownTypes.Add(GetType(ProgettoEnte.Conservazione.[Shared].ConservationInfo))
        knownTypes.Add(GetType(Autenthicate.LoginManager))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiProtocollo))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiDetermina))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiDelibera))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiDocumentoGenerico))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiContratto))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiAffissione))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiRegistroProtocollo))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiFatturaPassiva))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiFascicoloElettorale))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiGenerici))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiGiornaleCassa))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiOrdinativiSIOPE))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiFatturaAttiva))
        knownTypes.Add(GetType(Conservatori.Shared.AttributiFascicoli))
        '  knownTypes.Add(GetType(Conservatori.Shared.Fascicolo))
        Return knownTypes
    End Function


     
End Class