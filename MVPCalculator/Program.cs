using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPCalculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 viev = new Form1();
            Models.Model model = new Models.Model();
            Presenters.Presenter presenter = new Presenters.Presenter(viev, model);
            Application.Run(viev);
        }
    }
}
