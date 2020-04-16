using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public ListBox GetStudentList() => StudentList;

        public void SetGetStudentList( TextBox student) => StudentList.Items.Add(student);



        private void Add_Click(object sender, EventArgs e)
        {
            var add = new AddAndEdit();
            add.Text = "Add Student";
            if (add.ShowDialog() == DialogResult.OK)
                StudentList.Items.Add(add.MyText);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if(StudentList.SelectedIndex != -1)
            {
                if ((MessageBox.Show("Are you sure ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
                    StudentList.Items.RemoveAt(StudentList.SelectedIndex);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (StudentList.SelectedIndex != -1)
            {
                var edit = new AddAndEdit();
                edit.Text = "Edit Student";
                edit.MyText = StudentList.Items[StudentList.SelectedIndex].ToString();
                if (edit.ShowDialog() == DialogResult.OK)
                    StudentList.Items[StudentList.SelectedIndex] = edit.MyText;
            }

        }

        private void About_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
