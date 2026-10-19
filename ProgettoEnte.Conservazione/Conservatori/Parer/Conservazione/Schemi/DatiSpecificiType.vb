Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
 
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DatiSpecificiType

        Private versioneDatiSpecificiField As String

        Private anyField() As System.Xml.XmlElement

        '''<remarks/>
        Public Property VersioneDatiSpecifici() As String
            Get
                Return Me.versioneDatiSpecificiField
            End Get
            Set(value As String)
                Me.versioneDatiSpecificiField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAnyElementAttribute()> _
        Public Property Any() As System.Xml.XmlElement()
            Get
                Return Me.anyField
            End Get
            Set(value As System.Xml.XmlElement())
                Me.anyField = value
            End Set
        End Property
    End Class
End Namespace
