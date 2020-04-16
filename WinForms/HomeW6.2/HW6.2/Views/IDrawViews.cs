using HW6._2.Common;
using HW6._2.DomainModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6._2.Views
{
    public interface IDrawViews : IView
    {
        SolidBrush Brush { get; set; }
        //--------    Point     -------------//
        bool PointStart { get; set; }
        List<SuperPoint> SuperPoints { get; set; }

        //--------    Line       -------------//
        bool LineStart { get; set; }
        Point OnePoint { get; set; }
        Pen BluePen { get; set; }
        List<Line> Lines { get; set; }

        //-----------  Circle  ---------------//
        bool CircleStart { get; set; }
        int HeightCircle { get; set; }
        List<Circle> Circles { get; set; }

        //DiameterForm DiameterForms { get; set; }

        event EventHandler<MouseEventArgs> MouseClickForm;
        event EventHandler ToolPointClick;
        event EventHandler ToolLineClick;
        event EventHandler MenuItemColor;
        event EventHandler ToolCircleClick;
        event EventHandler ToolDelete;
        event EventHandler DiameterClick;
    }
}
