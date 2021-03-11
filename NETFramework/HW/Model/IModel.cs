using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    // IModel this is MyModel interface
    public interface IModel
    {
        // our DB 
        MyStoreContext Context { get; set; }

        decimal Totalcost { get; set; }
    }
}
