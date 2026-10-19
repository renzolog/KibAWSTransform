Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DatiRifVolumeType

        Private idVolumeField As String

        Private nomeVolumeField As String

        Private statoVolumeField As String

        '''<remarks/>
        Public Property IdVolume() As String
            Get
                Return Me.idVolumeField
            End Get
            Set(value As String)
                Me.idVolumeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property NomeVolume() As String
            Get
                Return Me.nomeVolumeField
            End Get
            Set(value As String)
                Me.nomeVolumeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property StatoVolume() As String
            Get
                Return Me.statoVolumeField
            End Get
            Set(value As String)
                Me.statoVolumeField = Value
            End Set
        End Property
    End Class
End Namespace
