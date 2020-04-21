using HW.Common;
using HW.Model;
using HW.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Presenters
{
    public class EditPresenter : BasePresenter<IEditForm>
    {
        public IModel Model { get; set; }

        public EditPresenter(IModel model, IEditForm view)
        {
            Model = model;
            View = view;
            View.LoadForm += LoadForm;
            View.Save += Save;
        }
        public void LoadForm(object sender, EventArgs e)
        {
            if(Model.Id != 0)
            {
                View.FirstName.Text = Model.FirstName;
                View.LastName.Text = Model.LastName;
                View.Phone.Text = Model.PhoneNumber;
                View.Adress.Text = Model.Adress;
            }
            else
            {
                View.FirstName.Text = string.Empty;
                View.LastName.Text = string.Empty;
                View.Phone.Text = string.Empty;
                View.Adress.Text = string.Empty;
            }
        }
        public void Save(object sender, EventArgs e)
        {
            Model.FirstName = View.FirstName.Text;
            Model.LastName = View.LastName.Text;
            Model.PhoneNumber = View.Phone.Text;
            Model.Adress = View.Adress.Text;
            Model.Save();
        }
    }
}
