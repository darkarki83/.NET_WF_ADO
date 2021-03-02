using HW.Common;
using HW.Model;
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
    public class Presenter : BasePresenter<IFormView>
    {
        public IModel Model { get; set; }

        public Presenter(IModel model, IFormView view)
        {
            Model = model;
            View = view;

            // Первичная загрузка окна => primary load window async
            View.LoadList += LoadList;

            // click to button AddToCart
            View.AddToCart += AddToCart;

            // click to button DeleteFromCart
            View.DeleteFromCart += DeleteFromCart;


            View.Order += AddOrder;

            // Подгружаем из БД не только сами объекты, но и
            // вложенные коллекции дочерних для них объектов
            Model.Context.Parts.Load();
            Model.Context.Orders.Load();
            Model.Context.PartsInOrders.Load();
            Model.Context.PartsCountHave.Load();
            Model.Context.Clients.Load();
            Model.Context.Manufacturers.Load();
        }

        // Первичная загрузка окна => primary load window async
        public async void LoadList(object sender, EventArgs e)
        {
            foreach (var item in Model.Context.Parts)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = item.Id.ToString();        // Убрать в релизе
                listItem.SubItems.Add(item.Name);

                var manufacturers = await Model.Context.Manufacturers.FindAsync(item.ManufacturerFk);
                listItem.SubItems.Add(manufacturers.Name);

                listItem.SubItems.Add(item.Cost.ToString());

                /* плохо  1 in 1 */
                var counts = await Model.Context.PartsCountHave.FindAsync(item.Id);
                listItem.SubItems.Add(counts.Count.ToString());

                View.ListViewPart.Items.Add(listItem);
            }
        }

        /*static async Task WaitAndApologizeAsync()  // примеры как добавить manufacturer по ManufacturerFk
        {
            foreach (var item in Model.Context.Parts)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = item.Id.ToString();

                listItem.SubItems.Add(item.Name);

                //не работает и у всех трех одна ошибка открыт поток
                foreach (var manufacturer in Model.Context.Manufacturers)
                {
                    if(manufacturer.Id == item.ManufacturerFk)
                    {
                        listItem.SubItems.Add(manufacturer.Name);
                    }
                }

                var manufacturers = Model.Context.Manufacturers.AsNoTracking().SingleOrDefault(u => u.Id == item.ManufacturerFk);
        
                var manufacturers = Model.Context.Manufacturers.Find(item.ManufacturerFk);

                listItem.SubItems.Add(manufacturers.Name);

                listItem.SubItems.Add(item.Cost.ToString());
                View.ListViewPart.Items.Add(listItem);
            }
        }*/

        public void AddToCart(object sender, EventArgs e)
        {
            // is add this item first time 
            bool flag = false;                                                              

            // Count Elements in ListViewPart (есть ли товар на складе)
            int countLeft = int.Parse(View.ListViewPart.SelectedItems[0].SubItems[4].Text); 

            if (countLeft > 0)
            {
                // если выбрал товар из ListView ListViewPart
                if (View.ListViewPart.CanSelect == true)  
                {
                    // пробигаю по заказу смотрю есть ли такая
                    // деталь в ListView ListViewCart
                    foreach (ListViewItem item in View.ListViewCart.Items)
                    {
                        // сравнить ID
                        if (item.SubItems[3].Text == View.ListViewPart.SelectedItems[0].SubItems[0].Text)  // есть
                        {
                            // add +1 to count in order
                            item.SubItems[2].Text = (int.Parse(item.SubItems[2].Text) + 1).ToString();  
                            
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        // if added first time this parts  function AddNewPart описана ниже
                        AddNewPart(View.ListViewPart.SelectedItems[0]);
                    }

                    //  add to lable LabelTotalCost total cost
                    View.LabelTotalCost.Text = (Decimal.Parse(View.LabelTotalCost.Text) + Decimal.Parse(View.ListViewPart.SelectedItems[0].SubItems[3].Text)).ToString();
                    // add ((count = count - 1)) in ListViewPart.SelectedItems[0]
                    View.ListViewPart.SelectedItems[0].SubItems[4].Text = (countLeft - 1).ToString();
                }
            }
        }

        private void AddNewPart(ListViewItem item)  //  if added first time this parts (async не очень работает)
        {
            ListViewItem listItem = new ListViewItem();

            listItem.Text = View.ListViewPart.SelectedItems[0].SubItems[1].Text;        // 1) name 
            listItem.SubItems.Add(View.ListViewPart.SelectedItems[0].SubItems[3]);      // 2) cost
            listItem.SubItems.Add(1.ToString());                                        // 3) count = 1 первое добовление
            listItem.SubItems.Add(View.ListViewPart.SelectedItems[0].SubItems[0].Text); // 4) Id part
            View.ListViewCart.Items.Add(listItem);                                      // add to ListViewCart
        }

        public void DeleteFromCart(object sender, EventArgs e)
        { 
            if (MessageBox.Show("Are you sure to delete this item?", "Confirm Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int num = int.Parse(View.ListViewCart.SelectedItems[0].SubItems[2].Text);
                decimal dec = Decimal.Parse(View.ListViewCart.SelectedItems[0].SubItems[1].Text);

                // возврацаем количество parts in ListViewPart
                foreach (ListViewItem item in View.ListViewPart.Items)
                {
                   // if ID equels
                    if (int.Parse(View.ListViewCart.SelectedItems[0].SubItems[3].Text) == int.Parse(item.SubItems[0].Text))  
                    {
                        // возврацаем количество
                        item.SubItems[4].Text = (int.Parse(item.SubItems[4].Text) + int.Parse(View.ListViewCart.SelectedItems[0].SubItems[2].Text)).ToString();
                        break;
                    }
                }
                // delete element from ListViewCart
                View.ListViewCart.Items.Remove(View.ListViewCart.SelectedItems[0]);
                // delete From Total Cost 
                View.LabelTotalCost.Text = (Decimal.Parse(View.LabelTotalCost.Text) - (num * dec)).ToString();
            }
        }

        public void AddOrder(object sender, EventArgs e)
        {
            Model.TempOrder = new Order();

            Model.TempOrder.OrderData = DateTime.Now;

            /* List<ClientOrder> clientOrder = new List<ClientOrder>();*/
            /*foreach (ListViewItem item in View.ListViewCart.Items)
             {
                Model.TempOrder.Parts.Add(item.)
                 clientOrder.Add(item);
             } 

            Model.TempOrder.Parts.Add()*/



            var UserPresenter = new UserPresenter(this.Model, new UserFormView(), View.ListViewCart);
            ((Form)UserPresenter.View).ShowDialog(); 
        }
    }
}
