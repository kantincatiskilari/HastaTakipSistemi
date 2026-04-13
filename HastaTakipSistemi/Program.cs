using System;
using System.Windows.Forms;
using HastaTakipSistemi.Forms;

namespace HastaTakipSistemi
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
