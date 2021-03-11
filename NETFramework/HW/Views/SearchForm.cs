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
    public partial class SearchForm : Form , ISearchFormView
    {
        public event EventHandler ClientIndexCheange;
        public event EventHandler OrderIndexCheange;

        public Label LabelId { get => labelId; set => labelId = value; }
        public Label LabelDate { get => labelDate; set => labelDate = value; }
        public Label LabelStatus { get => labelStatus; set => labelStatus = value; }

        public SearchForm()
        {
            InitializeComponent();
        }

        public ComboBox ComboBoxClient { get => comboBoxClient; set => comboBoxClient = value; }
        public ComboBox ComboBoxOrder { get => comboBoxOrder; set => comboBoxClient = value; }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxOrder.Text = "";
            ComboBoxOrder.Items.Clear();
            ClientIndexCheange(sender, EventArgs.Empty);
        }

        private void comboBoxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderIndexCheange(sender, EventArgs.Empty);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
