using HW6._2.Common;
using HW6._2.DomainModel;
using HW6._2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6._2.Presenters
{
    public class DrawPresenter : BasePresenter<IDrawViews>
    {
        public IDrawModel DrawModel { get; set; } 

        public DrawPresenter(IDrawModel drawModel, IDrawViews drawViews)
        {
            DrawModel = drawModel;
            this.View = drawViews;

            View.MouseClickForm += MouseClickToForm;
            View.ToolPointClick += ToolPointClicks;
            View.ToolLineClick += ToolLineClicks;
            View.ToolCircleClick += ToolCircleClicks;
            View.ToolDelete += ToolDeleteClick;
            View.MenuItemColor += ChangeColor;
            View.DiameterClick += DiameterClicks;
        }

        public void MouseClickToForm(object sender, MouseEventArgs e)
        {
            if (DrawModel.PointStart)
            {
                DrawModel.NewPoints(sender, e);
                View.SuperPoints = DrawModel.SuperPoints;
            }
            else if (DrawModel.LineStart)
            {
                DrawModel.NewLines(sender, e);
                View.OnePoint = DrawModel.OnePoint;
                View.Lines = DrawModel.Lines;

            }
            else if (DrawModel.CircleStart)
            {
                DrawModel.NewCircle(sender, e);
                View.Circles = DrawModel.Circles;
            }
        }

        public void ToolPointClicks(object sender, EventArgs e)
        {
            DrawModel.StopPrimitiv();
            DrawModel.PointStart = true;
            EqualizeStarts();
        }

        public void ToolLineClicks(object sender, EventArgs e)
        {
            DrawModel.StopPrimitiv();
            DrawModel.LineStart = true;
            EqualizeStarts();
        }

        public void ToolCircleClicks(object sender, EventArgs e)
        {
            DrawModel.StopPrimitiv();
            DrawModel.CircleStart = true;
            EqualizeStarts();
        }

        public void ToolDeleteClick(object sender, EventArgs e)
        {
            DrawModel.DeleteAll();
            View.SuperPoints = DrawModel.SuperPoints;
            View.Lines = DrawModel.Lines;
            View.Circles = DrawModel.Circles;
            View.HeightCircle = DrawModel.HeightCircle;
            View.OnePoint = DrawModel.OnePoint;
            DrawModel.StopPrimitiv();
            EqualizeStarts();
        }

        public void ChangeColor(object sender, EventArgs e)
        {
            DrawModel.menuColorClick();
            View.Brush = DrawModel.Brush;
            View.BluePen = DrawModel.BluePen;
        }

        public void EqualizeStarts()
        {
            View.PointStart = DrawModel.PointStart;
            View.LineStart = DrawModel.LineStart;
            View.CircleStart = DrawModel.CircleStart;
        }
        public void DiameterClicks(object sender, EventArgs e)
        {
            DrawModel.HeightCircle = View.HeightCircle;
            var diameterPresenter = new DiameterPresenter(DrawModel, new DiameterForm());
            ((Form)diameterPresenter.View).ShowDialog();
            View.HeightCircle = DrawModel.HeightCircle;
        }
    }
}
