using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW3._2
{
    public partial class AddNewProduct : Form
    {
        public AddNewProduct()
        {
            InitializeComponent();
        }

        public void EnabledBlock(bool b)
        {
            name.Enabled = b;
            price.Enabled = b;
            textName.Enabled = b;
            textPrice.Enabled = b;
        }

        public void LoadLists()
        {
            foreach (var item in ((MainForm)Owner).Map)
            {
                listName.Items.Add(item.Key);
                listPrice.Items.Add(item.Value);
            }
        }

        private void AddNewProduct_Load(object sender, EventArgs e)
        {
            addToMap.Enabled = false;
            EnabledBlock(false);
            LoadLists();
        }

        private void add_Click(object sender, EventArgs e)
        {
            EnabledBlock(true);
            name.Text = "Name : ";
            price.Text = "Price : ";
        }

        private void changeProduct_Click(object sender, EventArgs e)
        {
            if (listName.SelectedIndex != -1)
            {
                add_Click(sender, e);
                textPrice.Text = listPrice.Items[listName.SelectedIndex].ToString();
                textName.Text = listName.Items[listName.SelectedIndex].ToString();
                delete_Click(sender, e);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if(listName.SelectedIndex != -1)
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to remove product", "Delete product", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    string key = listName.Items[listName.SelectedIndex].ToString();
                    int index = listName.SelectedIndex;
                    ((MainForm)Owner).Map.Remove(key);

                    listPrice.Items.RemoveAt(index);
                    listName.Items.RemoveAt(index);
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToMap_Click(object sender, EventArgs e)
        {
            bool add = true;
            if (textName.TextLength > 0 && textPrice.TextLength > 0)
            {
                foreach (var item in ((MainForm)Owner).Map)
                    if (item.Key == textName.Text)
                        add = false;

                if (add)
                {
                    try
                    {
                        ((MainForm)Owner).Map.Add(textName.Text, int.Parse(textPrice.Text));
                        listPrice.Items.Add(int.Parse(textPrice.Text));
                    }
                    catch
                    {
                        ((MainForm)Owner).Map.Add(textName.Text, 0);
                        listPrice.Items.Add(0);

                    }
                    listName.Items.Add(textName.Text);
                    textPrice.Text = string.Empty;
                    textName.Text = string.Empty;
                    EnabledBlock(false);
                }
            }
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            if (textPrice.TextLength > 0)
                addToMap.Enabled = true;
        }

        private void textPrice_TextChanged(object sender, EventArgs e)
        {
            if (textName.TextLength > 0)
                addToMap.Enabled = true;
        }

        private void listName_SelectedIndexChanged(object sender, EventArgs e)
        {
            listPrice.SelectedIndex = listName.SelectedIndex;
        }

        private void listPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            listName.SelectedIndex = listPrice.SelectedIndex;
        }
    }
}
