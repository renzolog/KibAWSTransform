Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute()> _
    Public Enum ECEsitoControlloType

        '''<remarks/>
        POSITIVO

        '''<remarks/>
        NEGATIVO

        '''<remarks/>
        WARNING

        '''<remarks/>
        NON_ESEGUITO

        '''<remarks/>
        FORMATO_NON_CONOSCIUTO

        '''<remarks/>
        FORMATO_NON_CONFORME

        '''<remarks/>
        NON_AMMESSO_DELIB_45_CNIPA

        '''<remarks/>
        DISABILITATO

        '''<remarks/>
        NON_NECESSARIO

        '''<remarks/>
        ERRORE

        '''<remarks/>
        CERTIFICATO_ERRATO

        '''<remarks/>
        CERTIFICATO_NON_VALIDO

        '''<remarks/>
        CERTIFICATO_REVOCATO

        '''<remarks/>
        CERTIFICATO_SCADUTO

        '''<remarks/>
        CERTIFICATO_SCADUTO_3_12_2009

        '''<remarks/>
        CRL_NON_SCARICABILE

        '''<remarks/>
        CRL_NON_VALIDA

        '''<remarks/>
        CRL_SCADUTA
    End Enum
End Namespace
