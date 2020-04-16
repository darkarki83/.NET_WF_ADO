using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW3._1
{
    /*1. Разработайте программу, которая позволяет пользователю
         осуществлять поиск файлов по заданному критерию.
         Приложение состоит из двух форм — главное окно
         и окно поиска. Пользователь может открыть сколько
         угодно окон поиска. Окно поиска запускается немодально.
         В окне поиска пользователь выбирает папку, в которой
         будет идти поиск и вводит маску поиска, например «*.doc».
         Найденные файлы отображаются в списке.*/
    public partial class mainForm : Form
    {
        public searchForm FindF { get; set; } = null;

        public mainForm()
        {
            InitializeComponent();
        }

        public void SetListFiles(string v) => listFiles.Items.Add(v);

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FindF = new searchForm();
            FindF.Show();
            FindF.Owner = this;
            FindF.BringToFront();
            listFiles.SelectedIndex = listFiles.Items.Count - 1;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = listFiles.SelectedIndex;
            if(selectedIndex != -1)
            {
                listFiles.Items.RemoveAt(selectedIndex);
            }
        }
    }
}
