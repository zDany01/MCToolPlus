Imports System.IO
Imports System.IO.Compression
Imports MCTool_.SharedCode.ErrorHandler
Imports Microsoft.Win32
Imports LibNbt
Imports System.ComponentModel

Public Class GestoreMondi
#Region "Variabili Globali"
    ReadOnly AppdataRoaming As String = Environment.GetEnvironmentVariable("appdata").ToString & "\"
    Const ZipKey As String = "aWwgdHJhcGV6aW8gc2NhbGVubyDDqCB1biBhYm9ydG8="
    Public RegDataKey As RegistryKey
    Private Structure ImportWorld_Data 'dati condivisi fra due sub
        Shared TmpExtractDirectory As String
        Shared McWorldsArleadyExisting As New List(Of String)
        Shared NMondiImportati As Integer = 0
        Shared TemporaneyCheckedListBox As New CheckedListBox With {
            .Location = New Point(12, 111),
            .Size = New Size(358, 196)
        }
        Shared ImportSelectedBtn As New Button With {
            .Text = "Import Selected",
            .Location = New Point(15, 307),
            .Size = New Size(179, 23)
        }
        Shared ImportAllBtn As New Button With {
        .Text = "Import All",
        .Location = New Point(193, 307),
        .Size = New Size(179, 23)
        }
        Public Shared Sub Reset()
            TmpExtractDirectory = ""
            McWorldsArleadyExisting.Clear()
            NMondiImportati = 0
            GestoreMondi.Controls.Remove(TemporaneyCheckedListBox)
            TemporaneyCheckedListBox.Items.Clear()
            GestoreMondi.Controls.Remove(ImportAllBtn)
            GestoreMondi.Controls.Remove(ImportSelectedBtn)
            RemoveHandler ImportSelectedBtn.Click, AddressOf GestoreMondi.DynamicBtnClick
            RemoveHandler ImportAllBtn.Click, AddressOf GestoreMondi.DynamicBtnAllClick
        End Sub
    End Structure

#End Region
#Region "Funzioni/Subroutine richiamabili"
    Private Function TryFileWrite(a As Action) As Short
        Try
            a()
        Catch ex As Exception
            HandleError(ex)
            Return -1
        End Try
        Return 0
    End Function
    Private Sub ControlloMinecraft(Manual As Integer, Optional DirToCheck As String = "")
        Dim MCDir As String
        If Manual = 0 Then
            If Directory.Exists($"{AppdataRoaming}.minecraft\saves") Then PercorsoMCtbx.Text = $"{AppdataRoaming}.minecraft" : Return
        ElseIf Manual = 1 Then
            If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then MCDir = FolderBrowserDialog1.SelectedPath Else Return
        Else : MCDir = DirToCheck 'direct writing.
        End If

#Disable Warning BC42104 ' La variabile è stata usata prima dell'assegnazione di un valore
        If Not Directory.Exists($"{MCDir}\saves") Then
#Enable Warning BC42104 ' La variabile è stata usata prima dell'assegnazione di un valore
            If TryFileWrite(Sub() Directory.CreateDirectory($"{MCDir}\saves")) = -1 Then Return
        End If
        PercorsoMCtbx.Text = MCDir

    End Sub
    Private Sub ControlloDati()
        Dim KeyExist As Boolean = False
        Dim ParentKey As Boolean = False
        For Each _regkey As String In Registry.CurrentUser.OpenSubKey("SOFTWARE").GetSubKeyNames 'controlla l'esistenza della chiave
            If _regkey = "MCToolPlus" Then
                ParentKey = True
                For Each _internalregkey In Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("MCToolPlus").GetSubKeyNames
                    If _internalregkey = "WM" Then
                        KeyExist = True
                        Exit For
                    End If
                Next
            End If
        Next

        If Not KeyExist Then
            If ParentKey Then RegDataKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", True).OpenSubKey("MCToolPlus", True).CreateSubKey("WM", True) Else RegDataKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", True).CreateSubKey("MCToolPlus", True).CreateSubKey("WM", True)
            RegDataKey.SetValue("SavePath", True)
            RegDataKey.SetValue("MCPath", "")
            RegDataKey.SetValue("AutoRefresh", False)
        Else
            RegDataKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", True).OpenSubKey("MCToolPlus", True).OpenSubKey("WM", True)
        End If
        If Boolean.TryParse(RegDataKey.GetValue("SavePath"), True) = False OrElse Boolean.TryParse(RegDataKey.GetValue("AutoRefresh"), True) = False Then 'controlla se il valore della chiave è corretto(se è convertibile in boolean), in caso contrario la elimina e chiude il form ///specificamente quello che prova a fare è convertire il valore della chiave SavePath in boolean, se ci riesce allora restituisce il valore "True" altrimenti false
            MsgBox($"Damaged data were found.{Environment.NewLine}Resetting data...", MsgBoxStyle.Critical, "Restoring...")
            ResetAppConfig()
        End If

        If RegDataKey.GetValue("SavePath") Then 'controlla se la checkbox Save path(salva il percorso) deve essere spuntata o no sulla base del valore nel registro.
            SaveMinecraftPathCbx.Checked = True
            PercorsoMCtbx.Text = RegDataKey.GetValue("MCPath")
        Else
            SaveMinecraftPathCbx.Checked = False
        End If

        If RegDataKey.GetValue("AutoRefresh") Then
            AutoRefreshCbx.Checked = True
        Else
            AutoRefreshCbx.Checked = False
        End If
    End Sub
    Private Sub ResetAppConfig()
        Registry.CurrentUser.OpenSubKey("SOFTWARE", True).OpenSubKey("MCToolPlus", True).DeleteSubKeyTree("WM", False)
        Close()
        Return
    End Sub
    Private Sub ZipAddAlsoFileInSubDirs(ArchiveToAddFiles As ZipArchive, DirectoryToCheck As String, KUsedForReplace As String)
        Try
            For Each _filetowrite As String In Directory.GetFileSystemEntries(DirectoryToCheck)
                If Directory.Exists(_filetowrite) Then
                    ZipAddAlsoFileInSubDirs(ArchiveToAddFiles, $"{_filetowrite}\", KUsedForReplace)
                    Continue For 'Serve per passare direttamente alla prossima esecuzione del for senza continuare il codice
                End If
                ArchiveToAddFiles.CreateEntryFromFile(_filetowrite, _filetowrite.Replace(KUsedForReplace, Nothing))
            Next
        Catch ex As Exception
            HandleError(ex)
            Return
        End Try
    End Sub
    Private Sub ZipSigning(Archivio As ZipArchive)
        Using textwriter As New StreamWriter(Archivio.CreateEntry("key").Open()) 'crea un file nell'archivio zip che viene passato allo stream writer per essere scritto
            textwriter.Write(ZipKey) 'scrive la chiave dello zip che verrà verificata successivamente durante l'importazione
            textwriter.Flush() : textwriter.Close()
        End Using
    End Sub
    Private Sub CheckWord()
        If Not Directory.Exists($"{PercorsoMCtbx.Text}\saves") Then
            PercorsoMCtbx.Text = ""
            Return
        End If
        WordListBox.Items.Clear()
        Dim levelnamenbt As New NbtFile
        Dim extlevelname As String
        For Each _directory As String In Directory.GetDirectories(PercorsoMCtbx.Text & "\saves")
            Try
                levelnamenbt.LoadFile($"{_directory}\level.dat")
                extlevelname = levelnamenbt.Query("//Data/LevelName").ToString
                extlevelname = extlevelname.Remove(0, extlevelname.LastIndexOf(":") + 2)
            Catch
                extlevelname = "???"
            End Try
            WordListBox.Items.Add(_directory.Replace($"{PercorsoMCtbx.Text}\saves\", Nothing) & $"({extlevelname})")
            levelnamenbt.Dispose()
        Next
    End Sub
    Public Sub Re_Center()
        CenterToScreen()
        MsgBox("Why?", MsgBoxStyle.Question)
    End Sub
    Private Sub AfterWorldImport()
        If ImportWorld_Data.NMondiImportati <> 0 Then
            If MsgBox(IIf(ImportWorld_Data.NMondiImportati > 1, $"{ImportWorld_Data.NMondiImportati} worlds have been successfully imported.{Environment.NewLine}Do you want to delete the backup file?", $"The world has been successfully imported.{Environment.NewLine}Do you want to delete the backup file?"), MsgBoxStyle.YesNo + MsgBoxStyle.Information, "World Importer") = vbYes Then File.Delete(OpenFileDialog1.FileName)
        End If
        ContextMenuStrip1.Items.Item(0).PerformClick() 'ricarica la lista.
        StatusLabel.Hide()
        ObjectToDisable.Enabled = True
    End Sub
    Private Sub ImportWorlds()
        'Try
        For Each NomeMondo As String In ImportWorld_Data.TemporaneyCheckedListBox.CheckedItems
            If ImportWorld_Data.McWorldsArleadyExisting.Contains(NomeMondo) Then 'controlla se il mondo già esiste
                If MsgBox($"The world {NomeMondo} has already been found in the saves folder, do you want to replace the world?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = vbYes Then
                    Directory.Delete($"{PercorsoMCtbx.Text}\saves\{NomeMondo}", True) 'nel caso in cui l'utente decide di sostituire il mondo allora elimina il mondo
                Else
                    Continue For 'se l'utente decide di non sostituire il mondo allora passa al mondo successivo se c'è.
                End If
            End If
            Directory.Move($"{ImportWorld_Data.TmpExtractDirectory}\{NomeMondo}", $"{PercorsoMCtbx.Text}\saves\{NomeMondo}") 'questo codice che serve per spostare le directory non verrà eseguito se la persona decide di non sovrascrivere il mondo.
            LogForms.AppendLog($"{Environment.NewLine}Imported World: {NomeMondo}", Color.DarkCyan)
            ImportWorld_Data.NMondiImportati += 1
        Next
        Directory.Delete(ImportWorld_Data.TmpExtractDirectory, True)

        ' Catch ex As Exception
        ' HandleError(ex)
        ' Finally
        ImportWorld_Data.Reset()
        AfterWorldImport()
        'End Try
    End Sub
#End Region

    Private Sub AutoscanBtn_Click(sender As Object, e As EventArgs) Handles AutoscanBtn.Click
        ControlloMinecraft(0)
    End Sub

    Private Sub SelectDir_Click(sender As Object, e As EventArgs) Handles SelectDir.Click
        ControlloMinecraft(1)
    End Sub

    Private Sub DirectWrtBtn_Click(sender As Object, e As EventArgs) Handles DirectWrtBtn.Click
        Dim DirToCheck As String = InputBox("Insert Directory Path: ", "Directory Chooser")
        If Directory.Exists(DirToCheck) Then If Not String.IsNullOrWhiteSpace(DirToCheck) Then ControlloMinecraft(2, DirToCheck) Else MsgBox("Check the data entered.", MsgBoxStyle.Exclamation, "Invalid data")
    End Sub

    Private Sub SettingsBtn_Click(sender As Object, e As EventArgs) Handles SettingsBtn.Click
        ControlloDati()
        ObjectToDisable.Enabled = False
        OptionPanel.Show()
    End Sub

    Private Sub SaveMinecraftPathCbx_CheckedChanged(sender As Object, e As EventArgs) Handles SaveMinecraftPathCbx.CheckedChanged
        If SaveMinecraftPathCbx.Checked Then
            RegDataKey.SetValue("SavePath", True)
        Else
            RegDataKey.SetValue("SavePath", False)
            RegDataKey.SetValue("MCPath", "")
        End If
    End Sub

    Private Sub PercorsoMCtbx_TextChanged(sender As Object, e As EventArgs) Handles PercorsoMCtbx.TextChanged
        If SaveMinecraftPathCbx.Checked Then RegDataKey.SetValue("MCPath", PercorsoMCtbx.Text)
        CheckWord()
        If Not String.IsNullOrWhiteSpace(PercorsoMCtbx.Text) Then
            AutoRefreshCbx.Enabled = True
            OpenPathbtn.Enabled = True
            If AutoRefreshCbx.Checked Then DirectoryModifyChecker.Path = $"{PercorsoMCtbx.Text}\saves\" 'viene eseguito in tutti i casi anche se prima non era attivo per un cambio normale
        Else
            If AutoRefreshCbx.Checked Then
                AutoRefreshCbx.Enabled = False
                OpenPathbtn.Enabled = False
            End If
        End If
    End Sub

    Private Sub GestoreMondi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImportWorld_Data.Reset()
        SaveFileZipDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        LogForms.GetReady()
        ControlloDati() 'se nel controllo dati esce anche una directory predefinita allora automaticamente cambierà la TextBox con la cartella dei mondi che triggererà la sub PercorsoMCTbx_TextChanged che automaticamente caricherà i mondi.
        OptionPanel.BringToFront()
    End Sub

    Private Sub CloseOptionPanelBtn_Click(sender As Object, e As EventArgs) Handles CloseOptionPanelBtn.Click
        OptionPanel.Hide()
        ObjectToDisable.Enabled = True
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        CheckWord()
    End Sub

    Private Sub ExportWordBtn_Click(sender As Object, e As EventArgs) Handles ExportWordBtn.Click
        If WordListBox.CheckedItems.Count <> 0 Then
            SaveFileZipDialog.ShowDialog()
        End If
    End Sub

    Private Async Sub SaveFileZipDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileZipDialog.FileOk

        If File.Exists(SaveFileZipDialog.FileName) Then
            If TryFileWrite(Sub() File.Delete(SaveFileZipDialog.FileName)) = -1 Then Return 'un try che nel caso accada un errore lo rimanda all'ErrorHandler
        End If

        Try
            Using PosizioneZip = New IO.FileStream(SaveFileZipDialog.FileName, FileMode.Append) 'questa riga serve a creare il nuovo file zip che sarà nuovo. (Using a differenza di dim crea una variabile che viene eliminata dopo l'End using, in questo caso conviene farlo poiché nel caso in cui l'utente successivamente volesse creare un altro file zip potrebbero verificarsi errori(potrebbero non verificato) perché questa variabili potrebbero ancora contenere dei dati.
                Using Archivio = New ZipArchive(PosizioneZip, ZipArchiveMode.Create) 'con questa variabile ci riferiremo all'archivio zip creato precedentemente, e come se fosse uno StreamWriter(file), con lo ziparchivemode.create specifichiamo che tutti i file che aggiungeremo al zip sono nuovi e non stiamo richiamando la funzione per rimuovere o aggiornare file già presenti

                    ObjectToDisable.Enabled = False
                    StatusLabel.Text = "Exporting..."
                    StatusLabel.Show()
                    Await Task.Delay(750)
                    For Each _worditem As String In WordListBox.CheckedItems
                        ZipAddAlsoFileInSubDirs(Archivio, $"{PercorsoMCtbx.Text}\saves\{_worditem.ToString.Substring(0, _worditem.ToString.LastIndexOf("("))}", $"{PercorsoMCtbx.Text}\saves\")
                        LogForms.AppendLog($"{Environment.NewLine}Backupped World: {Environment.NewLine}{_worditem} >> {SaveFileZipDialog.FileName.Remove(0, SaveFileZipDialog.FileName.LastIndexOf("\") + 1)}", Color.DarkGreen)
                    Next
                    ZipSigning(Archivio)
                    StatusLabel.Text = "Exported!"
                    Await Task.Delay(1000)
                    ContextMenuStrip1.Items.Item(2).PerformClick() 'deseleziona tutto
                End Using
            End Using
        Catch ex As Exception
            HandleError(ex)
            File.Delete(SaveFileZipDialog.FileName)
        End Try

        StatusLabel.Hide()
        ObjectToDisable.Enabled = True
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For i As Integer = 0 To WordListBox.Items.Count - 1
            WordListBox.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub DeselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeselectAllToolStripMenuItem.Click
        For i As Integer = 0 To WordListBox.Items.Count - 1
            WordListBox.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub ImportWorldBtn_Click(sender As Object, e As EventArgs) Handles ImportWorldBtn.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Async Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        If String.IsNullOrWhiteSpace(PercorsoMCtbx.Text) Then Return

        Try
            Using PosizioneZip = New IO.FileStream(OpenFileDialog1.FileName, FileMode.Open)
                Using Archivio = New ZipArchive(PosizioneZip, ZipArchiveMode.Update)

                    If Not Archivio.Entries.Contains(Archivio.GetEntry("key")) Then 'nel caso in cui la chiave dello zip(file:"key") non esista allora il programma dice che non è un backup valido.
zipnotvalid:
                        MsgBox("The selected file isn't a valid backup", MsgBoxStyle.Exclamation, "World Importer")
                        Return
                    End If


                    ObjectToDisable.Enabled = False
                    StatusLabel.Text = "Checking..." 'verificata l'esistenza del file key verifica che sia valido
                    StatusLabel.Show()
                    Await Task.Delay(750)
                    Dim RndClass As New Random, Rndnumber As Integer = RndClass.Next(1, 7583)
                    ImportWorld_Data.TmpExtractDirectory = $"{My.Computer.FileSystem.SpecialDirectories.Temp}\jwmtempworld{Rndnumber}"
                    Directory.CreateDirectory(ImportWorld_Data.TmpExtractDirectory)
                    Archivio.ExtractToDirectory(ImportWorld_Data.TmpExtractDirectory)
                    ObjectToDisable.Enabled = False
                    If Not File.ReadAllText($"{ImportWorld_Data.TmpExtractDirectory}\key") = ZipKey Then GoTo zipnotvalid
                    File.Delete($"{ImportWorld_Data.TmpExtractDirectory}\key")
                    StatusLabel.Text = "Importing..."

                    For Each _WorldtoaddinList As String In Directory.GetFileSystemEntries($"{PercorsoMCtbx.Text}\saves")
                        If Directory.Exists(_WorldtoaddinList) Then ImportWorld_Data.McWorldsArleadyExisting.Add(_WorldtoaddinList.Replace($"{PercorsoMCtbx.Text}\saves\", Nothing))
                    Next

                    If Directory.GetDirectories(ImportWorld_Data.TmpExtractDirectory).Count > 1 Then 'se c'è più di un mondo, messo il numero due poiché un elemento è sempre il file key, un altro è una cartella del mondo
                        NotifyService.ShowBalloonTip(1500, "MCTool+", "More than one world was found in the package, choose which worlds import or press the Import All button.", ToolTipIcon.Info)

                        For Each _Directory As String In Directory.GetDirectories(ImportWorld_Data.TmpExtractDirectory)
                            ImportWorld_Data.TemporaneyCheckedListBox.Items.Add(_Directory.Replace($"{ImportWorld_Data.TmpExtractDirectory}\", Nothing))
                        Next
                        AddHandler ImportWorld_Data.ImportSelectedBtn.Click, AddressOf DynamicBtnClick
                        AddHandler ImportWorld_Data.ImportAllBtn.Click, AddressOf DynamicBtnAllClick
                        Controls.Add(ImportWorld_Data.TemporaneyCheckedListBox)
                        Controls.Add(ImportWorld_Data.ImportAllBtn)
                        Controls.Add(ImportWorld_Data.ImportSelectedBtn)
                        ImportWorld_Data.TemporaneyCheckedListBox.BringToFront()
                        ImportWorld_Data.ImportAllBtn.BringToFront()
                        ImportWorld_Data.ImportSelectedBtn.BringToFront()
                    Else
                        For Each _Directory As String In Directory.GetDirectories(ImportWorld_Data.TmpExtractDirectory)
                            Dim NomeMondo As String = _Directory.Replace($"{ImportWorld_Data.TmpExtractDirectory}\", Nothing)
                            If ImportWorld_Data.McWorldsArleadyExisting.Contains(NomeMondo) Then 'controlla se il mondo già esiste
                                If MsgBox($"The world {NomeMondo} has already been found in the saves folder, do you want to replace the world?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = vbYes Then
                                    Directory.Delete($"{PercorsoMCtbx.Text}\saves\{NomeMondo}", True) 'nel caso in cui l'utente decide di sostituire il mondo allora elimina il mondo
                                Else
                                    Continue For 'se l'utente decide di non sostituire il mondo allora passa al mondo successivo se c'è.
                                End If
                            End If
                            Directory.Move(ImportWorld_Data.TmpExtractDirectory & "\" & NomeMondo, $"{PercorsoMCtbx.Text}\saves\{NomeMondo}") 'questo codice che serve per spostare le directory non verrà eseguito se la persona decide di non sovrascrivere il mondo.
                            LogForms.AppendLog($"{Environment.NewLine}Imported World: {NomeMondo}", Color.DarkCyan)
                            ImportWorld_Data.NMondiImportati += 1
                            Directory.Delete(ImportWorld_Data.TmpExtractDirectory, True)
                        Next

                        AfterWorldImport()

                    End If
                End Using
            End Using

        Catch ex As Exception
            HandleError(ex)
            ImportWorld_Data.Reset()
        End Try
    End Sub

    Private Sub DynamicBtnClick(sender As Object, e As EventArgs)
        ImportWorlds()
    End Sub
    Private Sub DynamicBtnAllClick(sender As Object, e As EventArgs)
        For i As Integer = 0 To ImportWorld_Data.TemporaneyCheckedListBox.Items.Count - 1
            ImportWorld_Data.TemporaneyCheckedListBox.SetItemChecked(i, True)
        Next
        ImportWorlds()
    End Sub

    Private Sub DeleteWorldBtn_Click(sender As Object, e As EventArgs) Handles DeleteWorldBtn.Click
        Dim NMondiSelezionati As Integer = WordListBox.CheckedItems.Count
        If NMondiSelezionati <> 0 Then
            If MsgBox(IIf(NMondiSelezionati > 1, $"Are you sure you want to delete these {NMondiSelezionati} Worlds?", $"Are you sure you want to delete {WordListBox.CheckedItems.Item(0)}?"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "World Importer") = vbYes Then
                For Each _world As String In WordListBox.CheckedItems
                    TryFileWrite(Sub() Directory.Delete($"{PercorsoMCtbx.Text}\saves\{_world.Substring(0, _world.LastIndexOf("("))}", True))
                Next
                ContextMenuStrip1.Items.Item(0).PerformClick() 'ricarica la lista.
            End If
        End If
    End Sub

    Private Sub OpenPathbtn_Click(sender As Object, e As EventArgs) Handles OpenPathbtn.Click
        If Not String.IsNullOrWhiteSpace(PercorsoMCtbx.Text) Then Process.Start($"{PercorsoMCtbx.Text}\saves")
    End Sub

    Private Sub AutoRefresh_CheckedChanged(sender As Object, e As EventArgs) Handles AutoRefreshCbx.CheckedChanged
        If AutoRefreshCbx.Checked Then
            RegDataKey.SetValue("AutoRefresh", True)
            If Not String.IsNullOrWhiteSpace(PercorsoMCtbx.Text) Then
                DirectoryModifyChecker.Path = $"{PercorsoMCtbx.Text}\saves\"
            Else
                AutoRefreshCbx.Checked = False
                Return
            End If
            DirectoryModifyChecker.IncludeSubdirectories = False
            DirectoryModifyChecker.EnableRaisingEvents = True
            CheckWord()
        Else
            DirectoryModifyChecker.EnableRaisingEvents = False
            RegDataKey.SetValue("AutoRefresh", False)
        End If
    End Sub

    Private Sub Directorymodifychecker_changed(sender As Object, e As FileSystemEventArgs) Handles DirectoryModifyChecker.Changed, DirectoryModifyChecker.Created, DirectoryModifyChecker.Deleted
        CheckWord()
        Select Case e.ChangeType
            Case WatcherChangeTypes.Created
                LogForms.AppendLog($"{Environment.NewLine}Directory created: ", Color.Green)
                LogForms.AppendLog(e.Name, Color.Black)
            Case WatcherChangeTypes.Deleted
                LogForms.AppendLog($"{Environment.NewLine}Directory deleted: ", Color.Red)
                LogForms.AppendLog(e.Name, Color.Black)
        End Select
    End Sub
    Private Sub DirectoryModifyChecker_Renamed(sender As Object, e As RenamedEventArgs) Handles DirectoryModifyChecker.Renamed
        LogForms.AppendLog($"{Environment.NewLine}Directory renamed: ", Color.Blue)
        LogForms.AppendLog($"{e.OldName} --> {e.Name}", Color.Black)
    End Sub

    Private Sub ResetAppBtn_Click(sender As Object, e As EventArgs) Handles ResetAppBtn.Click
        ResetAppConfig()
    End Sub

    Private Sub ShowLogsBtn_Click(sender As Object, e As EventArgs) Handles ShowLogsBtn.Click
        LogForms.Show()
    End Sub

    Private Sub GestoreMondi_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        LogForms.Location = New Size(Me.Location.X + 390, Me.Location.Y)
    End Sub

    Private Sub OpenWorldDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenWorldDirectoryToolStripMenuItem.Click
        If WordListBox.SelectedItem <> "" Then If Directory.Exists($"{PercorsoMCtbx.Text}\saves\{WordListBox.SelectedItem.ToString.Substring(0, WordListBox.SelectedItem.ToString.LastIndexOf("("))}") Then Process.Start($"{PercorsoMCtbx.Text}\saves\{WordListBox.SelectedItem.ToString.Substring(0, WordListBox.SelectedItem.ToString.LastIndexOf("("))}")
    End Sub

    Private Sub GestoreMondi_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        LogForms.Close()
    End Sub

    Private Sub GestoreMondi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        LogForms.ApplicationLogs.ResetText()
    End Sub

    Private Sub NotifyService_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyService.MouseDoubleClick
        OpenToolStripMenuItem.PerformClick()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        WindowState = WindowState.Normal
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class