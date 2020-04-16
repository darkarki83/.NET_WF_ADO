using HW6._2.DomainModel;
using HW6._2.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6._2
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

            var drawPresenter = new DrawPresenter(new DrawModel(), new MainForm()); 
            Application.Run((Form)drawPresenter.View);
        }
    }
}
