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
        ListView ListViewPart { get; set; }
        ListView ListViewCart { get; set; }
        Label LabelTotalCost { get; set; }

        ListView ListViewOrder { get; set; }
        ListView ListViewPartsInOrder { get; set; }

        event EventHandler LoadList;
        event EventHandler AddToCart;
        event EventHandler DeleteFromCart;
        event EventHandler Order;

        event EventHandler SearchOrder;
        event EventHandler LoginAdmin;

        void EnabledDisAdd(bool status);
        void EnabledDisOrder(bool status);
    }
}
