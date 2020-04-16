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
using Home5._3.Views;

namespace Home5._3
{

    public partial class MainForm : Form, IHomeView
    {
        public event EventHandler Open;
        public event EventHandler Save;
        public event EventHandler SaveAs;

        public MainForm()
        {
            InitializeComponent();
            EnabledButtonSave(false);
            EnabledButtonCopy(false);

            //richText.AllowDrop = true;
            //richText.DragDrop += richText_DragDrop;
            //richText.DragEnter += richText_DragEnter;
        }

        public void EnabledButtonSave(bool e)
        {
            saveQuickMenu.Enabled = e;
            saveMenuItem.Enabled = e;
        }

        public void EnabledButtonCopy(bool e)
        {
            pasteMenuItem.Enabled = e;
            pasteQuickMenu.Enabled = e;
        }

        public RichTextBox GetRichTextText()
        {
            return richText;
        }

        public void SetRichTextText(string text)
        {
            if (richText != null)
                richText.Text = text;
            else
            {
                richText.Text = text;
            }
        }

        private void openQuickMenu_Click(object sender, EventArgs e)
        {
            Open(sender, EventArgs.Empty);
            EnabledButtonSave(false);
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            Save(sender, EventArgs.Empty);
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs(sender, EventArgs.Empty);
            EnabledButtonSave(true);
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want close program", "Close program", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                Close();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            richText.Copy();
            if (richText.SelectedText.Length > 0)
                EnabledButtonCopy(true);
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            richText.Cut();
            if (richText.SelectedText.Length > 0)
                EnabledButtonCopy(true);
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            richText.Paste();
        }

        private void cancelMenuItem_Click(object sender, EventArgs e)
        {
            richText.Select(richText.SelectionStart, 0);
        }

        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = richText.ForeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richText.ForeColor = colorDialog.Color;
                Invalidate();
            }
        }

        private void fontMenuItem_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog
            {
                ShowColor = true,
                Font = this.Font,
                Color = ForeColor
            };
            fontDialog.Font = richText.Font;
            fontDialog.Color = richText.ForeColor;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richText.Font = fontDialog.Font;
                richText.ForeColor = fontDialog.Color;
                Invalidate();
            }
        }

        private void richText_MouseDown(object sender, MouseEventArgs e) // пытаюсь реализовать перетаскивание
        {
            //richText.DoDragDrop(richText.Text, DragDropEffects.Copy);
        }

        private void richText_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop/*.StringFormat*/))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void richText_DragDrop(object sender, DragEventArgs e)
        {
            string[] str = ((string[])e.Data.GetData(DataFormats.FileDrop));
            foreach (var item in str)
            {
                using (StreamReader sr = new StreamReader(item, System.Text.Encoding.Default))
                {
                    richText.Text = sr.ReadToEnd();
                }
            }
        }
        private void richText_TextChanged(object sender, EventArgs e)
        {
            //if(richText.Text)
        }
    }
}
