using BLL.Services;
using ClientServer;
using System;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class FormAuthorization : Form
    {
        Server server;
        UserService userService;
        public FormAuthorization(Server server1)
        {
            InitializeComponent();
            server = server1;
            userService = new UserService();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var admin = userService.AuthenticateAdmin(textBoxLogin.Text ?? "", textBoxPassword.Text ?? "");
            if (admin != null)
            {
                var form = new FormTestServer(server, this, admin);
                form.Show();
                textBoxLogin.Text = "";
                this.Hide();
            } else
            {
                MessageBox.Show("Authentication failed");
            }
            textBoxPassword.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAuthorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.CloseAllSockets();
        }
    }
}
