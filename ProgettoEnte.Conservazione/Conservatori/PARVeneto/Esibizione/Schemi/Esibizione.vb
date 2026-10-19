'
'Codice sorgente generato automaticamente da xsd, versione=4.6.1055.0.
'

Namespace Conservatori.PARVeneto.Esibizione.Schemi


    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class valore

    Private elementoField() As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("elemento")>
    Public Property elemento() As String()
        Get
            Return Me.elementoField
        End Get
        Set
            Me.elementoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class criterioRichVisNorma

    Private nomeField As String

    Private valoreField() As String

    '''<remarks/>
    Public Property nome() As String
        Get
            Return Me.nomeField
        End Get
        Set
            Me.nomeField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("elemento", IsNullable:=False)>
    Public Property valore() As String()
        Get
            Return Me.valoreField
        End Get
        Set
            Me.valoreField = Value
        End Set
    End Property
End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),
     System.SerializableAttribute(),
     System.Diagnostics.DebuggerStepThroughAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class root

        Private criterioRichVisNormaField() As criterioRichVisNorma

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("criterioRichVisNorma")>
        Public Property criterioRichVisNorma() As criterioRichVisNorma()
            Get
                Return Me.criterioRichVisNormaField
            End Get
            Set
                Me.criterioRichVisNormaField = Value
            End Set
        End Property
    End Class


End Namespace
