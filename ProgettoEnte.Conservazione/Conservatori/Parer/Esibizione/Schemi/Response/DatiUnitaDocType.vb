Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DatiUnitaDocType

        Private versatoreField As SCVersatoreType

        Private chiaveField As ChiaveType

        Private statoConservazioneUDField As String

        Private volumiField() As DatiVolumeType

        '''<remarks/>
        Public Property Versatore() As SCVersatoreType
            Get
                Return Me.versatoreField
            End Get
            Set(value As SCVersatoreType)
                Me.versatoreField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Chiave() As ChiaveType
            Get
                Return Me.chiaveField
            End Get
            Set(value As ChiaveType)
                Me.chiaveField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property StatoConservazioneUD() As String
            Get
                Return Me.statoConservazioneUDField
            End Get
            Set(value As String)
                Me.statoConservazioneUDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Volume", IsNullable:=False)> _
        Public Property Volumi() As DatiVolumeType()
            Get
                Return Me.volumiField
            End Get
            Set(value As DatiVolumeType())
                Me.volumiField = Value
            End Set
        End Property
    End Class
End Namespace
