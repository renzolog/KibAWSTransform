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
    Partial Public Class ECDocumentoTypeEsitoDocumento

        Private codiceEsitoField As ECEsitoPosNegWarType

        Private verificaTipoDocumentoField As String

        Private corrispondenzaDatiSpecificiField As String

        Private corrispondenzaDatiFiscaliField As String

        Private numerazioneFiscaleField As ECEsitoPosNegType

        Private numerazioneFiscaleFieldSpecified As Boolean

        Private verificaTipoStrutturaField As ECEsitoPosNegType

        Private verificaTipoStrutturaFieldSpecified As Boolean

        Private verificaFirmeDocumentoField As ECEsitoPosNegWarType

        Private verificaFirmeDocumentoFieldSpecified As Boolean

        Private univocitaOrdinePresentazioneField As ECEsitoPosNegType

        Private univocitaOrdinePresentazioneFieldSpecified As Boolean

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
        Public Property VerificaTipoDocumento() As String
            Get
                Return Me.verificaTipoDocumentoField
            End Get
            Set(value As String)
                Me.verificaTipoDocumentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CorrispondenzaDatiSpecifici() As String
            Get
                Return Me.corrispondenzaDatiSpecificiField
            End Get
            Set(value As String)
                Me.corrispondenzaDatiSpecificiField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CorrispondenzaDatiFiscali() As String
            Get
                Return Me.corrispondenzaDatiFiscaliField
            End Get
            Set(value As String)
                Me.corrispondenzaDatiFiscaliField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property NumerazioneFiscale() As ECEsitoPosNegType
            Get
                Return Me.numerazioneFiscaleField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.numerazioneFiscaleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property NumerazioneFiscaleSpecified() As Boolean
            Get
                Return Me.numerazioneFiscaleFieldSpecified
            End Get
            Set(value As Boolean)
                Me.numerazioneFiscaleFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaTipoStruttura() As ECEsitoPosNegType
            Get
                Return Me.verificaTipoStrutturaField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.verificaTipoStrutturaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaTipoStrutturaSpecified() As Boolean
            Get
                Return Me.verificaTipoStrutturaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaTipoStrutturaFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaFirmeDocumento() As ECEsitoPosNegWarType
            Get
                Return Me.verificaFirmeDocumentoField
            End Get
            Set(value As ECEsitoPosNegWarType)
                Me.verificaFirmeDocumentoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaFirmeDocumentoSpecified() As Boolean
            Get
                Return Me.verificaFirmeDocumentoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaFirmeDocumentoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UnivocitaOrdinePresentazione() As ECEsitoPosNegType
            Get
                Return Me.univocitaOrdinePresentazioneField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.univocitaOrdinePresentazioneField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property UnivocitaOrdinePresentazioneSpecified() As Boolean
            Get
                Return Me.univocitaOrdinePresentazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.univocitaOrdinePresentazioneFieldSpecified = Value
            End Set
        End Property
    End Class
End Namespace
