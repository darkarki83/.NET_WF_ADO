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

namespace HomeW3._3
{
    public partial class MainForm : Form
    {
        /*3. Разработайте приложение, которое состоит из двух
             форм. Первая форма содержит TextBox доступный только
             для чтения и две кнопки «загрузить файл» и «редактировать
             ». Кнопка «редактировать» изначально неактивна.
             При нажатии на первую кнопку, открывается диалог
             и пользователю предлагают выбрать текстовый файл.
             Выбранный файл загружается в TextBox и кнопка «редактировать
             » становится активной. При нажатии на вторую
             кнопку открывается вторая форма (не модально), которая
             содержит TextBox доступный для редактирования
             и две кнопки «Сохранить» и «Отменить». При нажатии
             на первую кнопку изменения отображаются в TextBox
             первой формы.*/
        public MainForm()
        {
            InitializeComponent();
        }

        public string GetTextBoxText() => textBox.Text;

        public void SetTextBoxText(string value) => textBox.Text = value;

        private void loadFile_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        textBox.Text = reader.ReadToEnd();
                    }
                }
            }
            edit.Enabled = true;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm();
            edit.Owner = this;
            edit.Show(); ;

            if (edit.DialogResult == DialogResult.OK)
            {

            }
        }
    }
}
