using System;
using System.Windows.Forms;

namespace day11_ADO.Net
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProductManagerApp.Form1());
        }
    }
}
