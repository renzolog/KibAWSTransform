Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class UnitaDocumentariaSIPType

        Private chiaveField As SCChiaveType

        Private tipologiaUnitaDocumentariaField As String

        Private documentoPrincipaleField As DocumentoSIPType

        Private allegatoField() As DocumentoSIPType

        Private annessoField() As DocumentoSIPType

        Private annotazioneField() As DocumentoSIPType

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
        Public Property TipologiaUnitaDocumentaria() As String
            Get
                Return Me.tipologiaUnitaDocumentariaField
            End Get
            Set(value As String)
                Me.tipologiaUnitaDocumentariaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DocumentoPrincipale() As DocumentoSIPType
            Get
                Return Me.documentoPrincipaleField
            End Get
            Set(value As DocumentoSIPType)
                Me.documentoPrincipaleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Allegato")> _
        Public Property Allegato() As DocumentoSIPType()
            Get
                Return Me.allegatoField
            End Get
            Set(value As DocumentoSIPType())
                Me.allegatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Annesso")> _
        Public Property Annesso() As DocumentoSIPType()
            Get
                Return Me.annessoField
            End Get
            Set(value As DocumentoSIPType())
                Me.annessoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Annotazione")> _
        Public Property Annotazione() As DocumentoSIPType()
            Get
                Return Me.annotazioneField
            End Get
            Set(value As DocumentoSIPType())
                Me.annotazioneField = Value
            End Set
        End Property
    End Class
End Namespace
