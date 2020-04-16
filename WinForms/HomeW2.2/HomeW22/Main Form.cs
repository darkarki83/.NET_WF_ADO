using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW22
{
    public partial class MainForm : Form
    {
        /*Написать приложение — анкету, которую предлагается
          заполнить пользователю, все данные отображаются
          на результирующем текстовом поле.*/
        public MainForm()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                if(i == 0)
                    listBox.Items.Add("Name");
                if(i == 1)
                    listBox.Items.Add("Family");
                if (i == 2)
                    listBox.Items.Add("Birth");
                if(i == 3)
                    listBox.Items.Add("Gander");
                if (i == 4)
                    listBox.Items.Add("Telephon");
                if (i == 5)
                    listBox.Items.Add("Education");
                if (i == 6)
                    listBox.Items.Add("Subject");
                listBox.Items.Add(string.Empty);
            }
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            TextBox t = new TextBox();
            t = (TextBox)sender;

            listBox.Items.RemoveAt(int.Parse(t.Tag.ToString()));
            listBox.Items.Insert(int.Parse(t.Tag.ToString()), (object)t.Text);
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
                ComboBox t = new ComboBox();
                t = (ComboBox)sender;
            for (int i = 0; i < t.Text.Length; i++)
            {
                if (t.Text[i] < '0' || t.Text[i] > '9')
                {
                    MessageBox.Show("Wring Input Phone number. For exampel : 38054223315", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox.Text = string.Empty;
                    break;
                }
                else
                {
                    listBox.Items.RemoveAt(int.Parse(t.Tag.ToString()));
                    listBox.Items.Insert(int.Parse(t.Tag.ToString()), (object)t.Text);
                }
            }
        }
        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker data = new DateTimePicker();
            data = (DateTimePicker)sender;

            listBox.Items.RemoveAt(int.Parse(data.Tag.ToString()));
            listBox.Items.Insert(int.Parse(data.Tag.ToString()), (object)data.Value.Date);
        }

        private void checkFamale_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = new CheckBox();
            check = (CheckBox)sender;

            if (checkFamale.Checked == true)
            {
                checkMale.Enabled = false;
                listBox.Items.RemoveAt(int.Parse(check.Tag.ToString()));
                listBox.Items.Insert(int.Parse(check.Tag.ToString()), (object)check.Text);
            }
            else
            {
                checkMale.Enabled = true;
            }
        }

        private void checkMale_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = new CheckBox();
            check = (CheckBox)sender;

            if (checkMale.Checked == true)
            {
                checkFamale.Enabled = false;
                listBox.Items.RemoveAt(int.Parse(check.Tag.ToString()));
                listBox.Items.Insert(int.Parse(check.Tag.ToString()), (object)check.Text);
            }
            else
            {
                checkFamale.Enabled = true;
            }
        }

    }
}
