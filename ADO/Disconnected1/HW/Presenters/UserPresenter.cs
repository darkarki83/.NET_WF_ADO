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
    public class UserPresenter : BasePresenter<IUserView>
    {
        public IUserModel Model { get; set; }

        public UserPresenter(IUserModel model, IUserView view)
        {
            Model = model;
            View = view;
            View.FormLoad += LoadForm;
            View.EditEvent += EditEvent;
            View.DeleteEvent += DeleteEvent;
            View.AddEvent += AddEvent;
        }

        public void LoadForm(object sender, EventArgs e)
        {
            Model.LoadForm(View.DataGrid);
        }

        public void EditEvent(object sender, EventArgs e)
        {
            int rowToEdit = View.DataGrid.Rows.GetFirstRow(
            DataGridViewElementStates.Selected);
            if (rowToEdit > -1 && rowToEdit < View.DataGrid.Rows.Count - 1)
            {
                Model.IndexEdit = rowToEdit;
                var editPresenter = new EditPresenter(Model, new EditForm(View.DataGrid.Rows[rowToEdit]));
                if (((Form)editPresenter.View).ShowDialog() == DialogResult.Yes)
                {
                    View.DataGrid.Rows[Model.IndexEdit].Cells[0].Value = Model.Login;
                    View.DataGrid.Rows[Model.IndexEdit].Cells[1].Value = Model.Adress;
                    View.DataGrid.Rows[Model.IndexEdit].Cells[2].Value = Model.Phone;
                    View.DataGrid.Rows[Model.IndexEdit].Cells[3].Value = Model.IsAdmin;
                }
            }
            if(rowToEdit == View.DataGrid.Rows.Count - 1)
            {
                AddEvent(sender, e);
            }
        }

        public void DeleteEvent(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удоление записей", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Model.IndexEdit = View.DataGrid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                Model.DeleteRow(View.DataGrid);
                //View.DataGrid.Rows.Insert(Model.IndexEdit, 1);
            }
        }

        public void AddEvent(object sender, EventArgs e)
        {
            var addPresenter = new AddPresenter(Model, new AddForm());
            ((Form)addPresenter.View).ShowDialog();


        }
    }
}
