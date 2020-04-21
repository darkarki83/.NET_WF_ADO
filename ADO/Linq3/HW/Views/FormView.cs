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
    public partial class FormView : Form, IFormView
    {
        public FormView()
        {
            InitializeComponent();
        }
        public event EventHandler LoadForm;
        public event EventHandler SortByFamily;
        public event EventHandler SortByPhone;
        public event EventHandler SortByName;
        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;

        public ListView ListViewForm { get => listViewForm; set => listViewForm = value; }

        private void FormView_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void buttonSortByFamily_Click(object sender, EventArgs e)
        {
            SortByFamily(sender, e);
            Invalidate();
        }

        private void buttonSortByPhone_Click(object sender, EventArgs e)
        {
            SortByPhone(sender, e);
        }

        private void buttonSortByName_Click(object sender, EventArgs e)
        {
            SortByName(sender, e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add(sender, e);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (ListViewForm.SelectedIndices.Count > 0)
                Edit(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ListViewForm.SelectedIndices.Count > 0)
                Delete(sender, e);
        }
    }
}
