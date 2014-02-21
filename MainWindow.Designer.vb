<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.trayicon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.traymenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.user_log = New System.Windows.Forms.TextBox()
        Me.button_start_stop = New System.Windows.Forms.Button()
        Me.button_exit = New System.Windows.Forms.Button()
        Me.button_settings = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.currenttrack = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.About_button = New System.Windows.Forms.Button()
        Me.traymenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'trayicon
        '
        Me.trayicon.ContextMenuStrip = Me.traymenu
        Me.trayicon.Text = "LastFM to VK"
        Me.trayicon.Visible = True
        '
        'traymenu
        '
        Me.traymenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НастройкиToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.traymenu.Name = "traymenu"
        Me.traymenu.Size = New System.Drawing.Size(135, 48)
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.НастройкиToolStripMenuItem.Text = "Настройки"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ExitToolStripMenuItem.Text = "Выход"
        '
        'user_log
        '
        Me.user_log.Location = New System.Drawing.Point(12, 58)
        Me.user_log.Multiline = True
        Me.user_log.Name = "user_log"
        Me.user_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.user_log.Size = New System.Drawing.Size(458, 185)
        Me.user_log.TabIndex = 1
        '
        'button_start_stop
        '
        Me.button_start_stop.Location = New System.Drawing.Point(486, 58)
        Me.button_start_stop.Name = "button_start_stop"
        Me.button_start_stop.Size = New System.Drawing.Size(162, 35)
        Me.button_start_stop.TabIndex = 2
        Me.button_start_stop.Text = "Стоп"
        Me.button_start_stop.UseVisualStyleBackColor = True
        '
        'button_exit
        '
        Me.button_exit.Location = New System.Drawing.Point(486, 188)
        Me.button_exit.Name = "button_exit"
        Me.button_exit.Size = New System.Drawing.Size(162, 35)
        Me.button_exit.TabIndex = 3
        Me.button_exit.Text = "Выход"
        Me.button_exit.UseVisualStyleBackColor = True
        '
        'button_settings
        '
        Me.button_settings.Location = New System.Drawing.Point(486, 102)
        Me.button_settings.Name = "button_settings"
        Me.button_settings.Size = New System.Drawing.Size(162, 35)
        Me.button_settings.TabIndex = 4
        Me.button_settings.Text = "Настройки"
        Me.button_settings.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'currenttrack
        '
        Me.currenttrack.AutoSize = True
        Me.currenttrack.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.currenttrack.Location = New System.Drawing.Point(168, 9)
        Me.currenttrack.Name = "currenttrack"
        Me.currenttrack.Size = New System.Drawing.Size(315, 24)
        Me.currenttrack.TabIndex = 0
        Me.currenttrack.Text = "Вы сейчас ничего не слушаете"
        Me.currenttrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Текущий трек:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'About_button
        '
        Me.About_button.Location = New System.Drawing.Point(486, 146)
        Me.About_button.Name = "About_button"
        Me.About_button.Size = New System.Drawing.Size(162, 35)
        Me.About_button.TabIndex = 6
        Me.About_button.Text = "О программе"
        Me.About_button.UseVisualStyleBackColor = True
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(672, 264)
        Me.Controls.Add(Me.About_button)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.currenttrack)
        Me.Controls.Add(Me.user_log)
        Me.Controls.Add(Me.button_settings)
        Me.Controls.Add(Me.button_exit)
        Me.Controls.Add(Me.button_start_stop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(615, 293)
        Me.Name = "MainWindow"
        Me.Text = "Last.fm to vk"
        Me.TopMost = True
        Me.traymenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents traymenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents НастройкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents button_exit As System.Windows.Forms.Button
    Friend WithEvents button_settings As System.Windows.Forms.Button
    Public WithEvents button_start_stop As System.Windows.Forms.Button
    Friend WithEvents trayicon As System.Windows.Forms.NotifyIcon
    Public WithEvents user_log As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents currenttrack As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents About_button As System.Windows.Forms.Button

End Class
