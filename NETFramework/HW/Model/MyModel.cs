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
        private MyStoreContext _context;

        public MyStoreContext Context { get => _context; set => _context = value; }
        
        public MyModel(MyStoreContext context)
        {
            Context = context;
            //Context.Manufacturers.Load();
            //Context.Clients.Load();
            //Context.Parts.Load();
            //Context.Orders.Load();
        }
    }
}
