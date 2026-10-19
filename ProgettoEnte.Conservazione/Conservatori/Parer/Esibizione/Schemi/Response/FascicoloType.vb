Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class FascicoloType

        Private identificativoField As String

        Private oggettoField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token", IsNullable:=True)> _
        Public Property Identificativo() As String
            Get
                Return Me.identificativoField
            End Get
            Set(value As String)
                Me.identificativoField = Value
            End Set
        End Property

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
    End Class
End Namespace
