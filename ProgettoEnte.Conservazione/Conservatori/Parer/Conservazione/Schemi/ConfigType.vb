Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
 
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ConfigType

        Private tipoConservazioneField As Conservatori.PARER.Conservazione.Schemi.TipoConservazioneType

        Private tipoConservazioneFieldSpecified As Boolean

        Private sistemaDiMigrazioneField As String

        Private forzaAccettazioneField As Boolean

        Private forzaAccettazioneFieldSpecified As Boolean

        Private forzaConservazioneField As Boolean

        Private forzaConservazioneFieldSpecified As Boolean

        Private forzaCollegamentoField As Boolean

        Private forzaCollegamentoFieldSpecified As Boolean

        Private simulaSalvataggioDatiInDBField As Boolean

        Private simulaSalvataggioDatiInDBFieldSpecified As Boolean

        '''<remarks/>
        Public Property TipoConservazione() As Conservatori.PARER.Conservazione.Schemi.TipoConservazioneType
            Get
                Return Me.tipoConservazioneField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.TipoConservazioneType)
                Me.tipoConservazioneField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TipoConservazioneSpecified() As Boolean
            Get
                Return Me.tipoConservazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.tipoConservazioneFieldSpecified = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property SistemaDiMigrazione() As String
            Get
                Return Me.sistemaDiMigrazioneField
            End Get
            Set(value As String)
                Me.sistemaDiMigrazioneField = value
            End Set
        End Property

        '''<remarks/>
        Public Property ForzaAccettazione() As Boolean
            Get
                Return Me.forzaAccettazioneField
            End Get
            Set(value As Boolean)
                Me.forzaAccettazioneField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ForzaAccettazioneSpecified() As Boolean
            Get
                Return Me.forzaAccettazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.forzaAccettazioneFieldSpecified = value
            End Set
        End Property

        '''<remarks/>
        Public Property ForzaConservazione() As Boolean
            Get
                Return Me.forzaConservazioneField
            End Get
            Set(value As Boolean)
                Me.forzaConservazioneField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ForzaConservazioneSpecified() As Boolean
            Get
                Return Me.forzaConservazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.forzaConservazioneFieldSpecified = value
            End Set
        End Property

        '''<remarks/>
        Public Property ForzaCollegamento() As Boolean
            Get
                Return Me.forzaCollegamentoField
            End Get
            Set(value As Boolean)
                Me.forzaCollegamentoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ForzaCollegamentoSpecified() As Boolean
            Get
                Return Me.forzaCollegamentoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.forzaCollegamentoFieldSpecified = value
            End Set
        End Property

        '''<remarks/>
        Public Property SimulaSalvataggioDatiInDB() As Boolean
            Get
                Return Me.simulaSalvataggioDatiInDBField
            End Get
            Set(value As Boolean)
                Me.simulaSalvataggioDatiInDBField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property SimulaSalvataggioDatiInDBSpecified() As Boolean
            Get
                Return Me.simulaSalvataggioDatiInDBFieldSpecified
            End Get
            Set(value As Boolean)
                Me.simulaSalvataggioDatiInDBFieldSpecified = value
            End Set
        End Property
    End Class
End Namespace
