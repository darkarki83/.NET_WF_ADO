using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook
{
    public class Search
    {
        private Client searchClient;

        public ConsoleKey ItemMenuDelete { get; set; }

        public Search()
        {
            ItemMenuDelete = 0;
            searchClient = new Client();
        }

        public Client GetSearchClient() => searchClient;

        public void SetSearchClient(Client SearchClient) => searchClient = SearchClient;

        static public int SearchBy(Client searchClient, PhoneBook phoneBook, Func<Client, Client, bool> compare)
        {
            bool equally = false;
            int i;

            for (i = 0; i < phoneBook.Count; i++)
            {
                if (compare(phoneBook.PhonesBook[i], searchClient))
                {
                    equally = true;
                    break;
                }
            }
            return (equally ? i : -1);
        }

        static public void SearchListClients(List<int> list, Client searchClient, PhoneBook phoneBook, Func<Client, Client, bool> compare)
        {
            int i;
            if (list.Count > 0)
            {
                for (i = 0; i < phoneBook.Count; i++)
                    if (compare(phoneBook.PhonesBook[i], searchClient))
                        list.Add(i);
            }
        }

        static public int SearchByName(Client searchClient, PhoneBook book)
        {
            return SearchBy(searchClient, book, (client1, client2) => string.Compare(client1.firstName, client2.firstName) == 0);
        }

        static public void SearchByName(List<int> list, Client searchClient, PhoneBook book)
        {
            SearchListClients(list,searchClient, book, (client1, client2) => string.Compare(client1.firstName, client2.firstName) == 0);
        }

        static public int SearchByLastName(Client searchClient, PhoneBook book)
        {
            return SearchBy(searchClient, book, (client1, client2) => string.Compare(client1.lastName, client2.lastName) == 0);
        }

        static public void SearchByLastName(List<int> list, Client searchClient, PhoneBook book)
        {
            SearchListClients(list, searchClient, book, (client1, client2) => string.Compare(client1.lastName, client2.lastName) == 0);
        }

        static public int SearchByFhone(Client searchClient, PhoneBook book)
        {
            return SearchBy(searchClient, book, (client1, client2) => client1.foneNumber == client2.foneNumber);
        }

        static public void SearchByFhone(List<int> list, Client searchClient, PhoneBook book)
        {
            SearchListClients(list, searchClient, book, (client1, client2) => client1.foneNumber == client2.foneNumber);
        }

        public void MenuSearchDelete()   // menu delete cases
        {
            Console.WriteLine("Delite Client");
            Console.WriteLine("1) By last name Clien");
            Console.WriteLine("2) By phone namber Clien");
            Console.Write("Your choice : ");
            do
            {
                Console.CursorLeft = 15;
                ItemMenuDelete = Console.ReadKey().Key;

            } while (ItemMenuDelete != ConsoleKey.D1 && ItemMenuDelete != ConsoleKey.NumPad1 
            && ItemMenuDelete != ConsoleKey.D2 && ItemMenuDelete != ConsoleKey.NumPad2);

            Console.WriteLine();
            ImputByChoice();
        }

        public void ImputByChoice() //input client to search
        {
            if (ItemMenuDelete == ConsoleKey.D1 || ItemMenuDelete == ConsoleKey.NumPad1)
                Client.InputClientLastName(ref searchClient);
            else
                Client.InputClientFoneNumber(ref searchClient);
               
        }
    }
}
