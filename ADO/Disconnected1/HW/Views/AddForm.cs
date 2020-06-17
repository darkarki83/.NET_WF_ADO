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
    public partial class AddForm : Form, IAddView
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public string Login { get => textLogin.Text; set => textLogin.Text = value; }
        public string Password { get => textPassword.Text; set => textPassword.Text = value; }
        public string Adress { get => textAdress.Text; set => textAdress.Text = value; }
        public string Phone { get => textPhone.Text; set => textPhone.Text = value; }
        public bool IsAdmin { get => checkIsAdmin.Checked; set => checkIsAdmin.Checked = value; }

        public event EventHandler<MyEventAdd> SaveAddForm;
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сохронить записи?", "Сохронение записей", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var myAddEvent = new MyEventAdd(Login, Password, Adress, Phone, IsAdmin);
                SaveAddForm(sender, myAddEvent);
            }
            else
                this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
