using ClientServer;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class TestC : Form
    {
        User user;
        Client client;
        List<Test> tests;
        List<Result> results;
        AuthorizationC form;
        public TestC(User user, Client client, AuthorizationC form)
        {
            this.user = user;
            this.client = client;
            tests = new List<Test>();
            results = new List<Result>();
            InitializeComponent();
            this.form = form;
        }

        private void button_getT_Click(object sender, EventArgs e)
        {
            if(dataGridView_newT.SelectedRows.Count==0)
            {
                MessageBox.Show("Please, choose a test");
                return;
            };
            var testIndex = 0;
            Int32.TryParse(dataGridView_newT.SelectedRows[0].Cells[0].Value.ToString(),out testIndex);
            Test test = tests.FirstOrDefault(test => test.Id == testIndex);
            if (test == null)
            {
                MessageBox.Show("Opps, something went wrong, please try again.");
                return;
            }
            GetTestC form3 = new GetTestC(client, user, test,this);
            form3.ShowDialog();
        }

        private void TestC_Load(object sender, EventArgs e)
        {
             tests = client.GetAssignedTests(user);
             InitForm();
        }

        private void InitForm()
        {
            dataGridView_resT.Rows.Clear();
            dataGridView_newT.Rows.Clear();
            if (tests.Count != 0)
            {
                foreach (var test in tests)
                {
                    int maxPoints = 0;
                    test.Questions.ToList().ForEach(x => maxPoints += x.NumOfPoints);
                    dataGridView_newT.Rows.Add(test.Id,test.Title ?? "", test.Description ?? "", test.MinPassPercentage, maxPoints);
                }
            }  

            if(results.Count != 0)
            {
                foreach (var result in results)
                {
                    dataGridView_resT.Rows.Add(result.UserTestId,result.PointsGained,result.IsPassed);
                }
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            InitForm();
        }

        public void AddResult(Result result)
        {
            results.Add(result);
        }

        private void TestC_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
            client.Exit();
        }
    }
}
