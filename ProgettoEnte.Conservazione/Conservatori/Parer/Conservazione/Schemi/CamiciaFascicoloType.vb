Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class CamiciaFascicoloType

        Private classificaField As String

        Private fascicoloField As Conservatori.PARER.Conservazione.Schemi.FascicoloType

        Private sottoFascicoloField As Conservatori.PARER.Conservazione.Schemi.FascicoloType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property Classifica() As String
            Get
                Return Me.classificaField
            End Get
            Set(value As String)
                Me.classificaField = value
            End Set
        End Property

        '''<remarks/>
        Public Property Fascicolo() As Conservatori.PARER.Conservazione.Schemi.FascicoloType
            Get
                Return Me.fascicoloField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.FascicoloType)
                Me.fascicoloField = value
            End Set
        End Property

        '''<remarks/>
        Public Property SottoFascicolo() As Conservatori.PARER.Conservazione.Schemi.FascicoloType
            Get
                Return Me.sottoFascicoloField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.FascicoloType)
                Me.sottoFascicoloField = value
            End Set
        End Property
    End Class
End Namespace
