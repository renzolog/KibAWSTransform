Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
 
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ComponenteType

        Private idField As String

        Private ordinePresentazioneField As String

        Private tipoComponenteField As String

        Private tipoSupportoComponenteField As TipoSupportoType

        Private tipoSupportoComponenteFieldSpecified As Boolean

        Private riferimentoField As ChiaveType

        Private tipoRappresentazioneComponenteField As String

        Private nomeComponenteField As String

        Private formatoFileVersatoField As String

        Private hashVersatoField As String

        Private urnVersatoField As String

        Private iDComponenteVersatoField As String

        Private datiSpecificiField As DatiSpecificiType

        Private datiSpecificiMigrazioneField As DatiSpecificiType

        Private utilizzoDataFirmaPerRifTempField As Boolean

        Private utilizzoDataFirmaPerRifTempFieldSpecified As Boolean

        Private riferimentoTemporaleField As Date

        Private riferimentoTemporaleFieldSpecified As Boolean

        Private descrizioneRiferimentoTemporaleField As String

        Private sottoComponentiField() As SottoComponenteType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property ID() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
        Public Property OrdinePresentazione() As String
            Get
                Return Me.ordinePresentazioneField
            End Get
            Set(value As String)
                Me.ordinePresentazioneField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipoComponente() As String
            Get
                Return Me.tipoComponenteField
            End Get
            Set(value As String)
                Me.tipoComponenteField = value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoSupportoComponente() As TipoSupportoType
            Get
                Return Me.tipoSupportoComponenteField
            End Get
            Set(value As TipoSupportoType)
                Me.tipoSupportoComponenteField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TipoSupportoComponenteSpecified() As Boolean
            Get
                Return Me.tipoSupportoComponenteFieldSpecified
            End Get
            Set(value As Boolean)
                Me.tipoSupportoComponenteFieldSpecified = value
            End Set
        End Property

        '''<remarks/>
        Public Property Riferimento() As ChiaveType
            Get
                Return Me.riferimentoField
            End Get
            Set(value As ChiaveType)
                Me.riferimentoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipoRappresentazioneComponente() As String
            Get
                Return Me.tipoRappresentazioneComponenteField
            End Get
            Set(value As String)
                Me.tipoRappresentazioneComponenteField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property NomeComponente() As String
            Get
                Return Me.nomeComponenteField
            End Get
            Set(value As String)
                Me.nomeComponenteField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property FormatoFileVersato() As String
            Get
                Return Me.formatoFileVersatoField
            End Get
            Set(value As String)
                Me.formatoFileVersatoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property HashVersato() As String
            Get
                Return Me.hashVersatoField
            End Get
            Set(value As String)
                Me.hashVersatoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property UrnVersato() As String
            Get
                Return Me.urnVersatoField
            End Get
            Set(value As String)
                Me.urnVersatoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property IDComponenteVersato() As String
            Get
                Return Me.iDComponenteVersatoField
            End Get
            Set(value As String)
                Me.iDComponenteVersatoField = value
            End Set
        End Property


        '  <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property DatiSpecifici() As DatiSpecificiType
            Get
                Return Me.datiSpecificiField
            End Get
            Set(value As DatiSpecificiType)
                Me.datiSpecificiField = value
            End Set
        End Property


        '  <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property DatiSpecificiMigrazione() As DatiSpecificiType
            Get
                Return Me.datiSpecificiMigrazioneField
            End Get
            Set(value As DatiSpecificiType)
                Me.datiSpecificiMigrazioneField = value
            End Set
        End Property

        '''<remarks/>
        Public Property UtilizzoDataFirmaPerRifTemp() As Boolean
            Get
                Return Me.utilizzoDataFirmaPerRifTempField
            End Get
            Set(value As Boolean)
                Me.utilizzoDataFirmaPerRifTempField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property UtilizzoDataFirmaPerRifTempSpecified() As Boolean
            Get
                Return Me.utilizzoDataFirmaPerRifTempFieldSpecified
            End Get
            Set(value As Boolean)
                Me.utilizzoDataFirmaPerRifTempFieldSpecified = value
            End Set
        End Property

        '''<remarks/>
        Public Property RiferimentoTemporale() As Date
            Get
                Return Me.riferimentoTemporaleField
            End Get
            Set(value As Date)
                Me.riferimentoTemporaleField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property RiferimentoTemporaleSpecified() As Boolean
            Get
                Return Me.riferimentoTemporaleFieldSpecified
            End Get
            Set(value As Boolean)
                Me.riferimentoTemporaleFieldSpecified = value
            End Set
        End Property

        '''<remarks/>
        Public Property DescrizioneRiferimentoTemporale() As String
            Get
                Return Me.descrizioneRiferimentoTemporaleField
            End Get
            Set(value As String)
                Me.descrizioneRiferimentoTemporaleField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("SottoComponente", IsNullable:=False)> _
        Public Property SottoComponenti() As SottoComponenteType()
            Get
                Return Me.sottoComponentiField
            End Get
            Set(value As SottoComponenteType())
                Me.sottoComponentiField = value
            End Set
        End Property
    End Class
End Namespace
