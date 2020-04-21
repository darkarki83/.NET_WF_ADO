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
    public partial class EditForm : Form, IEditForm
    {
        public EditForm()
        {
            InitializeComponent();
        }
        public event EventHandler LoadForm;
        public event EventHandler Save;
        public TextBox FirstName { get => textBoxFirstName; set => textBoxFirstName = value; }
        public TextBox LastName { get => textBoxLastName; set => textBoxLastName = value; }
        public TextBox Phone { get => textBoxPhone; set => textBoxPhone = value; }
        public TextBox Adress { get => textBoxAdress; set => textBoxAdress = value; }
        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сохронить записи?", "Сохронение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Save(sender, e);
                Close();
            }
        }
    }
}
