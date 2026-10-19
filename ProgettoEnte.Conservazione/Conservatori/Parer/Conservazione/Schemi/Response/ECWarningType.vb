Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECWarningType

        Private codiceWarningField As String

        Private messaggioWarningField As String

        '''<remarks/>
        Public Property CodiceWarning() As String
            Get
                Return Me.codiceWarningField
            End Get
            Set(value As String)
                Me.codiceWarningField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MessaggioWarning() As String
            Get
                Return Me.messaggioWarningField
            End Get
            Set(value As String)
                Me.messaggioWarningField = Value
            End Set
        End Property
    End Class
End Namespace
