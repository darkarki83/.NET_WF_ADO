using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home5._3.Models
{
    public interface IModel
    {

        RichTextBox RichText { get; set; }

        string Text { get; set; }

        void Open();

        void Save();

        void SaveAs();

        void Color();

        void Font();
    }
}
