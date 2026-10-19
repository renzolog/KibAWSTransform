Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DocumentoContenutoType

        Private uRNDocumentoField As String

        Private dataVersamentoField As Date

        Private tipoConservazioneField As TipoConservazioneType

        Private tipoConservazioneFieldSpecified As Boolean

        Private sistemaDiMigrazioneField As String

        '''<remarks/>
        Public Property URNDocumento() As String
            Get
                Return Me.uRNDocumentoField
            End Get
            Set(value As String)
                Me.uRNDocumentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataVersamento() As Date
            Get
                Return Me.dataVersamentoField
            End Get
            Set(value As Date)
                Me.dataVersamentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoConservazione() As TipoConservazioneType
            Get
                Return Me.tipoConservazioneField
            End Get
            Set(value As TipoConservazioneType)
                Me.tipoConservazioneField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TipoConservazioneSpecified() As Boolean
            Get
                Return Me.tipoConservazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.tipoConservazioneFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SistemaDiMigrazione() As String
            Get
                Return Me.sistemaDiMigrazioneField
            End Get
            Set(value As String)
                Me.sistemaDiMigrazioneField = Value
            End Set
        End Property
    End Class
End Namespace
