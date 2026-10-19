Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlRootAttribute("RapportoVersamento", [Namespace]:="", IsNullable:=False)> _
    Partial Public Class RapportoVersamentoType

        Private versioneField As String

        Private uRNRapportoVersamentoField As String

        Private dataRapportoVersamentoField As Date

        Private esitoGeneraleField As ECEsitoGeneraleType

        Private warningUlterioriField() As ECWarningType

        Private versatoreField As SCVersatoreType

        Private sIPField As SIPType

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
        Public Property URNRapportoVersamento() As String
            Get
                Return Me.uRNRapportoVersamentoField
            End Get
            Set(value As String)
                Me.uRNRapportoVersamentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DataRapportoVersamento() As Date
            Get
                Return Me.dataRapportoVersamentoField
            End Get
            Set(value As Date)
                Me.dataRapportoVersamentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EsitoGenerale() As ECEsitoGeneraleType
            Get
                Return Me.esitoGeneraleField
            End Get
            Set(value As ECEsitoGeneraleType)
                Me.esitoGeneraleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Warning", IsNullable:=False)> _
        Public Property WarningUlteriori() As ECWarningType()
            Get
                Return Me.warningUlterioriField
            End Get
            Set(value As ECWarningType())
                Me.warningUlterioriField = Value
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
        Public Property SIP() As SIPType
            Get
                Return Me.sIPField
            End Get
            Set(value As SIPType)
                Me.sIPField = Value
            End Set
        End Property
    End Class
End Namespace
