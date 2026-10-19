Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
 
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class StrutturaType

        Private tipoStrutturaField As String

        Private componentiField() As ComponenteType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipoStruttura() As String
            Get
                Return Me.tipoStrutturaField
            End Get
            Set(value As String)
                Me.tipoStrutturaField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Componente", IsNullable:=False)> _
        Public Property Componenti() As ComponenteType()
            Get
                Return Me.componentiField
            End Get
            Set(value As ComponenteType())
                Me.componentiField = value
            End Set
        End Property
    End Class
End Namespace
