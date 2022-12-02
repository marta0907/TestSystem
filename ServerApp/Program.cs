using ClientServer;
using System;
using System.Windows.Forms;

namespace ServerApp
{
    static class Program
    {
        private static Server server;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            server = new Server();
            server.SetupServer();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAuthorization(server));
            
        }
    }
}
