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
            View.SortByFamily += SortByFamily;
            View.SortByPhone += SortByPhone;
            View.SortByName += SortByName;
            View.Add += Add;
            View.Edit += Edit;
            View.Delete += Delete;
            Model.SaveAfterEdit += SaveAfterEdit;
        }

        public void LoadForm(object sender, EventArgs e)
        {
            Model.LoadForm(View.ListViewForm);
        }
        public void SortByFamily(object sender, EventArgs e)
        {
            Model.SortByFamily(View.ListViewForm);
        }
        public void SortByPhone(object sender, EventArgs e)
        {
            Model.SortByPhone(View.ListViewForm);
        }
        public void SortByName(object sender, EventArgs e)
        {
            Model.SortByName(View.ListViewForm);
        }
        public void Add(object sender, EventArgs e)
        {
            Model.Id = 0;
            var editPresenter = new EditPresenter(Model, new EditForm());
            ((Form)editPresenter.View).ShowDialog();
        }
        public void Edit(object sender, EventArgs e)
        {
            Model.IndexSelected(View.ListViewForm);
            var editPresenter = new EditPresenter(Model, new EditForm());
            ((Form)editPresenter.View).ShowDialog();
        }
        public void Delete(object sender, EventArgs e)
        {
            Model.Delete(View.ListViewForm);
        }
        public void SaveAfterEdit(object sender, EventArgs e)
        {
            View.ListViewForm.Items[Model.SelectedIndex].Text = Model.FirstName;
            View.ListViewForm.Items[Model.SelectedIndex].SubItems[1].Text = Model.LastName;
            View.ListViewForm.Items[Model.SelectedIndex].SubItems[2].Text = Model.PhoneNumber;
            View.ListViewForm.Items[Model.SelectedIndex].SubItems[3].Text = Model.Adress;


        }



    }
}
