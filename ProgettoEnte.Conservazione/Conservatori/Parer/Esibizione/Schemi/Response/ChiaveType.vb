Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ChiaveType

        Private numeroField As String

        Private annoField As String

        Private tipoRegistroField As String

        '''<remarks/>
        Public Property Numero() As String
            Get
                Return Me.numeroField
            End Get
            Set(value As String)
                Me.numeroField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="nonNegativeInteger")> _
        Public Property Anno() As String
            Get
                Return Me.annoField
            End Get
            Set(value As String)
                Me.annoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoRegistro() As String
            Get
                Return Me.tipoRegistroField
            End Get
            Set(value As String)
                Me.tipoRegistroField = Value
            End Set
        End Property
    End Class
End Namespace
