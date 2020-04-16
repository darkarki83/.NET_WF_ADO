using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views

{
    public partial class FormView : Form, IFormView
    {
        private Pen penXY;
        private Pen penGraph;
        public FormView()
        {
            InitializeComponent();
            penXY = new Pen(Brushes.Blue);
            PenGraph = new Pen(Brushes.DarkRed);
            PenGraph.Width = 5;
        }
        public event EventHandler ClickStart;
        public event EventHandler DrawG;

        public PictureBox MyPictureBox { get => pictureBox; set => pictureBox = value; }
        public Pen PenXY { get => penXY; set => penXY = value; }
        public Pen PenGraph { get => penGraph; set => penGraph = value; }
        public TextBox TextBoxA { get => textBoxA; set => textBoxA = value; }
        public TextBox TextBoxB { get => textBoxB; set => textBoxB = value; }
        public TextBox TextBoxC { get => textBoxC; set => textBoxC = value; }
        public int PictureBoxHeight { get; set; }
        public int PictureBoxWidth { get; set; }
        public int HeightMidle { get; set; }
        public int WidthMidle { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int Begin { get; set; }
        public int Finish { get; set; }
        public int Step { get; set; }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            
            using (Graphics grfx = MyPictureBox.CreateGraphics())
            {
                grfx.Clear(Color.White);
                ClickStart(sender, new EventArgs());
                grfx.DrawLine(penXY, 0, HeightMidle, PictureBoxWidth, HeightMidle);
                grfx.DrawLine(penXY, WidthMidle, 0, WidthMidle, PictureBoxHeight);
                DrawG(sender, new EventArgs());
                for (int i = Begin; i < Finish; i++)
                {
                    X1 = i + WidthMidle;
                    Y1 = -(A * i * i + B * i + C) + HeightMidle;

                    X2 = i + 1 + WidthMidle;
                    Y2 = -(A * (i + Step) * (i + Step) + B * (i + Step) + C) + HeightMidle;
                    grfx.DrawLine(penGraph, X1, Y1, X2, Y2);
                }
            }
            Invalidate();
        }

        private void FormView_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}
