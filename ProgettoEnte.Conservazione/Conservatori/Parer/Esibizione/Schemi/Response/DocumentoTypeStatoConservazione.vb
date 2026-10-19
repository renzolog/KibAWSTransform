Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Public Enum DocumentoTypeStatoConservazione

        '''<remarks/>
        IN_ATTESA_SCHED

        '''<remarks/>
        IN_VOLUME_APERTO

        '''<remarks/>
        IN_VOLUME_CHIUSO

        '''<remarks/>
        IN_VOLUME_IN_ERRORE

        '''<remarks/>
        NON_SELEZ_SCHED
    End Enum
End Namespace
