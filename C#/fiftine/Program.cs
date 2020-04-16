using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiftine
{
    class Program
    {
        static void Main(string[] args)
        {
            Game Games = new Game();

            Games.FillArray();

            Games.PrintMap();
            
            Games.Mix();

            Games.PrintFilds();

            do
            {
                Games.PrintFilds();

                Games.move();
            } while (Games.Winner());

            Games.PrintFilds();

            Console.WriteLine("YOU ARE WINNER ");
        }
    }
}
