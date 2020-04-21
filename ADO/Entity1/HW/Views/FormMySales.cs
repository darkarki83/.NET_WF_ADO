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
    public partial class FormMySales : Form, IFormView
    {
        public FormMySales()
        {
            InitializeComponent();
            BoxTable.SelectedIndex = 0;
        }
        public event EventHandler LoadForm;
        public event EventHandler IndexChanged;

        public ComboBox BoxTable { get => comboBox; set => comboBox = value; }
        public ListView ListTable { get => listTable; set => listTable = value; }
        private void FormMySales_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IndexChanged(sender, e);
            }
            catch(Exception)
            {

            }
        }
    }
}
