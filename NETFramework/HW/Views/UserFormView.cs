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
    public partial class UserFormView : Form, IUserFormView
    {
        public event EventHandler Order;
        public TextBox  TName {get => textBoxName; set => textBoxName = value;}
        public TextBox  TDdress {get => textBoxAddress; set => textBoxAddress = value;}
 
        public ListView ListViewOrder { get => listViewOrder; set => listViewOrder = value; }
        
        
        public UserFormView()
        {
            InitializeComponent();
            buttonConfirm.Enabled = false;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Order(sender, EventArgs.Empty);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if(textBoxName.TextLength > 3 && textBoxAddress.TextLength > 3)
                buttonConfirm.Enabled = true;
            else
                buttonConfirm.Enabled = false;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
