using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface IFormView : IView
    {
        PictureBox picture { get; set; }
        PictureBox picture1 { get; set; }
        PictureBox picture2 { get; set; }
        PictureBox picture3 { get; set; }
        PictureBox picture4 { get; set; }




    }
}
