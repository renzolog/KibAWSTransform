Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class SottoComponenteType

        Private idField As String

        Private ordinePresentazioneField As String

        Private tipoComponenteField As String

        Private tipoSupportoComponenteField As Conservatori.PARER.Conservazione.Schemi.TipoSupportoType

        Private tipoSupportoComponenteFieldSpecified As Boolean

        Private riferimentoField As Conservatori.PARER.Conservazione.Schemi.ChiaveType

        Private nomeComponenteField As String

        Private formatoFileVersatoField As String

        Private urnVersatoField As String

        Private iDComponenteVersatoField As String

        Private datiSpecificiField As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType

        Private datiSpecificiMigrazioneField As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property ID() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
        Public Property OrdinePresentazione() As String
            Get
                Return Me.ordinePresentazioneField
            End Get
            Set(value As String)
                Me.ordinePresentazioneField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipoComponente() As String
            Get
                Return Me.tipoComponenteField
            End Get
            Set(value As String)
                Me.tipoComponenteField = value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoSupportoComponente() As Conservatori.PARER.Conservazione.Schemi.TipoSupportoType
            Get
                Return Me.tipoSupportoComponenteField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.TipoSupportoType)
                Me.tipoSupportoComponenteField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TipoSupportoComponenteSpecified() As Boolean
            Get
                Return Me.tipoSupportoComponenteFieldSpecified
            End Get
            Set(value As Boolean)
                Me.tipoSupportoComponenteFieldSpecified = value
            End Set
        End Property

        '''<remarks/>
        Public Property Riferimento() As Conservatori.PARER.Conservazione.Schemi.ChiaveType
            Get
                Return Me.riferimentoField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.ChiaveType)
                Me.riferimentoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property NomeComponente() As String
            Get
                Return Me.nomeComponenteField
            End Get
            Set(value As String)
                Me.nomeComponenteField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property FormatoFileVersato() As String
            Get
                Return Me.formatoFileVersatoField
            End Get
            Set(value As String)
                Me.formatoFileVersatoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property UrnVersato() As String
            Get
                Return Me.urnVersatoField
            End Get
            Set(value As String)
                Me.urnVersatoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property IDComponenteVersato() As String
            Get
                Return Me.iDComponenteVersatoField
            End Get
            Set(value As String)
                Me.iDComponenteVersatoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property DatiSpecifici() As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType
            Get
                Return Me.datiSpecificiField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType)
                Me.datiSpecificiField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property DatiSpecificiMigrazione() As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType
            Get
                Return Me.datiSpecificiMigrazioneField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType)
                Me.datiSpecificiMigrazioneField = value
            End Set
        End Property
    End Class
End Namespace
