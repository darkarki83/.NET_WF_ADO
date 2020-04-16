using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook
{
    public class Menu
    {
        public List<string> Options { get; set; } //  //сомо меню

        public int newItem { get; set; }

        public ConsoleLib.Coord StartCoord { get; set; }

        public Menu(ConsoleLib.Coord startCoord)
        {
            newItem = 2;
            StartCoord = startCoord;
            Options = new List<string>();
            Options.Add("TELETHON BOOK      ");
            Options.Add("Add new Client     ");
            Options.Add("Delete Client      ");
            Options.Add("Change Information ");
            Options.Add("Search by Last Name");
            Options.Add("Search by Phone    ");
            Options.Add("Sort               ");
            Options.Add("Print all Clients  ");
            Options.Add("Print Client       ");
            Options.Add("Exit and Save      ");
        }

        public void DrawMenu()
        {
            ConsoleLib.SetColor(ConsoleColor.Blue, ConsoleColor.Black);
            for (int i = 0; i < Options.Count; i++)
                ConsoleLib.WriteStr(StartCoord.x, StartCoord.y + i, Options[i]);
            
            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
        }

        public void MenuChange()
        {
            DrawMenu();

            var key = new ConsoleKey();

            const int minItem = 2;
            const int pointFromMenu = 2;
            const char chr = (char)219;

            do
            {
                ConsoleLib.WriteChar(StartCoord.x - pointFromMenu, StartCoord.y + newItem - 1, chr);   //ресует первый симан

                key = Console.ReadKey().Key;

                ConsoleLib.WriteChar(StartCoord.x - pointFromMenu, StartCoord.y + newItem - 1, ' ');    // стирает символ после перехода

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (newItem > minItem && newItem <= Options.Count)
                            newItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (newItem >= minItem && newItem < Options.Count)
                            newItem++;
                        break;
                }
            } while (key != ConsoleKey.Enter);
        }
    }        
}
