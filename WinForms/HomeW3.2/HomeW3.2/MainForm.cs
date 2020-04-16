using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW3._2
{
    /*2. Фирма продает составляющие компьютера. Первая
         форма отвечает за учет продаж, вторая за добавление
         и редактирование составляющих.
         Первая форма:
         Список, выпадающий список, текстовое поле, кнопка
         вызова второй формы. В выпадающем списке появляются
         наименования всех товаров, которые в наличии
         в магазине. Пользователь выбирает товар, в текстовом
         окне, которое нельзя редактировать, появляется цена.
         Пользователь нажимает «добавить» и товар добавляется
         в список продаж. Также должно быть окошко, которое
         выводит общую стоимость.
         Вторая форма:
         Информация о комплектующих (наименование, характеристика,
         описание и цена) вводится в текстовые
         поля; в список добавляется текстовая строка, содержащая
         информацию о товаре, кроме цены, цена в списке
         не видна, но содержится; также комплектующие можно
         редактировать.*/
    public partial class MainForm : Form
    {
        public Dictionary<string, int> Map { get; set; }

       // public AddNewProduct newAdd { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Map = new Dictionary<string, int>();
            Map.Add("auto", 258);
            Map.Add("doihatsu", 328);
            Map.Add("subaru", 120);
            allItemBox.SelectedIndex = 0;
        }



        private void allItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = allItemBox.SelectedIndex;
            string key = allItemBox.Items[selectedIndex].ToString();
            int result = 0;

            foreach (var pair in Map)
            {
                if(key == pair.Key)
                {
                    result = Map[key];
                    break;
                }
            }

            textPrice.Text = result.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int selectedIndex = allItemBox.SelectedIndex;
            string key = string.Empty;

            if (selectedIndex != - 1)
            {
                key = allItemBox.Items[selectedIndex].ToString();
                listBasket.Items.Add(allItemBox.Items[selectedIndex].ToString());
                if (textBasketPrice.Text.Length > 0)
                    textBasketPrice.Text = (int.Parse(textBasketPrice.Text) + Map[key]).ToString();
                else
                    textBasketPrice.Text = Map[key].ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBasket.SelectedIndex;
            if (selectedIndex != -1)
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to remove product", "Delete product", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    textBasketPrice.Text = (int.Parse(textBasketPrice.Text) - Map[listBasket.Items[selectedIndex].ToString()]).ToString();
                    listBasket.Items.RemoveAt(selectedIndex);
                }
            }
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            var newAdd = new AddNewProduct();
            newAdd.Owner = this;
            newAdd.ShowDialog();
            newAdd.BringToFront();
            allItemBox.Items.Clear();
            bool flag = false;
            string key = string.Empty;
            textBasketPrice.Text = string.Empty;
            foreach (var item in Map)
            {
                allItemBox.Items.Add(item.Key);
            }
            for (int i = 0; i < listBasket.Items.Count; i++)
            {
                for (int j = 0; j < allItemBox.Items.Count; j++)
                {
                    if(listBasket.Items[i] == allItemBox.Items[j])
                    {
                        flag = true;
                        key = allItemBox.Items[j].ToString();
                        if (textBasketPrice.Text.Length > 0)
                            textBasketPrice.Text = (int.Parse(textBasketPrice.Text) + Map[key]).ToString();
                        else
                            textBasketPrice.Text = Map[key].ToString();
                        break;
                    }
                }
                if(!flag)
                {

                    listBasket.Items.RemoveAt(i);
                    i--;
                }
                flag = false;
            }

            allItemBox.SelectedIndex = 0;
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            allItemBox.Items.Clear();
        }
    }
}
