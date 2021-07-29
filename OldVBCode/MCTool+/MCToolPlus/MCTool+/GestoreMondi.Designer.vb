<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestoreMondi
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestoreMondi))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OptionPanel = New System.Windows.Forms.Panel()
        Me.ResetAppBtn = New System.Windows.Forms.Button()
        Me.OpenPathbtn = New System.Windows.Forms.Button()
        Me.AutoRefreshCbx = New System.Windows.Forms.CheckBox()
        Me.CloseOptionPanelBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveMinecraftPathCbx = New System.Windows.Forms.CheckBox()
        Me.SelectDir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SettingsBtn = New System.Windows.Forms.Button()
        Me.AutoscanBtn = New System.Windows.Forms.Button()
        Me.DirectWrtBtn = New System.Windows.Forms.Button()
        Me.PercorsoMCtbx = New System.Windows.Forms.TextBox()
        Me.ObjectToDisable = New System.Windows.Forms.Panel()
        Me.ShowLogsBtn = New System.Windows.Forms.Button()
        Me.DeleteWorldBtn = New System.Windows.Forms.Button()
        Me.WordListBox = New System.Windows.Forms.CheckedListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenWorldDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportWordBtn = New System.Windows.Forms.Button()
        Me.ImportWorldBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.SaveFileZipDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.DirectoryModifyChecker = New System.IO.FileSystemWatcher()
        Me.NotifyService = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyServiceIconMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionPanel.SuspendLayout()
        Me.ObjectToDisable.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DirectoryModifyChecker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NotifyServiceIconMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'OptionPanel
        '
        Me.OptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OptionPanel.Controls.Add(Me.ResetAppBtn)
        Me.OptionPanel.Controls.Add(Me.OpenPathbtn)
        Me.OptionPanel.Controls.Add(Me.AutoRefreshCbx)
        Me.OptionPanel.Controls.Add(Me.CloseOptionPanelBtn)
        Me.OptionPanel.Controls.Add(Me.Label2)
        Me.OptionPanel.Controls.Add(Me.SaveMinecraftPathCbx)
        Me.OptionPanel.Location = New System.Drawing.Point(59, 135)
        Me.OptionPanel.Name = "OptionPanel"
        Me.OptionPanel.Size = New System.Drawing.Size(263, 166)
        Me.OptionPanel.TabIndex = 6
        Me.OptionPanel.Visible = False
        '
        'ResetAppBtn
        '
        Me.ResetAppBtn.Location = New System.Drawing.Point(3, 129)
        Me.ResetAppBtn.Name = "ResetAppBtn"
        Me.ResetAppBtn.Size = New System.Drawing.Size(97, 23)
        Me.ResetAppBtn.TabIndex = 15
        Me.ResetAppBtn.Text = "Reset Data"
        Me.ResetAppBtn.UseVisualStyleBackColor = True
        '
        'OpenPathbtn
        '
        Me.OpenPathbtn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OpenPathbtn.Enabled = False
        Me.OpenPathbtn.Location = New System.Drawing.Point(147, 129)
        Me.OpenPathbtn.Name = "OpenPathbtn"
        Me.OpenPathbtn.Size = New System.Drawing.Size(111, 23)
        Me.OpenPathbtn.TabIndex = 14
        Me.OpenPathbtn.Text = "Open world path"
        Me.OpenPathbtn.UseVisualStyleBackColor = True
        '
        'AutoRefreshCbx
        '
        Me.AutoRefreshCbx.AutoSize = True
        Me.AutoRefreshCbx.Enabled = False
        Me.AutoRefreshCbx.Location = New System.Drawing.Point(3, 32)
        Me.AutoRefreshCbx.Name = "AutoRefreshCbx"
        Me.AutoRefreshCbx.Size = New System.Drawing.Size(139, 17)
        Me.AutoRefreshCbx.TabIndex = 5
        Me.AutoRefreshCbx.Text = "Enable AutoRefresh"
        Me.AutoRefreshCbx.UseVisualStyleBackColor = True
        '
        'CloseOptionPanelBtn
        '
        Me.CloseOptionPanelBtn.Location = New System.Drawing.Point(240, -1)
        Me.CloseOptionPanelBtn.Name = "CloseOptionPanelBtn"
        Me.CloseOptionPanelBtn.Size = New System.Drawing.Size(22, 23)
        Me.CloseOptionPanelBtn.TabIndex = 2
        Me.CloseOptionPanelBtn.Text = "X"
        Me.CloseOptionPanelBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana Pro Semibold", 12.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(52, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 40)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Other things" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "coming soon..."
        '
        'SaveMinecraftPathCbx
        '
        Me.SaveMinecraftPathCbx.AutoSize = True
        Me.SaveMinecraftPathCbx.Location = New System.Drawing.Point(3, 9)
        Me.SaveMinecraftPathCbx.Name = "SaveMinecraftPathCbx"
        Me.SaveMinecraftPathCbx.Size = New System.Drawing.Size(142, 17)
        Me.SaveMinecraftPathCbx.TabIndex = 0
        Me.SaveMinecraftPathCbx.Text = "Save Minecraft Path"
        Me.SaveMinecraftPathCbx.UseVisualStyleBackColor = True
        '
        'SelectDir
        '
        Me.SelectDir.Font = New System.Drawing.Font("Verdana Pro Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectDir.Location = New System.Drawing.Point(284, 17)
        Me.SelectDir.Name = "SelectDir"
        Me.SelectDir.Size = New System.Drawing.Size(80, 31)
        Me.SelectDir.TabIndex = 3
        Me.SelectDir.Text = "Browse"
        Me.SelectDir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Minecraft Data Directory"
        '
        'SettingsBtn
        '
        Me.SettingsBtn.Location = New System.Drawing.Point(1, 53)
        Me.SettingsBtn.Name = "SettingsBtn"
        Me.SettingsBtn.Size = New System.Drawing.Size(73, 23)
        Me.SettingsBtn.TabIndex = 4
        Me.SettingsBtn.Text = "Option"
        Me.SettingsBtn.UseVisualStyleBackColor = True
        '
        'AutoscanBtn
        '
        Me.AutoscanBtn.Font = New System.Drawing.Font("Verdana Pro Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoscanBtn.Location = New System.Drawing.Point(80, 53)
        Me.AutoscanBtn.Name = "AutoscanBtn"
        Me.AutoscanBtn.Size = New System.Drawing.Size(79, 23)
        Me.AutoscanBtn.TabIndex = 0
        Me.AutoscanBtn.Text = "Autoscan"
        Me.AutoscanBtn.UseVisualStyleBackColor = True
        '
        'DirectWrtBtn
        '
        Me.DirectWrtBtn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DirectWrtBtn.Location = New System.Drawing.Point(165, 53)
        Me.DirectWrtBtn.Name = "DirectWrtBtn"
        Me.DirectWrtBtn.Size = New System.Drawing.Size(97, 23)
        Me.DirectWrtBtn.TabIndex = 5
        Me.DirectWrtBtn.Text = "Direct writing"
        Me.DirectWrtBtn.UseVisualStyleBackColor = True
        '
        'PercorsoMCtbx
        '
        Me.PercorsoMCtbx.Location = New System.Drawing.Point(1, 23)
        Me.PercorsoMCtbx.Name = "PercorsoMCtbx"
        Me.PercorsoMCtbx.ReadOnly = True
        Me.PercorsoMCtbx.Size = New System.Drawing.Size(276, 21)
        Me.PercorsoMCtbx.TabIndex = 1
        '
        'ObjectToDisable
        '
        Me.ObjectToDisable.Controls.Add(Me.ShowLogsBtn)
        Me.ObjectToDisable.Controls.Add(Me.DeleteWorldBtn)
        Me.ObjectToDisable.Controls.Add(Me.WordListBox)
        Me.ObjectToDisable.Controls.Add(Me.ExportWordBtn)
        Me.ObjectToDisable.Controls.Add(Me.PercorsoMCtbx)
        Me.ObjectToDisable.Controls.Add(Me.Label1)
        Me.ObjectToDisable.Controls.Add(Me.ImportWorldBtn)
        Me.ObjectToDisable.Controls.Add(Me.SelectDir)
        Me.ObjectToDisable.Controls.Add(Me.Label3)
        Me.ObjectToDisable.Controls.Add(Me.DirectWrtBtn)
        Me.ObjectToDisable.Controls.Add(Me.SettingsBtn)
        Me.ObjectToDisable.Controls.Add(Me.AutoscanBtn)
        Me.ObjectToDisable.Location = New System.Drawing.Point(12, 7)
        Me.ObjectToDisable.Name = "ObjectToDisable"
        Me.ObjectToDisable.Size = New System.Drawing.Size(366, 327)
        Me.ObjectToDisable.TabIndex = 7
        '
        'ShowLogsBtn
        '
        Me.ShowLogsBtn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ShowLogsBtn.Location = New System.Drawing.Point(265, 53)
        Me.ShowLogsBtn.Name = "ShowLogsBtn"
        Me.ShowLogsBtn.Size = New System.Drawing.Size(97, 23)
        Me.ShowLogsBtn.TabIndex = 16
        Me.ShowLogsBtn.Text = "Show Logs"
        Me.ShowLogsBtn.UseVisualStyleBackColor = True
        '
        'DeleteWorldBtn
        '
        Me.DeleteWorldBtn.Font = New System.Drawing.Font("Verdana Pro Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.DeleteWorldBtn.Location = New System.Drawing.Point(119, 300)
        Me.DeleteWorldBtn.Name = "DeleteWorldBtn"
        Me.DeleteWorldBtn.Size = New System.Drawing.Size(125, 24)
        Me.DeleteWorldBtn.TabIndex = 13
        Me.DeleteWorldBtn.Text = "Delete World/s"
        Me.DeleteWorldBtn.UseVisualStyleBackColor = True
        '
        'WordListBox
        '
        Me.WordListBox.CheckOnClick = True
        Me.WordListBox.ContextMenuStrip = Me.ContextMenuStrip1
        Me.WordListBox.FormattingEnabled = True
        Me.WordListBox.Location = New System.Drawing.Point(1, 104)
        Me.WordListBox.Name = "WordListBox"
        Me.WordListBox.Size = New System.Drawing.Size(358, 196)
        Me.WordListBox.TabIndex = 12
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.DeselectAllToolStripMenuItem, Me.OpenWorldDirectoryToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(187, 92)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'DeselectAllToolStripMenuItem
        '
        Me.DeselectAllToolStripMenuItem.Name = "DeselectAllToolStripMenuItem"
        Me.DeselectAllToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.DeselectAllToolStripMenuItem.Text = "Deselect All"
        '
        'OpenWorldDirectoryToolStripMenuItem
        '
        Me.OpenWorldDirectoryToolStripMenuItem.Name = "OpenWorldDirectoryToolStripMenuItem"
        Me.OpenWorldDirectoryToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.OpenWorldDirectoryToolStripMenuItem.Text = "Open world directory"
        '
        'ExportWordBtn
        '
        Me.ExportWordBtn.Font = New System.Drawing.Font("Verdana Pro Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ExportWordBtn.Location = New System.Drawing.Point(250, 300)
        Me.ExportWordBtn.Name = "ExportWordBtn"
        Me.ExportWordBtn.Size = New System.Drawing.Size(109, 24)
        Me.ExportWordBtn.TabIndex = 11
        Me.ExportWordBtn.Text = "Export World/s"
        Me.ExportWordBtn.UseVisualStyleBackColor = True
        '
        'ImportWorldBtn
        '
        Me.ImportWorldBtn.Font = New System.Drawing.Font("Verdana Pro Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ImportWorldBtn.Location = New System.Drawing.Point(3, 300)
        Me.ImportWorldBtn.Name = "ImportWorldBtn"
        Me.ImportWorldBtn.Size = New System.Drawing.Size(110, 24)
        Me.ImportWorldBtn.TabIndex = 9
        Me.ImportWorldBtn.Text = "Import World/s"
        Me.ImportWorldBtn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana Pro Semibold", 12.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(132, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "World List"
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Verdana Pro", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.StatusLabel.ForeColor = System.Drawing.Color.ForestGreen
        Me.StatusLabel.Location = New System.Drawing.Point(80, 183)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(228, 38)
        Me.StatusLabel.TabIndex = 13
        Me.StatusLabel.Text = "Exporting..."
        Me.StatusLabel.Visible = False
        '
        'SaveFileZipDialog
        '
        Me.SaveFileZipDialog.AddExtension = False
        Me.SaveFileZipDialog.FileName = "Exported"
        Me.SaveFileZipDialog.Filter = "World Manager pack file|*.jwm"
        Me.SaveFileZipDialog.Title = "Save..."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "World Manager pack file|*.jwm"
        '
        'DirectoryModifyChecker
        '
        Me.DirectoryModifyChecker.EnableRaisingEvents = True
        Me.DirectoryModifyChecker.IncludeSubdirectories = True
        Me.DirectoryModifyChecker.NotifyFilter = System.IO.NotifyFilters.DirectoryName
        Me.DirectoryModifyChecker.SynchronizingObject = Me
        '
        'NotifyService
        '
        Me.NotifyService.BalloonTipText = "Hello :)"
        Me.NotifyService.BalloonTipTitle = "Hello :)"
        Me.NotifyService.ContextMenuStrip = Me.NotifyServiceIconMenu
        Me.NotifyService.Icon = CType(resources.GetObject("NotifyService.Icon"), System.Drawing.Icon)
        Me.NotifyService.Text = "Hello :)"
        Me.NotifyService.Visible = True
        '
        'NotifyServiceIconMenu
        '
        Me.NotifyServiceIconMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.NotifyServiceIconMenu.Name = "NotifyServiceIconMenu"
        Me.NotifyServiceIconMenu.Size = New System.Drawing.Size(181, 70)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'GestoreMondi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 340)
        Me.Controls.Add(Me.OptionPanel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.ObjectToDisable)
        Me.Font = New System.Drawing.Font("Verdana Pro Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "GestoreMondi"
        Me.Text = "Word Manager"
        Me.OptionPanel.ResumeLayout(False)
        Me.OptionPanel.PerformLayout()
        Me.ObjectToDisable.ResumeLayout(False)
        Me.ObjectToDisable.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DirectoryModifyChecker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NotifyServiceIconMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OptionPanel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents SaveMinecraftPathCbx As CheckBox
    Friend WithEvents CloseOptionPanelBtn As Button
    Friend WithEvents SelectDir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents SettingsBtn As Button
    Friend WithEvents AutoscanBtn As Button
    Friend WithEvents DirectWrtBtn As Button
    Friend WithEvents PercorsoMCtbx As TextBox
    Friend WithEvents ObjectToDisable As Panel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents ImportWorldBtn As Button
    Friend WithEvents ExportWordBtn As Button
    Friend WithEvents SaveFileZipDialog As SaveFileDialog
    Friend WithEvents WordListBox As CheckedListBox
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeselectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusLabel As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents DeleteWorldBtn As Button
    Friend WithEvents AutoRefreshCbx As CheckBox
    Friend WithEvents DirectoryModifyChecker As IO.FileSystemWatcher
    Friend WithEvents OpenPathbtn As Button
    Friend WithEvents ResetAppBtn As Button
    Friend WithEvents ShowLogsBtn As Button
    Friend WithEvents OpenWorldDirectoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotifyService As NotifyIcon
    Friend WithEvents NotifyServiceIconMenu As ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
End Class
