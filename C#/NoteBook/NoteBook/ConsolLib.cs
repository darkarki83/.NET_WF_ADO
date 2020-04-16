using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook
{
    public class ConsoleLib
    {
        public static void GotoXY(int _x, int _y) => Console.SetCursorPosition(_x, _y);

        public static void WriteStr(int x, int y, string str)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(str);
        }

        public static void WriteChar(int _x, int _y, char _symbol)
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_symbol);
        }

        public static void WriteChar(ConsoleLib.Coord coordYX, char _symbol)
        {
            Console.SetCursorPosition(coordYX.x, coordYX.y);
            Console.Write(_symbol);
        }

        public static void WriteChars(int _x, int _y, char _symbol, int count)
        {
            Console.SetCursorPosition(_x, _y);
            for (int i = 0; i < count; i++)
            {
                Console.Write(_symbol);
            }
        }

        public static void SetColor(ConsoleColor ColorText, ConsoleColor ColorBack)
        {
            Console.ForegroundColor = ColorText;
            Console.BackgroundColor = ColorBack;
        }

        public struct Coord
        {
            public int y;
            public int x;
            public Coord(int one, int next)
            {
                y = one;
                x = next;
            }

            public static bool operator ==(Coord one, Coord next) => one.y == next.y && one.x == next.x;

            public static bool operator !=(Coord one, Coord next) => !(one.y == next.y && one.x == next.x);
        }
    }
}
