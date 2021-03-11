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
    public partial class AdminForm : Form, IAdminFormView
    {
        // add part
        public TextBox TextBoxPartName { get => textBoxPartName; set => textBoxPartName = value; }
        public TextBox TextBoxPartCost { get => textBoxPartCost; set => textBoxPartCost = value; }
        public ComboBox ComboBoxPartMan { get => comboBoxPartMan; set => comboBoxPartMan = value; }
        public NumericUpDown NumericPartCount { get => numericPartCount; set => numericPartCount = value; }

        public ListView ListViewParts { get => listViewParts; set => listViewParts = value; }
        
        public event EventHandler AddPart;
        //// end
        
        // add manufacturer
        public TextBox TextBoxManName { get => textBoxManName; set => textBoxManName = value; }

        public event EventHandler AddMan;
        //// end

        // add client
        public TextBox TextBoxClientName { get => textBoxClientName; set => textBoxClientName = value; }
        public TextBox TextBoxClientAddress { get => textBoxClientAddress; set => textBoxClientAddress = value; }
        public NumericUpDown NumericBonus { get => numericBonus; set => numericBonus = value; }

        public event EventHandler AddCliient;
        //// end

        // add count
        public ComboBox ComboBoxPartName { get => comboBoxPartName; set => comboBoxPartName = value; }
        public NumericUpDown NumericCount { get => numericCount; set => numericCount = value; }

        public event EventHandler ChangeCount;
        //// end

        // delete part
        public event EventHandler DeletePart;
        //// end

        public event EventHandler LoadForm;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            buttonPart.Enabled = false;
            buttonMan.Enabled = false;
            buttonClient.Enabled = false;
            buttonCount.Enabled = false;
            buttonDelete.Enabled = false;
            LoadForm(sender, EventArgs.Empty);
        }

        private void buttonPart_Click(object sender, EventArgs e)
        {
            AddPart(sender, EventArgs.Empty);
        }

        private void buttonMan_Click(object sender, EventArgs e)
        {
            AddMan(sender, EventArgs.Empty);
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            AddCliient(sender, EventArgs.Empty);
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            ChangeCount(sender, EventArgs.Empty);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeletePart(sender, EventArgs.Empty);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxPartName_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxPartName.Text.Length > 3 && TextBoxPartCost.Text.Length > 0 && ComboBoxPartMan.SelectedIndex >= 0)
                buttonPart.Enabled = true;
            else
                buttonPart.Enabled = false;
        }

        private void textBoxManName_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxManName.Text.Length > 3)
                buttonMan.Enabled = true;
            else
                buttonMan.Enabled = false;
        }

        private void textBoxClientName_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxClientName.Text.Length > 3 && TextBoxClientAddress.Text.Length > 1)
                buttonClient.Enabled = true;
            else
                buttonClient.Enabled = false;
        }

        private void comboBoxPartName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPartName.SelectedIndex >= 0)
            {
                buttonCount.Enabled = true;
            }
            else
            {
                buttonCount.Enabled = false;
            }
        }

        private void listViewParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewParts.CanSelect == true)
                buttonDelete.Enabled = true;
            else
                buttonDelete.Enabled = false;
        }

        public void ClierPart()   // clier all part group
        {
            TextBoxPartName.Text = String.Empty;
            TextBoxPartCost.Text = String.Empty;
            ComboBoxPartMan.SelectedIndex = -1;
            NumericPartCount.Value = 34;
        }

        public void ClierMan()   // clier all manufacturer group
        {
            TextBoxManName.Text = String.Empty;
        }

        public void ClierClient()   // clier all client group
        {
            TextBoxClientName.Text = String.Empty;
            TextBoxClientAddress.Text = String.Empty;
            NumericBonus.Value = 3;
        }

        public void ClierCount()     // clier all count group
        {
            comboBoxPartName.SelectedIndex = -1;
        }   
    }
}
