Option Strict Off

Option Explicit On

Imports System.Xml.Serialization

Namespace Conservatori.PARER.Esibizione.Schemi.Response
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class SCVersatoreType

        Private ambienteField As String

        Private enteField As String

        Private strutturaField As String

        Private userIDField As String

        '''<remarks/>
        Public Property Ambiente() As String
            Get
                Return Me.ambienteField
            End Get
            Set(value As String)
                Me.ambienteField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Ente() As String
            Get
                Return Me.enteField
            End Get
            Set(value As String)
                Me.enteField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Struttura() As String
            Get
                Return Me.strutturaField
            End Get
            Set(value As String)
                Me.strutturaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UserID() As String
            Get
                Return Me.userIDField
            End Get
            Set(value As String)
                Me.userIDField = Value
            End Set
        End Property
    End Class
End Namespace
