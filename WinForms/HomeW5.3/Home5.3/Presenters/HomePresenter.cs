using Home5._3.Common;
using Home5._3.Models;
using Home5._3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home5._3.Presenters
{
    public class HomePresenter : BasePresenter<IHomeView>
    {
        public IModel Model { get; set; }

        public HomePresenter(IHomeView view, IModel model)
        {
            Model = model;
            View = view;
            View.Open += OpenFile;
            View.Save += SaveFile;
            View.SaveAs += SaveAsFile;
        }

        public void OpenFile(object sender, EventArgs e)
        {
            Model.Open();
            View.SetRichTextText(Model.RichText.Text);
        }

        public void SaveFile(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Save File ?", "Save Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Model.RichText = View.GetRichTextText();
                Model.Save();
            }
        }

        public void SaveAsFile(object sender, EventArgs e)
        {
            Model.RichText = View.GetRichTextText();
            Model.SaveAs();
        }
    }
}
