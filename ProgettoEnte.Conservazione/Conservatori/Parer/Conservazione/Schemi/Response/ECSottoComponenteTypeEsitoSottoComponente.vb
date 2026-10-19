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
    Partial Public Class ECSottoComponenteTypeEsitoSottoComponente

        Private codiceEsitoField As ECEsitoPosNegWarType

        Private verificaTipoComponenteField As ECEsitoPosNegType

        Private verificaTipoComponenteFieldSpecified As Boolean

        Private corrispondenzaDatiSpecificiField As String

        Private verificaTipoSupportoComponenteField As String

        Private verificaNomeComponenteField As ECEsitoPosNegType

        Private verificaNomeComponenteFieldSpecified As Boolean

        Private verificaAmmissibilitaFormatoField As ECEsitoPosNegType

        Private verificaAmmissibilitaFormatoFieldSpecified As Boolean

        Private verificaRiconoscimentoFormatoField As ECEsitoRicFormatoType

        Private verificaRiconoscimentoFormatoFieldSpecified As Boolean

        Private messaggioRiconoscimentoFormatoField As String

        Private verificaRiferimentoUnitaDocumentariaField As ECEsitoPosNegType

        Private verificaRiferimentoUnitaDocumentariaFieldSpecified As Boolean

        '''<remarks/>
        Public Property CodiceEsito() As ECEsitoPosNegWarType
            Get
                Return Me.codiceEsitoField
            End Get
            Set(value As ECEsitoPosNegWarType)
                Me.codiceEsitoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaTipoComponente() As ECEsitoPosNegType
            Get
                Return Me.verificaTipoComponenteField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.verificaTipoComponenteField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaTipoComponenteSpecified() As Boolean
            Get
                Return Me.verificaTipoComponenteFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaTipoComponenteFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CorrispondenzaDatiSpecifici() As String
            Get
                Return Me.corrispondenzaDatiSpecificiField
            End Get
            Set(value As String)
                Me.corrispondenzaDatiSpecificiField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaTipoSupportoComponente() As String
            Get
                Return Me.verificaTipoSupportoComponenteField
            End Get
            Set(value As String)
                Me.verificaTipoSupportoComponenteField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaNomeComponente() As ECEsitoPosNegType
            Get
                Return Me.verificaNomeComponenteField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.verificaNomeComponenteField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaNomeComponenteSpecified() As Boolean
            Get
                Return Me.verificaNomeComponenteFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaNomeComponenteFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaAmmissibilitaFormato() As ECEsitoPosNegType
            Get
                Return Me.verificaAmmissibilitaFormatoField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.verificaAmmissibilitaFormatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaAmmissibilitaFormatoSpecified() As Boolean
            Get
                Return Me.verificaAmmissibilitaFormatoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaAmmissibilitaFormatoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaRiconoscimentoFormato() As ECEsitoRicFormatoType
            Get
                Return Me.verificaRiconoscimentoFormatoField
            End Get
            Set(value As ECEsitoRicFormatoType)
                Me.verificaRiconoscimentoFormatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaRiconoscimentoFormatoSpecified() As Boolean
            Get
                Return Me.verificaRiconoscimentoFormatoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaRiconoscimentoFormatoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MessaggioRiconoscimentoFormato() As String
            Get
                Return Me.messaggioRiconoscimentoFormatoField
            End Get
            Set(value As String)
                Me.messaggioRiconoscimentoFormatoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VerificaRiferimentoUnitaDocumentaria() As ECEsitoPosNegType
            Get
                Return Me.verificaRiferimentoUnitaDocumentariaField
            End Get
            Set(value As ECEsitoPosNegType)
                Me.verificaRiferimentoUnitaDocumentariaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property VerificaRiferimentoUnitaDocumentariaSpecified() As Boolean
            Get
                Return Me.verificaRiferimentoUnitaDocumentariaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.verificaRiferimentoUnitaDocumentariaFieldSpecified = Value
            End Set
        End Property
    End Class
End Namespace
