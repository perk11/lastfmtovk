
Imports lastfmtovk.notification
Imports vk

Public Class lastfm_api
    Const api_key = "***REMOVED***"
    Public Shared nothing_notified As Boolean = False
    Public Class user
        Public Function getlastTrack(username As String) As vk.api.audio.track.trackname
            If My.Settings.notifyadditional Then
                notify("Запрашиваем текущий трек с last.fm...")
            End If
            Dim parameters As New Dictionary(Of String, String), artist As String = Nothing, name As String = Nothing
            parameters.Add("user", username)
            parameters.Add("limit", "1")
            Dim s As Xml.XmlTextReader = lastm_api_request("user.getrecenttracks", parameters)
            Try
                While s.Read
                    If s.NodeType = Xml.XmlNodeType.Element Then
                        If s.Name = "track" Then
                            If s.GetAttribute("nowplaying") = "true" Then
                                Dim track As Xml.XmlReader = s.ReadSubtree()
                                While track.Read
                                    Select Case track.Name
                                        Case "artist"
                                            artist = s.ReadElementContentAsString
                                        Case "name"
                                            name = s.ReadElementContentAsString
                                    End Select
                                End While
                            End If
                        End If
                    End If
                End While
                If Not (IsNothing(artist) And IsNothing(name)) Then
                    If My.Settings.notifyadditional Then
                        notify("Текущий трек на last.fm " & artist & "-" & name)
                    End If
                    nothing_notified = False
                    Return New vk.api.audio.track.trackname(artist, name)
                Else
                    If (Not nothing_notified) Or My.Settings.notifyadditional Then
                        notify("По данным last.fm, ничего не воспроизводится")
                        nothing_notified = True
                    End If
                    Return Nothing
                    End If
            Catch ex As Exception
                nothing_notified = False
                notify("Не удалось совершить запрос к last.fm: " & ex.Message)
                Return Nothing
            End Try
        End Function
    End Class
    Shared Function lastm_api_request(method As String, Optional parameters As Dictionary(Of String, String) = Nothing) As Xml.XmlTextReader

        Dim request_text As String
        request_text = method
        If Not IsNothing(parameters) Then
            For Each s In parameters
                request_text = request_text & "&" & System.Web.HttpUtility.UrlEncode(s.Key) & "=" & System.Web.HttpUtility.UrlEncode(s.Value)
            Next
        End If
        Return New Xml.XmlTextReader("http://ws.audioscrobbler.com/2.0/?method=" & request_text & "&api_key=" & api_key)
    End Function
End Class
