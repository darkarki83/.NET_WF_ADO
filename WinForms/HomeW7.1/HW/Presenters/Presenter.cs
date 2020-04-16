using HW.Common;
using HW.Model;
using HW.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Presenters
{
    public class Presenter : BasePresenter<IFormView>
    {
        public IModel Model { get; set; }

        public Presenter(IModel model, IFormView view)
        {
            Model = model;
            View = view;
            View.ClickStart += ClickStart;
            View.DrawG += DrawG;
    }
        public void ClickStart(object sender, EventArgs e)
        {
            Model.Height = View.MyPictureBox.Height; //высота пикчер бокс
            Model.Width = View.MyPictureBox.Width;   // ширена пикчер бокс
            Model.ClickStart();
            View.PictureBoxHeight = Model.Height;
            View.PictureBoxWidth = Model.Width;
            View.HeightMidle = Model.HeightMidle;
            View.WidthMidle = Model.WidthMidle;

            
        }

        public void DrawG(object sender, EventArgs e)
        {
            try
            {
                Model.A = int.Parse(View.TextBoxA.Text);
                Model.B = int.Parse(View.TextBoxB.Text);
                Model.C = int.Parse(View.TextBoxC.Text);
            }
            catch (Exception)
            {
                //
            }
            View.A = Model.A;
            View.B = Model.B;
            View.C = Model.C;
            View.Begin = Model.Begin;
            View.Finish = Model.Finish;
            View.Step = Model.Step;
        }
    }
}
