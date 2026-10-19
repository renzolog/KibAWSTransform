Imports System.IO
Imports System.Xml

Namespace Conservatori.Infocert.Shared
    Public Class Utility

        Friend Shared Function ManageWebException(Metodo As String, WebEx As System.Net.WebException, LoginSession As Object, SuFile As String) As Exception.InfocertExtededSystemException

            Dim ErrorInfo As New ErrorInfo

            Try
                If WebEx.Response IsNot Nothing Then
                    Using reader As New StreamReader(WebEx.Response.GetResponseStream())
                        ErrorInfo = GetErrorInfo(reader.ReadToEnd)
                    End Using

                End If
            Catch ex As System.Exception

            End Try

            If String.IsNullOrEmpty(SuFile)=False Then
                LogSystem.LogTextFile(Nothing, "CONSERVA", SuFile, ErrorInfo.Description)
            End If

            Return New Exception.InfocertExtededSystemException(Metodo, String.Format("{0} - {1}", WebEx.Message, ErrorInfo), WebEx.InnerException, ErrorInfo, LoginSession)

        End Function

        Friend Shared Function ManageWebException(Metodo As String, WebEx As System.Net.WebException, LoginSession As Object) As Exception.InfocertExtededSystemException

            Dim ErrorInfo As New ErrorInfo
            Dim ErrorInfoDescription As String = ""

            Try
                If WebEx.Response IsNot Nothing Then
                    Using reader As New StreamReader(WebEx.Response.GetResponseStream())
                        ErrorInfo = GetErrorInfo(reader.ReadToEnd)
                        ErrorInfoDescription = ErrorInfo.Description
                    End Using

                End If
            Catch ex As System.Exception

            End Try

            Try
                Dim dLogin As String = ""
                If LoginSession IsNot Nothing Then
                    Dim ISTAT As String = ""

                    If TypeOf LoginSession Is Autenthicate.LoginSession Then
                        Dim Login = CType(LoginSession, Autenthicate.LoginSession)
                        If Login.Ente IsNot Nothing Then
                            dLogin = Login.Ente.ISTAT
                        End If
                    End If
                End If
                Dim webExMessage As String = ""
                Dim webExMessageInner As String = ""
                If WebEx IsNot Nothing Then
                    webExMessage = WebEx.Message
                    If WebEx.InnerException IsNot Nothing Then
                        webExMessageInner = WebEx.InnerException.ToString
                    End If
                End If
                Dim TestoMessaggio As String = String.Format("{0} - {1} - {2} - {3} - {4}", Metodo, webExMessage, ErrorInfoDescription, webExMessageInner, dLogin)
                'IO.File.WriteAllText($"c:\temp\rafEXEC{Now.Ticks.ToString}_.txt", TestoMessaggio)
            Catch ex As System.Exception

            End Try

            Return New Exception.InfocertExtededSystemException(Metodo, String.Format("{0} - {1}", WebEx.Message, ErrorInfo), WebEx.InnerException, ErrorInfo, LoginSession)

        End Function

        Friend Shared Function GetErrorInfo(xml As String) As ErrorInfo
            Dim ErrorInfo As New ErrorInfo

            Dim gxml As New Xml.XmlDocument()

            Try
                gxml.LoadXml(xml)
            Catch ex As System.Exception
                ErrorInfo.Code = "Non TAG XML"
                ErrorInfo.Description = xml
                Return ErrorInfo 
            End Try

            If gxml.DocumentElement.Name = "error" Then '
                Dim n As XmlNode = gxml.SelectSingleNode("error")
                ErrorInfo.Code = n.ChildNodes(0).InnerText
                ErrorInfo.Description = n.ChildNodes(1).InnerText
            End If

            Return ErrorInfo

        End Function

        Friend Shared Function GetErrorInfoException(Metodo As String, xml As String) As Exception.InfocertExtededSystemException
            Dim lGetErrorInfo As ErrorInfo = GetErrorInfo(xml)
            If lGetErrorInfo Is Nothing Then
                lGetErrorInfo = New ErrorInfo
            End If
            Return New Exception.InfocertExtededSystemException(Metodo, "Errore non Gestito durante la comunicazione - " & lGetErrorInfo.ToString, Nothing, lGetErrorInfo, Nothing)

        End Function



    End Class
End Namespace

