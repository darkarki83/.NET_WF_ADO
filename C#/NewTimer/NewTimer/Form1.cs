using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTimer
{
    public partial class Timer : Form
    {
        public Timer()
        {
            InitializeComponent();
            Stop.Enabled = false; ;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            ourTimer.Start();
            Stop.Enabled = true;
            Start.Enabled = false;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            ourTimer.Stop();
            Start.Enabled = true;
            Stop.Enabled = false;
        }

        private void ourTimer_Tick(object sender, EventArgs e)
        {
            if (numericUpDown.Value > 0)
                numericUpDown.Value--;
        }
    }
}
