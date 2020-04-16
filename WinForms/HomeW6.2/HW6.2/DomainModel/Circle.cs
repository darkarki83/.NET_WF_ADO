using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2.DomainModel
{
    public class Circle
    {
        public int X;
        public int Y;
        public int Height;
        public SolidBrush Brush { get; set; }

        public Circle(SolidBrush brush, int x, int y, int height)
        {
            X = x;
            Y = y;
            Height = height;
            Brush = brush;
        }
    }
}
