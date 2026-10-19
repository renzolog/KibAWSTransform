Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)> _
    Partial Public Class IndiceProveConservazione

        Private versioneField As String

        Private versioneXMLChiamataField As String

        Private dataRichiestaStatoField As Date

        Private esitoGeneraleField As EsitoGenericoType

        Private esitoChiamataWSField As EsitoChiamataWSType

        Private chiaveField As ChiaveType

        Private notaField As String

        Private volumiField() As PCVolumeType

        '''<remarks/>
        Public Property Versione() As String
            Get
                Return Me.versioneField
            End Get
            Set(value As String)
                Me.versioneField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VersioneXMLChiamata() As String
            Get
                Return Me.versioneXMLChiamataField
            End Get
            Set(value As String)
                Me.versioneXMLChiamataField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataRichiestaStato() As Date
            Get
                Return Me.dataRichiestaStatoField
            End Get
            Set(value As Date)
                Me.dataRichiestaStatoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoGenerale() As EsitoGenericoType
            Get
                Return Me.esitoGeneraleField
            End Get
            Set(value As EsitoGenericoType)
                Me.esitoGeneraleField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoChiamataWS() As EsitoChiamataWSType
            Get
                Return Me.esitoChiamataWSField
            End Get
            Set(value As EsitoChiamataWSType)
                Me.esitoChiamataWSField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Chiave() As ChiaveType
            Get
                Return Me.chiaveField
            End Get
            Set(value As ChiaveType)
                Me.chiaveField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Nota() As String
            Get
                Return Me.notaField
            End Get
            Set(value As String)
                Me.notaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Volume", IsNullable:=False)> _
        Public Property Volumi() As PCVolumeType()
            Get
                Return Me.volumiField
            End Get
            Set(value As PCVolumeType())
                Me.volumiField = Value
            End Set
        End Property
    End Class
End Namespace
