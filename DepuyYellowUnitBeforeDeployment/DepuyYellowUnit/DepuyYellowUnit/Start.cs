using System;
using System.Windows.Forms;

namespace DepuyYellowUnit
{
    static class Start
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new General_Screen());
        }
    }
}
