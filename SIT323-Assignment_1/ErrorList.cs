using System;
using System.Windows.Forms;

namespace SIT323_Assignment
{
    public partial class ErrorList : Form
    {
        public ErrorList()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void TextBoxForm2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
