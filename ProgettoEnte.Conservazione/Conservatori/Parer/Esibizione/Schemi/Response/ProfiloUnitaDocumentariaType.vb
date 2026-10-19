Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ProfiloUnitaDocumentariaType

        Private oggettoField As String

        Private dataField As System.Nullable(Of Date)

        Private cartaceoField As Boolean

        Private cartaceoFieldSpecified As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property Oggetto() As String
            Get
                Return Me.oggettoField
            End Get
            Set(value As String)
                Me.oggettoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property Data() As System.Nullable(Of Date)
            Get
                Return Me.dataField
            End Get
            Set(value As System.Nullable(Of Date))
                Me.dataField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Cartaceo() As Boolean
            Get
                Return Me.cartaceoField
            End Get
            Set(value As Boolean)
                Me.cartaceoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property CartaceoSpecified() As Boolean
            Get
                Return Me.cartaceoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.cartaceoFieldSpecified = Value
            End Set
        End Property
    End Class
End Namespace
