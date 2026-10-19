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
    Partial Public Class ECUnitaDocTypeEsitoUnitaDocumentaria

        Private codiceEsitoField As ECEsitoPosNegWarType

        Private codiceEsitoFieldSpecified As Boolean

        Private identificazioneVersatoreField As String

        Private univocitaChiaveField As ECEsitoPosNegType

        Private univocitaChiaveFieldSpecified As Boolean

        Private verificaTipologiaUDField As ECEsitoPosNegType

        Private verificaTipologiaUDFieldSpecified As Boolean

        Private corrispondenzaDatiSpecificiField As String

        Private presenzaUDCollegateField As String

        Private verificaFirmeUnitaDocumentariaField As ECEsitoPosNegWarType

        Private verificaFirmeUnitaDocumentariaFieldSpecified As Boolean

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
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property CodiceEsitoSpecified() As Boolean
            Get
                Return Me.codiceEsitoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.codiceEsitoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property IdentificazioneVersatore() As String
            Get
                Return Me.identificazioneVersatoreField
            End Get
            Set(value As String)
                Me.identificazioneVersatoreField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UnivocitaChiave() As ECEsitoPosNegType
            Get
                Return Me.univocitaChiaveField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.univocitaChiaveField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property UnivocitaChiaveSpecified() As Boolean
            Get
                Return Me.univocitaChiaveFieldSpecified
            End Get
            Set(value As Boolean)
                Me.univocitaChiaveFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaTipologiaUD() As ECEsitoPosNegType
            Get
                Return Me.verificaTipologiaUDField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.verificaTipologiaUDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaTipologiaUDSpecified() As Boolean
            Get
                Return Me.verificaTipologiaUDFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaTipologiaUDFieldSpecified = Value
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
        Public Property PresenzaUDCollegate() As String
            Get
                Return Me.presenzaUDCollegateField
            End Get
            Set(value As String)
                Me.presenzaUDCollegateField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaFirmeUnitaDocumentaria() As ECEsitoPosNegWarType
            Get
                Return Me.verificaFirmeUnitaDocumentariaField
            End Get
            Set(value As ECEsitoPosNegWarType)
                Me.verificaFirmeUnitaDocumentariaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaFirmeUnitaDocumentariaSpecified() As Boolean
            Get
                Return Me.verificaFirmeUnitaDocumentariaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaFirmeUnitaDocumentariaFieldSpecified = Value
            End Set
        End Property
    End Class
End Namespace
