Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DocumentoType

        Private iDDocumentoField As String

        Private tipoDocumentoField As String

        Private profiloDocumentoField As Conservatori.PARER.Conservazione.Schemi.ProfiloDocumentoType

        Private datiSpecificiField As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType

        Private datiSpecificiMigrazioneField As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType

        Private datiFiscaliField As Conservatori.PARER.Conservazione.Schemi.DatiFiscaliType

        Private strutturaOriginaleField As Conservatori.PARER.Conservazione.Schemi.StrutturaType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property IDDocumento() As String
            Get
                Return Me.iDDocumentoField
            End Get
            Set(value As String)
                Me.iDDocumentoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipoDocumento() As String
            Get
                Return Me.tipoDocumentoField
            End Get
            Set(value As String)
                Me.tipoDocumentoField = value
            End Set
        End Property

        '''<remarks/>
        Public Property ProfiloDocumento() As Conservatori.PARER.Conservazione.Schemi.ProfiloDocumentoType
            Get
                Return Me.profiloDocumentoField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.ProfiloDocumentoType)
                Me.profiloDocumentoField = value
            End Set
        End Property


        ' <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property DatiSpecifici() As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType
            Get
                Return Me.datiSpecificiField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType)
                Me.datiSpecificiField = value
            End Set
        End Property


        ' <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property DatiSpecificiMigrazione() As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType
            Get
                Return Me.datiSpecificiMigrazioneField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.DatiSpecificiType)
                Me.datiSpecificiMigrazioneField = value
            End Set
        End Property

        '''<remarks/>
        Public Property DatiFiscali() As Conservatori.PARER.Conservazione.Schemi.DatiFiscaliType
            Get
                Return Me.datiFiscaliField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.DatiFiscaliType)
                Me.datiFiscaliField = value
            End Set
        End Property

        '''<remarks/>
        Public Property StrutturaOriginale() As Conservatori.PARER.Conservazione.Schemi.StrutturaType
            Get
                Return Me.strutturaOriginaleField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.StrutturaType)
                Me.strutturaOriginaleField = value
            End Set
        End Property
    End Class
End Namespace
