using HW6._2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6._2.Views
{
    public interface IDiameterView : IView
    {
        event EventHandler<MyEvent> OkClick;
        event EventHandler LoadDiamiter;
        NumericUpDown NumericDiametr { get; set; }
    }
}
