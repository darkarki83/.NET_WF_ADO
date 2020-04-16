using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._1
{
    public class PawnWhite : Figure
    {
        private Image imege = Image.FromFile(@"..\..\белаяП.jpg");

        public override Image Image
        {
            get => imege;
        }
    }
}
