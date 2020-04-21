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
            View.LoadForm += LoadForm;
            View.AddList += AddList;
            View.EditList += EditList;
            View.DeleteFromList += DeleteFromList;
            Model.Update += Update;

        }

        public void LoadForm(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in Model.Context.Users)
            {
                View.ListView.Items.Add(new ListViewItem());
                View.ListView.Items[i].SubItems.Add(item.Login);
                View.ListView.Items[i].SubItems.Add(item.Password);
                i++;
            }
            i = 0;
            foreach (var item in Model.Context.Informations)
            {
                View.ListView.Items[i].Text = item.Id.ToString();
                View.ListView.Items[i].SubItems.Add(item.Adress);
                View.ListView.Items[i].SubItems.Add(item.Phone);
                View.ListView.Items[i].SubItems.Add(item.Admin.ToString());
                i++;
            }
            
        }
        public void AddList(object sender, EventArgs e)
        {
            Model.Id = View.ListView.Items.Count + 1;
            var presenterEdit = new PresenterEdit(Model, new FormEdit());
            ((Form)presenterEdit.View).ShowDialog();
        }
        public void EditList(object sender, EventArgs e)
        {
            Model.Id = int.Parse(View.ListView.Items[View.ListView.SelectedIndices[0]].Text);
            var presenterEdit = new PresenterEdit(Model, new FormEdit());
            ((Form)presenterEdit.View).ShowDialog();
        }

        public void Update(object sender, EventArgs e)
        {
            var listItem = new ListViewItem();
            Information info = Model.Context.Informations.Find(Model.Id);
            int? IdFK = null;
            if (info != null)
            {
                IdFK = info.UserFK;
                User user = Model.Context.Users.Find(IdFK);
                if (user != null)
                {
                    listItem.SubItems.Add(user.Login);
                    listItem.SubItems.Add(user.Password);
                }
                listItem.Text = info.Id.ToString();
                listItem.SubItems.Add(info.Adress);
                listItem.SubItems.Add(info.Phone);
                listItem.SubItems.Add(info.Admin.Value.ToString());

                if (Model.Id <= View.ListView.Items.Count)
                    View.ListView.Items[Model.Id - 1] = listItem;
                else
                    View.ListView.Items.Add(listItem);
            }
        }
        public void DeleteFromList(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить записи?", "Удаление записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Model.Id = int.Parse(View.ListView.Items[View.ListView.SelectedIndices[0]].Text);
            Model.DeleteItem();
            View.ListView.Items.RemoveAt(Model.Id - 1);
        }


    }
}
