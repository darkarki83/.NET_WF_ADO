using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWAdo2.Model
{
    public interface IAcounting
    {
        SqlConnectionStringBuilder Builder { get; set; }
        SqlConnection Connection { get; set; }
        ConnectionStringSettings Settings { get; set; }

        void LoadAcounting(ComboBox outComboBox, PictureBox outPictureBox, ListBox outListBox);
        void FillListView(ComboBox outComboBox, PictureBox outPictureBox, ListBox outListBox);
        void NewWorker(ComboBox outComboBox, PictureBox outPictureBox, ListBox outListBox);

    }
}
