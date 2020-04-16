using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2.Views
{
    public class MyEvent : EventArgs
    {
        public int MyDiameter { get; set; }
        public MyEvent(int NewD)
        {
            MyDiameter = NewD;
        }
    }
}
