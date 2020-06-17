using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Model
{
    public interface IUserModel
    {
        SqlConnection SqlConnection { get; set; }
        DataSet MyUserDataSet { get; set; }
        SqlDataAdapter DataAdpater { get; set; }

        SqlDataAdapter UserAndPassword { get; set; }
        SqlDataAdapter OneUser { get; set; }

        int IndexEdit { get; set; }

        string Login { get; set; }
        string Password { get; set; }
        string Adress { get; set; }
        string Phone { get; set; }
        bool IsAdmin { get; set; }

        void LoadForm(DataGridView dataGrid);
        void Update();
        void DeleteRow(DataGridView dataGrid);
    }
}
