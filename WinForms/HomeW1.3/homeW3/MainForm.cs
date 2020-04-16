using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homeW3
{
    public partial class MainForm : Form
    {
        private bool controlPut = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!controlPut)
                {
                    if ((e.Location.X > 10 && e.Location.X < Width - 40) && (e.Location.Y > 10 && e.Location.Y < Height - 60))
                        MessageBox.Show("You in Cube", "Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if ((e.Location.X < 10 || e.Location.X > Width - 40) || (e.Location.Y < 10 || e.Location.Y > Height - 60))
                        MessageBox.Show("You out from Cube", "Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if ((e.Location.X == 10 || e.Location.X == Width - 40) || (e.Location.Y == 10 || e.Location.Y == Height - 60))
                        MessageBox.Show("You on the botder", "Click", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    Close();
            }
            else
            {
                Text = "H : " + Height.ToString() + "W : " + Width.ToString();
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.Location.ToString();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.ControlKey)
                controlPut = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                controlPut = false;
        }
    }
}
