using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogForm
{
    public partial class AddAndEdit : Form
    {
        public AddAndEdit()
        {
            InitializeComponent();
        }

        // get ; set propertis
        public string MyText
        {
            get => myText.Text.Trim();
            set  => myText.Text = value.Trim();
        }

        public bool FildEnpty()
        {
            return myText.Text.Trim().Length > 0;
        }
        
        // observer TextBox myText (change text) Ok enabled = true
        private void myText_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = FildEnpty();
        }

       
    }
}
