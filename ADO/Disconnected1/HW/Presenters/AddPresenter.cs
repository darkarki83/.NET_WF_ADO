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
    public class AddPresenter : BasePresenter<IAddView>
    {
        public IUserModel Model { get; set; }

        public AddPresenter(IUserModel model, IAddView view)
        {
            Model = model;
            View = view;
            View.SaveAddForm += SaveAddForm;
        }

        public void SaveAddForm(object sender, MyEventAdd e)
        {

        }

    }
}
