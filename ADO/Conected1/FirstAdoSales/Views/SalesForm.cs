using FirstAdo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstAdo.Views
{
    public partial class SalesForm : Form, ISalesView
    {
        private List<long> bookIDs;
        private List<long> authorFKs;

        private ListView listview;

        public event EventHandler LoadForm;
        public event EventHandler CloseForm;
        public SalesForm()
        {
            InitializeComponent();

            bookIDs = new List<long>();
            authorFKs = new List<long>();
            listview = new ListView();
        }

        public List<long> BookIDs 
        {
            get => bookIDs; 
            set => bookIDs = value;
        }

        public List<long> AuthorFKs
        {
            get => authorFKs; 
            set => authorFKs = value;
        }

        public ListView Listview
        {
            get => listview;
            set => listview = value;
        }

        private void LibraryForm_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            for (int i = 0; i < Listview.Items.Count; i++)
            {
                ListViewItem item = listViewForm.Items.Add(new ListViewItem());
                item.Text = Listview.Items[i].Text;
                item.SubItems.Add(Listview.Items[i].SubItems[1]);
                item.SubItems.Add(Listview.Items[i].SubItems[2]);
                item.SubItems.Add(Listview.Items[i].SubItems[3]);
            }
            Invalidate();
        }

        private void LibraryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm(sender, e);
        }


    }
}
