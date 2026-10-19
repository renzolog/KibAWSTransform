Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class ECMarcaTypeEsitoMarca

        Private controlloConformitaField As ECEsitoControlloType

        Private controlloConformitaFieldSpecified As Boolean

        Private dettaglioControlloConformitaField As String

        Private verificaMarcaField As ECMarcaTypeEsitoMarcaVerificaMarca

        '''<remarks/>
        Public Property ControlloConformita() As ECEsitoControlloType
            Get
                Return Me.controlloConformitaField
            End Get
            Set(value As ECEsitoControlloType)
                Me.controlloConformitaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ControlloConformitaSpecified() As Boolean
            Get
                Return Me.controlloConformitaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.controlloConformitaFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DettaglioControlloConformita() As String
            Get
                Return Me.dettaglioControlloConformitaField
            End Get
            Set(value As String)
                Me.dettaglioControlloConformitaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaMarca() As ECMarcaTypeEsitoMarcaVerificaMarca
            Get
                Return Me.verificaMarcaField
            End Get
            Set(value As ECMarcaTypeEsitoMarcaVerificaMarca)
                Me.verificaMarcaField = Value
            End Set
        End Property
    End Class
End Namespace
