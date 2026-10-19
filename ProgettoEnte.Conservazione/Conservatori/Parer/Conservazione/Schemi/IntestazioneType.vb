Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
 
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class IntestazioneType

        Private versioneField As String

        Private versatoreField As Conservatori.PARER.Conservazione.Schemi.VersatoreType

        Private chiaveField As Conservatori.PARER.Conservazione.Schemi.ChiaveType

        Private tipologiaUnitaDocumentariaField As String

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

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipologiaUnitaDocumentaria() As String
            Get
                Return Me.tipologiaUnitaDocumentariaField
            End Get
            Set(value As String)
                Me.tipologiaUnitaDocumentariaField = value
            End Set
        End Property
    End Class
End Namespace
