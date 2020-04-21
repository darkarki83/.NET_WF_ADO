using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Model
{
    public class MyModel : IModel
    {
        private List<Book> bookTable;
        private List<Phone> phoneTable;
        private int id;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string adress;
        private int selectedIndex;
        public event EventHandler SaveAfterEdit;

        public MyModel()
        {

            PhoneTable = new List<Phone>();
            PhoneTable.Add(new Phone(1, "+3801234"));
            PhoneTable.Add(new Phone(2, "+3802235"));
            PhoneTable.Add(new Phone(3, "+3803236"));
            PhoneTable.Add(new Phone(4, "+3804237"));
            PhoneTable.Add(new Phone(5, "+3805238"));
            PhoneTable.Add(new Phone(6, "+3806239"));
            PhoneTable.Add(new Phone(7, "+3807230"));

            BookTable = new List<Book>();
            BookTable.Add(new Book(1, "Artem", "Krol", 1, "zabolotnogo 36"));
            BookTable.Add(new Book(2, "Artem", "Krol", 2, "zabolotnogo 36"));
            BookTable.Add(new Book(3, "Artem", "Krol", 3, "zabolotnogo 36"));
            BookTable.Add(new Book(4, "Inga", "Greenberg", 4, "shivte israel 19"));
            BookTable.Add(new Book(5, "Inga", "Greenberg", 5, "shivte israel 19"));
            BookTable.Add(new Book(6, "Iliia", "ivanov", 6, "zabolotnogo 11"));
            BookTable.Add(new Book(7, "Oleg", "Pretrov", 7, "izmailovskii prospekt"));

        }
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Adress { get => adress; set => adress = value; }
        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }

        public List<Book> BookTable { get => bookTable; set => bookTable = value; }
        public List<Phone> PhoneTable { get => phoneTable; set => phoneTable = value; }

        public void LoadForm(ListView listViewForm)
        {
            var ToList =
                           from p in PhoneTable
                           from b in BookTable
                           where p.Id == b.PhoneNumberFk
                           select new
                           {
                               b.Id,
                               b.FirstName,
                               b.LastName,
                               p.PhoneNumber,
                               b.Adress
                           };

            foreach (var items in ToList)
            {

                ListViewItem item = listViewForm.Items.Add(new ListViewItem());
                item.Text = items.FirstName;
                item.SubItems.Add(items.LastName);
                item.SubItems.Add(items.PhoneNumber);
                item.SubItems.Add(items.Adress);
            }
        }
        public void SortByFamily(ListView listViewForm)
        {
            listViewForm.ListViewItemSorter = new ListViewItemComparer(1);

        }
        public void SortByPhone(ListView listViewForm)
        {
            listViewForm.ListViewItemSorter = new ListViewItemComparer(2);
        }
        public void SortByName(ListView listViewForm)
        {
            listViewForm.ListViewItemSorter = new ListViewItemComparer(0);
        }
        public void IndexSelected(ListView listViewForm)
        {
            ListView.SelectedIndexCollection selectedIndices = listViewForm.SelectedIndices;
            SelectedIndex = selectedIndices[0];
            for (int j = 0; j < PhoneTable.Count- 1; j++)
            {
                if ((PhoneTable[j].PhoneNumber == listViewForm.Items[SelectedIndex].SubItems[2].Text))
                {
                    var ToList =
                      from p in PhoneTable
                      from b in BookTable
                      where p.Id == j + 1 && p.Id == b.PhoneNumberFk
                      select new
                      {
                          b.Id,
                          b.FirstName,
                          b.LastName,
                          p.PhoneNumber,
                          b.Adress
                      };
                    foreach (var items in ToList)
                    {

                        Id = items.Id;
                        FirstName = items.FirstName;
                        LastName = items.LastName;
                        PhoneNumber = items.PhoneNumber;
                        Adress = items.Adress;
                    }
                    break;
                }
            }
        }
        
        public void Delete(ListView listViewForm)
        {
            if (MessageBox.Show("Вы действительно хотите удалить записи?", "Удаление записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            else
            {
                ListView.SelectedIndexCollection selectedIndices = listViewForm.SelectedIndices;

                try
                {
                    // Удаляем книги из списка снизу вверх
                    for (int i = selectedIndices.Count - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < BookTable.Count - 1; j++)
                        {
                            if (BookTable[j].LastName == listViewForm.Items[selectedIndices[i]].Text)
                            {
                                BookTable.RemoveAt(BookTable[j].Id);
                                PhoneTable.RemoveAt(BookTable[j].PhoneNumberFk);
                            }
                        }
                        listViewForm.Items.RemoveAt(selectedIndices[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Save()
        {
            if (Id != 0)
            {
                BookTable[Id].FirstName = FirstName;
                BookTable[Id].LastName = LastName;
                BookTable[Id].Adress = Adress;
                BookTable[Id].FirstName = FirstName;
                var ToID =
                          from p in PhoneTable
                          from b in BookTable
                          where p.Id == Id && p.Id == b.PhoneNumberFk
                          select p.Id;

                foreach (var items in ToID)
                {
                    PhoneTable[items].PhoneNumber = PhoneNumber;
                    break;
                }
                Id = 0;
                SaveAfterEdit(new object(), new EventArgs());
            }
        }


        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }

    }
}
