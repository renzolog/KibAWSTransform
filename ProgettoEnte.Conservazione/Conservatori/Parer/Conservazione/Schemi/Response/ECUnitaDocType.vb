Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECUnitaDocType

        Private versatoreField As SCVersatoreType

        Private chiaveField As SCChiaveType

        Private dataVersamentoField As Date

        Private dataVersamentoFieldSpecified As Boolean

        Private statoConservazioneField As ECStatoConsType

        Private statoConservazioneFieldSpecified As Boolean

        Private firmatoDigitalmenteField As Boolean

        Private firmatoDigitalmenteFieldSpecified As Boolean

        Private esitoUnitaDocumentariaField As ECUnitaDocTypeEsitoUnitaDocumentaria

        Private documentoPrincipaleField As ECDocumentoType

        Private allegatiField() As ECDocumentoType

        Private annessiField() As ECDocumentoType

        Private annotazioniField() As ECDocumentoType

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
        Public Property EsitoUnitaDocumentaria() As ECUnitaDocTypeEsitoUnitaDocumentaria
            Get
                Return Me.esitoUnitaDocumentariaField
            End Get
            Set(value As ECUnitaDocTypeEsitoUnitaDocumentaria)
                Me.esitoUnitaDocumentariaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DocumentoPrincipale() As ECDocumentoType
            Get
                Return Me.documentoPrincipaleField
            End Get
            Set(value As ECDocumentoType)
                Me.documentoPrincipaleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Allegato", IsNullable:=False)> _
        Public Property Allegati() As ECDocumentoType()
            Get
                Return Me.allegatiField
            End Get
            Set(value As ECDocumentoType())
                Me.allegatiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Annesso", IsNullable:=False)> _
        Public Property Annessi() As ECDocumentoType()
            Get
                Return Me.annessiField
            End Get
            Set(value As ECDocumentoType())
                Me.annessiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Annotazione", IsNullable:=False)> _
        Public Property Annotazioni() As ECDocumentoType()
            Get
                Return Me.annotazioniField
            End Get
            Set(value As ECDocumentoType())
                Me.annotazioniField = Value
            End Set
        End Property
    End Class
End Namespace
