using System;

namespace NoteBook
{
    public class ListSort
    {
        // Реализуем обобщенный метод сортировки
        static public void Sort(PhoneBook phoneBook, Func<Client, Client, bool> compare)
        {
            bool mySort = true;
            do
            {
                mySort = false;
                for (int i = 0; i < phoneBook.Count - 1; i++)
                {
                    if (compare(phoneBook.PhonesBook[i + 1], phoneBook.PhonesBook[i]))
                    {
                        Client j = phoneBook.PhonesBook[i];
                        phoneBook.PhonesBook[i] = phoneBook.PhonesBook[i + 1];
                        phoneBook.PhonesBook[i + 1] = j;
                        mySort = true;
                    }
                }
            } while (mySort);
        }

        static public void SortByName(PhoneBook book)
        {
            ListSort.Sort(book, (client1, client2) => string.Compare(client1.firstName, client2.firstName) < 0);
        }

        static public void SortByLastName(PhoneBook book)
        {
            ListSort.Sort(book, (client1, client2) => string.Compare(client1.lastName, client2.lastName) < 0);
        }

        static public void SortByFhone(PhoneBook book)
        {
            ListSort.Sort(book, (client1, client2)
            => client1.foneNumber > client2.foneNumber);
        }

        static public void SortByadress(PhoneBook book)
        {
            ListSort.Sort(book, (client1, client2) => string.Compare(client1.adress, client2.adress) < 0);
        }

        static public void SortMenu(out ConsoleKey keyBefor)
        {
            Console.WriteLine("Sort list by");
            Console.WriteLine("1) first name");
            Console.WriteLine("2) last name");
            Console.WriteLine("3) phone namber");
            Console.WriteLine("4) adress");
            Console.Write("Your choice : ");
            do
            {
                Console.CursorLeft = 15;
                keyBefor = Console.ReadKey().Key;
            } while (keyBefor < ConsoleKey.D1 || keyBefor > ConsoleKey.D4 && keyBefor < ConsoleKey.NumPad1 || keyBefor > ConsoleKey.NumPad4);
            Console.WriteLine();
        }
    }
}
