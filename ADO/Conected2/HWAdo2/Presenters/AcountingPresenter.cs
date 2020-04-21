using HWAdo2.Common;
using HWAdo2.Model;
using HWAdo2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWAdo2.Presenters
{
    public class AcountingPresenter : BasePresenter<IAcountingView>
    {
        private IAcounting Model;
        public AcountingPresenter(IAcounting model, IAcountingView view)
        {
            Model = model;
            View = view;
            View.LoadForm += LoadForm;
            View.NewWorker += NewWorker;
        }

        public void LoadForm(object sender, EventArgs e)
        {
            Model.LoadAcounting(View.OutComboBox, View.OutPictureBox, View.OutListBox);
            View.OutComboBox.SelectedIndex = 0;
        }

        public void NewWorker(object sender, EventArgs e)
        {
            Model.NewWorker(View.OutComboBox, View.OutPictureBox, View.OutListBox);
        }
    }
}
