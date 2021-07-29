<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.GestoreMondiBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'GestoreMondiBtn
        '
        Me.GestoreMondiBtn.Location = New System.Drawing.Point(70, 12)
        Me.GestoreMondiBtn.Name = "GestoreMondiBtn"
        Me.GestoreMondiBtn.Size = New System.Drawing.Size(114, 39)
        Me.GestoreMondiBtn.TabIndex = 0
        Me.GestoreMondiBtn.Text = "World Manager"
        Me.GestoreMondiBtn.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 62)
        Me.Controls.Add(Me.GestoreMondiBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainMenu"
        Me.Text = "Minecraft Tools"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GestoreMondiBtn As Button
End Class
