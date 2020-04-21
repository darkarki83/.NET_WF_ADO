using FirstAdo.Common;
using FirstAdo.Model;
using FirstAdo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstAdo.Presenter
{
    public class LibraryPresenter : BasePresenter<ISalesView>
    {
        private ISales Model { get; set; }

        public LibraryPresenter(ISales model, ISalesView libraryView)
        {
            Model = model;
            View = libraryView;

            View.LoadForm += LoadForm;
            View.CloseForm += CloseForm;
    }

        public void LoadForm(object sender, EventArgs e)
        {
            //View.AuthorFKs = Model.AuthorFKs;
            //View.BookIDs = Model.BookIDs;
            Model.LoadSales(View.Listview);
        }

        public void CloseForm(object sender, EventArgs e)
        {
            Model.Close();
        }


    }
}
