Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)> _
    Partial Public Class UnitaDocumentaria

        Private versioneField As String

        Private versioneXMLChiamataField As String

        Private dataRichiestaStatoField As Date

        Private esitoGeneraleField As EsitoGenericoType

        Private esitoChiamataWSField As EsitoChiamataWSType

        Private fileInclusiNellaRispostaField As Boolean

        Private versatoreField As SCVersatoreType

        Private chiaveField As ChiaveType

        Private esitoVersamentoField() As EsitoGenericoType

        Private tipologiaUnitaDocumentariaField As String

        Private dataCreazioneUDField As Date

        Private statoConservazioneUDField As String

        Private profiloArchivisticoField As ProfiloArchivisticoType

        Private profiloUnitaDocumentariaField As ProfiloUnitaDocumentariaType

        Private datiSpecificiField As DatiSpecificiType

        Private datiSpecificiMigrazioneField As DatiSpecificiType

        Private documentiCollegatiField() As DocumentoCollegatoTypeDocumentoCollegato

        Private numeroAllegatiField As String

        Private numeroAnnessiField As String

        Private numeroAnnotazioniField As String

        Private documentoPrincipaleField As DocumentoType

        Private allegatiField() As DocumentoType

        Private annessiField() As DocumentoType

        Private annotazioniField() As DocumentoType

        '''<remarks/>
        Public Property Versione() As String
            Get
                Return Me.versioneField
            End Get
            Set(value As String)
                Me.versioneField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property VersioneXMLChiamata() As String
            Get
                Return Me.versioneXMLChiamataField
            End Get
            Set(value As String)
                Me.versioneXMLChiamataField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataRichiestaStato() As Date
            Get
                Return Me.dataRichiestaStatoField
            End Get
            Set(value As Date)
                Me.dataRichiestaStatoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoGenerale() As EsitoGenericoType
            Get
                Return Me.esitoGeneraleField
            End Get
            Set(value As EsitoGenericoType)
                Me.esitoGeneraleField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoChiamataWS() As EsitoChiamataWSType
            Get
                Return Me.esitoChiamataWSField
            End Get
            Set(value As EsitoChiamataWSType)
                Me.esitoChiamataWSField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FileInclusiNellaRisposta() As Boolean
            Get
                Return Me.fileInclusiNellaRispostaField
            End Get
            Set(value As Boolean)
                Me.fileInclusiNellaRispostaField = Value
            End Set
        End Property

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
        Public Property Chiave() As ChiaveType
            Get
                Return Me.chiaveField
            End Get
            Set(value As ChiaveType)
                Me.chiaveField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Esito", IsNullable:=False)> _
        Public Property EsitoVersamento() As EsitoGenericoType()
            Get
                Return Me.esitoVersamentoField
            End Get
            Set(value As EsitoGenericoType())
                Me.esitoVersamentoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public Property TipologiaUnitaDocumentaria() As String
            Get
                Return Me.tipologiaUnitaDocumentariaField
            End Get
            Set(value As String)
                Me.tipologiaUnitaDocumentariaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataCreazioneUD() As Date
            Get
                Return Me.dataCreazioneUDField
            End Get
            Set(value As Date)
                Me.dataCreazioneUDField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property StatoConservazioneUD() As String
            Get
                Return Me.statoConservazioneUDField
            End Get
            Set(value As String)
                Me.statoConservazioneUDField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ProfiloArchivistico() As ProfiloArchivisticoType
            Get
                Return Me.profiloArchivisticoField
            End Get
            Set(value As ProfiloArchivisticoType)
                Me.profiloArchivisticoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ProfiloUnitaDocumentaria() As ProfiloUnitaDocumentariaType
            Get
                Return Me.profiloUnitaDocumentariaField
            End Get
            Set(value As ProfiloUnitaDocumentariaType)
                Me.profiloUnitaDocumentariaField = Value
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
        <System.Xml.Serialization.XmlArrayItemAttribute("DocumentoCollegato", IsNullable:=False)> _
        Public Property DocumentiCollegati() As DocumentoCollegatoTypeDocumentoCollegato()
            Get
                Return Me.documentiCollegatiField
            End Get
            Set(value As DocumentoCollegatoTypeDocumentoCollegato())
                Me.documentiCollegatiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="nonNegativeInteger")> _
        Public Property NumeroAllegati() As String
            Get
                Return Me.numeroAllegatiField
            End Get
            Set(value As String)
                Me.numeroAllegatiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="nonNegativeInteger")> _
        Public Property NumeroAnnessi() As String
            Get
                Return Me.numeroAnnessiField
            End Get
            Set(value As String)
                Me.numeroAnnessiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="nonNegativeInteger")> _
        Public Property NumeroAnnotazioni() As String
            Get
                Return Me.numeroAnnotazioniField
            End Get
            Set(value As String)
                Me.numeroAnnotazioniField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DocumentoPrincipale() As DocumentoType
            Get
                Return Me.documentoPrincipaleField
            End Get
            Set(value As DocumentoType)
                Me.documentoPrincipaleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Allegato", IsNullable:=False)> _
        Public Property Allegati() As DocumentoType()
            Get
                Return Me.allegatiField
            End Get
            Set(value As DocumentoType())
                Me.allegatiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Annesso", IsNullable:=False)> _
        Public Property Annessi() As DocumentoType()
            Get
                Return Me.annessiField
            End Get
            Set(value As DocumentoType())
                Me.annessiField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Annotazione", IsNullable:=False)> _
        Public Property Annotazioni() As DocumentoType()
            Get
                Return Me.annotazioniField
            End Get
            Set(value As DocumentoType())
                Me.annotazioniField = Value
            End Set
        End Property
    End Class
End Namespace
