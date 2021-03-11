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
    public partial class loginForm : Form, ILoginFormView
    {
        public TextBox Login { get => textBoxLogin; set => textBoxLogin = value; }
        public TextBox Password { get => textBoxPass; set => textBoxPass = value; }

        public event EventHandler LoginClick;

        public loginForm()
        {
            InitializeComponent();
            buttonLogin.Enabled = false;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginClick(sender, EventArgs.Empty);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Login.Text.Length > 3 && Password.Text.Length > 3)
                buttonLogin.Enabled = true;
        }

        public void LetUserLogin()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void DontLetUserLogin()
        {
            MessageBox.Show("Wrong user name or/and password.", "Login",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
