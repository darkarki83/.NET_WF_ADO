using System;
using System.Collections.Generic;

namespace NoteBook
{
    public class ChoiceEventArgs : EventArgs
    {
        public int EventNum;
    }

    delegate void MyEventHandler(object sender, ChoiceEventArgs e);

    class MyEvent
    {
        public event MyEventHandler SomeEvent;

        public void OnSomeEvent(int choice)
        {
            ChoiceEventArgs arg = new ChoiceEventArgs();

            if (SomeEvent != null)
            {
                arg.EventNum = choice ;
                SomeEvent(this, arg);
            }
        }
    }

    public class TheBook
    {
        //delegate void MyEventHandler(object sender, ChoiceEventArgs e);
        private PhoneBook one;

        private Menu menu;

        private Search search = new Search();

        private Client client = new Client();

        private MyEvent[] evt;

        public TheBook()
        {
            one = new PhoneBook();
            FileManager.LoadSerialization(out one);

            menu = new Menu(new ConsoleLib.Coord(5, 10));
            search = new Search();
            client = new Client();

            evt = new MyEvent[10];

            for (int i = 0; i < 9; i++)
                evt[i] = new MyEvent();

            evt[0].SomeEvent += AddClient;
            evt[1].SomeEvent += DeleteClient;
            evt[2].SomeEvent += ChangeInformation;
            evt[3].SomeEvent += SearchClientByName;
            evt[4].SomeEvent += SearchClientByPhone;
            evt[5].SomeEvent += SortClient;
            evt[6].SomeEvent += PrintAll;
            evt[7].SomeEvent += PrintByIndex;
            evt[8].SomeEvent += Exit;
        }

        public void WorkBook()
        {
            Console.CursorVisible = false;
           
            do
            {
                menu.MenuChange();

                Console.Clear();
                evt[menu.newItem - 2].OnSomeEvent(menu.newItem);
                
                var key = Console.ReadKey().Key;
                        Console.Clear();
            } while (menu.newItem != 10);
        }

        public void AddClient(object sender, ChoiceEventArgs e)
        {
            Client.InputClient(out client);
            one.Add(client);

            Console.WriteLine("New Client Added");
        }

        public void DeleteClient(object sender, ChoiceEventArgs e)
        {
            search.MenuSearchDelete();
            try
            {
                if (search.ItemMenuDelete == ConsoleKey.D1 || search.ItemMenuDelete == ConsoleKey.NumPad1)  // Choice delete by name or by phone
                    one.DeleteAt(Search.SearchByLastName(search.GetSearchClient(), one));
                else
                    one.DeleteAt(Search.SearchByFhone(search.GetSearchClient(), one));

                Console.WriteLine("Delete Is Done");
            }
            catch
            {
                Console.WriteLine("So sorry but in this book no have this client");
            }
        }

        public void ChangeInformation(object sender, ChoiceEventArgs e)
        {
            var key = new ConsoleKey();

            Console.WriteLine("Search Client For change");
            Console.WriteLine("1) First name");
            Console.WriteLine("2) Last name");
            Console.WriteLine("3) Phone namber");
            Console.Write("Your choice : ");
            do
            {
                Console.CursorLeft = 15;
                key = Console.ReadKey().Key;
            } while (key < ConsoleKey.D1 || key > ConsoleKey.D3
            && key < ConsoleKey.NumPad1 || key > ConsoleKey.NumPad3);

            Console.WriteLine();
            int index = -1;


            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Client.InputClientName(ref client);
                    index = Search.SearchByName(client, one);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Client.InputClientLastName(ref client);
                    index = Search.SearchByLastName(client, one);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Client.InputClientFoneNumber(ref client);
                    index = Search.SearchByFhone(client, one);
                    break;
            }
           
            try
            {
                one.PrintByIndex(index);
                Client.InputClient(out client);
                one.PhonesBook[index] = client;
                Console.WriteLine("Change Is Done");
            }
            catch
            {
                Console.WriteLine("No have this Client in Phone book");
            }
        }

        public void SearchClientByName(object sender, ChoiceEventArgs e)
        {
            Client.InputClientLastName(ref client);

            search.SetSearchClient(client);

            List<int> list = new List<int>();
           
            Search.SearchByLastName(list, search.GetSearchClient(), one);
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    one.PrintByIndex(list[i]);
                }
            }
            else
                Console.WriteLine("In your phone book no have Client with this name");
        }

        public void SearchClientByPhone(object sender, ChoiceEventArgs e)
        {
            Client.InputClientFoneNumber(ref client);
            
            search.SetSearchClient(client);
            List<int> list = new List<int>();

            Search.SearchByFhone(list, search.GetSearchClient(), one);

            if (list.Count > 0)
                for (int i = 0; i < list.Count; i++) 
                    one.PrintByIndex(list[i]); 
            else
                Console.WriteLine("In your phone book no have Client with this phone");
        }

        public void SortClient(object sender, ChoiceEventArgs e)
        {
            ConsoleKey keyBefor;

            ListSort.SortMenu(out keyBefor);
            switch (keyBefor)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ListSort.SortByName(one);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ListSort.SortByLastName(one);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ListSort.SortByFhone(one);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ListSort.SortByadress(one);
                    break;
            }
            Console.WriteLine("Sort Is done");
        }

        public void PrintAll(object sender, ChoiceEventArgs e)
        {
            one.PrintAllBook();
        }

        public void PrintByIndex(object sender, ChoiceEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                one.PrintByIndex(index);
            }
            catch
            {
                Console.WriteLine("Non-Book Index");
                Console.WriteLine($"Index Min {0}, Index Max {one.PhonesBook.Count - 1}");
            }
        }

        public void Exit(object sender, ChoiceEventArgs e)
        {
            Console.WriteLine("GOOD BAY BAY");
            FileManager.SaveSerialization(one);
        }

    }
}
