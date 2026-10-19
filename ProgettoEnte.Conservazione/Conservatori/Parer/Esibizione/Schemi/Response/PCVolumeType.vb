Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class PCVolumeType

        Private idVolumeField As String

        Private nomeVolumeField As String

        Private directoryField As String

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
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property Directory() As String
            Get
                Return Me.directoryField
            End Get
            Set(value As String)
                Me.directoryField = Value
            End Set
        End Property
    End Class
End Namespace
