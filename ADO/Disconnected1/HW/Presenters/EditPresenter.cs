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
    public class EditPresenter : BasePresenter<IEditView>
    {
        public IUserModel Model { get; set; }

        public EditPresenter(IUserModel model, IEditView view)
        {
            Model = model;
            View = view;
            View.SaveEditForm += SaveEditForm;
        }

        public void SaveEditForm(object sender, MyEvent e)
        {
            Model.Login = e.Login;
            Model.Adress = e.Adress;
            Model.Phone = e.Phone;
            Model.IsAdmin = e.IsAdmin;
            Model.Update();
        }

    }
}
