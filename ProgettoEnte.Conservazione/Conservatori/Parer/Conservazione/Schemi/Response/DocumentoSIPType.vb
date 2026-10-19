Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DocumentoSIPType

        Private chiaveDocField As String

        Private iDDocumentoField As String

        Private tipoDocumentoField As String

        Private firmatoDigitalmenteField As Boolean

        Private firmatoDigitalmenteFieldSpecified As Boolean

        Private componentiField() As ComponenteSIPType

        '''<remarks/>
        Public Property ChiaveDoc() As String
            Get
                Return Me.chiaveDocField
            End Get
            Set(value As String)
                Me.chiaveDocField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property IDDocumento() As String
            Get
                Return Me.iDDocumentoField
            End Get
            Set(value As String)
                Me.iDDocumentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoDocumento() As String
            Get
                Return Me.tipoDocumentoField
            End Get
            Set(value As String)
                Me.tipoDocumentoField = Value
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
        <System.Xml.Serialization.XmlArrayItemAttribute("Componente", IsNullable:=False)> _
        Public Property Componenti() As ComponenteSIPType()
            Get
                Return Me.componentiField
            End Get
            Set(value As ComponenteSIPType())
                Me.componentiField = Value
            End Set
        End Property
    End Class
End Namespace
