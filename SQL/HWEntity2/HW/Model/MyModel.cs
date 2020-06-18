using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MyModel : IModel
    {
        private MyUserContext myContext;
        public event EventHandler Update;
        public MyModel(MyUserContext context)
        {
            Context = context;
            Context.Users.Load();
            Context.Informations.Load();
        }
        public int Id { get; set; }
        public MyUserContext Context { get => myContext; set => myContext = value; }
        public void UpdateList()
        {
            Update(new object(), EventArgs.Empty);
        }
        public void DeleteItem()
        {
            Information info = Context.Informations.Find(Id);
            int? IdFK = null;
            if (info != null)
            {
                IdFK = info.UserFK;
                User user = Context.Users.Find(IdFK);
                Context.Informations.Remove(info);
                Context.Users.Remove(user);
                Context.SaveChanges();
            }
        }

    }
}
