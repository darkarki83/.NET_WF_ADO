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
        event EventHandler LoadForm;
        event EventHandler IndexChanged;
        ComboBox BoxTable { get; set; }
        ListView ListTable { get; set; }
    }
}
