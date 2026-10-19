Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECEsitoChiamataWSType

        Private versioneWSCorrettaField As ECEsitoPosNegType

        Private credenzialiOperatoreField As ECEsitoPosNegType

        Private fileAttesiRicevutiField As ECEsitoPosNegType

        '''<remarks/>
        Public Property VersioneWSCorretta() As ECEsitoPosNegType
            Get
                Return Me.versioneWSCorrettaField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.versioneWSCorrettaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CredenzialiOperatore() As ECEsitoPosNegType
            Get
                Return Me.credenzialiOperatoreField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.credenzialiOperatoreField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FileAttesiRicevuti() As ECEsitoPosNegType
            Get
                Return Me.fileAttesiRicevutiField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.fileAttesiRicevutiField = Value
            End Set
        End Property
    End Class
End Namespace
