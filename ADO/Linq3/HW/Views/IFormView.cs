using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface IFormView : IView
    {
        ListView ListViewForm { get; set; }
        event EventHandler LoadForm;
        event EventHandler SortByFamily;
        event EventHandler SortByPhone;
        event EventHandler SortByName;
        event EventHandler Add;
        event EventHandler Edit;
        event EventHandler Delete;
    }
}
