using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Views
{
    public interface IEditView : IView
    {
        string Login { get; set; }
        string Adress { get; set; }
        string Phone { get; set; }
        bool IsAdmin { get; set; }

        event EventHandler<MyEvent> SaveEditForm;
    }

    public class MyEvent : EventArgs
    {
        public string Login { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }

        public MyEvent(string login, string adress, string phone, bool isAdmin)
        {
            Login = login;
            Adress = adress;
            Phone = phone;
            IsAdmin = isAdmin;
        }
    }
}
