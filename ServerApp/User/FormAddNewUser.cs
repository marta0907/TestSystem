using BLL.Services;
using DAL.Entities;
using System;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class FormAddNewUser : Form
    {
        private UserService userService;
        private User user;
        public FormAddNewUser(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                First_Name = this.textBoxFirstName.Text ?? "",
                Last_Name = this.textBoxLastName.Text ?? "",
                Login = this.textBoxLogin.Text ?? "",
                Password = this.textBoxPassword.Text ?? "",
                IsAdmin = this.checkBoxIsAdmin.Checked
            };
            this.userService.Add(user);
            MessageBox.Show("User is saved!");
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
