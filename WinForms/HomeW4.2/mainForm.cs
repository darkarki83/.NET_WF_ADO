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

namespace HomeW4._2
{
    /*2. Написать программу «Проводник»
      • При первом запуске программа отображает список
      доступных дисков.
      • Программа должна содержать дерево дисков, стро-
      ку адреса, меню, панель инструментов и окно для
      отображения содержимого папки.
      • Дерево дисков отображает только диски и папки
      (можно реализовать с
      • помощью ListBox).
      • При двойном щелчке по папке — в окне содержи-
      мого отображаются файлы и подпапки.
      • Программа должна иметь развернутое меню, кон-
      текстное меню и возможность работы с горячими
      клавишами.*/
    public partial class mainForm : Form, IGuideView
    {
        private string CopyText {get;set;}

        public mainForm()
        {
            InitializeComponent();
            drivers = new List<DriveInfo>();
            dir = new DirectoryInfo[10];
            treeDir = new DirectoryInfo[10];
        }

        #region IGuideView Implementation

        private List<DriveInfo> drivers;

        private DirectoryInfo[] dir = null;

        private DirectoryInfo[] treeDir = null;

        public event EventHandler MainForm;

        public event EventHandler<EventSelect> OpenFile;


        public List<DriveInfo> DriverF
        {
            get => drivers;
            set
            {
                foreach (var item in value)
                    drivers.Add(item);
            }
        }

        public DirectoryInfo[] Dir
        {
            get => dir;
            set
            {
                dir = new DirectoryInfo[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    dir[i] = value[i];
                }
            }
        }

        public DirectoryInfo[] TreeDir
        {
            get => treeDir;
            set
            {
                if (value != null)
                {
                    treeDir = new DirectoryInfo[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        treeDir[i] = value[i];
                    }
                }
                else
                    treeDir = null;
            }
        }

        #endregion

        public void EnabledButtons(bool b)
        {
            open.Enabled = b;
            toolOpen.Enabled = b;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            int buttonlocation = 0;
            int buttonTag = 0;

            foreach (var item in drivers)
            {
                buttonTag++;
                var button = new Button();
                button.AutoSize = true;
                button.Tag = buttonTag;
                button.Text = item.ToString();
                button.Click += Button_Click;

                groupBox.Controls.Add(button);
                button.Location = new Point(50 + buttonlocation, 25);
                buttonlocation += 100;
            }
        }

        public void Button_Click(object sender, EventArgs e)
        {
           MainForm(sender, EventArgs.Empty);

            if (Dir != null)
            {
                treeFolders.Items.Clear();
                foreach (var item in Dir)
                {
                    treeFolders.Items.Add(item);
                }
            }
        }
        private void OpenFolder(object sender, EventArgs e)
        {
            OpenFile(sender, new EventSelect(treeFolders.SelectedIndex));

            if (TreeDir != null)
            {
                tree.Items.Clear();
                foreach (var item in TreeDir)
                {
                    tree.Items.Add(item);
                }
            }
            else
                tree.Items.Clear();
        }
        private void Font_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog
            {
                ShowColor = true,
                Font = this.Font,
                Color = ForeColor
            };
            fontDialog.Font = treeFolders.Font;
            fontDialog.Color = treeFolders.ForeColor;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                treeFolders.Font = fontDialog.Font;
                tree.Font = fontDialog.Font;

                treeFolders.ForeColor = fontDialog.Color;
                tree.ForeColor = fontDialog.Color;
                Invalidate();
            }
        }
        private void Color_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = treeFolders.ForeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                treeFolders.ForeColor = colorDialog.Color;
                tree.ForeColor = colorDialog.Color;
                Invalidate();
            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void treeFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(treeFolders.SelectedIndex >= 0)
                EnabledButtons(true);
            else
                EnabledButtons(false);
        }
    }
}
