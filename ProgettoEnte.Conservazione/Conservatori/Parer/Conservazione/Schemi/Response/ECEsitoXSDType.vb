Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECEsitoXSDType

        Private codiceEsitoField As ECEsitoPosNegType

        Private controlloStrutturaXMLField As String

        Private univocitaIDComponentiField As String

        Private univocitaIDDocumentiField As String

        Private corrispondenzaAllegatiDichiaratiField As ECEsitoPosNegType

        Private corrispondenzaAllegatiDichiaratiFieldSpecified As Boolean

        Private corrispondenzaAnnessiDichiaratiField As ECEsitoPosNegType

        Private corrispondenzaAnnessiDichiaratiFieldSpecified As Boolean

        Private corrispondenzaAnnotazioniDichiarateField As ECEsitoPosNegType

        Private corrispondenzaAnnotazioniDichiarateFieldSpecified As Boolean

        '''<remarks/>
        Public Property CodiceEsito() As ECEsitoPosNegType
            Get
                Return Me.codiceEsitoField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.codiceEsitoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ControlloStrutturaXML() As String
            Get
                Return Me.controlloStrutturaXMLField
            End Get
            Set(value As String)
                Me.controlloStrutturaXMLField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UnivocitaIDComponenti() As String
            Get
                Return Me.univocitaIDComponentiField
            End Get
            Set(value As String)
                Me.univocitaIDComponentiField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UnivocitaIDDocumenti() As String
            Get
                Return Me.univocitaIDDocumentiField
            End Get
            Set(value As String)
                Me.univocitaIDDocumentiField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CorrispondenzaAllegatiDichiarati() As ECEsitoPosNegType
            Get
                Return Me.corrispondenzaAllegatiDichiaratiField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.corrispondenzaAllegatiDichiaratiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property CorrispondenzaAllegatiDichiaratiSpecified() As Boolean
            Get
                Return Me.corrispondenzaAllegatiDichiaratiFieldSpecified
            End Get
            Set(value As Boolean)
                Me.corrispondenzaAllegatiDichiaratiFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CorrispondenzaAnnessiDichiarati() As ECEsitoPosNegType
            Get
                Return Me.corrispondenzaAnnessiDichiaratiField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.corrispondenzaAnnessiDichiaratiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property CorrispondenzaAnnessiDichiaratiSpecified() As Boolean
            Get
                Return Me.corrispondenzaAnnessiDichiaratiFieldSpecified
            End Get
            Set(value As Boolean)
                Me.corrispondenzaAnnessiDichiaratiFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CorrispondenzaAnnotazioniDichiarate() As ECEsitoPosNegType
            Get
                Return Me.corrispondenzaAnnotazioniDichiarateField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.corrispondenzaAnnotazioniDichiarateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property CorrispondenzaAnnotazioniDichiarateSpecified() As Boolean
            Get
                Return Me.corrispondenzaAnnotazioniDichiarateFieldSpecified
            End Get
            Set(value As Boolean)
                Me.corrispondenzaAnnotazioniDichiarateFieldSpecified = Value
            End Set
        End Property
    End Class
End Namespace
