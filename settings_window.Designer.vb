<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings_window
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.user = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.timeout = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.minimize = New System.Windows.Forms.CheckBox()
        Me.ontop = New System.Windows.Forms.CheckBox()
        Me.notify_additional = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.vkusername = New System.Windows.Forms.Label()
        Me.checkforupdates = New System.Windows.Forms.CheckBox()
        Me.autorun = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.timeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Имя пользователя на last.fm"
        '
        'user
        '
        Me.user.Location = New System.Drawing.Point(161, 28)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(199, 20)
        Me.user.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Частота запросов к last.fm"
        '
        'timeout
        '
        Me.timeout.Location = New System.Drawing.Point(161, 56)
        Me.timeout.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.timeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.timeout.Name = "timeout"
        Me.timeout.Size = New System.Drawing.Size(44, 20)
        Me.timeout.TabIndex = 2
        Me.timeout.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(205, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "c"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(84, 311)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 29)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "ОК"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(188, 311)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(83, 29)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "Отмена"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(22, 232)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(321, 33)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Сменить пользователя vk"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'minimize
        '
        Me.minimize.AutoSize = True
        Me.minimize.Checked = True
        Me.minimize.CheckState = System.Windows.Forms.CheckState.Checked
        Me.minimize.Location = New System.Drawing.Point(5, 90)
        Me.minimize.Name = "minimize"
        Me.minimize.Size = New System.Drawing.Size(197, 17)
        Me.minimize.TabIndex = 6
        Me.minimize.Text = "Сворачивать главное окно в трей"
        Me.minimize.UseVisualStyleBackColor = True
        '
        'ontop
        '
        Me.ontop.AutoSize = True
        Me.ontop.Checked = True
        Me.ontop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ontop.Location = New System.Drawing.Point(5, 114)
        Me.ontop.Name = "ontop"
        Me.ontop.Size = New System.Drawing.Size(147, 17)
        Me.ontop.TabIndex = 7
        Me.ontop.Text = "Поверх остальных окон"
        Me.ontop.UseVisualStyleBackColor = True
        '
        'notify_additional
        '
        Me.notify_additional.AutoSize = True
        Me.notify_additional.Location = New System.Drawing.Point(5, 138)
        Me.notify_additional.Name = "notify_additional"
        Me.notify_additional.Size = New System.Drawing.Size(210, 17)
        Me.notify_additional.TabIndex = 8
        Me.notify_additional.Text = "Выводить информацию для отладки"
        Me.notify_additional.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 206)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Текущий пользователь:"
        '
        'vkusername
        '
        Me.vkusername.AutoSize = True
        Me.vkusername.Location = New System.Drawing.Point(154, 206)
        Me.vkusername.Name = "vkusername"
        Me.vkusername.Size = New System.Drawing.Size(0, 13)
        Me.vkusername.TabIndex = 10
        '
        'checkforupdates
        '
        Me.checkforupdates.AutoSize = True
        Me.checkforupdates.Location = New System.Drawing.Point(5, 161)
        Me.checkforupdates.Name = "checkforupdates"
        Me.checkforupdates.Size = New System.Drawing.Size(188, 17)
        Me.checkforupdates.TabIndex = 11
        Me.checkforupdates.Text = "Проверять наличие обновлений"
        Me.checkforupdates.UseVisualStyleBackColor = True
        '
        'autorun
        '
        Me.autorun.AutoSize = True
        Me.autorun.Location = New System.Drawing.Point(5, 184)
        Me.autorun.Name = "autorun"
        Me.autorun.Size = New System.Drawing.Size(185, 17)
        Me.autorun.TabIndex = 12
        Me.autorun.Text = "Запускать при старте системы"
        Me.autorun.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(22, 272)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(321, 33)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Трансляция в группы"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'settings_window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(366, 361)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.autorun)
        Me.Controls.Add(Me.checkforupdates)
        Me.Controls.Add(Me.vkusername)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.notify_additional)
        Me.Controls.Add(Me.ontop)
        Me.Controls.Add(Me.minimize)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.timeout)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "settings_window"
        Me.Text = "Настройки"
        CType(Me.timeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents user As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents timeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents minimize As System.Windows.Forms.CheckBox
    Friend WithEvents ontop As System.Windows.Forms.CheckBox
    Friend WithEvents notify_additional As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents vkusername As System.Windows.Forms.Label
    Friend WithEvents checkforupdates As System.Windows.Forms.CheckBox
    Friend WithEvents autorun As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
