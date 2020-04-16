using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace fiftine
{
    class Game
    {
        public Game()
        {
            TheArray = new int[4, 4];
            MyY = 3;
            MyX = 3;
        }
        public enum MoveD
        {
            Up = ConsoleKey.UpArrow,
            Down = ConsoleKey.DownArrow,
            Right = ConsoleKey.RightArrow,
            Left = ConsoleKey.LeftArrow
        }

        private int[,] TheArray { get; set; }

        private int MyY { get; set; }
        private int MyX { get; set; }

        public void FillArray()
        {
            for (int i = 0; i < TheArray.GetLength(0); i++)
            {
                for (int j = 0; j < TheArray.GetLength(1); j++)
                {
                    if (i > 0)
                        TheArray[i, j] = (j + 1) + TheArray[i - 1, TheArray.GetLength(1) - 1];
                    else
                        TheArray[i, j] = (j + 1);
                }
                if (i == TheArray.GetLength(0) - 1)
                    TheArray[i, TheArray.GetLength(1) - 1] = 0;
            }
        }

        public void PrintFilds()
        {
            for (int i = 0; i < TheArray.GetLength(0); i++)
            {
                for (int j = 0; j < TheArray.GetLength(1); j++)
                {
                    Console.SetCursorPosition(1 * j + 3 * (1 + j * 3), 3 * (1 + i * 2));
                    if (TheArray[i, j] != 0)
                        Console.Write("{0,3}", TheArray[i, j]);
                    else
                        Console.Write("{0,3}", " ");
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 26);


        }

        public void move()
        {
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyY - 1 >= 0)
                    {
                        TheArray[MyY, MyX] = TheArray[MyY - 1, MyX];
                        TheArray[MyY - 1, MyX] = 0;
                        MyY = MyY - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyY + 1 < 4)
                    {
                        TheArray[MyY, MyX] = TheArray[MyY + 1, MyX];
                        TheArray[MyY + 1, MyX] = 0;
                        MyY = MyY + 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyX + 1 < 4)
                    {
                        TheArray[MyY, MyX] = TheArray[MyY, MyX + 1];
                        TheArray[MyY, MyX + 1] = 0;
                        MyX = MyX + 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyX - 1 >= 0)
                    {
                        TheArray[MyY, MyX] = TheArray[MyY, MyX - 1];
                        TheArray[MyY, MyX - 1] = 0;
                        MyX = MyX - 1;
                    }
                    break;
            }
        }

        public void PrintMap()
        {
            Console.WriteLine("┌─────────┬─────────┬─────────┬─────────┐");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("├─────────┼─────────┼─────────┼─────────┤");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("├─────────┼─────────┼─────────┼─────────┤");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("├─────────┼─────────┼─────────┼─────────┤");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("└─────────┴─────────┴─────────┴─────────┘");
        }

        public void Mix()
        {
            Random r = new Random();
            for (int i = 0; i < 200; i++)
            {


                int choice = r.Next(1, 4);
                switch (choice)
                {
                    case 1:
                        if (MyY - 1 >= 0)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY - 1, MyX];
                            TheArray[MyY - 1, MyX] = 0;
                            MyY = MyY - 1;
                        }
                        if (MyX + 1 < 4)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY, MyX + 1];
                            TheArray[MyY, MyX + 1] = 0;
                            MyX = MyX + 1;
                        }
                        break;
                    case 2:
                        if (MyX - 1 >= 0)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY, MyX - 1];
                            TheArray[MyY, MyX - 1] = 0;
                            MyX = MyX - 1;
                        }
                        if (MyY + 1 < 4)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY + 1, MyX];
                            TheArray[MyY + 1, MyX] = 0;
                            MyY = MyY + 1;
                        }
                        if (MyY - 1 >= 0)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY - 1, MyX];
                            TheArray[MyY - 1, MyX] = 0;
                            MyY = MyY - 1;
                        }
                        break;
                    case 3:
                        if (MyX + 1 < 4)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY, MyX + 1];
                            TheArray[MyY, MyX + 1] = 0;
                            MyX = MyX + 1;
                        }
                        if (MyY + 1 < 4)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY + 1, MyX];
                            TheArray[MyY + 1, MyX] = 0;
                            MyY = MyY + 1;
                        }
                        break;
                    case 4:
                        if (MyY + 1 < 4)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY + 1, MyX];
                            TheArray[MyY + 1, MyX] = 0;
                            MyY = MyY + 1;
                        }
                        if (MyX + 1 < 4)
                        {
                            TheArray[MyY, MyX] = TheArray[MyY, MyX + 1];
                            TheArray[MyY, MyX + 1] = 0;
                            MyX = MyX + 1;
                        }
                        break;
                }
            }
        }

        public bool Winner()
        {
            int[,] Temp = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
           for (int i = 0; i < TheArray.GetLength(0); i++)
            {
                for (int j = 0; j < TheArray.GetLength(1); j++)
                {
                    if (TheArray[i, j] != Temp[i, j])
                        return true;
                }
            }
            return false;
        }
    }
}
