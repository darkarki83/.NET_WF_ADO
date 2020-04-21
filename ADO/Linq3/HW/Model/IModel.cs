using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Model
{
    public interface IModel
    {
        List<Book> BookTable { get; set; }
        List<Phone> PhoneTable { get; set; }
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Adress { get; set; }
        int SelectedIndex { get; set ; }
        event EventHandler SaveAfterEdit;
        void LoadForm(ListView listViewForm);
        void SortByFamily(ListView listViewForm);
        void SortByPhone(ListView listViewForm);
        void SortByName(ListView listViewForm);
        void IndexSelected(ListView listViewForm);
        void Delete(ListView listViewForm);
        void Save();
    }
}
