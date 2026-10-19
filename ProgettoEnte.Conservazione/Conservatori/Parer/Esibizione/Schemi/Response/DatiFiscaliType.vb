Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DatiFiscaliType

        Private denominazioneField As String

        Private nomeField As String

        Private cognomeField As String

        Private cfField As String

        Private pIVAField As String

        Private dataEmissioneField As Date

        Private numeroProgressivoField As String

        Private registroField As String

        Private periodoFiscaleField As String

        Private dataTermineEmissioneField As System.Nullable(Of Date)

        '''<remarks/>
        Public Property Denominazione() As String
            Get
                Return Me.denominazioneField
            End Get
            Set(value As String)
                Me.denominazioneField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Nome() As String
            Get
                Return Me.nomeField
            End Get
            Set(value As String)
                Me.nomeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Cognome() As String
            Get
                Return Me.cognomeField
            End Get
            Set(value As String)
                Me.cognomeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property CF() As String
            Get
                Return Me.cfField
            End Get
            Set(value As String)
                Me.cfField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property PIVA() As String
            Get
                Return Me.pIVAField
            End Get
            Set(value As String)
                Me.pIVAField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataEmissione() As Date
            Get
                Return Me.dataEmissioneField
            End Get
            Set(value As Date)
                Me.dataEmissioneField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")> _
        Public Property NumeroProgressivo() As String
            Get
                Return Me.numeroProgressivoField
            End Get
            Set(value As String)
                Me.numeroProgressivoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Registro() As String
            Get
                Return Me.registroField
            End Get
            Set(value As String)
                Me.registroField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property PeriodoFiscale() As String
            Get
                Return Me.periodoFiscaleField
            End Get
            Set(value As String)
                Me.periodoFiscaleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
        Public Property DataTermineEmissione() As System.Nullable(Of Date)
            Get
                Return Me.dataTermineEmissioneField
            End Get
            Set(value As System.Nullable(Of Date))
                Me.dataTermineEmissioneField = Value
            End Set
        End Property
    End Class
End Namespace
