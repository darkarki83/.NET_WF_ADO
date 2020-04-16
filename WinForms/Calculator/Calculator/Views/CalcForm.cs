using Calculator.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalcForm : System.Windows.Forms.Form, ICalcView
    {
        public event EventHandler InNumber;
        public event EventHandler Clien;
        public event EventHandler PlusAndProsent;
        public event EventHandler SumbolCalc;
        public event EventHandler Copy;
        public event EventHandler Paste;



        public double Result { get; set; }

        public double FirstNumber { get; set; }

        public bool OutNumber { get; set; }

        public char Sumbol { get; set; }

        public string TextBoxInNumber { get; set; }

        public CalcForm()
        {
            InitializeComponent();
            textBox.Text = "0";
            OutNumber = false;
            pasteToolStripMenuItem.Enabled = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            InNumber(sender, EventArgs.Empty);
            textBox.Text = TextBoxInNumber;
        }

        private void button_Clien_Click(object sender, EventArgs e)
        {
            Clien(sender, EventArgs.Empty);
            textBox.Text = TextBoxInNumber;
            pasteToolStripMenuItem.Enabled = false;
        }

        private void buttonProsent_Click(object sender, EventArgs e)
        {
            PlusAndProsent(sender, EventArgs.Empty);
            textBox.Text = TextBoxInNumber;
        }

        private void buttonSumbol_Click(object sender, EventArgs e)
        {
            SumbolCalc(sender, EventArgs.Empty);
            if (OutNumber)
            {
                textBox.Text = TextBoxInNumber;
                OutNumber = false;
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            Copy(sender, e);
            pasteToolStripMenuItem.Enabled = true;
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            Paste(sender, e);
            textBox.Text = TextBoxInNumber;
        }

        private void About_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void Digis_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
