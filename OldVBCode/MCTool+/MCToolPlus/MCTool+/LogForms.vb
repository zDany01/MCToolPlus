Imports System.ComponentModel
Imports MCTool_.SharedCode.ErrorHandler

Public Class LogForms
    Public Sub GetReady()
        ApplicationLogs.SelectionStart = ApplicationLogs.TextLength
        ApplicationLogs.SelectionLength = 0
        ApplicationLogs.SelectionColor = Color.Black
        ApplicationLogs.SelectionFont = New Font(ApplicationLogs.SelectionFont.FontFamily, ApplicationLogs.SelectionFont.Size, FontStyle.Bold Or FontStyle.Italic) 'so che potrebbe sembrare strano e contro-intuitivo ma per unire due tipi di font si deve usare Or(e non and)
        'spiegazione: FontStyle.Bold Or FontStyle.Italic
        'will create a FontStyle that Is both Bold And Italic. It may seem strange To use Or When logically you mean And, but this Is a bitwise operation. Each individual value Is a series of bits that only has a single bit set. The bitwise Or creates a New value that has both the bit for Bold And the bit for Italic set.
        ApplicationLogs.SelectionColor = ApplicationLogs.ForeColor
        ApplicationLogs.AppendText($"Logs of {Date.UtcNow}")
    End Sub

    Public Sub AppendLog(TextToAppend As String, TextColor As Color)
        ApplicationLogs.SelectionStart = ApplicationLogs.TextLength
        ApplicationLogs.SelectionLength = 0
        ApplicationLogs.SelectionColor = TextColor
        ApplicationLogs.AppendText(TextToAppend)
        ApplicationLogs.SelectionColor = ApplicationLogs.ForeColor
    End Sub

    Private Sub LogForms_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        GestoreMondi.Location = New Size(Me.Location.X - 390, Me.Location.Y)
    End Sub

    Private Sub LogForms_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Hide()
        If GestoreMondi.DesktopLocation.X <= 0 Or GestoreMondi.DesktopLocation.Y <= 0 Then GestoreMondi.Re_Center()
    End Sub

    Private Sub CloseLogsWindowsBtn_Click(sender As Object, e As EventArgs) Handles CloseLogsWindowsBtn.Click
        Hide()
    End Sub

    Private Sub ClearLogsBtn_Click(sender As Object, e As EventArgs) Handles ClearLogsBtn.Click
        ApplicationLogs.Clear()
    End Sub

    Private Sub SaveLogsBtn_Click(sender As Object, e As EventArgs) Handles SaveLogsBtn.Click
        SaveLogFileDialog.ShowDialog()
    End Sub

    Private Sub SaveLogFileDialog_FileOk(sender As Object, e As CancelEventArgs) Handles SaveLogFileDialog.FileOk
        Try
            If SaveLogFileDialog.FileName.EndsWith(".rtf") Then ApplicationLogs.SaveFile(SaveLogFileDialog.FileName) Else IO.File.WriteAllText(SaveLogFileDialog.FileName, ApplicationLogs.Text)
        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub
End Class