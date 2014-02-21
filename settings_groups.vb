Public Class settings_groups

    Private Sub settings_groups_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Reflection.Assembly.GetEntryAssembly().Location)
        Dim h As New ColumnHeader()
        h.Width = groupsListView.ClientSize.Width - SystemInformation.VerticalScrollBarWidth
        groupsListView.Columns.Add(h)
        Dim mypageitem = New ListViewItem("Моя страница")
        mypageitem.Checked = My.Settings.mypage
        mypageitem.Tag = 0
        groupsListView.Items.Add(mypageitem)
        For Each group In vk.api.groups._get(vk.api.current_user.uid, True, filter:=New List(Of vk.api.groups.getfilter)({vk.api.groups.getfilter.editor}))
            Dim gritem As New ListViewItem(group.name)
            If Not IsNothing(My.Settings.groups) Then If My.Settings.groups.Contains(group.gid) Then gritem.Checked = True
            gritem.Tag = group.gid
            groupsListView.Items.Add(gritem)
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim groups As New Collections.Specialized.StringCollection
        For Each group As ListViewItem In groupsListView.Items
            If group.Tag = 0 Then
                My.Settings.mypage = group.Checked
            Else
                If group.Checked Then
                    groups.Add(group.Tag)
                End If
            End If
         
        Next
        My.Settings.groups = groups
        If groups.Count > 0 Then

            '       If Not ((vk.api.account.getAppPermissions() And vk.api.permissions.groups) = vk.api.permissions.groups) Then 'Проверяем битовую маску на вхождение groups
            MainWindow.request_new_permissions()
        End If
        MainWindow.update_target_ids()
        My.Settings.Save()
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class