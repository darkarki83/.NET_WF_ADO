using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day_Of_Weak
{
    /*
     6. Написать программу, которая по введенной дате
        определяет день недели. Результат выводить в текстовое
        поле (желательно по-русски).*/
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DateTime date;
            try
            {
                date = DateTime.Parse(comboBox.Text);
                labelOut.Text = date.DayOfWeek.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wrong input", "Input Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox.Text = string.Empty;
            }
        }
    }
}
