Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ComponenteType

        Private ordinePresentazioneField As String

        Private tipoComponenteField As String

        Private tipoSupportoComponenteField As TipoSupportoType

        Private tipoSupportoComponenteFieldSpecified As Boolean

        Private riferimentoField As ChiaveType

        Private tipoRappresentazioneComponenteField As String

        Private nomeComponenteField As String

        Private formatoRappresentazioneField As String

        Private formatoRappresentazioneEstesoField As String

        Private hashVersatoField As String

        Private hashCalcolatoField As String

        Private algoritmoHashCalcolatoField As String

        Private encodingCalcolatoField As String

        Private dimensioneFileField As String

        Private urnVersatoField As String

        Private urnCalcolatoField As String

        Private iDComponenteVersatoField As String

        Private datiSpecificiField As DatiSpecificiType

        Private datiSpecificiMigrazioneField As DatiSpecificiType

        Private utilizzoDataFirmaPerRifTempField As Boolean

        Private riferimentoTemporaleField As Date

        Private riferimentoTemporaleFieldSpecified As Boolean

        Private descrizioneRiferimentoTemporaleField As String

        Private sottoComponentiField() As SottoComponenteType

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
        Public Property TipoRappresentazioneComponente() As String
            Get
                Return Me.tipoRappresentazioneComponenteField
            End Get
            Set(value As String)
                Me.tipoRappresentazioneComponenteField = Value
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
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property HashVersato() As String
            Get
                Return Me.hashVersatoField
            End Get
            Set(value As String)
                Me.hashVersatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property HashCalcolato() As String
            Get
                Return Me.hashCalcolatoField
            End Get
            Set(value As String)
                Me.hashCalcolatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property AlgoritmoHashCalcolato() As String
            Get
                Return Me.algoritmoHashCalcolatoField
            End Get
            Set(value As String)
                Me.algoritmoHashCalcolatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property EncodingCalcolato() As String
            Get
                Return Me.encodingCalcolatoField
            End Get
            Set(value As String)
                Me.encodingCalcolatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="nonNegativeInteger")> _
        Public Property DimensioneFile() As String
            Get
                Return Me.dimensioneFileField
            End Get
            Set(value As String)
                Me.dimensioneFileField = Value
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

        '''<remarks/>
        Public Property UtilizzoDataFirmaPerRifTemp() As Boolean
            Get
                Return Me.utilizzoDataFirmaPerRifTempField
            End Get
            Set(value As Boolean)
                Me.utilizzoDataFirmaPerRifTempField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RiferimentoTemporale() As Date
            Get
                Return Me.riferimentoTemporaleField
            End Get
            Set(value As Date)
                Me.riferimentoTemporaleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property RiferimentoTemporaleSpecified() As Boolean
            Get
                Return Me.riferimentoTemporaleFieldSpecified
            End Get
            Set(value As Boolean)
                Me.riferimentoTemporaleFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DescrizioneRiferimentoTemporale() As String
            Get
                Return Me.descrizioneRiferimentoTemporaleField
            End Get
            Set(value As String)
                Me.descrizioneRiferimentoTemporaleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("SottoComponente", IsNullable:=False)> _
        Public Property SottoComponenti() As SottoComponenteType()
            Get
                Return Me.sottoComponentiField
            End Get
            Set(value As SottoComponenteType())
                Me.sottoComponentiField = Value
            End Set
        End Property
    End Class
End Namespace
