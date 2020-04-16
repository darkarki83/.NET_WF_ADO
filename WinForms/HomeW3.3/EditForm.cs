using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW3._3
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            textEditBox.Text = ((MainForm)Owner).GetTextBoxText();
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            ((MainForm)Owner).SetTextBoxText(textEditBox.Text);
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
