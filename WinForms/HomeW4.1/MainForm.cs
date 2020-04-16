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

namespace HomeW4._1
{
    /*
     1. Разработать текстовый редактор, организовать
        открытие \ сохранение текстовых файлов.
        • В панели инструментов расположить кнопки ( От-
        крыть, сохранить, новый документ, копировать,
        вырезать, вставить, отменить, кнопка настройки
        редактора (цвет шрифта, цвет фона, ШРИФт)).
        • Меню должно дублировать панель инструментов
        (+ выделить всё, +сохранить как).
        • В Заголовке окна находиться полный путь к файлу.
        • Организовать контекстное меню для окна редактора
        (Копировать, Вырезать, Вставить, Отменить).*/
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void SetEnabledTools(bool b)
        {
            copyToolStripMenuItem1.Enabled = b;
            copyToolStripMenuItem.Enabled = b;
            cutToolStripMenuItem.Enabled = b;
            cutToolStripMenu.Enabled = b;
            cancelToolStripMenuItem1.Enabled = b;
            cancelToolStripMenuItem.Enabled = b;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text files (*.txt)|*.txt|C++ files (*.cpp;*.h;*.hpp)|*.cpp;*.h;*.hpp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Text = openFileDialog.FileName;
                var fileStream = openFileDialog.OpenFile();

                using(StreamReader reader = new StreamReader(Text, System.Text.Encoding.Default))
                {
                    richText.Text = reader.ReadToEnd();
                }
            }
            richText.Enabled = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            Text = saveFileDialog.FileName;
            richText.SaveFile(richText.Text);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Text = saveFileDialog.FileName;
                var fileStream = saveFileDialog.OpenFile();
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < richText.Lines.Length; i++)
                    {
                        writer.WriteLine(richText.Lines[i]);
                    }
                }
                MessageBox.Show(saveFileDialog.FileName, "Saved To");
            }
            richText.SaveFile(Text);
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            FileStream fin;
            try
            {
                fin = new FileStream("C:\\Users\\MOB_master\\Desktop\\new.txt", FileMode.CreateNew);
                openFileDialog.FileName = "C:\\Users\\MOB_master\\Desktop\\new.txt";
            }
            catch
            {
                openFileDialog.FileName = "C:\\Users\\MOB_master\\Desktop\\new.txt";
            }
            Text = openFileDialog.FileName;

            richText.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Copy();
            richText.Cut();
            if (!pasteToolStripMenuItem.Enabled)
            {
                pasteToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.Copy();
            if (!pasteToolStripMenuItem.Enabled)
            {
                pasteToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Paste();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Select(richText.SelectionStart, 0);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = richText.SelectionColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richText.ForeColor = colorDialog.Color;
                Invalidate();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog
            {
                ShowColor = true,
                Font = this.Font,
                Color = ForeColor
            };
            fontDialog.Font = richText.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richText.Font = fontDialog.Font;
                richText.ForeColor = fontDialog.Color;
                Invalidate();
            }
        }

        private void richText_SelectionChanged(object sender, EventArgs e)
        {
            if(richText.SelectedText.Length > 0)
                SetEnabledTools(true);
            else
                SetEnabledTools(false);
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectAll();
        }

        private void saveAssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               richText.SaveFile(saveFileDialog.FileName);
            }
        }
    }
}
