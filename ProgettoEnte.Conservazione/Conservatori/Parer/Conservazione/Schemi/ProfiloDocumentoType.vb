Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
 
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ProfiloDocumentoType

        Private descrizioneField As String

        Private autoreField As String

        '''<remarks/>
        Public Property Descrizione() As String
            Get
                Return Me.descrizioneField
            End Get
            Set(value As String)
                Me.descrizioneField = value
            End Set
        End Property

        '''<remarks/>
        Public Property Autore() As String
            Get
                Return Me.autoreField
            End Get
            Set(value As String)
                Me.autoreField = value
            End Set
        End Property
    End Class
End Namespace
