using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCToolPlus.Forms;
using System.IO;

namespace MCToolPlus
{
    static class SharedCode
    {

        public static void OpenForm(ref Form form,string ClassForm) //ref specifica che il void può cambiare il valore originale della variabile
        {

            if (form.IsDisposed)
            {
                switch (ClassForm)
                {
                    case "MainMenu":
                        form = new MainMenu();
                        break; //esce dallo switch
                    case "WorldManager":
                        form = new WorldManager();
                        break;
                    case "LogForm":
                        form = new LogForm();
                        break;
                    default:
                        throw new System.TypeLoadException();
                }
            }
            form.Show();
        }

        public static void HandleError(Exception ex)
        {
            if (ex.GetType() == typeof(AccessViolationException)) {MessageBox.Show("Unable to get access to the specified directory.", "Access Error",MessageBoxButtons.OK,MessageBoxIcon.Error);}
            else if (ex.GetType() == typeof(UnauthorizedAccessException)) { MessageBox.Show("Unable to get write access to specified directory.", "Write Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (ex.GetType() == typeof(FileNotFoundException)) { MessageBox.Show("Unable to find the specified file.", "File Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (ex.GetType() == typeof(DirectoryNotFoundException)) { MessageBox.Show("Unable to find the specified directory.", "Directory Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (ex.GetType() == typeof(IOException)) { MessageBox.Show("Unknown Error", "Application", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
