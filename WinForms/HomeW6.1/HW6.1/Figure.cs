using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._1
{
    public class Figure
    {
        private string name;
        public Figure()
        {
            this.name = null;
        }
        public Figure(string n)
        {
            this.name = n;
        }
        public virtual Image Image { get; }
    }
}
