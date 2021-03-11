using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface IUserFormView : IView
    {
        event EventHandler Order;
        event EventHandler SelectedIndexChanged;

        ListView ListViewOrder { get; set; }
        ComboBox ComboClient { get; set; }

        TextBox TDdress { get; set; }
        TextBox Cost { get; set; }
        TextBox Bonus { get; set; }
        TextBox TotalCost { get; set; }
    }
}
