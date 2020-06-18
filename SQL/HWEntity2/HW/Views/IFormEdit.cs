using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface IFormEdit : IView
    {
        TextBox TextBoxLogin { get; set; }
        TextBox TextBoxPassword { get; set; }
        TextBox TextBoxAdress { get; set; }
        TextBox TextBoxPhone { get; set; }
        CheckBox CheckBoxAdmin { get; set; }
        event EventHandler FormEditLoad;
        event EventHandler SaveClick;
    }
}
