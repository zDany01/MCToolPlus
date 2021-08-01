using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCToolPlus
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
    namespace Forms
    {
        public struct AppForms
        {
            public static Form WorldManager = new WorldManager();
            public static Form MainMenu;
            public static Form LogForm = new LogForm();
        }
    }
}
