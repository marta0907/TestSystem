using System;
using System.Windows.Forms;
using BLL.Services;
using DAL.Entities;

namespace ServerApp
{
    public partial class FormEditGroup : Form
    {
        GroupService GroupService;
        Group Group;
        public FormEditGroup(GroupService groupService, Group group)
        {
            InitializeComponent();
            this.Group = group;
            this.GroupService = groupService;
            this.textBoxNameGroup.Text = Group.Name;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Group.Name = textBoxNameGroup.Text;
            GroupService.UpdateGroup(Group);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
