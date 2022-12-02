using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class Report : Form
    {
        string text;
        public Report(string text)
        {
            InitializeComponent();
            this.text = text;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = this.text;
            this.richTextBox1.ReadOnly = true;
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }
    }
}
