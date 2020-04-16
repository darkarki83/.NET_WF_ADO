using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Two_Date
{
    public partial class MainForm : Form
    {
        /*7. Написать программу, вычисляющую сколько осталось
             времени до указанной даты (дата вводится с клавиатуры
             в Edit). Предусмотреть возможность выдачи результата
             в годах, месяцах, днях, минутах, секундах (для первых
             двух вариантов ответ дробный). Для переключения меж-
             ду вариантами желательно использовать переключатели
             (RadioButton).*/
        public MainForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            Until.Text = "Until this Date:";
            if (firstRadio.Checked)
                OurLabel.Text = ((dateTimePicker.Value - DateTime.Now).TotalDays / 365).ToString() + " Years";
            if (secondRadio.Checked)
                OurLabel.Text = ((dateTimePicker.Value - DateTime.Now).TotalDays / 30).ToString() + " Month";
            if (thertRadio.Checked)
                OurLabel.Text = (dateTimePicker.Value - DateTime.Now).TotalDays.ToString() + " Days";
            if (fourRadio.Checked)
                OurLabel.Text = (dateTimePicker.Value - DateTime.Now).TotalMinutes.ToString() + " Minuts";
            if (fiveRadio.Checked)
                OurLabel.Text = (dateTimePicker.Value - DateTime.Now).TotalSeconds.ToString() + " Second";
        }

        private void firstRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(OurLabel.Text != "Choice Date")
            OurLabel.Text = ((dateTimePicker.Value - DateTime.Now).TotalDays / 365).ToString() + " Years";
        }

        private void firstRadio_CheckedChanged_1(object sender, EventArgs e)
        {
            if (firstRadio.Checked)
                OurLabel.Text = ((dateTimePicker.Value - DateTime.Now).TotalDays / 365).ToString() + " Years";
            if (secondRadio.Checked)
                OurLabel.Text = ((dateTimePicker.Value - DateTime.Now).TotalDays / 30).ToString() + " Month";
            if (thertRadio.Checked)
                OurLabel.Text = (dateTimePicker.Value - DateTime.Now).TotalDays.ToString() + " Days";
            if (fourRadio.Checked)
                OurLabel.Text = (dateTimePicker.Value - DateTime.Now).TotalMinutes.ToString() + " Minuts";
            if (fiveRadio.Checked)
                OurLabel.Text = (dateTimePicker.Value - DateTime.Now).TotalSeconds.ToString() + " Second";
        }
    }
}
