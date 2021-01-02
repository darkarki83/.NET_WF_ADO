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
    public partial class MainForm : Form, IFormView
    {
        public ListView ListViewPart { get => listViewParts; set => listViewParts = value; }
        public ListBox ListBoxx { get => listBox1; set => listBox1 = value; }

        public event EventHandler LoadList;

        public MainForm()
        {
            InitializeComponent();
            //Load(new object(), EventArgs.Empty);
        }
       
        public void LoadListMetod(object sender, EventArgs e)
        {
            LoadList(sender, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListMetod(sender, EventArgs.Empty);
        }
    }
}
