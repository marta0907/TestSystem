using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestConstructorApp
{

    public partial class addNewQuestionForm : Form
    {
        private Question question;
        private testConstructorForm form;
        public addNewQuestionForm()
        {
            InitializeComponent();
            question = new Question();
        }
        public addNewQuestionForm(testConstructorForm form1)
        {
            InitializeComponent();
            form = form1;
            question = new Question();
            question.Answers = new List<Answer>();
        }
        public addNewQuestionForm(testConstructorForm form1, Question question1)
        {
            InitializeComponent();
            question = question1;
            form = form1;
            InitFrom(question);
        }
        public void addNewAnswer(Answer answer)
        {
            question.Answers.Add(answer);
            this.addAnswerToDAtaGridView(answer);
        }
        private void addAnswerToDAtaGridView(Answer answer)
        {
            this.dataGridView1.Rows.Add(answer.AnswerText, answer.IsTrue);
        }
        private void InitFrom(Question question)
        {
            textBox1.Text = question.QuestionText;
            textBox2.Text = question.NumOfPoints.ToString();
            if (question.Answers is null) return;
            foreach(var answer in question.Answers)
            {
                addAnswerToDAtaGridView(answer);
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            var answerForm = new AddNewAnswerForm(this);
            answerForm.ShowDialog();
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var AnswerText = row.Cells[0].Value.ToString();
                var IsTrue = Boolean.Parse(row.Cells[1].Value.ToString());

                var answer = this.question.Answers.FirstOrDefault(answer => answer.AnswerText == AnswerText && answer.IsTrue == IsTrue);

                var answerForm = new AddNewAnswerForm(answer, this);
                answerForm.ShowDialog();
                
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                this.dataGridView1.Rows.Remove(row);
                var AnswerText = row.Cells[0].Value.ToString();
                var IsTrue = Boolean.Parse(row.Cells[1].Value.ToString());

                var answer = this.question.Answers.FirstOrDefault(answer => answer.AnswerText == AnswerText && answer.IsTrue == IsTrue);
                this.question.Answers.Remove(answer);
            }
        }
        public void DeleteAnswer(Answer answer)
        {
            var index = this.question.Answers.IndexOf(answer);
            if (index != -1)
            {
                this.dataGridView1.Rows.RemoveAt(index);
                this.question.Answers.RemoveAt(index);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                form.DeleteQuestion(question);
                question.QuestionText = textBox1.Text;
                question.NumOfPoints = Int32.Parse(textBox2.Text);
                form.AddQuestion(question);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
