using HW6._2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6._2
{
   

    public partial class DiameterForm : Form, IDiameterView
    {
        public NumericUpDown NumericDiametr { get => numericDiameter; set => numericDiameter = value; }
        public DiameterForm()
        {
            InitializeComponent();
        }

        public event EventHandler<MyEvent> OkClick;
        public event EventHandler LoadDiamiter;
        private void DiameterForm_Load(object sender, EventArgs e)
        {
            if (LoadDiamiter != null)
                LoadDiamiter(sender, e);
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            int a = int.Parse(numericDiameter.Value.ToString());
            OkClick(sender, new MyEvent(a));
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
