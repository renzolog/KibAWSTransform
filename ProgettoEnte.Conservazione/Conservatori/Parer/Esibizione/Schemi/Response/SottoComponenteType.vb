Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class SottoComponenteType

        Private ordinePresentazioneField As String

        Private tipoComponenteField As String

        Private tipoSupportoComponenteField As TipoSupportoType

        Private tipoSupportoComponenteFieldSpecified As Boolean

        Private riferimentoField As ChiaveType

        Private nomeComponenteField As String

        Private formatoRappresentazioneField As String

        Private formatoRappresentazioneEstesoField As String

        Private urnVersatoField As String

        Private urnCalcolatoField As String

        Private iDComponenteVersatoField As String

        Private datiSpecificiField As DatiSpecificiType

        Private datiSpecificiMigrazioneField As DatiSpecificiType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="nonNegativeInteger")> _
        Public Property OrdinePresentazione() As String
            Get
                Return Me.ordinePresentazioneField
            End Get
            Set(value As String)
                Me.ordinePresentazioneField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipoComponente() As String
            Get
                Return Me.tipoComponenteField
            End Get
            Set(value As String)
                Me.tipoComponenteField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoSupportoComponente() As TipoSupportoType
            Get
                Return Me.tipoSupportoComponenteField
            End Get
            Set(value As TipoSupportoType)
                Me.tipoSupportoComponenteField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TipoSupportoComponenteSpecified() As Boolean
            Get
                Return Me.tipoSupportoComponenteFieldSpecified
            End Get
            Set(value As Boolean)
                Me.tipoSupportoComponenteFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Riferimento() As ChiaveType
            Get
                Return Me.riferimentoField
            End Get
            Set(value As ChiaveType)
                Me.riferimentoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property NomeComponente() As String
            Get
                Return Me.nomeComponenteField
            End Get
            Set(value As String)
                Me.nomeComponenteField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FormatoRappresentazione() As String
            Get
                Return Me.formatoRappresentazioneField
            End Get
            Set(value As String)
                Me.formatoRappresentazioneField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FormatoRappresentazioneEsteso() As String
            Get
                Return Me.formatoRappresentazioneEstesoField
            End Get
            Set(value As String)
                Me.formatoRappresentazioneEstesoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UrnVersato() As String
            Get
                Return Me.urnVersatoField
            End Get
            Set(value As String)
                Me.urnVersatoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UrnCalcolato() As String
            Get
                Return Me.urnCalcolatoField
            End Get
            Set(value As String)
                Me.urnCalcolatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property IDComponenteVersato() As String
            Get
                Return Me.iDComponenteVersatoField
            End Get
            Set(value As String)
                Me.iDComponenteVersatoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DatiSpecifici() As DatiSpecificiType
            Get
                Return Me.datiSpecificiField
            End Get
            Set(value As DatiSpecificiType)
                Me.datiSpecificiField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DatiSpecificiMigrazione() As DatiSpecificiType
            Get
                Return Me.datiSpecificiMigrazioneField
            End Get
            Set(value As DatiSpecificiType)
                Me.datiSpecificiMigrazioneField = Value
            End Set
        End Property
    End Class
End Namespace
