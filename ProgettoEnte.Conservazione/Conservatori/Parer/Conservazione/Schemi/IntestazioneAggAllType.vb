Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class IntestazioneAggAllType

        Private versioneField As String

        Private versatoreField As Conservatori.PARER.Conservazione.Schemi.VersatoreType

        Private chiaveField As Conservatori.PARER.Conservazione.Schemi.ChiaveType

        '''<remarks/>
        Public Property Versione() As String
            Get
                Return Me.versioneField
            End Get
            Set(value As String)
                Me.versioneField = value
            End Set
        End Property

        '''<remarks/>
        Public Property Versatore() As Conservatori.PARER.Conservazione.Schemi.VersatoreType
            Get
                Return Me.versatoreField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.VersatoreType)
                Me.versatoreField = value
            End Set
        End Property

        '''<remarks/>
        Public Property Chiave() As Conservatori.PARER.Conservazione.Schemi.ChiaveType
            Get
                Return Me.chiaveField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.ChiaveType)
                Me.chiaveField = value
            End Set
        End Property
    End Class
End Namespace
