using HWAdo2.Model;
using HWAdo2.Presenters;
using HWAdo2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWAdo2
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
            var acountingPresenter = new AcountingPresenter(new Acounting(), new AcountingForm());
            Application.Run((Form)acountingPresenter.View);
        }
    }
}
