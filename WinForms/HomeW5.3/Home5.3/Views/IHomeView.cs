using Home5._3.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home5._3.Views
{
    public interface IHomeView : IView
    {
        event EventHandler Open;
        event EventHandler Save;
        event EventHandler SaveAs;

        void EnabledButtonSave(bool e);
        void EnabledButtonCopy(bool e);
        RichTextBox GetRichTextText();
        void SetRichTextText(string text);



    }
}
