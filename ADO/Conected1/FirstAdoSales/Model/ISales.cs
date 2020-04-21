using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstAdo.Model
{
    public interface ISales
    {
        SqlConnectionStringBuilder Builder { get; set; }
        SqlConnection Connection { get; set; }
        List<long> BookIDs { get; set; }
        List<long> AuthorFKs { get; set; }

        void LoadSales(ListView listView);
        void Close();
    }
}
