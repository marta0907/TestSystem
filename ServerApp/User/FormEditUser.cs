using BLL.Services;
using DAL.Entities;
using System;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class FormEditUser : Form
    {
        private UserService userService;
        private User user;
        public FormEditUser(UserService userService, User user)
        {
            InitializeComponent();
            this.userService = userService;
            this.user = user;
            this.textBoxFirstName.Text = user.First_Name;
            this.textBoxLastName.Text = user.Last_Name;
            this.textBoxLogin.Text = user.Login;
            this.textBoxPassword.Text = user.Password;
            this.checkBoxIsAdmin.Checked = user.IsAdmin;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.user.First_Name = this.textBoxFirstName.Text ?? "";
            this.user.Last_Name = this.textBoxLastName.Text ?? "";
            this.user.Login = this.textBoxLogin.Text ?? "";
            this.user.Password = this.textBoxPassword.Text ?? "";
            this.user.IsAdmin = this.checkBoxIsAdmin.Checked;
            this.userService.UpdateUser(user);
            MessageBox.Show("User is updated!");
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
