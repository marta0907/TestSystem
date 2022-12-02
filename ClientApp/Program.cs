using ClientServer;
using System;
using System.Windows.Forms;

namespace ClientApp
{
    static class Program
    {
        private static Client client;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            client = new Client();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthorizationC(client));
        }
    }
}
