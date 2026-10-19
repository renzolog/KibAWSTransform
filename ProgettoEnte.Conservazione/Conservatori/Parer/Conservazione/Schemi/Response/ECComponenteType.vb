Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECComponenteType
        Private ordinePresentazioneField As String

        Private tipoComponenteField As String

        Private uRNField As String

        Private hashField() As Byte

        Private algoritmoHashField As String

        Private encodingField As String

        Private formatoRappresentazioneField As String

        Private formatoRappresentazioneEstesoField As String

        Private idoneitaFormatoField As ECEsitoIdonFormatoType

        Private idoneitaFormatoFieldSpecified As Boolean

        Private dimensioneFileField As String

        Private firmatoDigitalmenteField As Boolean

        Private firmatoDigitalmenteFieldSpecified As Boolean

        Private esitoComponenteField As ECComponenteTypeEsitoComponente

        Private marcheField() As ECMarcaType

        Private firmatariField() As ECFirmatarioType

        Private sottoComponentiField() As ECSottoComponenteType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")> _
        Public Property OrdinePresentazione() As String
            Get
                Return Me.ordinePresentazioneField
            End Get
            Set(value As String)
                Me.ordinePresentazioneField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoComponente() As String
            Get
                Return Me.tipoComponenteField
            End Get
            Set(value As String)
                Me.tipoComponenteField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property URN() As String
            Get
                Return Me.uRNField
            End Get
            Set(value As String)
                Me.uRNField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="hexBinary")> _
        Public Property Hash() As Byte()
            Get
                Return Me.hashField
            End Get
            Set(value As Byte())
                Me.hashField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property AlgoritmoHash() As String
            Get
                Return Me.algoritmoHashField
            End Get
            Set(value As String)
                Me.algoritmoHashField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property Encoding() As String
            Get
                Return Me.encodingField
            End Get
            Set(value As String)
                Me.encodingField = Value
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
        Public Property IdoneitaFormato() As ECEsitoIdonFormatoType
            Get
                Return Me.idoneitaFormatoField
            End Get
            Set(value As ECEsitoIdonFormatoType)
                Me.idoneitaFormatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property IdoneitaFormatoSpecified() As Boolean
            Get
                Return Me.idoneitaFormatoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.idoneitaFormatoFieldSpecified = Value
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
        Public Property FirmatoDigitalmente() As Boolean
            Get
                Return Me.firmatoDigitalmenteField
            End Get
            Set(value As Boolean)
                Me.firmatoDigitalmenteField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property FirmatoDigitalmenteSpecified() As Boolean
            Get
                Return Me.firmatoDigitalmenteFieldSpecified
            End Get
            Set(value As Boolean)
                Me.firmatoDigitalmenteFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoComponente() As ECComponenteTypeEsitoComponente
            Get
                Return Me.esitoComponenteField
            End Get
            Set(value As ECComponenteTypeEsitoComponente)
                Me.esitoComponenteField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Marca", IsNullable:=False)> _
        Public Property Marche() As ECMarcaType()
            Get
                Return Me.marcheField
            End Get
            Set(value As ECMarcaType())
                Me.marcheField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Firmatario", IsNullable:=False)> _
        Public Property Firmatari() As ECFirmatarioType()
            Get
                Return Me.firmatariField
            End Get
            Set(value As ECFirmatarioType())
                Me.firmatariField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("SottoComponente", IsNullable:=False)> _
        Public Property SottoComponenti() As ECSottoComponenteType()
            Get
                Return Me.sottoComponentiField
            End Get
            Set(value As ECSottoComponenteType())
                Me.sottoComponentiField = Value
            End Set
        End Property
    End Class
End Namespace
