using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Views
{
    public interface IAddView : IView
    {
        string Login { get; set; }
        string Password { get; set; }
        string Adress { get; set; }
        string Phone { get; set; }
        bool IsAdmin { get; set; }

        event EventHandler<MyEventAdd> SaveAddForm;
    }

    public class MyEventAdd : EventArgs
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }

        public MyEventAdd(string login, string password, string adress, string phone, bool isAdmin)
        {
            Login = login;
            Password = password;
            Adress = adress;
            Phone = phone;
            IsAdmin = isAdmin;
        }
    }

}
