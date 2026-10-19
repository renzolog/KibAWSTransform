
Imports System.Xml

Namespace Conservatori.DAX.Esibizione
    Class Request
        Shared Function Create(LoginSession As Autenticazione.DAXLoginSession, EsibizioneArgs As EsibizioneArgs) As String

            Dim p As New Esibizione.Schemi.Request.RequestEsibizioneSync
            p.Doc = New Schemi.Request.DocId
            p.Doc.ItemElementName = Schemi.Request.ItemChoiceType.IdConservazione
            p.Doc.Item = EsibizioneArgs.Token

            Dim XmlEsibizione As XmlDocument = serialize(Of Schemi.Request.RequestEsibizioneSync)(p)
            Dim strEsibizione As String = XmlEsibizione.ChildNodes(1).OuterXml

            Dim req As New dipSincroRequest
            req.xmlRequest = "{0}"



            Dim XmlDip As XmlDocument = serialize(Of dipSincroRequest)(req)

            Dim strDip As String = XmlDip.ChildNodes(1).OuterXml
            Dim stringRequest As String = String.Format(strDip, strEsibizione)



            Dim str As String = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sip=""http://sip.esito.core.iris.eng.it"">
                                   <soapenv:Header />                                
                                   <soapenv:Body>" &
                                      stringRequest & "
                                   </soapenv:Body>
                               </soapenv:Envelope>"


            Return str




        End Function



        Public Shared Function serialize(Of T)(ByVal obj As T) As XmlDocument

            Try
                Dim File As String = System.IO.Path.GetTempFileName()
                Using i As System.IO.FileStream = New System.IO.FileStream(File, System.IO.FileMode.OpenOrCreate)
                    Dim S As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(obj.GetType())
                    S.Serialize(i, obj)
                End Using

                Dim dc As XmlDocument = New XmlDocument()
                dc.PreserveWhitespace = False
                dc.Load(File)
                System.IO.File.Delete(File)
                Return dc
            Catch ex As Exception
                Stop
            End Try


        End Function



    End Class

End Namespace
