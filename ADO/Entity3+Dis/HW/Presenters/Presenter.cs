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
            View.AuthorSearch += AuthorSearch;
            View.PressSearch += PressSearch;
            View.AuthorPressSearch += AuthorPressSearch;
        }

        public void LoadForm(object sender, EventArgs e)
        {
            foreach (var item in Model.Context.Authors)
                View.ComboAuthor.Items.Add(item.Name);
            View.ComboAuthor.SelectedIndex = 0;
            foreach (var item in Model.Context.Presses)
                View.ComboPress.Items.Add(item.Name);
            View.ComboPress.SelectedIndex = 0;
        }
        public void AuthorSearch(object sender, EventArgs e)
        {
            View.ListBooks.Items.Clear();
            int i = 0;
            foreach(var item in Model.Context.Books)
            {
                if (item.AuthorFK == View.ComboAuthor.SelectedIndex + 1)
                {
                    View.ListBooks.Items.Add(new ListViewItem());
                    View.ListBooks.Items[i].Text = item.Name;
                    View.ListBooks.Items[i].SubItems.Add(item.Author.Name);
                    View.ListBooks.Items[i].SubItems.Add(item.Pages.ToString());
                    View.ListBooks.Items[i].SubItems.Add(item.Price.ToString());
                    View.ListBooks.Items[i].SubItems.Add(item.Press.Name);
                    i++;
                }
            }
        }
        public void PressSearch(object sender, EventArgs e)
        {
            View.ListBooks.Items.Clear();
            int i = 0;
            foreach (var item in Model.Context.Books)
            {
                if (item.PressFK == View.ComboPress.SelectedIndex + 1)
                {
                    View.ListBooks.Items.Add(new ListViewItem());
                    View.ListBooks.Items[i].Text = item.Name;
                    View.ListBooks.Items[i].SubItems.Add(item.Author.Name);
                    View.ListBooks.Items[i].SubItems.Add(item.Pages.ToString());
                    View.ListBooks.Items[i].SubItems.Add(item.Price.ToString());
                    View.ListBooks.Items[i].SubItems.Add(item.Press.Name);
                    i++;
                }
            }
        }
        public void AuthorPressSearch(object sender, EventArgs e)
        {
            View.ListBooks.Items.Clear();
            int i = 0;
            foreach (var item in Model.Context.Books)
            {
                if (item.AuthorFK == View.ComboAuthor.SelectedIndex + 1 && item.PressFK == View.ComboPress.SelectedIndex + 1)
                {
                    View.ListBooks.Items.Add(new ListViewItem());
                    View.ListBooks.Items[i].Text = item.Name;
                    View.ListBooks.Items[i].SubItems.Add(item.Author.Name);
                    View.ListBooks.Items[i].SubItems.Add(item.Pages.ToString());
                    View.ListBooks.Items[i].SubItems.Add(item.Price.ToString());
                    View.ListBooks.Items[i].SubItems.Add(item.Press.Name);
                    i++;
                }
            }
        }
    }
}
