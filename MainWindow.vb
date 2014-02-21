Imports System.Reflection

'Imports System.Timers

Imports lastfmtovk.notification
Imports System.Threading
Imports vk
Imports System.IO

Public Class MainWindow
    Dim userpath As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\lastfmtovk_tracks_cache"
    Shared update_locker As New Object
    Private firstresize As Boolean = True, closedfromtray = False
    Shared _timer As Timer
    Shared gui_locker As New Object
    Public Shared current_version As String = AssemblyName.GetAssemblyName("lastfmtovk.exe").Version.ToString

    Public Shared lastfmuser As New lastfm_api.user, lasttrack As vk.api.audio.track.trackname, username As String, gui_updater As gui_update

    Delegate Sub gui_update(s As String)
    Delegate Sub network_thread_delegate()
    Public network_thread As Thread
    Const initial_permissons = 8 + 1024
    Shared target_ids As List(Of Long), permissions As Integer = initial_permissons

    Public Sub gui_notification(s As String)
        Try
            Me.trayicon.Text = Microsoft.VisualBasic.Left(s, 63)
            Me.user_log.AppendText(s & vbNewLine)
            Thread.Sleep(300)
        Catch ex As Exception
#If DEBUG Then
            Try
                notification.logfile.WriteLine(ex.Message)
            Catch
            End Try
#End If
        End Try

    End Sub

    Private Sub MainWindow_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.minimizetotray Then
            If Not closedfromtray Then
                e.Cancel = True
                Me.Hide()
            Else
                finish()
            End If
        Else
            finish()
        End If
    End Sub
    Private Sub finish()
        vk.api.savetoken()
        Using strm As New FileStream(userpath, FileMode.Create)
            Dim ser As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            ser.Serialize(strm, vk.api.current_user)
        End Using
    End Sub
    Private Sub update_checker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim lastversion As String
        Try
            lastversion = ((New System.Net.WebClient()).DownloadString("http://lastfmtovk.ru/last.txt?v=" & Web.HttpUtility.UrlEncode(current_version))).TrimEnd
            If Not (lastversion = current_version) Then
                Dim reply As DialogResult = MessageBox.Show("Вышла новая версия Last.fm to VK, хотите скачать её?", "Обновление", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                If reply = DialogResult.Yes Then
                    Process.Start("http://lastfmtovk.ru/lastfmtovk_installer.exe")
                End If

            End If
        Catch ex As Exception
            notify("Не удалось проверить обновления: " & ex.Message)
        End Try
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Icon = Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().Location)
        trayicon.Icon = Me.Icon
        If My.Settings.updaterequired Then
            notify("Читаем настройки из предыдущей версии приложения...")
            My.Settings.Upgrade()
            My.Settings.updaterequired = False
            My.Settings.Save()
        End If
        update_permissions()
        '    While True
        If File.Exists(userpath) Then
            If My.Settings.notifyadditional Then
                notify("Читаем кэш аудиозаписей...")
            End If
            Dim ser As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Using strm As New FileStream(userpath, FileMode.Open)
                Try
                    api.actual_current_user = ser.Deserialize(strm)
                Catch ex As Exception
                    notify("Не удалось прочитать кэш аудио: " & ex.Message)
                End Try
            End Using
    
        End If

        Try

            api.setoptions("2821031", permissions, debug_notifications:=My.Settings.notifyadditional)
                '  Exit While
        Catch ex As Exception
            If ex.Data("reason") = "Auth window closed" Then
                MsgBox("Для работы приложения необходимо авторизоваться в VK, чтобы разрешить приложению обновлять ваш статус")
                closedfromtray = True
                Application.Exit()
                Environment.Exit(0)
            End If
            notify(ex.Message)
            Application.DoEvents()
            System.Threading.Thread.Sleep(100)
        End Try
        update_target_ids()
        ' End While

        ' Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = Not My.Settings.minimizetotray
        Application.DoEvents()
        gui_updater = New gui_update(AddressOf gui_notification)
        Me.Visible = True
        If My.Settings.notifyadditional Then
            notify("Запуск...")
        End If
        Me.Timer1.Interval = My.Settings.lastfmtimeout * 1000
        Me.Timer1.Enabled = True
        notification.form_ready = True


        If My.Settings.notifyadditional Then
            notify("Приложение запущено")
        End If
        If My.Settings.checkforupdates Then
            If My.Settings.notifyadditional Then
                notify("Проверка обновлений...")
            End If
            Dim update_checker As New System.ComponentModel.BackgroundWorker
            AddHandler update_checker.DoWork, AddressOf update_checker_DoWork
            update_checker.RunWorkerAsync()
        End If

    End Sub
    Private Sub update_permissions()
        If Not IsNothing(My.Settings.groups) Or My.Settings.requested_groups_permission Then
            If My.Settings.groups.Count > 0 Or My.Settings.requested_groups_permission Then
                permissions = initial_permissons + vk.api.permissions.groups
                My.Settings.requested_groups_permission = True
            End If
        End If
    End Sub
    Public Sub update_target_ids()
        target_ids = Nothing
        If Not IsNothing(My.Settings.groups) Then
            If My.Settings.groups.Count > 0 Then
                target_ids = New List(Of Long)
                For Each group In My.Settings.groups
                    target_ids.Add(0 - CLng(group))
                Next
            End If
        End If
        If Not IsNothing(target_ids) Then
            If My.Settings.mypage Then
                target_ids.Add(vk.api.current_user.uid)
            End If
        End If
    End Sub
    Public Sub request_new_permissions()
        update_permissions()
        vk.api.token = Nothing
        Try
            api.setoptions(Nothing, permissions)
        Catch ex As Exception
            notify("Не удалось получить новые разрешения в ВК: " & ex.Message)
            My.Settings.requested_groups_permission = False
        End Try
    End Sub
    Private Sub update_status()
        '  Application.DoEvents()
        SyncLock update_locker
            If username = "" Then
                notify("Не задано имя пользователя на Last.fm")
            Else
                Dim lastfmtrack As api.audio.track.trackname = lastfmuser.getlastTrack(username)
                If Now.CompareTo(vk.api.custom.playend) > 0 Then
                    If Not IsNothing(lasttrack) Then
                        If My.Settings.notifyadditional Then
                            notify("Проигрывание " & lasttrack.ToString & " должно закончиться к настоящему моменту")
                        End If
                    End If
                    lasttrack = Nothing
                End If
                If Not (lasttrack = lastfmtrack) Then
                    If IsNothing(lastfmtrack) Then
                        lasttrack = lastfmtrack
                        Me.currenttrack.Text = "Вы сейчас ничего не слушаете"
                    Else
                        Try
                            If My.Settings.notifyadditional Then
                                notify("Попытка установить статус: " & lastfmtrack.ToString)
                            End If
                            vk.api.custom.set_status_by_track_name(lastfmtrack, target_ids)
                            lasttrack = lastfmtrack
                            Me.currenttrack.Text = lasttrack.ToString
                            Me.Text = lasttrack.ToString
                            notify("Статус был успешно установлен: " & lastfmtrack.ToString)
                            Dim traytext As String = lasttrack.ToString
                            If traytext.Length > 62 Then traytext = traytext.Substring(0, 63)
                            trayicon.Text = traytext
                        Catch ex As Exception

                            If ex.Data("reason") = "not found" Then
                                lasttrack = lastfmtrack
                                Me.currenttrack.Text = "Трек не найден в ВК"
                                notify("Не удалось установить статус: Трек не найден в ВК")
                            Else
                                Me.currenttrack.Text = "Не удалось обновить статус в ВК"
                                notify("Не удалось установить статус: " & ex.Message)
                            End If


                            Dim dblWaitTil As Date = Now.AddSeconds(30)
                            Do Until Now > dblWaitTil
                                Application.DoEvents() ' Allow windows messages to be processed
                                System.Threading.Thread.Sleep(100)
                            Loop
                        End Try

                    End If
                End If
            End If
        End SyncLock
    End Sub





    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        closedfromtray = True
        Application.Exit()
    End Sub

    Private Sub НастройкиToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles НастройкиToolStripMenuItem.Click
        settings_window.Show()
    End Sub


    Protected Overrides Sub Finalize() 'Этот метод почему-то никогда не вызывается...
        trayicon.Dispose()

        MyBase.Finalize()
    End Sub


    Private Sub button_exit_Click(sender As System.Object, e As System.EventArgs) Handles button_exit.Click
        closedfromtray = True
        Application.Exit()
    End Sub


    Private Sub button_start_stop_Click(sender As System.Object, e As System.EventArgs) Handles button_start_stop.Click
        If Me.Timer1.Enabled Then
            Me.Timer1.Stop()
            Me.button_start_stop.Text = "Старт"
            notify("Status updating stopped by user")
        Else
            Me.Timer1.Start()
            Me.button_start_stop.Text = "Стоп"
            notify("Status updating started")
        End If
    End Sub

    Private Sub button_settings_Click(sender As System.Object, e As System.EventArgs) Handles button_settings.Click
        settings_window.Show()
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'If Not IsNothing(network_thread) Then
        ' If network_thread.IsAlive Then
        ' network_thread.Join()
        ' End If
        'End If

        'network_thread = New Thread(AddressOf update_status)
        'network_thread.Start()
        Try
            update_status()
        Catch ex As Exception
            notify("The following error happened during the attemp to update vk status:" & ex.Message)
        End Try
    End Sub




    Private Sub MainWindow_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        SyncLock gui_locker
            If notification.form_ready Then
                If firstresize Then
                    firstresize = False
                Else
                    'If Me.WindowState = FormWindowState.Minimized Then
                    'Me.ShowInTaskbar = False

                    If Me.Visible Then
                        If My.Settings.minimizetotray Then
                            Me.Hide()
                        End If
                    Else
                        Me.Show()

                    End If
                End If
            End If
        End SyncLock
    End Sub


    Private Sub trayicon_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles trayicon.MouseDoubleClick
        SyncLock gui_locker


            'Me.WindowState = FormWindowState.Maximized
            ' Me.ShowInTaskbar = True
            'Me.Size = sz
            Me.Show()
            Me.Activate()
        End SyncLock
    End Sub

    Private Sub MainWindow_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        Me.ShowInTaskbar = True

        Application.DoEvents()

        Me.TopMost = My.Settings.ontop
        If My.Settings.lastfmuser = "" And Not settings_window.Visible Then
            Dim answer As DialogResult = settings_window.ShowDialog()
            If answer = Windows.Forms.DialogResult.Cancel Then
                notify("User cancelled settings input request, exiting...")
                MsgBox("Для работы программы необходимо указать имя пользователя на last.fm")
                closedfromtray = True
                Application.Exit()
            End If
        End If
        username = My.Settings.lastfmuser
        If My.Settings.lastfmtimeout <= 0 Then My.Settings.lastfmtimeout = 10
        update_status()
    End Sub


    Private Sub About_Click(sender As System.Object, e As System.EventArgs) Handles About_button.Click
        about.Show()
    End Sub
    Public Class groups_list 'для настроек
        Inherits List(Of Long)
    End Class
End Class

