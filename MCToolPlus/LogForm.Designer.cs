
namespace MCToolPlus
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CloseLogsWindowsBtn = new System.Windows.Forms.Button();
            this.ClearLogsBtn = new System.Windows.Forms.Button();
            this.SaveLogsBtn = new System.Windows.Forms.Button();
            this.ApplicationLogs = new System.Windows.Forms.RichTextBox();
            this.SaveLogFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // CloseLogsWindowsBtn
            // 
            this.CloseLogsWindowsBtn.Location = new System.Drawing.Point(169, 527);
            this.CloseLogsWindowsBtn.Name = "CloseLogsWindowsBtn";
            this.CloseLogsWindowsBtn.Size = new System.Drawing.Size(68, 23);
            this.CloseLogsWindowsBtn.TabIndex = 7;
            this.CloseLogsWindowsBtn.Text = "Close";
            this.CloseLogsWindowsBtn.UseVisualStyleBackColor = true;
            // 
            // ClearLogsBtn
            // 
            this.ClearLogsBtn.Location = new System.Drawing.Point(243, 527);
            this.ClearLogsBtn.Name = "ClearLogsBtn";
            this.ClearLogsBtn.Size = new System.Drawing.Size(163, 23);
            this.ClearLogsBtn.TabIndex = 6;
            this.ClearLogsBtn.Text = "Clear Logs";
            this.ClearLogsBtn.UseVisualStyleBackColor = true;
            // 
            // SaveLogsBtn
            // 
            this.SaveLogsBtn.Location = new System.Drawing.Point(12, 527);
            this.SaveLogsBtn.Name = "SaveLogsBtn";
            this.SaveLogsBtn.Size = new System.Drawing.Size(151, 23);
            this.SaveLogsBtn.TabIndex = 5;
            this.SaveLogsBtn.Text = "Save Logs";
            this.SaveLogsBtn.UseVisualStyleBackColor = true;
            // 
            // ApplicationLogs
            // 
            this.ApplicationLogs.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationLogs.Location = new System.Drawing.Point(0, 1);
            this.ApplicationLogs.Name = "ApplicationLogs";
            this.ApplicationLogs.ReadOnly = true;
            this.ApplicationLogs.Size = new System.Drawing.Size(418, 520);
            this.ApplicationLogs.TabIndex = 4;
            this.ApplicationLogs.Text = "";
            // 
            // SaveLogFileDialog
            // 
            this.SaveLogFileDialog.AddExtension = false;
            this.SaveLogFileDialog.FileName = "Logs";
            this.SaveLogFileDialog.Filter = "File RTF|*.rtf|File di log|*.log";
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 551);
            this.Controls.Add(this.CloseLogsWindowsBtn);
            this.Controls.Add(this.ClearLogsBtn);
            this.Controls.Add(this.SaveLogsBtn);
            this.Controls.Add(this.ApplicationLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Logs";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button CloseLogsWindowsBtn;
        internal System.Windows.Forms.Button ClearLogsBtn;
        internal System.Windows.Forms.Button SaveLogsBtn;
        internal System.Windows.Forms.RichTextBox ApplicationLogs;
        internal System.Windows.Forms.SaveFileDialog SaveLogFileDialog;
    }
}