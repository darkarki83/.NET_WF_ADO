using HWAdo2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWAdo2.Views
{
    public interface IAcountingView : IView
    {
        ListBox OutListBox { get; set; }
        ComboBox OutComboBox { get; set; }
        PictureBox OutPictureBox { get; set; }

        event EventHandler LoadForm;
        event EventHandler NewWorker;

    }
}
