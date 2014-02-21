Imports System.IO

Public Class notification

    Public Shared logfile As StreamWriter, locker As New Object, form_ready As Boolean = False, notify_queue As New System.Text.StringBuilder

    Public Shared Sub notify(s As String)
        For Each n In vk.notification.GetList()
            notify_queue.AppendLine(n)
        Next
#If DEBUG Then
            If IsNothing(logfile) Then
                Try
                    logfile = New StreamWriter("log.txt", True)
                Catch ex As Exception
                    MsgBox("Не удалось создать файл log.txt")
                End Try
            End If
#End If
            SyncLock locker
#If DEBUG Then
                Try
                    logfile.WriteLine(Now.ToString & " " & s)
                    logfile.Flush()
                Catch
                End Try
#End If
                If form_ready Then
                    If notify_queue.Length > 0 Then
                        notify_queue.Remove(notify_queue.Length - 1, 1)
                        MainWindow.gui_notification(notify_queue.ToString)
                        notify_queue = New System.Text.StringBuilder
                    End If
                    MainWindow.gui_notification(s)
                Else
                    notify_queue.AppendLine(s)
                End If


                '    MainWindow.notification(s)
                ' MainWindow.gui_notification(s)
            End SyncLock
    End Sub

End Class
