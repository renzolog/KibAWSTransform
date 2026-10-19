Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECMarcaType

        Private ordineMarcaField As String

        Private formatoMarcaField As String

        Private timestampField As Date

        Private timestampFieldSpecified As Boolean

        Private esitoMarcaField As ECMarcaTypeEsitoMarca

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")> _
        Public Property OrdineMarca() As String
            Get
                Return Me.ordineMarcaField
            End Get
            Set(value As String)
                Me.ordineMarcaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FormatoMarca() As String
            Get
                Return Me.formatoMarcaField
            End Get
            Set(value As String)
                Me.formatoMarcaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Timestamp() As Date
            Get
                Return Me.timestampField
            End Get
            Set(value As Date)
                Me.timestampField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TimestampSpecified() As Boolean
            Get
                Return Me.timestampFieldSpecified
            End Get
            Set(value As Boolean)
                Me.timestampFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoMarca() As ECMarcaTypeEsitoMarca
            Get
                Return Me.esitoMarcaField
            End Get
            Set(value As ECMarcaTypeEsitoMarca)
                Me.esitoMarcaField = Value
            End Set
        End Property
    End Class
End Namespace
