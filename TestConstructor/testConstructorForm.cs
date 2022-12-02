using BLL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TestConstructorApp
{
    public partial class testConstructorForm : Form
    {
        public Test test;
        private TestService testService;
        public testConstructorForm()
        {
            InitializeComponent();
            test = new Test();
            test.Questions = new List<Question>();
            testService = new TestService();
            EnableControls(this, false);
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            var questionForm = new addNewQuestionForm(this);
            questionForm.ShowDialog();
        }

        private void editQuestionButton_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var question = this.test.Questions[row.Index];
                var questionForm = new addNewQuestionForm(this,question);
                questionForm.ShowDialog();
            }
        }

        private void deleteQuestionButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                test.Questions.RemoveAt(row.Index);
                dataGridView1.Rows.Remove(row);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableControls(this, true);
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()!= DialogResult.Cancel)
            {
                var filePath = openFileDialog1.SafeFileName;
                test = await testService.LoadTestFromFileSystem(filePath);
                if (test is null) return;
                InitForm(test);
                EnableControls(this, true);
            }
        }

        private void InitForm(Test test)
        {
            authorTextBox.Text = test.Author ?? "";
            descriprionRichTextBox.Text = test.Description ?? "";
            infoRichTextBox.Text = test.InfoForTaker ?? "";
            titleTextBox.Text = test.Title ?? "";
            countTextBox.Text = test.Questions?.Count.ToString();
            maxPointsTextBox.Text = testService.MaxPoints(test).ToString();
            percentTextBox.Text = test.MinPassPercentage.ToString();
            foreach(var question in test.Questions)
                dataGridView1.Rows.Add(question.QuestionText,question.NumOfPoints);
        }
        private bool SaveTest(Test test)
        {
            try
            {
                test.Author = authorTextBox.Text ?? "";
                test.Description = descriprionRichTextBox.Text ?? "";
                test.InfoForTaker = infoRichTextBox.Text ?? "";
                test.MinPassPercentage = float.Parse(percentTextBox.Text);
                test.Title = titleTextBox.Text ?? "";
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

        private void ClearForm()
        {
            authorTextBox.Text = "";
            descriprionRichTextBox.Text ="";
            infoRichTextBox.Text = "";
            countTextBox.Text = "";
            maxPointsTextBox.Text = "";
            percentTextBox.Text ="";
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }
        public void DeleteQuestion(Question question)
        {
            var index = this.test.Questions.IndexOf(question);
            if (index != -1)
            {
                this.dataGridView1.Rows.RemoveAt(index);
                this.test.Questions.RemoveAt(index);
                countTextBox.Text = test.Questions.Count.ToString();
                maxPointsTextBox.Text = testService.MaxPoints(test).ToString();
            }
            dataGridView2.Rows.Clear();
        }

        public void AddQuestion(Question question)
        {
            dataGridView1.Rows.Add(question.QuestionText, question.NumOfPoints);
            test.Questions.Add(question);
            countTextBox.Text = test.Questions.Count.ToString();
            maxPointsTextBox.Text = testService.MaxPoints(test).ToString();
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveTest(test))
            {
                var saved = await testService.SaveTestToFileSystem(test);
                var message = saved ? "Saved" : "Something went wrong";
                MessageBox.Show(message);
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableControls(this, false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void EnableControls(Control control, bool Enable)
        {
            control.Controls.Cast<Control>()
             .Where(x=>x.GetType()!=typeof(MenuStrip))
             .ToList()
             .ForEach(x => x.Enabled = Enable);
            control.Controls.Cast<Control>()
             .ToList()
             .ForEach(x => EnableControls(x,Enable));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var answers = test.Questions?[e.RowIndex].Answers;
            if (answers is null) return;
            dataGridView2.Rows.Clear();
            foreach (var answer in answers)
            {
                dataGridView2.Rows.Add(answer.AnswerText, answer.IsTrue);
            }
        }
    }
}
