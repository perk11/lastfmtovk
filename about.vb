Public Class about

    Private Sub about_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Reflection.Assembly.GetEntryAssembly().Location)
        Me.version.Text = MainWindow.current_version
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://lastfmtovk.ru/")
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://vk.com/lastfmtovk")
    End Sub
End Class