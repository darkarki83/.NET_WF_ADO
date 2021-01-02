using HW.Common;
using HW.Model;
using HW.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Presenters
{
    public class Presenter : BasePresenter<IFormView>
    {
        public IModel Model { get; set; }

        public Presenter(IModel model, IFormView view)
        {
            Model = model;
            View = view;
            View.LoadList += SeeModel;

        }

        public void SeeModel(object sender, EventArgs e)
        {
            foreach (var part in Model.Context.Parts)
            {
                View.ListBoxx.Items.Add(part.Name);
                // if (part.Id == item.PartFk)
                //     listItem.SubItems.Add(part.Name.ToString());
            }
            
            foreach (var item in Model.Context.PartsInOrders)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = item.Id.ToString();

                listItem.SubItems.Add(item.Part.Name);
                listItem.SubItems.Add(item.OrderFk.ToString());
                listItem.SubItems.Add(item.Count.ToString());
                listItem.SubItems.Add(item.TotalCost.ToString());
                View.ListViewPart.Items.Add(listItem);

                //View.ListBoxx.Items.Add(item.TotalCost);
            }
            //View.ListBoxx.Items.Add(item.TotalCost);
        }



    }
}
