using FirstAdo.Model;
using FirstAdo.Presenter;
using FirstAdo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstAdo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var libraryPresenter = new LibraryPresenter(new Sales(), new SalesForm());
            Application.Run((Form)libraryPresenter.View);
        }
    }
}
