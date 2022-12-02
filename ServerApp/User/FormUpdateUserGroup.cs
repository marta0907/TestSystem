using BLL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class FormUpdateUserGroup : Form
    {
        private User user;
        private UserService userService;
        private GroupService groupService;
        private List<Group> groups;
        public FormUpdateUserGroup(User user, UserService userService, GroupService groupService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.groupService = groupService;
            this.InitForm();
        }

        private void InitForm()
        {
            this.groups = this.groupService.GetAll();

            int i = 0;
            foreach(var group in this.groups)
            {
                var checked1 = user.GroupUsers.Select(x => x.GroupId).Any(x => x == group.Id);
                this.checkedListBoxUserGroups.Items.Add(group.Name);
                this.checkedListBoxUserGroups.SetItemChecked(i, checked1);
                ++i;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < checkedListBoxUserGroups.Items?.Count ; i++)
            {
                var res = checkedListBoxUserGroups.GetItemChecked(i) ?
                    userService.AddUserToGroup(user, groups[i]) :
                    userService.DeleteUserFromGroup(user, groups[i]);
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
