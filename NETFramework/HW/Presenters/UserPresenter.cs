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
    public class UserPresenter : BasePresenter<IUserFormView>
    {
        public IModel Model { get; set; }

        public UserPresenter(IModel model, IUserFormView view, ListView listView)
        {
            Model = model;
            View = view;
            View.Order += ConfirmOrder;
            foreach (ListViewItem item in listView.Items)
            {
                ListViewItem listView1 = new ListViewItem();
                listView1.Text = item.SubItems[0].Text;
                listView1.SubItems.Add(item.SubItems[1].Text);
                listView1.SubItems.Add(item.SubItems[2].Text);
                listView1.SubItems.Add(item.SubItems[3].Text);
                View.ListViewOrder.Items.Add(listView1);
            }

            foreach (var item in Model.Context.Clients)
            {
                ListViewItem listView1 = new ListViewItem();
                listView1.Text = item.Id.ToString();
                listView1.SubItems.Add(item.Name);
                listView1.SubItems.Add(item.Bonus.ToString());
                listView1.SubItems.Add(item.Adrress);
                View.ListViewOrder.Items.Add(listView1);
            }
            foreach (var item in Model.Context.Orders)
            {
                ListViewItem listView1 = new ListViewItem();
                listView1.Text = item.Id.ToString();
                listView1.SubItems.Add(item.ClientFk.ToString());
                View.ListViewOrder.Items.Add(listView1);
            }
            foreach (var item in Model.Context.PartsInOrders)
            {
                ListViewItem listView1 = new ListViewItem();
                listView1.Text = item.Id.ToString();
                listView1.SubItems.Add(item.PartFk.ToString());
                listView1.SubItems.Add(item.OrderFk.ToString());
                listView1.SubItems.Add(item.Count.ToString());
                listView1.SubItems.Add(item.TotalCost.ToString());
                View.ListViewOrder.Items.Add(listView1);
            }



            /*   var newAuthor = new Author() { Name = "Джеффри Рихтер" };
            context.Authors.Add(newAuthor);
            var newBook = new Book()
            {
                Author = newAuthor,
                Name = "CLR via C#",
                Pages = 500,
                Price = 250.00M,
                Press = context.Presses.FirstOrDefault(p => p.Name == "АСТ")
            };
            context.Books.Add(newBook);


             
             */


        }

        public void ConfirmOrder(object sender, EventArgs e)
        {

            
            var client = new Client()
            {
                Name = View.TName.Text,
                Adrress = View.TDdress.Text,
                Bonus = 15
            };
            Model.Context.Clients.Add(client);

             var newOrder = new Order()
             {
                 OrderData = null,
                 Client = client
             };
             Model.Context.Orders.Add(newOrder);
            
             foreach (ListViewItem item in View.ListViewOrder.Items)
             {
                 var newPartsInOrder = new PartsInOrder()
                 {
                     PartFk = long.Parse(item.SubItems[3].Text),
                     Order = newOrder,
                     Count = int.Parse(item.SubItems[2].Text),
                     TotalCost = null
                 };
                 Model.Context.PartsInOrders.Add(newPartsInOrder);
             }

            Model.Context.SaveChangesAsync();

            /*

                        var newAuthor = new Author() { Name = "Джеффри Рихтер" };
                        context.Authors.Add(newAuthor);
                        var newBook = new Book()
                        {
                            Author = newAuthor,
                            Name = "CLR via C#",
                            Pages = 500,
                            Price = 250.00M,
                            Press = context.Presses.FirstOrDefault(p => p.Name == "АСТ")
                        };
                        context.Books.Add(newBook);*/
        }

    }
}
