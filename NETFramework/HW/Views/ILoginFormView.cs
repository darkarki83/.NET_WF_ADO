using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface ILoginFormView : IView
    {
        TextBox Login { get; set; }
        TextBox Password { get; set; }

        event EventHandler LoginClick;

        void LetUserLogin();
        void DontLetUserLogin();
    }
}
