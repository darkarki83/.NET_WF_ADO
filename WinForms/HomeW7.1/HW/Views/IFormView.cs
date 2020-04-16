using HW.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface IFormView : IView
    {
        event EventHandler ClickStart;
        event EventHandler DrawG;
        PictureBox MyPictureBox { get; set; }
        Pen PenGraph { get; set; }
        Pen PenXY { get; set; }
        TextBox TextBoxA { get; set; }
        TextBox TextBoxB { get; set; }
        TextBox TextBoxC { get; set; }
        int PictureBoxHeight { get; set; }
        int PictureBoxWidth { get; set; }
        int HeightMidle { get; set; }
        int WidthMidle { get; set; }
        int X1 { get; set; }
        int X2 { get; set; }
        int Y1 { get; set; }
        int Y2 { get; set; }
        int A { get; set; }
        int B { get; set; }
        int C { get; set; }
        int Begin { get; set; }
        int Finish { get; set; }
        int Step { get; set; }

    }
}
