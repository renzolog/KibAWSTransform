

Imports System.Xml.Serialization

Namespace Conservatori.PARVeneto.Conservazione.Schemi



    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class values

        Private valueField() As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("value")>
        Public Property value() As String()
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = value
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
    Partial Public Class singlemetadata

        Private mandatoryField As String

        Private nameField As String

        Private valuesField() As String

        Private typeField As String

        '''<remarks/>
        Public Property mandatory() As String
            Get
                Return Me.mandatoryField
            End Get
            Set
                Me.mandatoryField = value
            End Set
        End Property

        '''<remarks/>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable:=False)>
        Public Property values() As String()
            Get
                Return Me.valuesField
            End Get
            Set
                Me.valuesField = value
            End Set
        End Property

        '''<remarks/>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = value
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
    Partial Public Class file

        Private filenameField As String

        Private mimetypeField As String

        Private hashField As String

        '''<remarks/>
        Public Property filename() As String
            Get
                Return Me.filenameField
            End Get
            Set
                Me.filenameField = value
            End Set
        End Property

        '''<remarks/>
        Public Property mimetype() As String
            Get
                Return Me.mimetypeField
            End Get
            Set
                Me.mimetypeField = value
            End Set
        End Property

        '''<remarks/>
        Public Property hash() As String
            Get
                Return Me.hashField
            End Get
            Set
                Me.hashField = value
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
    Partial Public Class metadata

        Private singlemetadataField() As singlemetadata

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("singlemetadata")>
        Public Property singlemetadata() As singlemetadata()
            Get
                Return Me.singlemetadataField
            End Get
            Set
                Me.singlemetadataField = value
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
    Partial Public Class files

        Private fileField() As file

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("file")>
        Public Property file() As file()
            Get
                Return Me.fileField
            End Get
            Set
                Me.fileField = value
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
    Partial Public Class versamento

        Private docTypeField As String

        Private metadataField() As singlemetadata

        Private filesField() As file

        '''<remarks/>
        Public Property docType() As String
            Get
                Return Me.docTypeField
            End Get
            Set
                Me.docTypeField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("singlemetadata", IsNullable:=False)>
        Public Property metadata() As singlemetadata()
            Get
                Return Me.metadataField
            End Get
            Set
                Me.metadataField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("file", IsNullable:=False)>
        Public Property files() As file()
            Get
                Return Me.filesField
            End Get
            Set
                Me.filesField = value
            End Set
        End Property
    End Class
End Namespace