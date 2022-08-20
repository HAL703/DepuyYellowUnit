using System;
using System.Windows.Forms;

namespace MicroPCGUI
{
    static class Start
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MicroPCUI());
        }
    }
}
