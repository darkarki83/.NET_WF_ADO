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
        private MyLibraryContext context;
        public MyLibraryContext Context { get => context; set => context = value; }

        public MyModel(MyLibraryContext context)
        {
            Context = context;
            Context.Authors.Load();
            Context.Presses.Load();
            Context.Books.Load();
        }


    }
}
