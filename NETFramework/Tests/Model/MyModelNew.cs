using HW.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Model
{
    public class MyModelNew : IModel
    {

        private MyStoreContext _context;
        public MyStoreContext Context { get => _context; set => _context = value; }
        public decimal Totalcost { get; set; }

        public MyModelNew(MyStoreContext context)
        {
            Context = new MyStoreContext();
        }
    }
}
