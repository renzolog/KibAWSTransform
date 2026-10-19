Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ProfiloArchivisticoType

        Private fascicoloPrincipaleField As CamiciaFascicoloType

        Private fascicoliSecondariField() As CamiciaFascicoloType

        '''<remarks/>
        Public Property FascicoloPrincipale() As CamiciaFascicoloType
            Get
                Return Me.fascicoloPrincipaleField
            End Get
            Set(value As CamiciaFascicoloType)
                Me.fascicoloPrincipaleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("FascicoloSecondario", IsNullable:=False)> _
        Public Property FascicoliSecondari() As CamiciaFascicoloType()
            Get
                Return Me.fascicoliSecondariField
            End Get
            Set(value As CamiciaFascicoloType())
                Me.fascicoliSecondariField = Value
            End Set
        End Property
    End Class
End Namespace
