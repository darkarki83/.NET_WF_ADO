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
    public partial class searchForm : Form
    {
        TextBox TextFilter { get=> textFilter; set => textFilter = value; }
        public searchForm()
        {
            InitializeComponent();
            ButtonEnabledStart();
        }

        // методы для внутренего пользывания
        public void ButtonEnabledStart()
        {
            buttonSearch.Enabled = true;
            buttonAdd.Enabled = false;
        }

        public void ButtonEnabled()
        {
            buttonSearch.Enabled = false;
            buttonAdd.Enabled = true;
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (textPath.Text.Length > 0)
            {
                textPath.Text = string.Empty;
                ButtonEnabledStart();
            }
            else
                Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var TreeDir = new FileInfo[10];
            DirectoryInfo directoryInfo;
            directoryInfo = new DirectoryInfo(textPath.Text);
            try
            {
                TreeDir = directoryInfo.GetFiles(TextFilter.Text);
            }
            catch (Exception ex)
            {
                TreeDir = null;
            }
            if (TreeDir != null)
            {
                foreach (var item in TreeDir)
                {
                    ((mainForm)Owner).SetListFiles(item.FullName);
                }
            }
            Close();
        }

        private void button_SearchClick(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog
            {
                SelectedPath = @"C:\",
                ShowNewFolderButton = false,
                Description = "Select folder to work with."
            };

            var openFileDialog1 = new OpenFileDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialog.SelectedPath;
            }
            openFileDialog1.Filter = "(*.*)|*.*";
            textPath.Text = openFileDialog1.InitialDirectory;
            ButtonEnabled();
        }
    }
}
