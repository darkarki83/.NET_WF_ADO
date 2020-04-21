using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface IEditForm : IView
    {
        event EventHandler LoadForm;
        event EventHandler Save;
        TextBox FirstName { get; set; }
        TextBox LastName { get; set; }
        TextBox Phone { get; set; }
        TextBox Adress { get; set; }


    }
}
