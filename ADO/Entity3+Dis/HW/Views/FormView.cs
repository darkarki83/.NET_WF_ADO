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
        public ComboBox ComboAuthor { get => comboAuthor; set => comboAuthor = value; }
        public ComboBox ComboPress { get => comboPress; set => comboPress = value; }
        public CheckBox CheckAuthor { get => checkAuthor; set => checkAuthor = value; }
        public CheckBox CheckPress { get => checkPress; set => checkPress = value; }
        public ListView ListBooks { get => listBooks; set => listBooks = value; }

        public event EventHandler LoadForm;
        public event EventHandler AuthorSearch;
        public event EventHandler PressSearch;
        public event EventHandler AuthorPressSearch;

        public FormView()
        {
            InitializeComponent();
        }
        private void checkAuthor_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAuthor.Checked)
                ComboAuthor.Enabled = true;
            else
                ComboAuthor.Enabled = false;
        }
        private void checkPublishing_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckPress.Checked)
                ComboPress.Enabled = true;
            else
                ComboPress.Enabled = false;
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            if (LoadForm != null)
                LoadForm(sender, e);
        }

        private void start_Click(object sender, EventArgs e)
        {
            if(CheckAuthor.Checked && CheckPress.Checked)
            {
                if (AuthorPressSearch != null)
                    AuthorPressSearch(sender, e);
            }
            else if(CheckAuthor.Checked && CheckPress.Checked == false)
            {
                if (AuthorSearch != null)
                    AuthorSearch(sender, e);
            }
            else if (CheckAuthor.Checked == false && CheckPress.Checked)
            {
                if (PressSearch != null)
                    PressSearch(sender, e);
            }

        }
    }
}
