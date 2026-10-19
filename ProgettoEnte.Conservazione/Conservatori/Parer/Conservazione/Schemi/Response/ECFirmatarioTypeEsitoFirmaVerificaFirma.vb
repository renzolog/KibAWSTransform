Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class ECFirmatarioTypeEsitoFirmaVerificaFirma

        Private codiceEsitoField As ECEsitoPosNegWarType

        Private controlloCrittograficoField As ECEsitoControlloType

        Private controlloCrittograficoFieldSpecified As Boolean

        Private dettaglioControlloCrittograficoField As String

        Private controlloCatenaTrustedField As ECEsitoControlloType

        Private controlloCatenaTrustedFieldSpecified As Boolean

        Private dettaglioControlloCatenaTrustedField As String

        Private controlloCertificatoField As ECEsitoControlloType

        Private controlloCertificatoFieldSpecified As Boolean

        Private dettaglioControlloCertificatoField As String

        Private controlloCRLField As ECEsitoControlloType

        Private controlloCRLFieldSpecified As Boolean

        Private dettaglioControlloCRLField As String

        '''<remarks/>
        Public Property CodiceEsito() As ECEsitoPosNegWarType
            Get
                Return Me.codiceEsitoField
            End Get
            Set(value As ECEsitoPosNegWarType)
                Me.codiceEsitoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ControlloCrittografico() As ECEsitoControlloType
            Get
                Return Me.controlloCrittograficoField
            End Get
            Set(value As ECEsitoControlloType)
                Me.controlloCrittograficoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ControlloCrittograficoSpecified() As Boolean
            Get
                Return Me.controlloCrittograficoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.controlloCrittograficoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DettaglioControlloCrittografico() As String
            Get
                Return Me.dettaglioControlloCrittograficoField
            End Get
            Set(value As String)
                Me.dettaglioControlloCrittograficoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ControlloCatenaTrusted() As ECEsitoControlloType
            Get
                Return Me.controlloCatenaTrustedField
            End Get
            Set(value As ECEsitoControlloType)
                Me.controlloCatenaTrustedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ControlloCatenaTrustedSpecified() As Boolean
            Get
                Return Me.controlloCatenaTrustedFieldSpecified
            End Get
            Set(value As Boolean)
                Me.controlloCatenaTrustedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DettaglioControlloCatenaTrusted() As String
            Get
                Return Me.dettaglioControlloCatenaTrustedField
            End Get
            Set(value As String)
                Me.dettaglioControlloCatenaTrustedField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ControlloCertificato() As ECEsitoControlloType
            Get
                Return Me.controlloCertificatoField
            End Get
            Set(value As ECEsitoControlloType)
                Me.controlloCertificatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ControlloCertificatoSpecified() As Boolean
            Get
                Return Me.controlloCertificatoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.controlloCertificatoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DettaglioControlloCertificato() As String
            Get
                Return Me.dettaglioControlloCertificatoField
            End Get
            Set(value As String)
                Me.dettaglioControlloCertificatoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ControlloCRL() As ECEsitoControlloType
            Get
                Return Me.controlloCRLField
            End Get
            Set(value As ECEsitoControlloType)
                Me.controlloCRLField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ControlloCRLSpecified() As Boolean
            Get
                Return Me.controlloCRLFieldSpecified
            End Get
            Set(value As Boolean)
                Me.controlloCRLFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DettaglioControlloCRL() As String
            Get
                Return Me.dettaglioControlloCRLField
            End Get
            Set(value As String)
                Me.dettaglioControlloCRLField = Value
            End Set
        End Property
    End Class
End Namespace
