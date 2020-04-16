using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6._2.DomainModel
{
    public class SuperPoint
    {
        public Point OnePoint { get; set; } 
        public Brush OneBrush { get; set; } 

        public SuperPoint()
        {
            OnePoint = new Point();
            OneBrush = new SolidBrush(Color.Red);
        }

        public SuperPoint(Point point, SolidBrush brush)
        {
            OnePoint = point;
            OneBrush = brush;
        }
    }

    public class Line
    {
        public int X1;
        public int X2;

        public int Y1;
        public int Y2;

        public Pen BluePen;

        public Line(int x1, int x2, int y1, int y2, Pen bluePen)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            BluePen = bluePen;
        }
    }

    public interface IDrawModel
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

        void NewPoints(object sender, MouseEventArgs e);

        void NewLines(object sender, MouseEventArgs e);

        void NewCircle(object sender, MouseEventArgs e);

        void DeleteAll();

        void StopPrimitiv();

        void menuColorClick();

        void NewHeightCircle(int newHeight);
    }
}
