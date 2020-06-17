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
    public partial class UserForm : Form, IUserView
    {
        public event EventHandler FormLoad;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler AddEvent;
        public UserForm()
        {
            InitializeComponent();
        }

        public DataGridView DataGrid { get => dataGridView; set => dataGridView = value; }

        private void UserForm_Load(object sender, EventArgs e)
        {
            FormLoad(sender, e);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            EditEvent(sender, e);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent(sender, e);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddEvent(sender, e);
        }
    }
}
