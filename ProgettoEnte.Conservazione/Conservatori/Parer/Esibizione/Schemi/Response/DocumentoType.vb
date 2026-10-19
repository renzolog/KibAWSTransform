Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DocumentoType

        Private chiaveDocField As String

        Private dataVersamentoDocField As Date

        Private tipoConservazioneField As TipoConservazioneType

        Private tipoConservazioneFieldSpecified As Boolean

        Private sistemaDiMigrazioneField As String

        Private iDDocumentoField As String

        Private tipoDocumentoField As String

        Private statoConservazioneField As DocumentoTypeStatoConservazione

        Private statoConservazioneFieldSpecified As Boolean

        Private volumiField() As DatiRifVolumeType

        Private profiloDocumentoField As ProfiloDocumentoType

        Private datiSpecificiField As DatiSpecificiType

        Private datiSpecificiMigrazioneField As DatiSpecificiType

        Private datiFiscaliField As DatiFiscaliType

        Private strutturaOriginaleField As StrutturaType

        '''<remarks/>
        Public Property ChiaveDoc() As String
            Get
                Return Me.chiaveDocField
            End Get
            Set(value As String)
                Me.chiaveDocField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataVersamentoDoc() As Date
            Get
                Return Me.dataVersamentoDocField
            End Get
            Set(value As Date)
                Me.dataVersamentoDocField = Value
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

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property IDDocumento() As String
            Get
                Return Me.iDDocumentoField
            End Get
            Set(value As String)
                Me.iDDocumentoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipoDocumento() As String
            Get
                Return Me.tipoDocumentoField
            End Get
            Set(value As String)
                Me.tipoDocumentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property StatoConservazione() As DocumentoTypeStatoConservazione
            Get
                Return Me.statoConservazioneField
            End Get
            Set(value As DocumentoTypeStatoConservazione)
                Me.statoConservazioneField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property StatoConservazioneSpecified() As Boolean
            Get
                Return Me.statoConservazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.statoConservazioneFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Volume", IsNullable:=False)> _
        Public Property Volumi() As DatiRifVolumeType()
            Get
                Return Me.volumiField
            End Get
            Set(value As DatiRifVolumeType())
                Me.volumiField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ProfiloDocumento() As ProfiloDocumentoType
            Get
                Return Me.profiloDocumentoField
            End Get
            Set(value As ProfiloDocumentoType)
                Me.profiloDocumentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DatiSpecifici() As DatiSpecificiType
            Get
                Return Me.datiSpecificiField
            End Get
            Set(value As DatiSpecificiType)
                Me.datiSpecificiField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DatiSpecificiMigrazione() As DatiSpecificiType
            Get
                Return Me.datiSpecificiMigrazioneField
            End Get
            Set(value As DatiSpecificiType)
                Me.datiSpecificiMigrazioneField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DatiFiscali() As DatiFiscaliType
            Get
                Return Me.datiFiscaliField
            End Get
            Set(value As DatiFiscaliType)
                Me.datiFiscaliField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property StrutturaOriginale() As StrutturaType
            Get
                Return Me.strutturaOriginaleField
            End Get
            Set(value As StrutturaType)
                Me.strutturaOriginaleField = Value
            End Set
        End Property
    End Class
End Namespace
