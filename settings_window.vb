Public Class settings_window
    Const runsubkey = "Software\Microsoft\Windows\CurrentVersion\Run"
    Const runkey As String = "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run"
    Dim run_at_startup As Boolean
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        My.Settings.lastfmuser = Me.user.Text
        My.Settings.lastfmtimeout = Me.timeout.Value
        MainWindow.Timer1.Interval = Me.timeout.Value * 1000
        My.Settings.notifyadditional = Me.notify_additional.Checked
        My.Settings.ontop = Me.ontop.Checked
        My.Settings.minimizetotray = Me.minimize.Checked
        MainWindow.username = Me.user.Text
        MainWindow.TopMost = Me.ontop.Checked
        MainWindow.MinimizeBox = Not Me.minimize.Checked
        My.Settings.checkforupdates = Me.checkforupdates.Checked
        My.Settings.Save()
        vk.api.debug = My.Settings.notifyadditional
        If Not Me.autorun.Checked = run_at_startup Then
            run_at_startup = Me.autorun.Checked
            If run_at_startup Then
                Microsoft.Win32.Registry.SetValue(runkey, "lastfmtovk", Application.ExecutablePath)
            Else
                Dim startup As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runsubkey, True)
                startup.DeleteValue("lastfmtovk", False)
            End If
        End If
        Me.Hide()
    End Sub

    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        Me.Hide()
    End Sub

    Private Sub settings_window_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Reflection.Assembly.GetEntryAssembly().Location)
        Me.vkusername.Text = vk.api.current_user.ToString
        Me.user.Text = My.Settings.lastfmuser
        Me.timeout.Value = My.Settings.lastfmtimeout
        Me.notify_additional.Checked = My.Settings.notifyadditional

        Me.ontop.Checked = My.Settings.ontop
        Me.minimize.Checked = My.Settings.minimizetotray
        Me.checkforupdates.Checked = My.Settings.checkforupdates
        If Me.user.Text = "" Then Me.Button1.Enabled = False
        If InStr(Microsoft.Win32.Registry.GetValue(runkey, "lastfmtovk", ""), "lastfmtovk.exe") > 0 Then
            run_at_startup = True
        Else
            run_at_startup = False
        End If
        Me.autorun.Checked = run_at_startup
    End Sub

    Private Sub user_TextChanged(sender As System.Object, e As System.EventArgs) Handles user.TextChanged
        If Me.user.Text = "" Then Me.Button1.Enabled = False Else Me.Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        MainWindow.lasttrack = Nothing
        vk.api.Logout()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        settings_groups.Show()
    End Sub
End Class