using HW6._2.DomainModel;
using HW6._2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6._2
{
    public partial class MainForm : Form, IDrawViews
    {
        private SolidBrush brush;
        //--------    Point     -------------//
        private bool pointStart = false;
        private List<SuperPoint> superPoints;

        //--------    Line       ------------//
        private bool lineStart = false;
        private Point onePoint;
        private Pen bluePen;
        private List<Line> lines;

        //-----------  Circle  ---------------//
        private bool circleStart = false;
        private int heightCircle;
        private List<Circle> circles;
        //------------
       // private DiameterForm diameterForms;

        //------------
        public event EventHandler<MouseEventArgs> MouseClickForm;
        public event EventHandler ToolPointClick;
        public event EventHandler ToolLineClick;
        public event EventHandler ToolCircleClick;
        public event EventHandler MenuItemColor;
        public event EventHandler ToolDelete;
        public event EventHandler DiameterClick;


        public MainForm()
        {
            InitializeComponent();

            Brush = new SolidBrush(Color.Red);

            //--------    Point     -------------//
            SuperPoints = new List<SuperPoint>();

            //--------    Line       ------------//
            onePoint = new Point();
            BluePen = new Pen(Brush.Color, 6);
            BluePen.StartCap = LineCap.Round;
            BluePen.EndCap = LineCap.Round;
            BluePen.DashStyle = DashStyle.Solid;
            BluePen.DashCap = DashCap.Round;
            lines = new List<Line>();

            //-----------  Circle  ---------------//
            HeightCircle = 100;
            circles = new List<Circle>();
            
        }

        public SolidBrush Brush { get => brush; set => brush = value; }
        //--------    Point     -------------//
        public bool PointStart { get => pointStart ; set => pointStart = value; }

        public List<SuperPoint> SuperPoints { get => superPoints; set => superPoints = value; }
        
        //--------    Line       -------------//
        
        public bool LineStart { get => lineStart; set => lineStart = value; }
       
        public Point OnePoint { get => onePoint; set => onePoint = value; }
        
        public Pen BluePen { get => bluePen; set => bluePen = value; }

        public List<Line> Lines { get => lines; set => lines = value; }
        
        //-----------  Circle  ---------------//
        public bool CircleStart { get => circleStart; set => circleStart = value; }
        public int HeightCircle { get => heightCircle; set => heightCircle = value; }
        public List<Circle> Circles { get => circles; set => circles = value; }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;

            gp.FillEllipse(Brush, OnePoint.X, OnePoint.Y, 6f, 6f);

            foreach (var item in SuperPoints)
            {
                gp.FillEllipse(item.OneBrush, item.OnePoint.X, item.OnePoint.Y, 10f, 10f);
            }

            foreach (var item in Lines)
            {
                gp.DrawLine(item.BluePen, item.X1, item.Y1, item.X2, item.Y2);
            }

            foreach (var item in Circles)
            {
                gp.FillEllipse(item.Brush, new RectangleF(item.X, item.Y, item.Height, item.Height));
            }
        }

        private void saveAsTool_Click(object sender, EventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            DialogResult dr = diag.ShowDialog();

            if (dr.Equals(DialogResult.OK))
            {

                string _filename = diag.FileName;

                // filename not specified. Use FileName = ...
                if (_filename == null || _filename.Length == 0)
                    throw new Exception("Unspecified file name");

                // cannot override RO file
                if (File.Exists(_filename)
                    && (File.GetAttributes(_filename)
                    & FileAttributes.ReadOnly) != 0)
                    throw new Exception("File exists and is read-only!");
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClickForm(sender, e);
            Invalidate();
        }

        private void toolPoint_Click(object sender, EventArgs e)
        {
            ToolPointClick(sender, e);
            CheckFigure(true, false, false);
            DiameterOffOn(false);
        }

        private void toolLine_Click(object sender, EventArgs e)
        {
            ToolLineClick(sender, e);
            CheckFigure(false, true, false);
            DiameterOffOn(false);
        }

        private void toolCircle_Click(object sender, EventArgs e)
        {
            ToolCircleClick(sender, e);
            CheckFigure(false, false, true);
            DiameterOffOn(true);
        }

        private void menuItemColor_Click(object sender, EventArgs e)
        {
            MenuItemColor(sender, e);
            Invalidate();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            ToolDelete(sender, e);
            CheckFigure(false, false, false);
            DiameterOffOn(false);
            Invalidate();
        }

        private void toolDiameter_Click(object sender, EventArgs e)
        {
            DiameterClick(sender, e);
        }

        public void DiameterOffOn(bool b)
        {
            toolDiameter.Enabled = b;
        }

        private void newTool_Click(object sender, EventArgs e)
        {
            ToolDelete(sender, e);
            DiameterOffOn(false);
            Invalidate();
        }
        private void CheckFigure(bool point, bool line, bool circle)
        {
            pointTool.Checked = point;
            toolPoint.Checked = point;
            lineTool.Checked = line;
            toolLine.Checked = line;
            circleTool.Checked = circle;
            toolCircle.Checked = circle;
        }
    }
}
