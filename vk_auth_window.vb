Imports System.Collections.Specialized
Imports System.Web
Imports lastfmtovk.notification



Public Class vk_auth_window
    Public showform As Boolean = False
    Private Sub WebBrowser1_DocumentCompleted(sender As System.Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Const successauthurl As String = "http://oauth.vk.com/blank.html"
        Dim currurl As String
        'Debug.Print("Document completed")
        currurl = WebBrowser1.Url.ToString
        If My.Settings.notifyadditional Then
            notify("Document " & currurl & " loaded")
        End If
        If currurl = "about:blank" Then
            vk_api.showform = False
            Me.Dispose()
        ElseIf (IIf(Len(currurl) >= Len(successauthurl), Microsoft.VisualBasic.Left(currurl, Len(successauthurl)) = successauthurl, False)) Then

            ' Debug.Print("hey, auth!")
            If My.Settings.notifyadditional Then
                notify("Hey, we've got auth result!")
            End If
            If InStr(currurl, "error") > 0 Then
                notify("Auth error! Trying again")
                MsgBox("Ошибка авторизации!")
                WebBrowser1.Navigate(MainWindow.vkauthurl)
                WebBrowser1.Visible = True
            ElseIf InStr(currurl, "access_token=") > 0 Then
                '    Debug.Print("hey, we've got token!")
                If My.Settings.notifyadditional Then
                    notify("Hey, we've got token!")
                End If
                '  MainWindow.started = True

                Dim parameters As NameValueCollection = HttpUtility.ParseQueryString(Microsoft.VisualBasic.Right(currurl, Len(currurl) - InStr(currurl, "#")))
#If Not Debug Then

                Try
#End If

                vk_api.token = parameters.Item("access_token")
                vk_api.tokenexpires = Now.AddSeconds(parameters.Item("expires_in"))
                vk_api.userid = parameters("user_id")
                vk_api.GetCurrentUser()
                WebBrowser1.Navigate("about:blank")
#If Not Debug Then
                Catch
                    MsgBox("Неизвестная ошибка при попытке авторизации, попробуйте ещё раз")
                    WebBrowser1.Navigate(vkauthurl)
                End Try
#End If
            Else
                notify("Something strange is happening, like IE6. url is " & currurl)
            End If

        ElseIf InStr(currurl, "navcancl.htm") > 0 Then
            notify("Failed to connect to vk, probably network error")
        ElseIf InStr(currurl, "cancel=1") Or InStr(currurl, "user_denied") > 0 Then
            notify("vk authorization canceled")
            WebBrowser1.Navigate(MainWindow.vkauthurl)
        Else
            '  If MainWindow.Timer1.Enabled Then MainWindow.Timer1.Enabled = False
            '   vk_api.showform = True
            If My.Settings.notifyadditional Then
                notify("User vk page loaded, showing it to user")
            End If
            '  Debug.Print("something else")
            ' MainWindow.started = False
            Me.Show()
            '     Me.Activate()

        End If
    End Sub

    Private Sub vk_auth_window_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' If MainWindow.Timer1.Enabled = False Then
        ' MainWindow.Timer1.Enabled = True
        ' End If
        vk_api.showform = False
    End Sub

    Private Sub vk_auth_window_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub




    Private Sub vk_auth_window_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        Me.Visible = False
    End Sub
End Class