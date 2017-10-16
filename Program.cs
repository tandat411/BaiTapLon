using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLSV
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
            Welcome welcome = new Welcome();
            Application.Run(welcome);
            if (welcome.IsDisposed)
            {
                Application.Run(new DangNhap());
            }
        }
    }
}
