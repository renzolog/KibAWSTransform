Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
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
                Me.numeroField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
        Public Property Anno() As String
            Get
                Return Me.annoField
            End Get
            Set(value As String)
                Me.annoField = value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoRegistro() As String
            Get
                Return Me.tipoRegistroField
            End Get
            Set(value As String)
                Me.tipoRegistroField = value
            End Set
        End Property
    End Class
End Namespace
