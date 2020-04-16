using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Cloak
{
    public partial class Cloak : Form
    {
        public Cloak()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            Stop.Enabled = true;
            if (choice.Checked)
                OurTime.Text = "0";
            timer.Enabled = true;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Start.Enabled = true;
            Stop.Enabled = false;
            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(OurTime.Text);
            OurTime.Text = (++count).ToString();
        }
    }
}
