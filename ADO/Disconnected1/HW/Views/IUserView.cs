using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface IUserView : IView
    {
        event EventHandler FormLoad;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler AddEvent;
        DataGridView DataGrid { get; set; }

    }
}
