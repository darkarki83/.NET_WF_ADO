using HW.Model.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Model
{
    // products
    public abstract class SpatialListView
    {
        public abstract ListView MyList { get; set; }
        public abstract ListView AllListView();
        public abstract ListViewItem ItemListView(ListViewItem item);
    }

    // ConcreteProduct

    public class OrderListView : SpatialListView
    {
        public override ListView MyList { get; set; }

        public OrderListView(ListView myList)
        {
            MyList = myList;
        }

        public override ListView AllListView()
        {
            ListView listView = new ListView();
            foreach (ListViewItem item in MyList.Items)
            {
                ListViewItem listView1 = new ListViewItem();
                listView1.Text = item.SubItems[0].Text;
                listView1.SubItems.Add(item.SubItems[1].Text);
                listView1.SubItems.Add(item.SubItems[2].Text);
                listView1.SubItems.Add(item.SubItems[3].Text);
                listView.Items.Add(listView1);
            }
            return listView;
        }
        public override ListViewItem ItemListView(ListViewItem item)
        {
            ListViewItem listView1 = new ListViewItem();
            listView1.Text = item.SubItems[0].Text;
            listView1.SubItems.Add(item.SubItems[1].Text);
            listView1.SubItems.Add(item.SubItems[2].Text);
            listView1.SubItems.Add(item.SubItems[3].Text);
            return listView1;
        }
    }

    public class CartListView : SpatialListView
    {
        public override ListView MyList { get; set; }

        public CartListView(ListView myList)
        {
            MyList = myList;
        }

        public override ListView AllListView()
        {
            ListView listView = new ListView();
            foreach (ListViewItem item in MyList.Items)
            {
                ListViewItem listView1 = new ListViewItem();
                listView1.Text = item.SubItems[0].Text;
                listView1.SubItems.Add(item.SubItems[1].Text);
                listView1.SubItems.Add(item.SubItems[2].Text);
                listView1.SubItems.Add(item.SubItems[3].Text);
                listView.Items.Add(listView1);
            }
            return listView;
        }
        public override ListViewItem ItemListView(ListViewItem item)
        {
            ListViewItem listView1 = new ListViewItem();
            listView1.Text = item.SubItems[0].Text;
            listView1.SubItems.Add(item.SubItems[1].Text);
            listView1.SubItems.Add(item.SubItems[2].Text);
            listView1.SubItems.Add(item.SubItems[3].Text);
            return listView1;
        }
    }







}
