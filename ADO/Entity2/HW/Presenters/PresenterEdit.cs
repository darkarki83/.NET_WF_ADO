using HW.Common;
using HW.Model;
using HW.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Presenters
{
    public class PresenterEdit : BasePresenter<IFormEdit>
    {
        public IModel Model { get; set; }

        public PresenterEdit(IModel model, IFormEdit view)
        {
            Model = model;
            View = view;
            View.FormEditLoad += FormEditLoad;
            View.SaveClick += SaveClick;
        }
        public void FormEditLoad(object sender, EventArgs e)
        {
            Information info = Model.Context.Informations.Find(Model.Id);
            int? IdFK = null;
            if (info != null)
            {
                View.TextBoxAdress.Text = info.Adress;
                View.TextBoxPhone.Text = info.Phone;
                View.CheckBoxAdmin.Checked = info.Admin.Value;
                IdFK = info.UserFK;
                User user = Model.Context.Users.Find(IdFK);
                if (IdFK != null)
                {
                    View.TextBoxLogin.Text = user.Login;
                    View.TextBoxPassword.Text = user.Password;
                }
            }
            else
            {
                View.TextBoxAdress.Text = string.Empty;
                View.TextBoxPhone.Text = string.Empty;
                View.CheckBoxAdmin.Checked = false;
                View.TextBoxLogin.Text = string.Empty;
                View.TextBoxPassword.Text = string.Empty;
            }
        }
        public void SaveClick(object sender, EventArgs e)
        {
            Information info = Model.Context.Informations.Find(Model.Id);
            int? IdFK = null;
            if (info != null)
            {
                info.Adress = View.TextBoxAdress.Text;
                info.Phone = View.TextBoxPhone.Text;
                info.Admin = View.CheckBoxAdmin.Checked;
                Model.Context.Entry(info).State = EntityState.Modified;
                IdFK = info.UserFK;
                User user = Model.Context.Users.Find(IdFK);
                if (user != null)
                {
                    user.Login = View.TextBoxLogin.Text;
                    user.Password = View.TextBoxPassword.Text;
                    Model.Context.Entry(user).State = EntityState.Modified;
                    Model.Context.SaveChanges();
                }
                Model.UpdateList();
            }
            else
            {
                User user = new User();
                user.Login = View.TextBoxLogin.Text;
                user.Password = View.TextBoxPassword.Text;
                Model.Context.Users.Add(user);
                Model.Context.SaveChanges();

                Information infos = new Information();
                infos.Adress = View.TextBoxAdress.Text;
                infos.Phone = View.TextBoxPhone.Text;
                infos.Admin = View.CheckBoxAdmin.Checked;
                infos.UserFK = user.Id;
                Model.Context.Informations.Add(infos);
                Model.Context.SaveChanges();
                Model.Id = infos.Id;
                Model.UpdateList();
            }
        }
    }
}
