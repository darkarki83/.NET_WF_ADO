using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views

{
    public partial class FormView : Form, IFormView
    {

        public PictureBox picture { get; set; }
        public FormView()
        {

            InitializeComponent();
        }
        public PictureBox picture1 { get; set; }
        public PictureBox picture2 { get; set; }
        public PictureBox picture3 { get; set; }
        public PictureBox picture4 { get; set; }

        public void test()
        {
            string str = "eee";
            string str1 = "eee";
            string str2 = "eee";
        }
       
    }
}
