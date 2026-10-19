Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ComponenteSIPType

        Private uRNField As String

        Private hashField As String

        Private algoritmoHashField As String

        Private encodingField As String

        '''<remarks/>
        Public Property URN() As String
            Get
                Return Me.uRNField
            End Get
            Set(value As String)
                Me.uRNField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Hash() As String
            Get
                Return Me.hashField
            End Get
            Set(value As String)
                Me.hashField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property AlgoritmoHash() As String
            Get
                Return Me.algoritmoHashField
            End Get
            Set(value As String)
                Me.algoritmoHashField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property Encoding() As String
            Get
                Return Me.encodingField
            End Get
            Set(value As String)
                Me.encodingField = Value
            End Set
        End Property
    End Class
End Namespace
