Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECEsitoXSDAggAllType

        Private codiceEsitoField As ECEsitoPosNegType

        Private controlloStrutturaXMLField As String

        Private univocitaIDComponentiField As String

        '''<remarks/>
        Public Property CodiceEsito() As ECEsitoPosNegType
            Get
                Return Me.codiceEsitoField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.codiceEsitoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ControlloStrutturaXML() As String
            Get
                Return Me.controlloStrutturaXMLField
            End Get
            Set(value As String)
                Me.controlloStrutturaXMLField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UnivocitaIDComponenti() As String
            Get
                Return Me.univocitaIDComponentiField
            End Get
            Set(value As String)
                Me.univocitaIDComponentiField = Value
            End Set
        End Property
    End Class
End Namespace
