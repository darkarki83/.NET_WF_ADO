using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW2._1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            buttonLoad.EnabledChanged += Start;
        }

        private void Start(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled == false)
            {
                button.Text = "Start";
                progressBar.Value = 0;
                label.Text = " Value = 0";
            }
            else
            {
                label.Text = "You are finish";
                button.Text = "Start Again ?";
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            buttonLoad.Enabled = false;

            for (int i = 0; i <= 100; i++)
            {
                label.Text = $" Value = {progressBar.Value }";
                Thread.Sleep(100);
                progressBar.PerformStep();
                Update();
            }
            
            buttonLoad.Enabled = true;
        }
    }
}
