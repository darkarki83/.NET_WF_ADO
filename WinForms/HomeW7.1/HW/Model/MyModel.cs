using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MyModel : IModel
    {
        public MyModel()
        {
            Begin = -100;
            Finish = 100;
            Step = 1;
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int HeightMidle { get; set; }
        public int WidthMidle { get; set; }
        public int Begin { get; set; }
        public int Finish { get; set; }
        public int Step { get; set; }
        public void ClickStart()
        {
            HeightMidle = Height / 2;
            WidthMidle = Width / 2;
        }

    }
}
