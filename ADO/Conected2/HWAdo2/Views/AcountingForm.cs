using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWAdo2.Views
{
    public partial class AcountingForm : Form, IAcountingView
    {

        public AcountingForm()
        {
           // OutListBox = new ListBox();

            InitializeComponent();
        }

        public event EventHandler LoadForm;
        public event EventHandler NewWorker;

        public ListBox OutListBox { get => listBox; set => listBox = value; }
        public ComboBox OutComboBox { get => comboBox; set => comboBox = value; }
        public PictureBox OutPictureBox { get => pictureBox; set => pictureBox = value; }

        private void AcountingForm_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewWorker(sender, e);
        }
    }
}
