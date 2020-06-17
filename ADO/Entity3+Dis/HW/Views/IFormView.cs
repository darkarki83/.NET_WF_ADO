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
        ComboBox ComboAuthor { get; set; }
        ComboBox ComboPress { get; set; }
        CheckBox CheckAuthor { get; set; }
        CheckBox CheckPress { get; set; }
        ListView ListBooks { get; set; }

        event EventHandler LoadForm;
        event EventHandler AuthorSearch;
        event EventHandler PressSearch;
        event EventHandler AuthorPressSearch;
    }
}
