using System;
using System.Windows.Forms;

namespace TicTacToeHarbi
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the login interface form first
            Application.Run(new LoginInterface());
        }
    }
}
