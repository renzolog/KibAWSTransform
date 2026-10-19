Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Conservazione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ECErroreType

        Private codiceErroreField As String

        Private messaggioErroreField As String

        '''<remarks/>
        Public Property CodiceErrore() As String
            Get
                Return Me.codiceErroreField
            End Get
            Set(value As String)
                Me.codiceErroreField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MessaggioErrore() As String
            Get
                Return Me.messaggioErroreField
            End Get
            Set(value As String)
                Me.messaggioErroreField = Value
            End Set
        End Property
    End Class
End Namespace
