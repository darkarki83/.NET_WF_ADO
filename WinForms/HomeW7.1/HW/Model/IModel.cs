using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public interface IModel
    {
        int Height { get; set; }
        int Width { get; set; }
        int A { get; set; }
        int B { get; set; }
        int C { get; set; }
        int HeightMidle { get; set; }
        int WidthMidle { get; set; }
        int Begin { get; set; }
        int Finish { get; set; }
        int Step { get; set; }
        void ClickStart();
    }
}
