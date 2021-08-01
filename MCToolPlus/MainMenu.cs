using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using MCToolPlus.Forms;

namespace MCToolPlus
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            WorldManagerBtn.Click += WorldManagerBtn_Click;
            AppForms.MainMenu = this;
#if DEBUG
            Label labelDebug = new Label()
            {
                Text = "DEBUG Ver",
                ForeColor = Color.Red,
                Font = new Font(this.Font,FontStyle.Bold),
                Location = new Point(1, 5)
            };
            this.Controls.Add(labelDebug);
#endif
        }

        private void WorldManagerBtn_Click(object sender, EventArgs e) {SharedCode.OpenForm(ref AppForms.WorldManager,"WorldManager");} //ref permette di passare la variabile alla routine in modo che essa possa modificare il valore, anche nella routine deve essere specificato che i valore passato può essere cambiato

    }
}
