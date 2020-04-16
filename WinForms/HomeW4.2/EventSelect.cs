using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW4._2
{
    public class EventSelect : EventArgs
    {
        int selectedItem;

        public EventSelect(int select)
        {
            selectedItem = select;
        }

        public int GetSelection()
        {
            return selectedItem;
        }

    }
}
