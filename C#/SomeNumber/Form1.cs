using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeNumber
{
    public partial class Games : Form
    {

        public Games()
        {
            InitializeComponent();
            mylabel.Text = "Guess the number from 1 - 2000\n and Press Start";
        }

        private void Quation_Click(object sender, EventArgs e)
        {
            Random rand = new Random(1 - 2000);
            int count = 0;

            Start.Enabled = false;
            mylabel.Text = String.Empty;

            string text;
            var result = new DialogResult();

            do
            {
                count++;
                int i = rand.Next(1, 2000);

                text = "You guessed : " + i.ToString();
                result = MessageBox.Show(text, "I Guess ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            } while (result != DialogResult.Yes);

            mylabel.Text = "Numbers of attemtpts : " + count.ToString();
            againLabel.Text = "Play One More Time Press Start ";
            Start.Enabled = true;

        }
    }
}
