Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ProfiloUnitaDocumentariaType

        Private oggettoField As String

        Private dataField As Date

        Private cartaceoField As Boolean

        Private cartaceoFieldSpecified As Boolean

        '''<remarks/>
        Public Property Oggetto() As String
            Get
                Return Me.oggettoField
            End Get
            Set(value As String)
                Me.oggettoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="date")> _
        Public Property Data() As Date
            Get
                Return Me.dataField
            End Get
            Set(value As Date)
                Me.dataField = value
            End Set
        End Property

        '''<remarks/>
        Public Property Cartaceo() As Boolean
            Get
                Return Me.cartaceoField
            End Get
            Set(value As Boolean)
                Me.cartaceoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property CartaceoSpecified() As Boolean
            Get
                Return Me.cartaceoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.cartaceoFieldSpecified = value
            End Set
        End Property
    End Class
End Namespace
