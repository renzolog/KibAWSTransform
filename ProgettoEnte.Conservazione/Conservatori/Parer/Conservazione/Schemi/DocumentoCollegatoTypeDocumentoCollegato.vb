Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class DocumentoCollegatoTypeDocumentoCollegato

        Private chiaveCollegamentoField As Conservatori.PARER.Conservazione.Schemi.ChiaveType

        Private descrizioneCollegamentoField As String

        '''<remarks/>
        Public Property ChiaveCollegamento() As Conservatori.PARER.Conservazione.Schemi.ChiaveType
            Get
                Return Me.chiaveCollegamentoField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.ChiaveType)
                Me.chiaveCollegamentoField = value
            End Set
        End Property

        '''<remarks/>
        Public Property DescrizioneCollegamento() As String
            Get
                Return Me.descrizioneCollegamentoField
            End Get
            Set(value As String)
                Me.descrizioneCollegamentoField = value
            End Set
        End Property
    End Class
End Namespace
