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
    public class PresenterMySales : BasePresenter<IFormView>
    {
        public IModel Model { get; set; }

        public PresenterMySales(IModel model, IFormView view)
        {
            Model = model;
            View = view;
            View.LoadForm += LoadForm;
            View.IndexChanged += UpgradeListTable;
        }

        public void LoadForm(object sender, EventArgs e)
        {
            UpgradeListTable(sender, e);
        }

        public void UpgradeListTable(object sender, EventArgs e)
        {
            int i = 0;
     
            View.ListTable.Columns.Clear();
            View.ListTable.Items.Clear();
            if (View.BoxTable.SelectedIndex == 0)
            {
                View.ListTable.Columns.Add("Id");
                View.ListTable.Columns.Add("FirstName");
                View.ListTable.Columns.Add("LastName");
                View.ListTable.Columns[0].Width = 180;
                View.ListTable.Columns[1].Width = 180;
                View.ListTable.Columns[2].Width = 180;

                foreach (var item in Model.Context.Buyers)
                {
                    View.ListTable.Items.Add(new ListViewItem());
                    View.ListTable.Items[i].Text = item.Id.ToString();
                    View.ListTable.Items[i].SubItems.Add(item.FirstName);
                    View.ListTable.Items[i].SubItems.Add(item.LastName);
                    i++;
                }
            }
            else if (View.BoxTable.SelectedIndex == 1)
            {
                View.ListTable.Columns.Add("Id");
                View.ListTable.Columns.Add("FirstName");
                View.ListTable.Columns.Add("LastName");
                View.ListTable.Columns[0].Width = 180;
                View.ListTable.Columns[1].Width = 180;
                View.ListTable.Columns[2].Width = 180;

                foreach (var item in Model.Context.Sellers)
                {
                    View.ListTable.Items.Add(new ListViewItem());
                    View.ListTable.Items[i].Text = item.Id.ToString();
                    View.ListTable.Items[i].SubItems.Add(item.FirstName);
                    View.ListTable.Items[i].SubItems.Add(item.LastName);
                    i++;
                }
            }
            else if (View.BoxTable.SelectedIndex == 2)
            {
                View.ListTable.Columns.Add("Id");
                View.ListTable.Columns.Add("SaleAmount");
                View.ListTable.Columns.Add("SaleDate");
                View.ListTable.Columns.Add("BuyerFK");
                View.ListTable.Columns.Add("SellerFK");
                View.ListTable.Columns[0].Width = 40;
                View.ListTable.Columns[1].Width = 180;
                View.ListTable.Columns[2].Width = 180;
                View.ListTable.Columns[3].Width = 60;
                View.ListTable.Columns[4].Width = 60;

                foreach (var item in Model.Context.Sales)
                {
                    View.ListTable.Items.Add(new ListViewItem());
                    View.ListTable.Items[i].Text = item.Id.ToString();
                    View.ListTable.Items[i].SubItems.Add(item.SaleAmount.ToString());
                    View.ListTable.Items[i].SubItems.Add(item.SaleDate.ToString());
                    View.ListTable.Items[i].SubItems.Add(item.BuyerFK.ToString());
                    View.ListTable.Items[i].SubItems.Add(item.SellerFK.ToString());
                    i++;
                }
            }
        }




    }
}
