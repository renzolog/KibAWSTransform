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
    Partial Public Class ECUnitaDocAggAllTypeEsitoUnitaDocumentaria

        Private codiceEsitoField As ECEsitoPosNegWarType

        Private codiceEsitoFieldSpecified As Boolean

        Private identificazioneVersatoreField As String

        Private identificazioneChiaveField As ECEsitoPosNegType

        Private identificazioneChiaveFieldSpecified As Boolean

        Private documentoUnivocoInUDField As ECEsitoPosNegType

        Private documentoUnivocoInUDFieldSpecified As Boolean

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
        Public Property IdentificazioneChiave() As ECEsitoPosNegType
            Get
                Return Me.identificazioneChiaveField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.identificazioneChiaveField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property IdentificazioneChiaveSpecified() As Boolean
            Get
                Return Me.identificazioneChiaveFieldSpecified
            End Get
            Set(value As Boolean)
                Me.identificazioneChiaveFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DocumentoUnivocoInUD() As ECEsitoPosNegType
            Get
                Return Me.documentoUnivocoInUDField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.documentoUnivocoInUDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property DocumentoUnivocoInUDSpecified() As Boolean
            Get
                Return Me.documentoUnivocoInUDFieldSpecified
            End Get
            Set(value As Boolean)
                Me.documentoUnivocoInUDFieldSpecified = Value
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
