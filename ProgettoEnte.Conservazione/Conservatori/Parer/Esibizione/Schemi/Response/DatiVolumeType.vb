Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class DatiVolumeType

        Private idVolumeField As String

        Private nomeVolumeField As String

        Private statoVolumeField As String

        Private dataAperturaVolumeField As Date

        Private dataAperturaVolumeFieldSpecified As Boolean

        Private dataChiusuraVolumeField As Date

        Private dataChiusuraVolumeFieldSpecified As Boolean

        Private dataFirmaVolumeField As Date

        Private dataFirmaVolumeFieldSpecified As Boolean

        Private documentiContenutiField() As DocumentoContenutoType

        '''<remarks/>
        Public Property IdVolume() As String
            Get
                Return Me.idVolumeField
            End Get
            Set(value As String)
                Me.idVolumeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property NomeVolume() As String
            Get
                Return Me.nomeVolumeField
            End Get
            Set(value As String)
                Me.nomeVolumeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property StatoVolume() As String
            Get
                Return Me.statoVolumeField
            End Get
            Set(value As String)
                Me.statoVolumeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataAperturaVolume() As Date
            Get
                Return Me.dataAperturaVolumeField
            End Get
            Set(value As Date)
                Me.dataAperturaVolumeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property DataAperturaVolumeSpecified() As Boolean
            Get
                Return Me.dataAperturaVolumeFieldSpecified
            End Get
            Set(value As Boolean)
                Me.dataAperturaVolumeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataChiusuraVolume() As Date
            Get
                Return Me.dataChiusuraVolumeField
            End Get
            Set(value As Date)
                Me.dataChiusuraVolumeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property DataChiusuraVolumeSpecified() As Boolean
            Get
                Return Me.dataChiusuraVolumeFieldSpecified
            End Get
            Set(value As Boolean)
                Me.dataChiusuraVolumeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataFirmaVolume() As Date
            Get
                Return Me.dataFirmaVolumeField
            End Get
            Set(value As Date)
                Me.dataFirmaVolumeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property DataFirmaVolumeSpecified() As Boolean
            Get
                Return Me.dataFirmaVolumeFieldSpecified
            End Get
            Set(value As Boolean)
                Me.dataFirmaVolumeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("DocumentoContenuto", IsNullable:=False)> _
        Public Property DocumentiContenuti() As DocumentoContenutoType()
            Get
                Return Me.documentiContenutiField
            End Get
            Set(value As DocumentoContenutoType())
                Me.documentiContenutiField = Value
            End Set
        End Property
    End Class
End Namespace
