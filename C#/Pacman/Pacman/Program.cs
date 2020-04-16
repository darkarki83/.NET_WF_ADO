using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{
    public class Program
    {
        public static ConsoleKey PlayGame()
        {

            var builder = new BilderGame();
            var director = new Director(builder);

            director.Construct();
            Game games = builder.GetGame();

            games.Play();
            if (games.ExitFromGame == false)
                return games.AfterPlay(); // проверка выигрыша и запись игры
            else
                return ConsoleKey.Enter;
        }

        public static void Main(string[] args)
        {
            Console.SetWindowSize(100, 45);

            ConsoleLib.Coord pos = new ConsoleLib.Coord();
             pos.y = 10;
             pos.x = 35;
             List<string> menuItems = new List<string>();
             menuItems.Add("  Start games           ");
             menuItems.Add("  Opshions              ");
             menuItems.Add("  Records               ");
             menuItems.Add("  Exit                  ");

             Menu menu = new Menu(pos, 25, 6, menuItems, 1);

             menu.Draw();
             menu.ChoiceOptions();
        }
    }
}
