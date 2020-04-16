using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._1
{
    public class QueenBlack : Figure
    {
        private Image imege = Image.FromFile(@"..\..\черныйФ.jpg");

        public override Image Image
        {
            get => imege;
        }
    }
}
