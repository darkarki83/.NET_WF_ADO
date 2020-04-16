using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman;

namespace Pacman
{
    public class MyMap : IMap   // карта
    {
        private int sizeY { get; set; }
        private int sizeX { get; set; }

        private int[,] map { get; set; }

        public MyMap()
        {
            map = new int[31, 32]
      { { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        { 1,0,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
        { 1,2,1,1,1,1,2,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,2,1,1,1,1,2,1 },
        { 1,2,1,0,0,1,2,1,0,0,0,0,0,1,2,1,1,2,1,0,0,0,0,0,1,2,1,0,0,1,2,1 },
        { 1,3,1,1,1,1,2,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,2,1,1,1,1,3,1 },
        { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
        { 1,2,1,1,1,1,2,1,1,1,2,1,1,1,1,1,1,1,1,1,1,2,1,1,1,2,1,1,1,1,2,1 },
        { 1,2,1,1,1,1,2,1,1,1,2,1,1,1,1,1,1,1,1,1,1,2,1,1,1,2,1,1,1,1,2,1 },
        { 1,2,2,2,2,2,2,1,1,1,2,2,2,2,2,1,1,2,2,2,2,2,1,1,1,2,2,2,2,2,2,1 },
        { 1,1,1,1,1,1,2,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,2,1,1,1,1,1,1 },
        { 0,0,0,0,0,1,2,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,2,1,0,0,0,0,0 },
        { 0,0,0,0,0,1,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,1,0,0,0,0,0 },
        { 0,0,0,0,0,1,2,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,2,1,0,0,0,0,0 },
        { 1,1,1,1,1,1,2,1,1,1,0,1,1,1,0,0,0,1,0,1,1,0,1,1,1,2,1,1,1,1,1,1 },
        { 0,0,0,0,0,0,2,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,2,0,0,0,0,0,0 },
        { 1,1,1,1,1,1,2,1,1,1,0,1,1,0,0,0,0,0,0,1,1,0,1,1,1,2,1,1,1,1,1,1 },
        { 0,0,0,0,0,1,2,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,2,1,0,0,0,0,0 },
        { 0,0,0,0,0,1,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,1,0,0,0,0,0 },
        { 0,0,0,0,0,1,2,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,2,1,0,0,0,0,0 },
        { 1,1,1,1,1,1,2,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,2,1,1,1,1,1,1 },
        { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
        { 1,2,1,1,1,1,2,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,2,1,1,1,1,2,1 },
        { 1,2,1,1,1,1,2,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,2,1,1,1,1,2,1 },
        { 1,2,2,2,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,2,2,2,1 },
        { 1,1,1,2,1,1,2,1,1,1,2,1,1,1,1,1,1,1,1,1,1,2,1,1,1,2,1,1,2,1,1,1 },
        { 1,1,1,2,1,1,2,1,1,1,2,1,1,1,1,1,1,1,1,1,1,2,1,1,1,2,1,1,2,1,1,1 },
        { 1,2,2,2,2,2,2,1,1,1,2,2,2,2,2,1,1,2,2,2,2,2,1,1,1,2,2,2,2,2,2,1 },
        { 1,2,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,2,1 },
        { 1,3,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,3,1 },
        { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }};
            SizeY = 31;
            SizeX = 32;
        }

        public int SizeY
        {
            get => sizeY;
            set => sizeY = value;
        }

        public int SizeX
        {
            get => sizeX;
            set => sizeX = value;
        }

        public int[,] Map
        {
            get => map;
            set => map = value;
        }

        public int GetPointInMap(int newY, int newX) => map[newY, newX];

        public void SetPointInMap(int newY, int newX, int value) => map[newY, newX] = value;

        public void SetPointInMap(ConsoleLib.Coord newCoord, int value) => map[newCoord.y, newCoord.x] = value;

        public void Draw(int y, int x)
        {
            //const char Well = (char)9472;
            const char Point = (char)183;
            const char SuperPoint = (char)164;
            //------------------------------------------------------------//
            //all outside well
            const char Gorizont = (char)9552;
            const char Vertikal = (char)9553;
            const char LeftUp = (char)9556;
            const char RightUp = (char)9559;
            const char RightDown = (char)9565;
            const char LeftDown = (char)9562;
            //------------------------------------------------------------//
            //all insade well
            const char LeftUpInside = (char)9484;
            const char RightUpInside = (char)9488;
            const char GorizontInside = (char)9472;
            const char VertikalInside = (char)9474;
            const char RightDownInside = (char)9496;
            const char LeftDownInside = (char)9492;

            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);

            ConsoleLib.WriteChar(x, y, LeftUp);             // first line
            ConsoleLib.WriteChars(x + 1, y, Gorizont, SizeX - 2);
            ConsoleLib.WriteChar(x + SizeX - 1, y, RightUp);
            ConsoleLib.WriteChar(x + 15, y, RightUp);
            ConsoleLib.WriteChar(x + 16, y, LeftUp);
            ConsoleLib.WriteChars(x + 15, y + 1, Vertikal, 2);  // second line
            ConsoleLib.WriteChars(x + 15, y + 2, Vertikal, 2);
            ConsoleLib.WriteChars(x + 15, y + 3, Vertikal, 2);
            ConsoleLib.WriteChar(x + 15, y + 4, LeftDown);
            ConsoleLib.WriteChar(x + 16, y + 4, RightDown);
            ConsoleLib.WriteChars(x + 1, y + 9, Gorizont, 4);
            ConsoleLib.WriteChar(x + 5, y + 9, RightUp);
            ConsoleLib.WriteChars(x + 27, y + 9, Gorizont, 4);
            ConsoleLib.WriteChar(x + 26, y + 9, LeftUp);
            ConsoleLib.WriteChars(x + 1, y + 13, Gorizont, 4);
            ConsoleLib.WriteChar(x + 5, y + 13, RightDown);
            ConsoleLib.WriteChars(x + 27, y + 13, Gorizont, 4);
            ConsoleLib.WriteChar(x + 26, y + 13, LeftDown);
            for (int i = 0; i < 3; i++)
            {
                ConsoleLib.WriteChar(x + 5, y + 10 + i, Vertikal);
                ConsoleLib.WriteChar(x + 26, y + 10 + i, Vertikal);
            }
            ConsoleLib.WriteChars(x + 1, y + 15, Gorizont, 4);
            ConsoleLib.WriteChar(x + 5, y + 15, RightUp);
            ConsoleLib.WriteChars(x + 27, y + 15, Gorizont, 4);
            ConsoleLib.WriteChar(x + 26, y + 15, LeftUp);
            for (int i = 0; i < 3; i++)
            {
                ConsoleLib.WriteChar(x + 5, y + 16 + i, Vertikal);
                ConsoleLib.WriteChar(x + 26, y + 16 + i, Vertikal);
            }
            ConsoleLib.WriteChars(x + 1, y + 19, Gorizont, 4);
            ConsoleLib.WriteChar(x + 5, y + 19, RightDown);
            ConsoleLib.WriteChars(x + 27, y + 19, Gorizont, 4);
            ConsoleLib.WriteChar(x + 26, y + 19, LeftDown);
            for (int i = 0; i < 2; i++)
            {
                ConsoleLib.WriteChar(x + 1, y + 24 + i, Gorizont);
                ConsoleLib.WriteChar(x + 30, y + 24 + i, Gorizont);
            }
            ConsoleLib.WriteChar(x + 2, y + 24, RightUp);
            ConsoleLib.WriteChar(x + 29, y + 24, LeftUp);
            ConsoleLib.WriteChar(x + 2, y + 25, RightDown);
            ConsoleLib.WriteChar(x + 29, y + 25, LeftDown);

            for (int i = 1; i < SizeY; i++)
            {
                if (i == 2 || i == 7 || i == 18 || i == 26)
                {
                    ConsoleLib.WriteChar(x + i, y + 2, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 3, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 4, LeftDownInside);
                    ConsoleLib.WriteChar(x + i, y + 21, LeftUpInside);
                    if (i != 26)
                        ConsoleLib.WriteChar(x + i, y + 22, LeftDownInside);
                    if (i != 7 && i != 26)
                    {
                        ConsoleLib.WriteChar(x + i, y + 27, LeftUpInside);
                        ConsoleLib.WriteChar(x + i, y + 28, LeftDownInside);
                    }
                }
                if (i == 2 || i == 7 || i == 11 || i == 22 || i == 26)
                {
                    ConsoleLib.WriteChar(x + i, y + 6, LeftUpInside);
                    if (i != 7 && i != 22)
                        ConsoleLib.WriteChar(x + i, y + 7, LeftDownInside);
                    else
                        ConsoleLib.WriteChar(x + i, y + 7, VertikalInside);
                }
                if (i == 5 || i == 13 || i == 24 || i == 29)
                {
                    ConsoleLib.WriteChar(x + i, y + 2, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 3, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 4, RightDownInside);
                    ConsoleLib.WriteChar(x + i, y + 21, RightUpInside);
                    if (i != 5)
                        ConsoleLib.WriteChar(x + i, y + 22, RightDownInside);
                }
                if (i == 5 || i == 9 || i == 20 || i == 24 || i == 29)
                {
                    ConsoleLib.WriteChar(x + i, y + 6, RightUpInside);

                    if (i != 9 && i != 24)
                        ConsoleLib.WriteChar(x + i, y + 7, RightDownInside);
                    else
                        ConsoleLib.WriteChar(x + i, y + 7, VertikalInside);
                }
                if ((i > 2 && i < 5) || (i > 7 && i < 13) || (i > 18 && i < 24)
                    || (i > 26 && i < 29))
                {
                    ConsoleLib.WriteChar(x + i, y + 2, GorizontInside);
                    ConsoleLib.WriteChar(x + i, y + 4, GorizontInside);
                    ConsoleLib.WriteChar(x + i, y + 21, GorizontInside);
                    if (i != 4 && i != 27)
                        ConsoleLib.WriteChar(x + i, y + 22, GorizontInside);
                }
                if ((i > 2 && i < 5) || (i > 7 && i < 9) || (i > 11 && i < 20)
                    || (i > 22 && i < 24) || (i > 26 && i < 29))
                {
                    ConsoleLib.WriteChar(x + i, y + 6, GorizontInside);
                    if (i != 15 && i != 16)
                    {
                        ConsoleLib.WriteChar(x + i, y + 7, GorizontInside);
                    }
                    if (i == 15)
                    {
                        ConsoleLib.WriteChar(x + i, y + 7, RightUpInside);
                        ConsoleLib.WriteChar(x + i, y + 10, LeftDownInside);
                        ConsoleLib.WriteChar(x + i, y + 8, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 19, RightUpInside);
                        ConsoleLib.WriteChar(x + i, y + 20, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 21, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 22, LeftDownInside);
                        ConsoleLib.WriteChar(x + i, y + 25, RightUpInside);
                        ConsoleLib.WriteChar(x + i, y + 26, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 27, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 28, LeftDownInside);

                    }
                    if (i == 16)
                    {
                        ConsoleLib.WriteChar(x + i, y + 7, LeftUpInside);
                        ConsoleLib.WriteChar(x + i, y + 10, RightDownInside);
                        ConsoleLib.WriteChar(x + i, y + 8, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 19, LeftUpInside);
                        ConsoleLib.WriteChar(x + i, y + 20, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 21, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 22, RightDownInside);
                        ConsoleLib.WriteChar(x + i, y + 25, LeftUpInside);
                        ConsoleLib.WriteChar(x + i, y + 26, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 27, VertikalInside);
                        ConsoleLib.WriteChar(x + i, y + 28, RightDownInside);
                    }
                }
                if ((i == 7 || i == 9) || i == 22 || i == 24)
                {
                    ConsoleLib.WriteChar(x + i, y + 8, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 11, VertikalInside);
                }
                if (i == 7 || i == 24 || (i == 15 || i == 16))
                    ConsoleLib.WriteChar(x + i, y + 9, VertikalInside);
                if (i == 7)
                {
                    ConsoleLib.WriteChar(x + i, y + 13, LeftDownInside);
                    ConsoleLib.WriteChar(x + i, y + 15, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 19, LeftDownInside);
                    ConsoleLib.WriteChar(x + i, y + 24, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 27, RightDownInside);
                }
                if (i == 9)
                {
                    ConsoleLib.WriteChar(x + i, y + 9, LeftDownInside);
                    ConsoleLib.WriteChar(x + i, y + 10, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 12, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 13, RightDownInside);
                    ConsoleLib.WriteChar(x + i, y + 15, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 19, RightDownInside);
                    ConsoleLib.WriteChar(x + i, y + 24, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 27, LeftDownInside);
                }
                if (i == 24)
                {
                    ConsoleLib.WriteChar(x + i, y + 15, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 13, RightDownInside);
                    ConsoleLib.WriteChar(x + i, y + 19, RightDownInside);
                    ConsoleLib.WriteChar(x + i, y + 24, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 27, LeftDownInside);
                }
                if (i == 22)
                {
                    ConsoleLib.WriteChar(x + i, y + 9, RightDownInside);
                    ConsoleLib.WriteChar(x + i, y + 10, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 12, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 13, LeftDownInside);
                    ConsoleLib.WriteChar(x + i, y + 15, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 19, LeftDownInside);
                    ConsoleLib.WriteChar(x + i, y + 24, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 27, RightDownInside);
                }
                if ((i == 22 || i == 24) || (i == 7 || i == 9))
                {
                    ConsoleLib.WriteChar(x + i, y + 16, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 17, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 18, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 25, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 26, VertikalInside);
                }
                if ((i > 9 && i < 13) || (i > 18 && i < 22))
                {
                    ConsoleLib.WriteChar(x + i, y + 9, GorizontInside);
                    ConsoleLib.WriteChar(x + i, y + 10, GorizontInside);
                }
                if (i == 13)
                {
                    ConsoleLib.WriteChar(x + i, y + 9, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 10, RightDownInside);
                    ConsoleLib.WriteChar(x + i, y + 27, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 28, RightDownInside);
                }
                if (i == 18)
                {
                    ConsoleLib.WriteChar(x + i, y + 9, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 10, LeftDownInside);
                }
                if (i == 7 || i == 24)
                {
                    ConsoleLib.WriteChar(x + i, y + 10, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 12, VertikalInside);
                }
                if (i == 11)
                {
                    ConsoleLib.WriteChar(x + i, y + 12, LeftUp);
                    ConsoleLib.WriteChar(x + i, y + 13, Vertikal);
                    ConsoleLib.WriteChar(x + i, y + 14, Vertikal);
                    ConsoleLib.WriteChar(x + i, y + 15, Vertikal);
                    ConsoleLib.WriteChar(x + i, y + 16, LeftDown);
                    ConsoleLib.WriteChar(x + i, y + 18, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 19, LeftDownInside);
                    ConsoleLib.WriteChar(x + i, y + 24, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 25, LeftDownInside);
                }
                if (i == 20)
                {
                    ConsoleLib.WriteChar(x + i, y + 12, RightUp);
                    ConsoleLib.WriteChar(x + i, y + 13, Vertikal);
                    ConsoleLib.WriteChar(x + i, y + 14, Vertikal);
                    ConsoleLib.WriteChar(x + i, y + 15, Vertikal);
                    ConsoleLib.WriteChar(x + i, y + 16, RightDown);
                    ConsoleLib.WriteChar(x + i, y + 18, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 19, RightDownInside);
                    ConsoleLib.WriteChar(x + i, y + 24, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 25, RightDownInside);
                }
                if (i > 11 && i < 15 || i > 16 && i < 20)
                {
                    ConsoleLib.WriteChar(x + i, y + 12, Gorizont);
                    ConsoleLib.WriteChar(x + i, y + 19, GorizontInside);
                    ConsoleLib.WriteChar(x + i, y + 25, GorizontInside);
                }
                if (i > 14 && i < 17)
                {
                    ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
                    ConsoleLib.WriteChar(x + i, y + 12, GorizontInside);
                }
                if (i > 11 && i < 20)
                {
                    ConsoleLib.WriteChar(x + i, y + 16, Gorizont);
                    ConsoleLib.WriteChar(x + i, y + 18, GorizontInside);
                    ConsoleLib.WriteChar(x + i, y + 24, GorizontInside);
                }
                if (i == 8 || i == 23)
                {
                    ConsoleLib.WriteChar(x + i, y + 13, GorizontInside);
                    ConsoleLib.WriteChar(x + i, y + 15, GorizontInside);
                    ConsoleLib.WriteChar(x + i, y + 19, GorizontInside);
                    ConsoleLib.WriteChar(x + i, y + 24, GorizontInside);
                }
                if (i == 4 || i == 5 || i == 26 || i == 27)
                {
                    ConsoleLib.WriteChar(x + i, y + 23, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 24, VertikalInside);
                }
                if (i == 4)
                {
                    ConsoleLib.WriteChar(x + i, y + 22, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 25, LeftDownInside);
                }
                if (i == 27)
                {
                    ConsoleLib.WriteChar(x + i, y + 22, LeftUpInside);
                    ConsoleLib.WriteChar(x + i, y + 25, RightDownInside);
                }
                if (i == 5)
                {
                    ConsoleLib.WriteChar(x + i, y + 22, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 25, RightDownInside);
                }
                if (i == 26)
                {
                    ConsoleLib.WriteChar(x + i, y + 22, VertikalInside);
                    ConsoleLib.WriteChar(x + i, y + 25, LeftDownInside);
                }
                if (i == 29)
                {
                    ConsoleLib.WriteChar(x + i, y + 27, RightUpInside);
                    ConsoleLib.WriteChar(x + i, y + 28, RightDownInside);
                }
                if (i > 2 && i < 7 || i > 9 && i < 13 || i > 18 && i < 22 ||
                    i > 24 && i < 29)
                {
                    ConsoleLib.WriteChar(x + i, y + 27, GorizontInside);
                }
                if (i > 2 && i < 13 || i > 18 && i < 29)
                {
                    ConsoleLib.WriteChar(x + i, y + 28, GorizontInside);
                }
            }
            for (int i = 1; i < SizeY; i++)
            {
                if (i > 0 && i <= 8)
                {
                    ConsoleLib.WriteChar(x, y + i, Vertikal);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, Vertikal);
                }
                if (i == 9)
                {
                    ConsoleLib.WriteChar(x, y + i, LeftDown);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, RightDown);
                }
                if (i == 13)
                {
                    ConsoleLib.WriteChar(x, y + i, Gorizont);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, Gorizont);

                }
                if (i == 15)
                {
                    ConsoleLib.WriteChar(x, y + i, Gorizont);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, Gorizont);
                }
                if (i == 19)
                {
                    ConsoleLib.WriteChar(x, y + i, LeftUp);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, RightUp);

                }
                if (i > 19 && i < 24)
                {
                    ConsoleLib.WriteChar(x, y + i, Vertikal);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, Vertikal);
                }
                if (i == 24)
                {
                    ConsoleLib.WriteChar(x, y + i, LeftDown);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, RightDown);
                }
                if (i == 25)
                {
                    ConsoleLib.WriteChar(x, y + i, LeftUp);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, RightUp);
                }
                if (i > 25 && i < SizeY - 1)
                {
                    ConsoleLib.WriteChar(x, y + i, Vertikal);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, Vertikal);
                }
                if (i == SizeY - 1)
                {
                    ConsoleLib.WriteChar(x, y + i, LeftDown);
                    ConsoleLib.WriteChar(x + SizeX - 1, y + i, RightDown);
                }
                ConsoleLib.WriteChars(x + 1, y + 30, Gorizont, 30);
            }
            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 1; j < SizeX; j++)
                {
                    ConsoleLib.SetColor(ConsoleColor.Yellow, ConsoleColor.Black);
                    if (GetPointInMap(i, j) == 2)
                        ConsoleLib.WriteChar(x + j, y + i, Point);
                    ConsoleLib.SetColor(ConsoleColor.Green, ConsoleColor.Black);
                    if (GetPointInMap(i, j) == 3)
                        ConsoleLib.WriteChar(x + j, y + i, SuperPoint);
                }
                Console.WriteLine();
            }
            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
        }
    }
}

