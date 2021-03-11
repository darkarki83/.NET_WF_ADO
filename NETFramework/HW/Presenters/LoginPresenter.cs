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
    public class LoginPresenter : BasePresenter<ILoginFormView>
    {
        public IModel Model { get; set; }

        public LoginPresenter(IModel model, ILoginFormView view)
        {
            Model = model;
            View = view;

            View.LoginClick += LoginClick;
        }

        public void LoginClick(object sender, EventArgs e)
        {
            var admin = Model.Context.Admins.AsNoTracking().SingleOrDefault(a => a.Login == View.Login.Text);
            
            if(admin != null)
            {
                if(admin.Password == View.Password.Text)
                    View.LetUserLogin();
                else
                    View.DontLetUserLogin();
            }
            else
            {
                View.DontLetUserLogin();
            }
        }
    }
}
