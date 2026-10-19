Imports System.Xml
Imports System.Text

Namespace Conservatori.Infocert.Conservazione
    Public Class ParametersFile

        Private ReadOnly _Value As String

        Private Function Create(PolicyID As String, File As ProgettoEnte.Conservazione.Shared.File, IndexFile As IndexFile, ConservePath As String) As String

            Dim doc As New XmlDocument

            doc.CreateXmlDeclaration("1.0", "UTF-8", "yes")

            Dim Par As XmlNode = doc.AppendChild(doc.CreateNode(XmlNodeType.Element, "parameters", ""))


            Dim policy As XmlNode = doc.CreateNode(XmlNodeType.Element, "policy_id", "")
            policy.InnerText = PolicyID
            Par.AppendChild(policy)

            Dim INDEX As XmlNode = doc.CreateNode(XmlNodeType.Element, "index_file", "")
            Par.AppendChild(INDEX)

            INDEX.AppendChild(doc.CreateNode(XmlNodeType.Element, "index_name", "")).InnerText = Conservatori.Infocert.Conservazione.IndexFile.name
            INDEX.AppendChild(doc.CreateNode(XmlNodeType.Element, "index_hash", "")).InnerText = IndexFile.GetHash
            INDEX.AppendChild(doc.CreateNode(XmlNodeType.Element, "index_mimetype", "")).InnerText = Conservatori.Infocert.Conservazione.IndexFile.mimetype


            Dim Data As XmlNode = doc.CreateNode(XmlNodeType.Element, "data_file", "")
            Par.AppendChild(Data)

            Data.AppendChild(doc.CreateNode(XmlNodeType.Element, "data_name", "")).InnerText = File.NomeFile.Pulisci
            Data.AppendChild(doc.CreateNode(XmlNodeType.Element, "data_hash", "")).InnerText = File.GetHash
            Data.AppendChild(doc.CreateNode(XmlNodeType.Element, "data_mimetype", "")).InnerText = Utility.Compute.getMimeEncoded(File.Mime)
            Par.AppendChild(doc.CreateNode(XmlNodeType.Element, "path", "")).InnerText = ConservePath

            Return doc.InnerXml

        End Function

        Private Function Create(PolicyID As String, ConservePath As String) As String

            Dim doc As New XmlDocument

            doc.CreateXmlDeclaration("1.0", "UTF-8", "yes")

            Dim Par As XmlNode = doc.AppendChild(doc.CreateNode(XmlNodeType.Element, "parameters", ""))


            Dim policy As XmlNode = doc.CreateNode(XmlNodeType.Element, "policy_id", "")
            policy.InnerText = PolicyID
            Par.AppendChild(policy)
            Par.AppendChild(doc.CreateNode(XmlNodeType.Element, "path", "")).InnerText = ConservePath

            Return doc.InnerXml

        End Function

        Public Sub New(PolicyID As String, File As ProgettoEnte.Conservazione.Shared.File, IndexFile As IndexFile, ConservePath As String)
            _Value = Create(PolicyID, File, IndexFile, ConservePath)
        End Sub

        Public Sub New(PolicyID As String, ConservePath As String)
            _Value = Create(PolicyID, ConservePath)
        End Sub


        Public Function GetBuffer() As Byte()
            Dim encoding As New UTF8Encoding()
            Return encoding.GetBytes(_Value)
        End Function

    End Class
End Namespace
