using System;
using System.Windows.Forms;
using BLL.Services;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ServerApp
{
    public partial class FormUpdateGroupUser : Form
    {
        private Group group;
        private UserService userService;
        private GroupService groupService;
        private List<User> users;
        public FormUpdateGroupUser(Group group, UserService userService, GroupService groupService)
        {
            InitializeComponent();
            this.group = group;
            this.userService = userService;
            this.groupService = groupService;
            this.InitForm();
        }
        private void InitForm()
        {
            this.users = this.userService.GetAll();

            int i = 0;
            foreach (var user in this.users)
            {
                var checked1 = false;
                if(group.GroupUsers != null)
                checked1 = group.GroupUsers.Select(x => x.UserId).Any(x => x == user.Id);
                this.checkedListBoxGroupUsers.Items.Add(user.First_Name);
                this.checkedListBoxGroupUsers.SetItemChecked(i, checked1);
                ++i;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxGroupUsers.Items?.Count; i++)
            {
                var res = checkedListBoxGroupUsers.GetItemChecked(i) ?
                    userService.AddUserToGroup(users[i], group) :
                    userService.DeleteUserFromGroup(users[i], group);
                MessageBox.Show(res ? "Success" : "Fail");
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
