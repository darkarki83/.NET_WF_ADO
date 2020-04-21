using FirstAdo.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstAdo.Views
{
    public interface ISalesView : IView
    {
       
        List<long> BookIDs { get; set; }
        List<long> AuthorFKs { get; set; }
        ListView Listview { get; set; }

        event EventHandler LoadForm;
        event EventHandler CloseForm;
    }
}
