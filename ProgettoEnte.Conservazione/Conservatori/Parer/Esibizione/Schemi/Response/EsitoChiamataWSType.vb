Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class EsitoChiamataWSType

        Private versioneWSCorrettaField As ECEsitoPosNegType

        Private credenzialiOperatoreField As ECEsitoPosNegType

        Private identificazioneVersatoreField As String

        Private identificazioneChiaveField As ECEsitoPosNegType

        Private identificazioneChiaveFieldSpecified As Boolean

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
        Public Property IdentificazioneVersatore() As String
            Get
                Return Me.identificazioneVersatoreField
            End Get
            Set(value As String)
                Me.identificazioneVersatoreField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property IdentificazioneChiave() As ECEsitoPosNegType
            Get
                Return Me.identificazioneChiaveField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.identificazioneChiaveField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property IdentificazioneChiaveSpecified() As Boolean
            Get
                Return Me.identificazioneChiaveFieldSpecified
            End Get
            Set(value As Boolean)
                Me.identificazioneChiaveFieldSpecified = Value
            End Set
        End Property
    End Class
End Namespace
