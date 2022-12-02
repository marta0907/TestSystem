using System;
using System.Windows.Forms;
using BLL.Services;
using DAL.Entities;

namespace ServerApp
{
    public partial class FormAddNewGroup : Form
    {
        GroupService GroupService;
        public FormAddNewGroup(GroupService GroupService)
        {
            InitializeComponent();
            this.GroupService = GroupService;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Group group = new Group()
            {
                Name = textBoxNameGroup.Text
            };
            GroupService.Add(group);
            
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
