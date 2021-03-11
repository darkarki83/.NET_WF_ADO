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
        // events
        public event EventHandler LoadList;
        public event EventHandler AddToCart;
        public event EventHandler DeleteFromCart;
        public event EventHandler Order;

        public event EventHandler SearchOrder;
        public event EventHandler LoginAdmin;


        // constructor
        public MainForm()
        {
            InitializeComponent();

            EnabledDisAdd(false);
            EnabledDisDelete(false);
            EnabledDisOrder(false);
        }

        // Field
        public ListView ListViewPart { get => listViewParts; set => listViewParts = value; }
        public ListView ListViewCart { get => listViewCart; set => listViewCart = value; }
        public Label LabelTotalCost { get => labelTotalCost; set => labelTotalCost = value; }

        public ListView ListViewOrder { get => listViewOrder; set => listViewOrder = value; }
        public ListView ListViewPartsInOrder { get => listViewPartInOrder; set => listViewPartInOrder = value; }

        // Load MainForm => open Event LoadList
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadList(sender, EventArgs.Empty);
        }

        // Add Button click
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddToCart(sender, EventArgs.Empty);
        }

        // Delete Button click
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteFromCart(sender, EventArgs.Empty);
            EnabledDisDelete(false);
        }

        private void listViewParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewPart.CanSelect)
                EnabledDisAdd(true);
            else
                EnabledDisAdd(false);
        }

        private void listViewCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewCart.CanSelect)
                EnabledDisDelete(true);
            else
                EnabledDisDelete(false);
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            Order(sender, EventArgs.Empty);
        }

        // Exit
        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        // functions Enabled/Disabled button
        public void EnabledDisAdd(bool status)
        {
            addButton.Enabled = status;
            toolStripButtonAdd.Enabled = status;
            addToCartToolStripMenu.Enabled = status;
        }

        private void EnabledDisDelete(bool status)
        {
            deleteButton.Enabled = status;
            toolStripButtonDelete.Enabled = status;
            deleteFromCartToolStripMenu.Enabled = status;
        }

        public void EnabledDisOrder(bool status)
        {
            buttonOrder.Enabled = status;
            toOrderToolStripMenuItem.Enabled = status;
            toolStripButtonOrder.Enabled = status;
        }

        private void myOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchOrder(sender, EventArgs.Empty);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginAdmin(sender, EventArgs.Empty);
        }
    }
}
