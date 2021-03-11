using HW.Presenters;
using HW.Views;
using HW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW
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

            /*
            var adminPresenter = new AdminPresenter(new MyModel(new MyStoreContext()), new AdminForm());
            Application.Run((Form)adminPresenter.View);*/

            
            Presenter presenter = new Presenter(new MyModel(new MyStoreContext()), new MainForm());
            Application.Run((Form)presenter.View);
        }
    }
}
