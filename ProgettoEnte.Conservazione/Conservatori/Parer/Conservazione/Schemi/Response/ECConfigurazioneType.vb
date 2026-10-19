Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECConfigurazioneType
        Private tipoConservazioneField As ECConfigurazioneTypeTipoConservazione

        Private tipoConservazioneFieldSpecified As Boolean

        Private sistemaDiMigrazioneField As String

        Private forzaAccettazioneField As Boolean

        Private forzaAccettazioneFieldSpecified As Boolean

        Private forzaConservazioneField As Boolean

        Private forzaConservazioneFieldSpecified As Boolean

        Private forzaCollegamentoField As Boolean

        Private forzaCollegamentoFieldSpecified As Boolean

        Private abilitaControlloCrittograficoField As Boolean

        Private abilitaControlloCrittograficoFieldSpecified As Boolean

        Private abilitaControlloTrustField As Boolean

        Private abilitaControlloTrustFieldSpecified As Boolean

        Private abilitaControlloCertificatoField As Boolean

        Private abilitaControlloCertificatoFieldSpecified As Boolean

        Private abilitaControlloCRLField As Boolean

        Private abilitaControlloCRLFieldSpecified As Boolean

        Private abilitaControlloFormatoField As Boolean

        Private abilitaControlloFormatoFieldSpecified As Boolean

        Private accettaFirmaSconosciutaField As Boolean

        Private accettaFirmaSconosciutaFieldSpecified As Boolean

        Private accettaFirmaNonConformeField As Boolean

        Private accettaFirmaNonConformeFieldSpecified As Boolean

        Private accettaFirmaNoDelibera45Field As Boolean

        Private accettaFirmaNoDelibera45FieldSpecified As Boolean

        Private accettaMarcaSconosciutaField As Boolean

        Private accettaMarcaSconosciutaFieldSpecified As Boolean

        Private accettaControlloCrittograficoNegativoField As Boolean

        Private accettaControlloCrittograficoNegativoFieldSpecified As Boolean

        Private accettaControlloTrustNegativoField As Boolean

        Private accettaControlloTrustNegativoFieldSpecified As Boolean

        Private accettaControlloCertificatoScadutoField As Boolean

        Private accettaControlloCertificatoScadutoFieldSpecified As Boolean

        Private accettaControlloCertificatoNoValidoField As Boolean

        Private accettaControlloCertificatoNoValidoFieldSpecified As Boolean

        Private accettaControlloCertificatoNoFirmaField As Boolean

        Private accettaControlloCertificatoNoFirmaFieldSpecified As Boolean

        Private accettaControlloCRLNegativoField As Boolean

        Private accettaControlloCRLNegativoFieldSpecified As Boolean

        Private accettaControlloCRLScadutaField As Boolean

        Private accettaControlloCRLScadutaFieldSpecified As Boolean

        Private accettaControlloCRLNoValidaField As Boolean

        Private accettaControlloCRLNoValidaFieldSpecified As Boolean

        Private accettaControlloCRLNoScaricField As Boolean

        Private accettaControlloCRLNoScaricFieldSpecified As Boolean

        Private accettaControlloFormatoNegativoField As Boolean

        Private accettaControlloFormatoNegativoFieldSpecified As Boolean

        '''<remarks/>
        Public Property TipoConservazione() As ECConfigurazioneTypeTipoConservazione
            Get
                Return Me.tipoConservazioneField
            End Get
            Set(value As ECConfigurazioneTypeTipoConservazione)
                Me.tipoConservazioneField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TipoConservazioneSpecified() As Boolean
            Get
                Return Me.tipoConservazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.tipoConservazioneFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SistemaDiMigrazione() As String
            Get
                Return Me.sistemaDiMigrazioneField
            End Get
            Set(value As String)
                Me.sistemaDiMigrazioneField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ForzaAccettazione() As Boolean
            Get
                Return Me.forzaAccettazioneField
            End Get
            Set(value As Boolean)
                Me.forzaAccettazioneField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ForzaAccettazioneSpecified() As Boolean
            Get
                Return Me.forzaAccettazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.forzaAccettazioneFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ForzaConservazione() As Boolean
            Get
                Return Me.forzaConservazioneField
            End Get
            Set(value As Boolean)
                Me.forzaConservazioneField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ForzaConservazioneSpecified() As Boolean
            Get
                Return Me.forzaConservazioneFieldSpecified
            End Get
            Set(value As Boolean)
                Me.forzaConservazioneFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ForzaCollegamento() As Boolean
            Get
                Return Me.forzaCollegamentoField
            End Get
            Set(value As Boolean)
                Me.forzaCollegamentoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ForzaCollegamentoSpecified() As Boolean
            Get
                Return Me.forzaCollegamentoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.forzaCollegamentoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AbilitaControlloCrittografico() As Boolean
            Get
                Return Me.abilitaControlloCrittograficoField
            End Get
            Set(value As Boolean)
                Me.abilitaControlloCrittograficoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AbilitaControlloCrittograficoSpecified() As Boolean
            Get
                Return Me.abilitaControlloCrittograficoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.abilitaControlloCrittograficoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AbilitaControlloTrust() As Boolean
            Get
                Return Me.abilitaControlloTrustField
            End Get
            Set(value As Boolean)
                Me.abilitaControlloTrustField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AbilitaControlloTrustSpecified() As Boolean
            Get
                Return Me.abilitaControlloTrustFieldSpecified
            End Get
            Set(value As Boolean)
                Me.abilitaControlloTrustFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AbilitaControlloCertificato() As Boolean
            Get
                Return Me.abilitaControlloCertificatoField
            End Get
            Set(value As Boolean)
                Me.abilitaControlloCertificatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AbilitaControlloCertificatoSpecified() As Boolean
            Get
                Return Me.abilitaControlloCertificatoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.abilitaControlloCertificatoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AbilitaControlloCRL() As Boolean
            Get
                Return Me.abilitaControlloCRLField
            End Get
            Set(value As Boolean)
                Me.abilitaControlloCRLField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AbilitaControlloCRLSpecified() As Boolean
            Get
                Return Me.abilitaControlloCRLFieldSpecified
            End Get
            Set(value As Boolean)
                Me.abilitaControlloCRLFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AbilitaControlloFormato() As Boolean
            Get
                Return Me.abilitaControlloFormatoField
            End Get
            Set(value As Boolean)
                Me.abilitaControlloFormatoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AbilitaControlloFormatoSpecified() As Boolean
            Get
                Return Me.abilitaControlloFormatoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.abilitaControlloFormatoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaFirmaSconosciuta() As Boolean
            Get
                Return Me.accettaFirmaSconosciutaField
            End Get
            Set(value As Boolean)
                Me.accettaFirmaSconosciutaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaFirmaSconosciutaSpecified() As Boolean
            Get
                Return Me.accettaFirmaSconosciutaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaFirmaSconosciutaFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaFirmaNonConforme() As Boolean
            Get
                Return Me.accettaFirmaNonConformeField
            End Get
            Set(value As Boolean)
                Me.accettaFirmaNonConformeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaFirmaNonConformeSpecified() As Boolean
            Get
                Return Me.accettaFirmaNonConformeFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaFirmaNonConformeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaFirmaNoDelibera45() As Boolean
            Get
                Return Me.accettaFirmaNoDelibera45Field
            End Get
            Set(value As Boolean)
                Me.accettaFirmaNoDelibera45Field = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaFirmaNoDelibera45Specified() As Boolean
            Get
                Return Me.accettaFirmaNoDelibera45FieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaFirmaNoDelibera45FieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaMarcaSconosciuta() As Boolean
            Get
                Return Me.accettaMarcaSconosciutaField
            End Get
            Set(value As Boolean)
                Me.accettaMarcaSconosciutaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaMarcaSconosciutaSpecified() As Boolean
            Get
                Return Me.accettaMarcaSconosciutaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaMarcaSconosciutaFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloCrittograficoNegativo() As Boolean
            Get
                Return Me.accettaControlloCrittograficoNegativoField
            End Get
            Set(value As Boolean)
                Me.accettaControlloCrittograficoNegativoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloCrittograficoNegativoSpecified() As Boolean
            Get
                Return Me.accettaControlloCrittograficoNegativoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloCrittograficoNegativoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloTrustNegativo() As Boolean
            Get
                Return Me.accettaControlloTrustNegativoField
            End Get
            Set(value As Boolean)
                Me.accettaControlloTrustNegativoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloTrustNegativoSpecified() As Boolean
            Get
                Return Me.accettaControlloTrustNegativoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloTrustNegativoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloCertificatoScaduto() As Boolean
            Get
                Return Me.accettaControlloCertificatoScadutoField
            End Get
            Set(value As Boolean)
                Me.accettaControlloCertificatoScadutoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloCertificatoScadutoSpecified() As Boolean
            Get
                Return Me.accettaControlloCertificatoScadutoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloCertificatoScadutoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloCertificatoNoValido() As Boolean
            Get
                Return Me.accettaControlloCertificatoNoValidoField
            End Get
            Set(value As Boolean)
                Me.accettaControlloCertificatoNoValidoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloCertificatoNoValidoSpecified() As Boolean
            Get
                Return Me.accettaControlloCertificatoNoValidoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloCertificatoNoValidoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloCertificatoNoFirma() As Boolean
            Get
                Return Me.accettaControlloCertificatoNoFirmaField
            End Get
            Set(value As Boolean)
                Me.accettaControlloCertificatoNoFirmaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloCertificatoNoFirmaSpecified() As Boolean
            Get
                Return Me.accettaControlloCertificatoNoFirmaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloCertificatoNoFirmaFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloCRLNegativo() As Boolean
            Get
                Return Me.accettaControlloCRLNegativoField
            End Get
            Set(value As Boolean)
                Me.accettaControlloCRLNegativoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloCRLNegativoSpecified() As Boolean
            Get
                Return Me.accettaControlloCRLNegativoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloCRLNegativoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloCRLScaduta() As Boolean
            Get
                Return Me.accettaControlloCRLScadutaField
            End Get
            Set(value As Boolean)
                Me.accettaControlloCRLScadutaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloCRLScadutaSpecified() As Boolean
            Get
                Return Me.accettaControlloCRLScadutaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloCRLScadutaFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloCRLNoValida() As Boolean
            Get
                Return Me.accettaControlloCRLNoValidaField
            End Get
            Set(value As Boolean)
                Me.accettaControlloCRLNoValidaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloCRLNoValidaSpecified() As Boolean
            Get
                Return Me.accettaControlloCRLNoValidaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloCRLNoValidaFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloCRLNoScaric() As Boolean
            Get
                Return Me.accettaControlloCRLNoScaricField
            End Get
            Set(value As Boolean)
                Me.accettaControlloCRLNoScaricField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloCRLNoScaricSpecified() As Boolean
            Get
                Return Me.accettaControlloCRLNoScaricFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloCRLNoScaricFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AccettaControlloFormatoNegativo() As Boolean
            Get
                Return Me.accettaControlloFormatoNegativoField
            End Get
            Set(value As Boolean)
                Me.accettaControlloFormatoNegativoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AccettaControlloFormatoNegativoSpecified() As Boolean
            Get
                Return Me.accettaControlloFormatoNegativoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.accettaControlloFormatoNegativoFieldSpecified = Value
            End Set
        End Property
    End Class
End Namespace
