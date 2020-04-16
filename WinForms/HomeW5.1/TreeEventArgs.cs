using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW51
{
    public class TreeEventArgs : EventArgs
    {
        private int index;

        public TreeEventArgs(int newIndex)
        {
            index = newIndex;
        }

        public int GetIndex() => index;
    }
}
