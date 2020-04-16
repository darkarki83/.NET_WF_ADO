using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smile
{
    /*5. Разработать приложение «убегающий статик». Суть
         приложения: на форме расположен статический элемент
         управления («статик»). Пользователь пытается подвести
         курсор мыши к «статику», и, если курсор находиться близко
         со статиком, элемент управления «убегает». Предусмот-
         реть перемещение «статика» только в пределах формы.*/
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChoiceOne(object sender, MouseEventArgs e)
        {
            if (e.Location.X + 25 >= smilic.Location.X && (e.Location.Y < smilic.Location.Y + 72
                    && e.Location.Y > smilic.Location.Y - 30) && e.Location.X < smilic.Location.X + 80)
            {
                Point point = smilic.Location;
                point.X = point.X + 10;
                smilic.Location = point;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
           // Text = e.Location.ToString();

            Text = smilic.Location.ToString() + "Height "+ smilic.Height.ToString() + "Widht " + smilic.Width.ToString();

            if (smilic.Location.X < Size.Width - 80 && smilic.Location.X > 5
                && smilic.Location.Y < Size.Height - 100 && smilic.Location.Y > 5)
            {
                ChoiceOne(sender, e);

                if (e.Location.X <= smilic.Location.X + 110 && (e.Location.Y < smilic.Location.Y + 72
                    && e.Location.Y > smilic.Location.Y - 30) && e.Location.X - 74 > smilic.Location.X + 5)
                {
                    Point point = smilic.Location;
                    point.X = point.X - 10;
                    smilic.Location = point;
                }
                else if (e.Location.Y + 40 >= smilic.Location.Y && (e.Location.X < smilic.Location.X + 60
                    && e.Location.X > smilic.Location.X - 18) && e.Location.Y < smilic.Location.Y + 80)
                {
                    Point point = smilic.Location;
                    point.Y = point.Y + 10;
                    smilic.Location = point;
                }
                else if (e.Location.Y - 110 <= smilic.Location.Y && (e.Location.X < smilic.Location.X + 60
                    && e.Location.X > smilic.Location.X - 18) && e.Location.Y > smilic.Location.Y + 50)
                {
                    Point point = smilic.Location;
                    point.Y = point.Y - 10;
                    smilic.Location = point;
                }
            }
            else
            {
                if (smilic.Location.Y > 380
                     && 300 < smilic.Location.X)
                {
                    Point point = smilic.Location;
                    point.Y = point.Y - 100;
                    point.X = point.X - 100;
                    smilic.Location = point;
                }
                else if (smilic.Location.Y > 380
                    && 300 > smilic.Location.X)
                {
                    Point point = smilic.Location;
                    point.Y = point.Y - 100;
                    point.X = point.X + 100;
                    smilic.Location = point;
                }
                else if (smilic.Location.Y < 15
                    && 300 > smilic.Location.X)
                {
                    Point point = smilic.Location;
                    point.Y = point.Y + 100;
                    point.X = point.X + 100;
                    smilic.Location = point;
                }
                else if (smilic.Location.Y < 15
                    && 300 < smilic.Location.X)
                {
                    Point point = smilic.Location;
                    point.Y = point.Y + 100;
                    point.X = point.X - 100;
                    smilic.Location = point;
                }
                else if (e.Location.X <= smilic.Location.X + 86 && (e.Location.Y < smilic.Location.Y + 72
                    && e.Location.Y > smilic.Location.Y - 30) && e.Location.X - 74 > smilic.Location.X + 5)
                {
                    Point point = smilic.Location;
                    point.Y = point.Y - 100;
                    point.X = point.X + 100;
                    smilic.Location = point;
                }
                else if (e.Location.Y + 30 >= smilic.Location.Y && (e.Location.X < smilic.Location.X + 60
                    && e.Location.X > smilic.Location.X - 20) && e.Location.Y < smilic.Location.Y + 80)
                {
                    Point point = smilic.Location;
                    point.X = point.X - 100;
                    point.Y = point.Y - 100;
                    if (point.X > 0)
                        smilic.Location = point;
                    else
                    {
                        point.X = point.X + 200;
                        smilic.Location = point;
                    }
                }
                else if (e.Location.Y - 90 <= smilic.Location.Y && (e.Location.X < smilic.Location.X + 60
                    && e.Location.X > smilic.Location.X - 20) && e.Location.Y > smilic.Location.Y + 150)
                {
                    Point point = smilic.Location;
                    point.X = point.X + 100;
                    point.Y = point.Y + 100;
                    smilic.Location = point;
                }
            }
        }
    }
}
