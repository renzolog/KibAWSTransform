Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECUnitaDocAggAllType

        Private versatoreField As SCVersatoreType

        Private chiaveField As SCChiaveType

        Private dataVersamentoField As Date

        Private dataVersamentoFieldSpecified As Boolean

        Private statoConservazioneField As ECStatoConsType

        Private statoConservazioneFieldSpecified As Boolean

        Private firmatoDigitalmenteField As Boolean

        Private firmatoDigitalmenteFieldSpecified As Boolean

        Private esitoUnitaDocumentariaField As ECUnitaDocAggAllTypeEsitoUnitaDocumentaria

        Private itemField As ECDocumentoType

        Private itemElementNameField As ItemChoiceType

        '''<remarks/>
        Public Property Versatore() As SCVersatoreType
            Get
                Return Me.versatoreField
            End Get
            Set(value As SCVersatoreType)
                Me.versatoreField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Chiave() As SCChiaveType
            Get
                Return Me.chiaveField
            End Get
            Set(value As SCChiaveType)
                Me.chiaveField = Value
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
        Public Property StatoConservazione() As ECStatoConsType
            Get
                Return Me.statoConservazioneField
            End Get
            Set(value As ECStatoConsType)
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
        Public Property FirmatoDigitalmente() As Boolean
            Get
                Return Me.firmatoDigitalmenteField
            End Get
            Set(value As Boolean)
                Me.firmatoDigitalmenteField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property FirmatoDigitalmenteSpecified() As Boolean
            Get
                Return Me.firmatoDigitalmenteFieldSpecified
            End Get
            Set(value As Boolean)
                Me.firmatoDigitalmenteFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoUnitaDocumentaria() As ECUnitaDocAggAllTypeEsitoUnitaDocumentaria
            Get
                Return Me.esitoUnitaDocumentariaField
            End Get
            Set(value As ECUnitaDocAggAllTypeEsitoUnitaDocumentaria)
                Me.esitoUnitaDocumentariaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Allegato", GetType(ECDocumentoType)), _
         System.Xml.Serialization.XmlElementAttribute("Annesso", GetType(ECDocumentoType)), _
         System.Xml.Serialization.XmlElementAttribute("Annotazione", GetType(ECDocumentoType)), _
         System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
        Public Property Item() As ECDocumentoType
            Get
                Return Me.itemField
            End Get
            Set(value As ECDocumentoType)
                Me.itemField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ItemElementName() As ItemChoiceType
            Get
                Return Me.itemElementNameField
            End Get
            Set(value As ItemChoiceType)
                Me.itemElementNameField = Value
            End Set
        End Property
    End Class
End Namespace
