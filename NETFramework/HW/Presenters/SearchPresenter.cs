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
    public class SearchPresenter : BasePresenter<ISearchFormView>
    {
        public IModel Model { get; set; }

        public SearchPresenter(IModel model, ISearchFormView view)
        {
            Model = model;
            View = view;

            View.ClientIndexCheange += ClientIndexCheange;
            View.OrderIndexCheange += OrderIndexCheange;

            foreach (var item in Model.Context.Clients)       //  add Client list to ComboBox
            {
                View.ComboBoxClient.Items.Add(item.Name);
            }
        }

        public void ClientIndexCheange(object sender, EventArgs e)
        {
            var client = Model.Context.Clients.AsNoTracking().SingleOrDefault(u => u.Name == View.ComboBoxClient.SelectedItem.ToString());

            foreach (var item in Model.Context.Orders)       //  add Client list to ComboBox
            {
                if(item.ClientFk == client.Id)
                    View.ComboBoxOrder.Items.Add(item.Id);
            }
        }

        public async void OrderIndexCheange(object sender, EventArgs e)
        {
            var order = await Model.Context.Orders.FindAsync(View.ComboBoxOrder.SelectedItem);

            View.LabelId.Text = order.Id.ToString();
            var Ordete = order.OrderData.ToString();

            if(order.OrderData != null)
            {
                if(order.OrderData > (DateTime.Now.AddDays(-1)))
                {
                    View.LabelStatus.Text = "In Work";
                }
                else if(order.OrderData > (DateTime.Now.AddDays(-3)))
                {
                    View.LabelStatus.Text = "Go";
                }
                else
                {
                    View.LabelStatus.Text = " In The house ";
                }
                View.LabelDate.Text = order.OrderData.ToString();
            }
            else
            {
                View.LabelDate.Text = "NULL";
                View.LabelStatus.Text = " Do not info Null ";
            }
        }
    }
}
