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
    public partial class FormViewUser : Form, IFormView
    {
        public event EventHandler LoadForm;
        public event EventHandler EditList;
        public event EventHandler DeleteFromList;
        public event EventHandler AddList;

        public FormViewUser()
        {
            InitializeComponent();
        }
        public ListView ListView { get => listView; set => listView = value; }

        private void FormViewUser_Load(object sender, EventArgs e)
        {
            if (LoadForm != null)
                LoadForm(sender, e);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
                if (AddList != null)
                    AddList(sender, e);
        }
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (ListView.SelectedIndices.Count > 0)
            {
                if (EditList != null)
                    EditList(sender, e);
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ListView.SelectedIndices.Count > 0)
            {
                if (DeleteFromList != null)
                    DeleteFromList(sender, e);
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
