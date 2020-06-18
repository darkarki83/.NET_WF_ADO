using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public partial class FormEdit : Form, IFormEdit
    {
        public TextBox TextBoxLogin { get => textBoxLogin; set => textBoxLogin = value; }
        public TextBox TextBoxPassword { get => textBoxPassword; set => textBoxPassword = value; }
        public TextBox TextBoxAdress { get => textBoxAdress; set => textBoxAdress = value; }
        public TextBox TextBoxPhone { get => textBoxPhone; set => textBoxPhone = value; }
        public CheckBox CheckBoxAdmin { get => checkBoxAdmin; set => checkBoxAdmin = value; }
        public FormEdit()
        {
            InitializeComponent();
            buttonSave.Enabled = false;
        }
        public event EventHandler FormEditLoad;
        public event EventHandler SaveClick;


        private void FormEdit_Load(object sender, EventArgs e)
        {
            FormEditLoad(sender, e);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveClick(sender, e);
            Close();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if(TextBoxPassword.TextLength > 6)
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;

        }
    }
}
