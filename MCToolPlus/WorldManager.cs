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
    public partial class WorldManager : Form
    {
        #region "Global Variables"
        #endregion
        #region "Callable Function"
        #endregion
        public WorldManager()
        {
            InitializeComponent();
            #region "Event Handler"
            ShowLogsBtn.Click += ShowLogsBtn_Click;
            this.Load += WorldManager_Load;
            #endregion
        }

        private void WorldManager_Load(object sender, EventArgs e)
        {
            //cambiare da form a classe per ogni tipo(Form MainMenu = new MainMenu() => MainMenu MainMenu = new MainMenu() cosi da utilizzare i void pubblici, trovare un modo per modificare la funzione per mostrare le sub)
        }

        private void ShowLogsBtn_Click(object sender, EventArgs e)
        {
          SharedCode.OpenForm(ref AppForms.LogForm, "LogForm");
        }

        public void ReCenter() { CenterToScreen(); MessageBox.Show(text: "Why?",caption:"",buttons:MessageBoxButtons.OK,icon:MessageBoxIcon.Question); }
    }
}
