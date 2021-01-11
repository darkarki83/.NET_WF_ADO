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
            View.AddToCart += AddToCart;
            View.DeleteFromCart += DeleteFromCart;
            View.Order += AddOrder;
        }

        public  void SeeModel(object sender, EventArgs e)
        {
                foreach(var item in Model.Context.Parts)
                {
                    ListViewItem listItem = new ListViewItem();
                    listItem.Text = item.Id.ToString();

                    listItem.SubItems.Add(item.Name);

                    listItem.SubItems.Add(item.ManufacturerFk.ToString());
                    listItem.SubItems.Add(item.Cost.ToString());
                    View.ListViewPart.Items.Add(listItem);
                }
        }


        public void AddToCart(object sender, EventArgs e)
        {
            bool flag = false;
            if(View.ListViewPart.CanSelect == true)
            {
                ListViewItem listItem = new ListViewItem();
                foreach (ListViewItem item in View.ListViewCart.Items)
                {
                    if(item.SubItems[3].Text == View.ListViewPart.SelectedItems[0].SubItems[0].Text)
                    {
                        item.SubItems[2].Text = (int.Parse(item.SubItems[2].Text) + 1).ToString();
                        View.LabelTotalCost.Text = (Decimal.Parse(View.LabelTotalCost.Text) + Decimal.Parse(item.SubItems[1].Text)).ToString();
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    listItem.Text = View.ListViewPart.SelectedItems[0].SubItems[1].Text;
                    listItem.SubItems.Add(View.ListViewPart.SelectedItems[0].SubItems[3]);
                    listItem.SubItems.Add(1.ToString());
                    listItem.SubItems.Add(View.ListViewPart.SelectedItems[0].SubItems[0].Text);
                    View.ListViewCart.Items.Add(listItem);
                    View.LabelTotalCost.Text = (Decimal.Parse(View.LabelTotalCost.Text) + Decimal.Parse(View.ListViewPart.SelectedItems[0].SubItems[3].Text)).ToString();
                }

            }
        }

        public void DeleteFromCart(object sender, EventArgs e)
        { 
            if (MessageBox.Show("Are you sure to delete this item ??", "Confirm Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int num = int.Parse(View.ListViewCart.SelectedItems[0].SubItems[2].Text);
                decimal dec = Decimal.Parse(View.ListViewCart.SelectedItems[0].SubItems[1].Text);

                View.ListViewCart.Items.Remove(View.ListViewCart.SelectedItems[0]);
                View.LabelTotalCost.Text = (Decimal.Parse(View.LabelTotalCost.Text) - (num * dec)).ToString();
            }
        }

        public void AddOrder(object sender, EventArgs e)
        {
            /* List<ClientOrder> clientOrder = new List<ClientOrder>();
             foreach (ListViewItem item in View.ListViewCart.Items)
             {
                 clientOrder.Add(item);
             } */


            var UserPresenter = new UserPresenter(this.Model, new UserFormView(), View.ListViewCart);
            ((Form)UserPresenter.View).ShowDialog();
        }
    }
}
