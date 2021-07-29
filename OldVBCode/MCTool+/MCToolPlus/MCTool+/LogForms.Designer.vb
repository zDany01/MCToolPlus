<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogForms
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ApplicationLogs = New System.Windows.Forms.RichTextBox()
        Me.SaveLogsBtn = New System.Windows.Forms.Button()
        Me.ClearLogsBtn = New System.Windows.Forms.Button()
        Me.CloseLogsWindowsBtn = New System.Windows.Forms.Button()
        Me.SaveLogFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'ApplicationLogs
        '
        Me.ApplicationLogs.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplicationLogs.Location = New System.Drawing.Point(0, 0)
        Me.ApplicationLogs.Name = "ApplicationLogs"
        Me.ApplicationLogs.ReadOnly = True
        Me.ApplicationLogs.Size = New System.Drawing.Size(418, 520)
        Me.ApplicationLogs.TabIndex = 0
        Me.ApplicationLogs.Text = ""
        '
        'SaveLogsBtn
        '
        Me.SaveLogsBtn.Location = New System.Drawing.Point(12, 526)
        Me.SaveLogsBtn.Name = "SaveLogsBtn"
        Me.SaveLogsBtn.Size = New System.Drawing.Size(151, 23)
        Me.SaveLogsBtn.TabIndex = 1
        Me.SaveLogsBtn.Text = "Save Logs"
        Me.SaveLogsBtn.UseVisualStyleBackColor = True
        '
        'ClearLogsBtn
        '
        Me.ClearLogsBtn.Location = New System.Drawing.Point(243, 526)
        Me.ClearLogsBtn.Name = "ClearLogsBtn"
        Me.ClearLogsBtn.Size = New System.Drawing.Size(163, 23)
        Me.ClearLogsBtn.TabIndex = 2
        Me.ClearLogsBtn.Text = "Clear Logs"
        Me.ClearLogsBtn.UseVisualStyleBackColor = True
        '
        'CloseLogsWindowsBtn
        '
        Me.CloseLogsWindowsBtn.Location = New System.Drawing.Point(169, 526)
        Me.CloseLogsWindowsBtn.Name = "CloseLogsWindowsBtn"
        Me.CloseLogsWindowsBtn.Size = New System.Drawing.Size(68, 23)
        Me.CloseLogsWindowsBtn.TabIndex = 3
        Me.CloseLogsWindowsBtn.Text = "Close"
        Me.CloseLogsWindowsBtn.UseVisualStyleBackColor = True
        '
        'SaveLogFileDialog
        '
        Me.SaveLogFileDialog.AddExtension = False
        Me.SaveLogFileDialog.FileName = "Logs"
        Me.SaveLogFileDialog.Filter = "File RTF|*.rtf|File di log|*.log"
        '
        'LogForms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 551)
        Me.Controls.Add(Me.CloseLogsWindowsBtn)
        Me.Controls.Add(Me.ClearLogsBtn)
        Me.Controls.Add(Me.SaveLogsBtn)
        Me.Controls.Add(Me.ApplicationLogs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LogForms"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Logs"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ApplicationLogs As RichTextBox
    Friend WithEvents SaveLogsBtn As Button
    Friend WithEvents ClearLogsBtn As Button
    Friend WithEvents CloseLogsWindowsBtn As Button
    Friend WithEvents SaveLogFileDialog As SaveFileDialog
End Class
