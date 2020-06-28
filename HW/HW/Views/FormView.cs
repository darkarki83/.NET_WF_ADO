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

        public void test()
        {
            string str = "eeeeeeeee";
        }
       
    }
}
