using HW6._2.Common;
using HW6._2.DomainModel;
using HW6._2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2.Presenters
{
    public class DiameterPresenter : BasePresenter<IDiameterView>
    {
        public IDrawModel DrawModel { get; set; }
        public DiameterPresenter(IDrawModel drawModel, IDiameterView drawViews)
        {
            DrawModel = drawModel;
            this.View = drawViews;
            View.LoadDiamiter += Load;
            View.OkClick += OkClickD;
        }
        public void Load(object sender, EventArgs e)
        {
            View.NumericDiametr.Value = DrawModel.HeightCircle;
        }
        public void OkClickD(object sender, MyEvent e)
        {
            DrawModel.NewHeightCircle(e.MyDiameter);
        }
    }
}
