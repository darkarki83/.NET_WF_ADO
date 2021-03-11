using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface ISearchFormView : IView
    {
        event EventHandler ClientIndexCheange;
        event EventHandler OrderIndexCheange;

        Label LabelId { get; set; }
        Label LabelDate { get; set; }
        Label LabelStatus { get; set; }

        ComboBox ComboBoxClient { get; set; }
        ComboBox ComboBoxOrder { get; set; }
    }
}
