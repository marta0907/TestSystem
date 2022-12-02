using ClientServer;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class AuthorizationC : Form
    {
        private readonly Client client;
        public AuthorizationC(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            client.ConnectToServer();
            if (client.Connected)
            {
                var user =Task.Run(() => client.Authenticate(textBox_login.Text, textBox_password.Text)).Result;
                if (user != null)
                {
                    textBox_login.Text = String.Empty;
                    var testForm = new TestC(user, client,this);
                    testForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login or password is incorrect, please try again");
                }

                textBox_password.Text = String.Empty;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
