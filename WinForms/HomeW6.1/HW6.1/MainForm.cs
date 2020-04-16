using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6._1
{
    public partial class MainForm : Form
    {
        List<Figure> Figur { get; set; }
        public MainForm()
        {
            InitializeComponent();
            Figur = new List<Figure>();
            Figur.Add(new PawnWhite());
            Figur.Add(new СastleWhite());
            Figur.Add(new KnightWhite());
            Figur.Add(new BishopWhite());
            Figur.Add(new KingWhite());
            Figur.Add(new QueenWhite());
            Figur.Add(new PawnBlack());
            Figur.Add(new СastleBlack());
            Figur.Add(new KnightBlack());
            Figur.Add(new BishopBlack());
            Figur.Add(new KingBlack());
            Figur.Add(new QueenBlack());
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Color cust1 = Color.FromArgb(255, 204, 153);
            Color cust2 = Color.FromArgb(182, 103, 200);
            SolidBrush WhiteBrush = new SolidBrush(cust1);
            SolidBrush BlackBrush = new SolidBrush(cust2);
            Graphics gs = this.CreateGraphics();
            Rectangle[,] rect = new Rectangle[8, 8];
            Pen BlackPen = new Pen(cust2);
            Rectangle border = new Rectangle(99, 99, 341, 341);
            
            gs.DrawRectangle(BlackPen, border);
            gs.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gs.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gs.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            
            for (int i = 0; i < 8; i++)                 //заполняем массив
                for (int j = 0; j < 8; j++)
                    rect[i, j] = new Rectangle(50 + ((i + 1) * 50), 50 + ((j + 1) * 50), 50, 50);
                 
            for (int i = 0; i < 8; i++)                 //красим клетки в нужный цвет
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        gs.FillRectangle(WhiteBrush, rect[i, j]);
                    else
                        gs.FillRectangle(BlackBrush, rect[i, j]);
                }
            }

            for (int i = 0; i < 400; i += 50)
                gs.DrawImage(Figur[0].Image, new Rectangle(102 + i, 102 + (50 * 6), 45, 45));
            gs.DrawImage(Figur[1].Image, new Rectangle(102, 102 + (50 * 7), 45, 45));
            gs.DrawImage(Figur[1].Image, new Rectangle(102 + 350, 102 + (50 * 7), 45, 45));
            gs.DrawImage(Figur[2].Image, new Rectangle(102 + 50, 102 + (50 * 7), 45, 45));
            gs.DrawImage(Figur[2].Image, new Rectangle(102 + 300, 102 + (50 * 7), 45, 45));
            gs.DrawImage(Figur[3].Image, new Rectangle(102 + 100, 102 + (50 * 7), 45, 45));
            gs.DrawImage(Figur[3].Image, new Rectangle(102 + 250, 102 + (50 * 7), 45, 45));
            gs.DrawImage(Figur[4].Image, new Rectangle(102 + 150, 102 + (50 * 7), 45, 45));
            gs.DrawImage(Figur[5].Image, new Rectangle(102 + 200, 102 + (50 * 7), 45, 45));

            for (int i = 0; i < 400; i += 50)
                gs.DrawImage(Figur[6].Image, new Rectangle(102 + i, 102 + 50, 45, 45));

            gs.DrawImage(Figur[7].Image, new Rectangle(102, 102 , 45, 45));
            gs.DrawImage(Figur[7].Image, new Rectangle(102 + 350, 102, 45, 45));
            gs.DrawImage(Figur[8].Image, new Rectangle(102 + 50, 102, 45, 45));
            gs.DrawImage(Figur[8].Image, new Rectangle(102 + 300, 102, 45, 45));
            gs.DrawImage(Figur[9].Image, new Rectangle(102 + 100, 102, 45, 45));
            gs.DrawImage(Figur[9].Image, new Rectangle(102 + 250, 102, 45, 45));
            gs.DrawImage(Figur[10].Image, new Rectangle(102 + 150, 102, 45, 45));
            gs.DrawImage(Figur[11].Image, new Rectangle(102 + 200, 102, 45, 45));
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 99 && e.X < 499 && (e.Y > 99 && e.Y < 199 || e.Y > 399 && e.Y < 499))
                contextMenu.Show(this, e.Location);
            contextMenu.PointToClient(new Point(e.X, e.Y));
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
           // Text = e.Location.ToString();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
