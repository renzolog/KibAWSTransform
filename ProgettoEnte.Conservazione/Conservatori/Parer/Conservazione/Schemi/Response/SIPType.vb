Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class SIPType

        Private uRNIndiceSIPField As String

        Private hashIndiceSIPField As String

        Private algoritmoHashIndiceSIPField As String

        Private encodingHashIndiceSIPField As String

        Private uRNPISIPField As String

        Private hashPISIPField As String

        Private algoritmoHashPISIPField As String

        Private encodingHashPISIPField As String

        Private dataVersamentoField As Date

        Private dataVersamentoFieldSpecified As Boolean

        Private unitaDocumentariaField As UnitaDocumentariaSIPType

        '''<remarks/>
        Public Property URNIndiceSIP() As String
            Get
                Return Me.uRNIndiceSIPField
            End Get
            Set(value As String)
                Me.uRNIndiceSIPField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property HashIndiceSIP() As String
            Get
                Return Me.hashIndiceSIPField
            End Get
            Set(value As String)
                Me.hashIndiceSIPField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property AlgoritmoHashIndiceSIP() As String
            Get
                Return Me.algoritmoHashIndiceSIPField
            End Get
            Set(value As String)
                Me.algoritmoHashIndiceSIPField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property EncodingHashIndiceSIP() As String
            Get
                Return Me.encodingHashIndiceSIPField
            End Get
            Set(value As String)
                Me.encodingHashIndiceSIPField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property URNPISIP() As String
            Get
                Return Me.uRNPISIPField
            End Get
            Set(value As String)
                Me.uRNPISIPField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property HashPISIP() As String
            Get
                Return Me.hashPISIPField
            End Get
            Set(value As String)
                Me.hashPISIPField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property AlgoritmoHashPISIP() As String
            Get
                Return Me.algoritmoHashPISIPField
            End Get
            Set(value As String)
                Me.algoritmoHashPISIPField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property EncodingHashPISIP() As String
            Get
                Return Me.encodingHashPISIPField
            End Get
            Set(value As String)
                Me.encodingHashPISIPField = Value
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
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property DataVersamentoSpecified() As Boolean
            Get
                Return Me.dataVersamentoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.dataVersamentoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UnitaDocumentaria() As UnitaDocumentariaSIPType
            Get
                Return Me.unitaDocumentariaField
            End Get
            Set(value As UnitaDocumentariaSIPType)
                Me.unitaDocumentariaField = Value
            End Set
        End Property
    End Class
End Namespace
