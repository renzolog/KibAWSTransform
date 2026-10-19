Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
 
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class FascicoloType

        Private identificativoField As String

        Private oggettoField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property Identificativo() As String
            Get
                Return Me.identificativoField
            End Get
            Set(value As String)
                Me.identificativoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property Oggetto() As String
            Get
                Return Me.oggettoField
            End Get
            Set(value As String)
                Me.oggettoField = value
            End Set
        End Property
    End Class
End Namespace
