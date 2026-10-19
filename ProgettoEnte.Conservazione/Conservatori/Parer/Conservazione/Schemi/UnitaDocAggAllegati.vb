Option Strict Off

Option Explicit On

Imports System.Xml.Serialization
Namespace Conservatori.PARER.Conservazione.Schemi
 
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)> _
    Partial Public Class UnitaDocAggAllegati

        Private intestazioneField As Conservatori.PARER.Conservazione.Schemi.IntestazioneAggAllType

        Private configurazioneField As Conservatori.PARER.Conservazione.Schemi.ConfigAggAllType

        Private itemField As Conservatori.PARER.Conservazione.Schemi.DocumentoType

        Private itemElementNameField As Conservatori.PARER.Conservazione.Schemi.ItemChoiceType

        '''<remarks/>
        Public Property Intestazione() As Conservatori.PARER.Conservazione.Schemi.IntestazioneAggAllType
            Get
                Return Me.intestazioneField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.IntestazioneAggAllType)
                Me.intestazioneField = value
            End Set
        End Property

        '''<remarks/>
        Public Property Configurazione() As Conservatori.PARER.Conservazione.Schemi.ConfigAggAllType
            Get
                Return Me.configurazioneField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.ConfigAggAllType)
                Me.configurazioneField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Allegato", GetType(Conservatori.PARER.Conservazione.Schemi.DocumentoType)), _
         System.Xml.Serialization.XmlElementAttribute("Annesso", GetType(Conservatori.PARER.Conservazione.Schemi.DocumentoType)), _
         System.Xml.Serialization.XmlElementAttribute("Annotazione", GetType(Conservatori.PARER.Conservazione.Schemi.DocumentoType)), _
         System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
        Public Property Item() As Conservatori.PARER.Conservazione.Schemi.DocumentoType
            Get
                Return Me.itemField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.DocumentoType)
                Me.itemField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ItemElementName() As Conservatori.PARER.Conservazione.Schemi.ItemChoiceType
            Get
                Return Me.itemElementNameField
            End Get
            Set(value As Conservatori.PARER.Conservazione.Schemi.ItemChoiceType)
                Me.itemElementNameField = value
            End Set
        End Property
    End Class
End Namespace
