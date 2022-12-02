using BLL.Services;
using ClientServer;
using DAL.Entities;
using ServerApp.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class FormTestServer : Form
    {
        private Server server;
        private FormAuthorization form;
        private User admin;
        private UserService userService;
        private User user;
        private Group group;
        private GroupService groupService;
        private List<Result> results;
        private List<Group> groups;
        private List<User> users;
        private Selection selection = Selection.None;
        private ResultService resultService;
        private TestService testService;

        public FormTestServer( Server server, FormAuthorization form, User admin )
        {
            this.server = server;
            this.form = form;
            this.admin = admin;
            this.groupService = new GroupService();
            this.userService = new UserService();
            results = new List<Result>();
            groups = new List<Group>();
            users = new List<User>();
            group = new Group();
            resultService = new ResultService();
            testService = new TestService();
            InitializeComponent();
        }

        private void buttonAsignNewTest_Click(object sender, EventArgs e)
        {
            FormAsignNewTest newForm = new FormAsignNewTest();
            newForm.Show();

        }

        private void buttonAddNewUser_Click(object sender, EventArgs e)
        {
            FormAddNewUser newForm = new FormAddNewUser(this.userService);
            newForm.ShowDialog();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            var userIndex = Int32.Parse(this.dataGridViewUsers.SelectedRows?[0].Cells?[0].Value.ToString());
            var user = this.userService.GetById(userIndex);
            FormEditUser newForm = new FormEditUser(this.userService, user);
            newForm.ShowDialog();
        }

        private void buttonAddNewGroup_Click(object sender, EventArgs e)
        {
            FormAddNewGroup newForm = new FormAddNewGroup(this.groupService);
            newForm.ShowDialog();
        }

        private void buttonUpdateGroupUser_Click(object sender, EventArgs e)
        {
            FormUpdateGroupUser newForm = new FormUpdateGroupUser(this.group, this.userService, this.groupService);
            newForm.Show();
        }

        private void buttonEditGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = Int32.Parse(this.dataGridViewGroups.SelectedRows?[0].Cells?[0].Value.ToString());
            var group = this.groupService.GetById(groupIndex);
            FormEditGroup newForm = new FormEditGroup(this.groupService, group);
            newForm.Show();

        }

        private void buttonUpdateUserGroup_Click(object sender, EventArgs e)
        {
            FormUpdateUserGroup newForm = new FormUpdateUserGroup(this.user, this.userService, this.groupService);
            newForm.ShowDialog();
        }

        private void FormTestServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "Server":
                {
                    listViewClientsConected.Items.Clear();
                    server._clientsNames.Values.ToList().ForEach(x => listViewClientsConected.Items.Add(x));
                    return;
                }
                case "Users":
                {
                    dataGridViewUsers.Rows.Clear();
                    users = userService.GetAll();
                    foreach (var user in users)
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.First_Name ?? "", user.Last_Name ?? "", user.IsAdmin);
                    }
                    return;
                }
                case "Results":
                {
                    results = resultService.GetAllResults().ToList();
                    InitResultsDataGridView();
                    return;
                }
                case "Groups":
                {
                    dataGridViewGroups.Rows.Clear(); 
                    groups = groupService.GetAll();
                    if (groups is null) return;
                    foreach (var group in groups)
                    {
                        dataGridViewGroups.Rows.Add(group.Id, group.Name ?? "");
                    }
                    return;
                }
                default:
                    return;
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewUsers.SelectedRows)
            {
                var userIndex = Int32.Parse(row.Cells?[0].Value.ToString());
                this.userService.DeleteUser(userIndex);
            }
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewUserGroup.Rows.Clear();
            var userIndex = Int32.Parse(this.dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.user = this.userService.GetById(userIndex);
            var groups = user.GroupUsers?.Select(x => x.Group).Distinct().ToList();
            foreach(var group in groups)
            {
                this.dataGridViewUserGroup.Rows.Add(group.Id, group.Name);
            }
        }

        private void radioButtonSelectUser_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                selection = Selection.User;
                users = userService.GetAll().ToList();
                users.ForEach(x => comboBoxSelect.Items.Add(x.First_Name+" "+x.Last_Name));
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                selection = Selection.Group;
                groups = groupService.GetAll().ToList();
                groups.ForEach(x => comboBoxSelect.Items.Add(x.Name));
            }
        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (selection == Selection.None) return;
            else if(selection == Selection.Group)
            {
                var groupindex = comboBox.SelectedIndex;
                var group = groups[groupindex];
                results = resultService.GetGroupResults(group)?.ToList();
            }
            else if (selection == Selection.User)
            {
                var userindex = comboBox.SelectedIndex;
                var user = users[userindex];
                results = resultService.GetUserResults(user)?.ToList();
            }

            InitResultsDataGridView();
        }

        private void InitResultsDataGridView()
        {
            dataGridViewResultTest.Rows.Clear();
            foreach (var result in results)
            {
                var us = userService.GetById(result.UserTest.UserId);
                var tst = testService.GetTestByIdFromDatabase(result.UserTest.TestId);

                dataGridViewResultTest.Rows.Add(
                    result.Id,
                    us?.First_Name + " " + us?.Last_Name,
                    tst?.Title,
                    result.Date,
                    result.PointsGained
                    );
            }
        }

        private void buttonShowReport_Click(object sender, EventArgs e)
        {
            if (dataGridViewResultTest.SelectedRows.Count == 0) return;
            
            StringBuilder message = new StringBuilder();
            foreach (DataGridViewRow row in dataGridViewResultTest.SelectedRows)
            {
                message.Clear();
                var res =results[row.Index];

                if (res == null) continue;

                var us = userService.GetById(res.UserTest.UserId);
                var tst = testService.GetTestByIdFromDatabase(res.UserTest.TestId);
                var countCorrectQuestions = res.UserAnswers.Where(x => x.ActualAnswer == x.ExpectedAnswer);
                var countIncorrectQuestions = res.UserAnswers.Where(x => x.ActualAnswer != x.ExpectedAnswer);
                message.AppendLine(res.Id.ToString());
                message.AppendLine("----------------------------------------------------");
                message.AppendLine(res.Date.ToString());
                message.AppendLine("----------------------------------------------------");
                message.AppendLine($"User: {us.First_Name} {us.Last_Name}");
                message.AppendLine("----------------------------------------------------");
                message.AppendLine($"Test Author: {tst.Author}");
                message.AppendLine($"Test Title: {tst.Title}");
                message.AppendLine($"Test Description: {tst.Description}");
                message.AppendLine($"Test Info for taker: {tst.InfoForTaker}");
                message.AppendLine("----------------------------------------------------");
                message.AppendLine($"Points: {res.PointsGained}");
                message.AppendLine($"Passed: {res.IsPassed}");
                message.AppendLine($"Count of correct questions {countCorrectQuestions}");
                message.AppendLine($"Count of incorrect questions {countIncorrectQuestions}");
                for(int i = 0; i < res.UserAnswers.Count; i++)
                {
                    message.AppendLine("----------------------------------------------------");
                    message.AppendLine($"Question {i}");
                    message.AppendLine($"Users answer: {res.UserAnswers[i].ActualAnswer}");
                    message.AppendLine($"Correct answer: {res.UserAnswers[i].ExpectedAnswer}");
                    message.AppendLine("----------------------------------------------------");
                }
                Report reportForm = new Report(message.ToString());
                reportForm.ShowDialog();
            }
            
        }

        private void FormTestServer_Load(object sender, EventArgs e)
        {
            dataGridViewGroups.Rows.Clear();
            groups = groupService.GetAll();
            if (groups is null) return;
            foreach (var group in groups)
            {
                dataGridViewGroups.Rows.Add(group.Id, group.Name ?? "");
            }
        }

        private void buttonDeleteGroup_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewGroups.SelectedRows)
            {
                var groupIndex = Int32.Parse(row.Cells?[0].Value.ToString());
                this.groupService.DeleteGroup(groupIndex);
            }
        }

        private void dataGridViewGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewGroupUsers.Rows.Clear();
            var groupIndex = Int32.Parse(this.dataGridViewGroups.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.group = this.groupService.GetById(groupIndex);
            var users = group.GroupUsers?.Select(x => x.User).Distinct().ToList();
            foreach (var user in users)
            {
                this.dataGridViewGroupUsers.Rows.Add(user.Id, user.First_Name, user.Last_Name, user.IsAdmin);
            }
        }
    }


}
