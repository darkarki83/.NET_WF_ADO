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
        public event EventHandler SelectedIndexChanged;

        public ListView ListViewOrder { get => listViewOrder; set => listViewOrder = value; }
        public ComboBox ComboClient { get => comboBoxClient; set => comboBoxClient = value; }

        public TextBox  TDdress {get => textBoxAddress; set => textBoxAddress = value;}
        public TextBox Cost { get => textBoxCost; set => textBoxCost = value; }
        public TextBox Bonus { get => textBoxBonus; set => textBoxBonus = value; }
        public TextBox TotalCost { get => textBoxTotalCost; set => textBoxTotalCost = value; }
        
        public UserFormView()
        {
            InitializeComponent();
            ButtonStatus();
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonStatus();
            SelectedIndexChanged(sender, EventArgs.Empty);  // SelectedIndexChanged => to change the Bonus
        }

        private void textBoxDress_TextChanged(object sender, EventArgs e)
        {
            ButtonStatus();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Order(sender, EventArgs.Empty);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonStatus()
        {
            if (TDdress.TextLength > 3 && ComboClient.SelectedIndex != -1)
                buttonConfirm.Enabled = true;
            else
                buttonConfirm.Enabled = false;

        }

    }
}
