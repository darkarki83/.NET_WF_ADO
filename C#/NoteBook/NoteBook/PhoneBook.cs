using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook
{
    [Serializable]
    public class PhoneBook
    {
        public List<Client> PhonesBook { get; set; }

        public int Count {get;set;}

        public PhoneBook()
         {
             PhonesBook = new List<Client>();
         }

        public void Add(Client client)
        {
            PhonesBook.Add(client);
            Count++;
        }

        public void Delete(Client client)
        {
            PhonesBook.Remove(client);
        }

        public void DeleteAt(int index)
        {
            if (index >= 0)
            {
                PhonesBook.RemoveAt(index);
            }
            else
                throw new Exception ("No have this client in phone book ");
        }

        public void PrintAllBook()
        {
            foreach (var item in PhonesBook)
            {
                Console.WriteLine($"Name : {item.firstName} {item.lastName}");
                Console.WriteLine($"Phone Number : {item.foneNumber}");
                Console.WriteLine($"Adrees : {item.adress} \n");
            }
        }

        public void PrintByIndex(int index)
        {
              Console.WriteLine($"Name : {PhonesBook[index].firstName} {PhonesBook[index].lastName}");
                Console.WriteLine($"Phone Number : {PhonesBook[index].foneNumber}");
                Console.WriteLine($"Adrees : {PhonesBook[index].adress} \n");
        }
    }
}
