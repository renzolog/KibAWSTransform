Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class CamiciaFascicoloType

        Private classificaField As String

        Private fascicoloField As FascicoloType

        Private sottoFascicoloField As FascicoloType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property Classifica() As String
            Get
                Return Me.classificaField
            End Get
            Set(value As String)
                Me.classificaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Fascicolo() As FascicoloType
            Get
                Return Me.fascicoloField
            End Get
            Set(value As FascicoloType)
                Me.fascicoloField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SottoFascicolo() As FascicoloType
            Get
                Return Me.sottoFascicoloField
            End Get
            Set(value As FascicoloType)
                Me.sottoFascicoloField = Value
            End Set
        End Property
    End Class
End Namespace
