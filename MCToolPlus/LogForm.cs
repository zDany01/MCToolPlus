using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCToolPlus.Forms;

namespace MCToolPlus
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            #region "Events"
            this.FormClosing += LogForm_FormClosing;
            CloseLogsWindowsBtn.Click += CloseLogsWindowsBtn_Click;
            SaveLogFileDialog.FileOk += SaveLogFileDialog_FileOk;
            SaveLogsBtn.Click += SaveLogsBtn_Click;
            #endregion
            GetReady();
        }

        private void SaveLogFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                if (SaveLogFileDialog.FileName.EndsWith(".rtf")) { ApplicationLogs.SaveFile(SaveLogFileDialog.FileName); } else { System.IO.File.WriteAllText(SaveLogFileDialog.FileName, ApplicationLogs.Text); }
            }
            catch (Exception ex)
            {
                SharedCode.HandleError(ex);
            }
        }

        private void GetReady()
        {
            ApplicationLogs.SelectionStart = ApplicationLogs.TextLength;
            ApplicationLogs.SelectionLength = 0;
            ApplicationLogs.SelectionColor = Color.Black;
            ApplicationLogs.SelectionFont = new Font(ApplicationLogs.SelectionFont.FontFamily, ApplicationLogs.SelectionFont.Size, FontStyle.Bold | FontStyle.Italic); //FintStyle.Bold | FontStyle.Italic will create a FontStyle that Is both Bold And Italic. It may seem strange To use Or When logically you mean And, but this Is a bitwise operation. Each individual value Is a series of bits that only has a single bit set. The bitwise Or creates a New value that has both the bit for Bold And the bit for Italic set.
            ApplicationLogs.SelectionColor = ApplicationLogs.ForeColor;
            ApplicationLogs.AppendText($"Logs of {DateTime.UtcNow}");
        }

        public void AppendLog(string TextToAppend, Color TextColor)
        {
            ApplicationLogs.SelectionStart = ApplicationLogs.TextLength;
            ApplicationLogs.SelectionLength = 0;
            ApplicationLogs.SelectionColor = TextColor;
            ApplicationLogs.AppendText(TextToAppend);
            ApplicationLogs.SelectionColor = ApplicationLogs.ForeColor;
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; Hide();
            if (AppForms.WorldManager.DesktopLocation.X <= 0 | AppForms.WorldManager.DesktopLocation.Y <= 0) { } { AppForms.MainMenu.DesktopLocation = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (AppForms.MainMenu.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (AppForms.MainMenu.Size.Height / 2)); }
        }

        private void CloseLogsWindowsBtn_Click(object sender, EventArgs e) { Hide(); }

        private void ClearLogsBtn_Click(object sender, EventArgs e) { ApplicationLogs.Clear(); }

        private void SaveLogsBtn_Click(object sender, EventArgs e) { SaveLogFileDialog.ShowDialog(); }
    }
}
