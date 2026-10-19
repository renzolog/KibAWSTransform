Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class DocumentoCollegatoTypeDocumentoCollegato
        Private chiaveCollegamentoField As ChiaveType

        Private descrizioneCollegamentoField As String

        '''<remarks/>
        Public Property ChiaveCollegamento() As ChiaveType
            Get
                Return Me.chiaveCollegamentoField
            End Get
            Set(value As ChiaveType)
                Me.chiaveCollegamentoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property DescrizioneCollegamento() As String
            Get
                Return Me.descrizioneCollegamentoField
            End Get
            Set(value As String)
                Me.descrizioneCollegamentoField = Value
            End Set
        End Property
    End Class
End Namespace
