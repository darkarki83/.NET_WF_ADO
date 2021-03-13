using HW.Common;
using HW.Model;
using HW.Model.Tables;
using HW.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Presenters
{
    public class UserPresenter : BasePresenter<IUserFormView>
    {
        public IModel Model { get; set; }

        public UserPresenter(IModel model, IUserFormView view, ListView listView)
        {
            Model = model;
            View = view;

            View.SelectedIndexChanged += SelectedIndexChanged;
            View.Order += ConfirmOrder;

            foreach (ListViewItem item in listView.Items)   //   from list to list
            {
                ListViewItem listView1 = new ListViewItem();
                listView1.Text = item.SubItems[0].Text;
                listView1.SubItems.Add(item.SubItems[1].Text);
                listView1.SubItems.Add(item.SubItems[2].Text);
                listView1.SubItems.Add(item.SubItems[3].Text);
                View.ListViewOrder.Items.Add(listView1);
            }

            View.Cost.Text = Model.Totalcost.ToString();     // add Cost to textBox

            foreach (var item in Model.Context.Clients)       //  add Client list to ComboBox
            {
                View.ComboClient.Items.Add(item.Name);
            }
        }

        public void SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = Model.Context.Clients.AsNoTracking().SingleOrDefault(u => u.Name == View.ComboClient.SelectedItem.ToString());

            View.Bonus.Text = client.Bonus.ToString();
            View.TotalCost.Text = (Decimal.Parse(View.Cost.Text) * Decimal.Parse(((100 - client.Bonus) / 100).ToString())).ToString();
        }

        public async void ConfirmOrder(object sender, EventArgs e)
        {
            var client = Model.Context.Clients.AsNoTracking().SingleOrDefault(u => u.Name == View.ComboClient.SelectedItem.ToString());

            var newOrder = new Order()
            {
                OrderData = DateTime.Now,
                ClientFk = client.Id
             };
             Model.Context.Orders.Add(newOrder);

             foreach (ListViewItem item in View.ListViewOrder.Items)
             {
                var newPartsInOrder = new PartsInOrder()
                {
                    PartFk = long.Parse(item.SubItems[3].Text),
                    Order = newOrder,
                    Count = int.Parse(item.SubItems[2].Text),
                    TotalCost = Decimal.Parse(View.TotalCost.Text)
                };
                Model.Context.PartsInOrders.Add(newPartsInOrder);
                var count = await Model.Context.PartsCountHave.FirstOrDefaultAsync(u => u.PartFk == newPartsInOrder.PartFk);
                if (count != null)
                {
                    count.Count = count.Count - int.Parse(item.SubItems[2].Text);
                    try
                    {
                        await Model.Context.SaveChangesAsync();
                    }
                    catch
                    {
                        MessageBox.Show("Count was not change", "Not Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            await Model.Context.SaveChangesAsync();
        }
    }
}
