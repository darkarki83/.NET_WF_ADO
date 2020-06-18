using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public interface IModel
    {
        event EventHandler Update;
        int Id { get; set; }
        MyUserContext Context { get; set; }
        void UpdateList();
        void DeleteItem();
    }
}
