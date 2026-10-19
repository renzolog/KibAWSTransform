Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECFirmatarioType
        Private ordineFirmaField As String

        Private cognomeNomeField As String

        Private formatoFirmaField As String

        Private riferimentoTemporaleUsatoField As Date

        Private riferimentoTemporaleUsatoFieldSpecified As Boolean

        Private tipoRiferimentoTemporaleUsatoField As String

        Private esitoFirmaField As ECFirmatarioTypeEsitoFirma

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")> _
        Public Property OrdineFirma() As String
            Get
                Return Me.ordineFirmaField
            End Get
            Set(value As String)
                Me.ordineFirmaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CognomeNome() As String
            Get
                Return Me.cognomeNomeField
            End Get
            Set(value As String)
                Me.cognomeNomeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FormatoFirma() As String
            Get
                Return Me.formatoFirmaField
            End Get
            Set(value As String)
                Me.formatoFirmaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RiferimentoTemporaleUsato() As Date
            Get
                Return Me.riferimentoTemporaleUsatoField
            End Get
            Set(value As Date)
                Me.riferimentoTemporaleUsatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property RiferimentoTemporaleUsatoSpecified() As Boolean
            Get
                Return Me.riferimentoTemporaleUsatoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.riferimentoTemporaleUsatoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoRiferimentoTemporaleUsato() As String
            Get
                Return Me.tipoRiferimentoTemporaleUsatoField
            End Get
            Set(value As String)
                Me.tipoRiferimentoTemporaleUsatoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoFirma() As ECFirmatarioTypeEsitoFirma
            Get
                Return Me.esitoFirmaField
            End Get
            Set(value As ECFirmatarioTypeEsitoFirma)
                Me.esitoFirmaField = Value
            End Set
        End Property
    End Class
End Namespace
