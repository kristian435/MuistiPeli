using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _16_Muistipeli__Kiitettävä_.Model;
using _16_Muistipeli__Kiitettävä_.Presenter;
using _16_Muistipeli__Kiitettävä_.View;

namespace _16_Muistipeli__Kiitettävä_
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
            IStartView startview = new StartForm();
            new StartPresenter(startview);
        }
    }
}
