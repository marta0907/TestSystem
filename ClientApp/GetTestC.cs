using ClientServer;
using DAL.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class GetTestC : Form
    {
        Client Client;
        User User;
        Test Test;
        Question currentQuestion;
        TestC Form;
        public GetTestC(Client client, User user,Test test, TestC form )
        {
            Client = client;
            User = user;
            Test = test;
            Form = form;
            InitializeComponent();
        }

        private void button_finishT_Click(object sender, EventArgs e)
        {
            var result = Client.SaveTestingResult(Test, User);
            MessageBox.Show($"points gained: {result.PointsGained}, passed: {result.IsPassed}");
            Form.AddResult(result);
            this.Close();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewAnswers.Rows)
            {
                row.Cells[1].Value = false;
            }
        }

        private void InitForm()
        {
            int maxPoints = 0;
            Test.Questions.ToList().ForEach(x => maxPoints += x.NumOfPoints);
            textBox_author.Text = Test.Author ?? "";
            textBox_title.Text = Test.Title ?? "";
            textBox_countOfQ.Text = Test.Questions.Count().ToString();
            textBox_maxP.Text = maxPoints.ToString();
            textBox_minPasP.Text = Test.MinPassPercentage.ToString();
            richTextBox_descr.Text = Test.Description ?? "";
            richTextBox_infoT.Text = Test.InfoForTaker ?? "";

            if (dataGridView_textQ.Rows.Count!=0)
                    dataGridView_textQ.Rows.Clear();

            if (Test.Questions.Count == 0) return;



            foreach(var question in Test.Questions)
            {
                foreach(var answer in question.Answers)
                {
                    answer.IsTrue = false;
                }
                dataGridView_textQ.Rows.Add(question.QuestionText, question.NumOfPoints, question.Answers.Count);
            }

        }

        private void GetTestC_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void dataGridView_textQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var questionIndex = e.RowIndex;
            currentQuestion = Test.Questions[questionIndex];
            dataGridViewAnswers.Rows.Clear();
            foreach (var answer in currentQuestion.Answers)
            {
                dataGridViewAnswers.Rows.Add(answer.AnswerText, answer.IsTrue);
            }
        }

        private void dataGridViewAnswers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewAnswers.IsCurrentCellDirty)
            {
                dataGridViewAnswers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewAnswers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAnswers.Columns[e.ColumnIndex].Name == "IsTrue")
            {
                DataGridViewCheckBoxCell checkCell =
                    (DataGridViewCheckBoxCell)dataGridViewAnswers.
                    Rows[e.RowIndex].Cells["IsTrue"];
                currentQuestion.Answers[e.RowIndex].IsTrue = (Boolean)checkCell.Value;

                dataGridViewAnswers.Invalidate();
            }
        }
    }
}
