using DAL.Entities;
using System;
using System.Windows.Forms;

namespace TestConstructorApp
{
    public partial class AddNewAnswerForm : Form
    {
        private Answer answer;
        private addNewQuestionForm form;
        public AddNewAnswerForm(addNewQuestionForm form)
        {
            InitializeComponent();
            this.form = form;
            answer = new Answer();
        }
        public AddNewAnswerForm(Answer answer, addNewQuestionForm form)
        {
            InitializeComponent();
            this.answer = answer;
            this.answerTextBox.Text = answer.AnswerText;
            this.isTrueCheckBox.Checked = answer.IsTrue;
            this.form = form;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.form.DeleteAnswer(this.answer);
            this.answer.AnswerText = this.answerTextBox.Text ?? "";
            this.answer.IsTrue = this.isTrueCheckBox.Checked;
            this.form.addNewAnswer(this.answer);
            this.Close();
        }
    }
}
