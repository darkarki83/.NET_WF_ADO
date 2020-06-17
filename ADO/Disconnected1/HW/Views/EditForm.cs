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

    public partial class EditForm : Form, IEditView
    {
        public string Login {get => textLogin.Text; set => textLogin.Text = value; }
        public string Adress {get => textAdress.Text; set => textAdress.Text = value; }
        public string Phone {get => textPhone.Text; set => textPhone.Text = value; }
        public bool IsAdmin {get => checkIsAdmin.Checked; set => checkIsAdmin.Checked = value; }

        public event EventHandler<MyEvent> SaveEditForm;
        public EditForm(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            Login = selectedRow.Cells[0].Value.ToString();
            Adress = selectedRow.Cells[1].Value.ToString();
            Phone = selectedRow.Cells[2].Value.ToString();

            if(selectedRow.Cells[2].Value.ToString() == "1")
                IsAdmin = true;
            else
                IsAdmin = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сохронить записи?", "Сохронение записей", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var myEvent = new MyEvent(Login, Adress, Phone, IsAdmin);
                SaveEditForm(sender, myEvent);
            }
            else
                this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
