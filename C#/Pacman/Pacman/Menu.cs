using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Menu
    {
        private ConsoleLib.Coord _pos;

        public int Width { get; set; }
        public int Height { get; set; }
        public int ItemCount { get; set; }
        public List<string> Items { get; set; }
        public int CurItem { get; set; }
        public int OpshionCase { get; set; }
        public SoundPlayer Sp { get; set; }

        public ConsoleColor foregRoundMenuColor;
        public ConsoleColor backgRoundMenuColor;
        public ConsoleColor foregRoundHighlightColor;
        public ConsoleColor backgRoundHighlightColor;

        public Menu(ConsoleLib.Coord pos, int width, int height, List<string> items, int curItem)
        {
            _pos = pos;
            Width = width;
            Height = height;

            Items = new List<string>();
            Items = items;
            OpshionCase = 1;
            ItemCount = Items.Count <= height - 2 ? Items.Count : height - 2;
            CurItem = (curItem > 0 && curItem <= Items.Count) ? curItem : 1;

            foregRoundMenuColor = ConsoleColor.White;
            backgRoundMenuColor = ConsoleColor.Red;
            foregRoundHighlightColor = ConsoleColor.White;
            backgRoundHighlightColor = ConsoleColor.Black;
            Sp = new SoundPlayer("file_example_WAV_10MG.wav");
        }

        public ConsoleLib.Coord GetPos() => _pos;

        public void SetPos(ConsoleLib.Coord pos) => _pos = pos;

        public void SetCurItem(int curItem)
        {
            if (curItem != CurItem && (curItem > 0 && curItem <= ItemCount))
            {
                ClearHighlightCurItem();
                CurItem = curItem;
                HighlightCurItem();
            }
        }

        public void HighlightCurItem()
        {
            ConsoleLib.GotoXY(_pos.x + 1, _pos.y + CurItem);
            Console.BackgroundColor = ConsoleColor.Red;
        }

        public void ClearHighlightCurItem()
        {
            ConsoleLib.GotoXY(_pos.x + 1, _pos.y + CurItem);
            Console.BackgroundColor = backgRoundMenuColor;
        }

        public bool IsPosAtItems(ConsoleLib.Coord pos) => (pos.x > _pos.x && pos.x < _pos.x + Width - 1)
            && (pos.y > _pos.y && pos.y < _pos.y + ItemCount + 1);

        public void Draw()
        {
            const char Gorizont = (char)9552;
            const char Vertikal = (char)9553;
            const char LeftUp = (char)9556;
            const char RightUp = (char)9559;
            const char RightDown = (char)9565;
            const char LeftDown = (char)9562;

            ConsoleLib.SetColor(foregRoundMenuColor, backgRoundMenuColor);
            ConsoleLib.WriteChar(_pos.x, _pos.y, LeftUp);
            ConsoleLib.WriteChars(_pos.x + 1, _pos.y, Gorizont, Width - 2);
            ConsoleLib.WriteChar(_pos.x + Width - 1, _pos.y, RightUp);

            for (int i = 1; i <= ItemCount; i++)
            {
                ConsoleLib.WriteChar(_pos.x, _pos.y + i, Vertikal);

                string itemToDraw = Items[i - 1];

                ConsoleLib.GotoXY(_pos.x + 1, _pos.y + i);
                Console.WriteLine(itemToDraw);
                ConsoleLib.WriteChar(_pos.x + Width - 1, _pos.y + i, Vertikal);
            }

            ConsoleLib.WriteChar(_pos.x, _pos.y + Height - 1, LeftDown);
            ConsoleLib.WriteChars(_pos.x + 1, _pos.y + Height - 1, Gorizont, Width - 2);
            ConsoleLib.WriteChar(_pos.x + Width - 1, _pos.y + Height - 1, RightDown);
        }

        public void ChoiceMove(ref ConsoleKey keyVitrualCode)
        {
            switch (keyVitrualCode)
            {
                case ConsoleKey.UpArrow:
                    if (CurItem == 1)
                        CurItem = ItemCount;
                    else
                        CurItem--;
                    break;
                case ConsoleKey.DownArrow:
                    if (CurItem == ItemCount)
                        CurItem = 1;
                    else
                        CurItem++;
                    break;
            }
        }

        public void ChoiceOptions()
        {
            ConsoleKey keyVitrualCode;
            bool flag = false;
            HighlightCurItem();
            do
            {
                keyVitrualCode = Console.ReadKey().Key;
                HighlightCurItem();

                if (Console.KeyAvailable != true)
                {
                    if (keyVitrualCode == ConsoleKey.Enter || keyVitrualCode == ConsoleKey.RightArrow)
                    {
                        switch (CurItem)
                        {
                            case 1:
                                ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
                                Console.Clear();
                                if(Program.PlayGame() != ConsoleKey.Enter)
                                {
                                    CaseExit();
                                    flag = true;
                                    break;
                                }
                                Console.Clear();
                                break;
                            case 2:
                                CreateOptionMenu();
                                break;
                            case 3:
                                CaseScore();
                                break;
                            case 4:
                                CaseExit();
                                flag = true;
                                break;
                        }
                        if (flag)
                            break;
                        Draw();
                        Console.CursorVisible = true;
                    }
                    ChoiceMove(ref keyVitrualCode);

                    ClearHighlightCurItem();
                }
            }
            while (keyVitrualCode != ConsoleKey.Escape && keyVitrualCode != ConsoleKey.LeftArrow);
        }

        public void ChoiceInsideOptions()
        {
            ConsoleKey keyVitrualCode;
            HighlightCurItem();
            do
            {
                keyVitrualCode = Console.ReadKey().Key;
                HighlightCurItem();

                if (Console.KeyAvailable != true)
                {
                    if (keyVitrualCode == ConsoleKey.Enter || keyVitrualCode == ConsoleKey.RightArrow)
                    {
                        OpshionSwitch();
                        Draw();
                    }
                    ChoiceMove(ref keyVitrualCode);

                    ClearHighlightCurItem();
                }
            }
            while (keyVitrualCode != ConsoleKey.Escape && keyVitrualCode != ConsoleKey.LeftArrow);
        }

        public void OpshionSwitch()
        {
            if (OpshionCase == 1)
            {
                switch (CurItem)
                {
                    case 1:
                        ConsoleLib.Coord pos = new ConsoleLib.Coord
                        {
                            y = 10,
                            x = 35
                        };

                        List<string> menuVol = new List<string>
                        {
                          "  Volume  ON           ",
                            "  Volume  OFF          "
                        };
                        Menu volMenu = new Menu(pos, 25, 4, menuVol, 1);

                        volMenu.Draw();
                        OpshionCase++;
                        ChoiceInsideOptions();
                        break;
                    case 2:
                        ConsoleLib.Coord posk = new ConsoleLib.Coord
                        {
                            y = 10,
                            x = 35
                        };
                        List<string> menuGraphics = new List<string>
                        {
                            "  Graphics  ON          ",
                            "  Graphics  OFF         "
                        };

                        Menu menuGraphic = new Menu(posk, 25, 4, menuGraphics, 1);

                        menuGraphic.Draw();
                        OpshionCase += 2;
                        ChoiceInsideOptions();
                        break;
                }
            }
            else if(OpshionCase == 2)
            {
                CreateVolumeSwitch(CurItem);
                OpshionCase--;
            }
            else if (OpshionCase == 3)
            {
                CreateGraphicsSwitch(CurItem);
                OpshionCase -= 2;
            }
        }

        public void CreateOptionMenu()
        {
            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
            Console.Clear();

            ConsoleLib.Coord pos = new ConsoleLib.Coord
            {
                y = 10,
                x = 35
            };

            List<string> menuOptions = new List<string>
            {
             "  Volume               ",
             "  Graphics             "
            };


            Menu newMenu = new Menu(pos, 25, 4, menuOptions, 1);

            newMenu.Draw();
            newMenu.ChoiceInsideOptions();
        }

        public void CaseScore()
        {
            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
            Console.Clear();
            List<SaveLoad> saveLoads = new List<SaveLoad>(10);
            FileManager.Load(ref saveLoads);
            FileManager.Print(ref saveLoads);

            ConsoleKey keyVitrualCode = Console.ReadKey().Key;
            Console.Clear();
        }

        public  void CaseExit()
        {
            Console.Clear();
            ConsoleLib.GotoXY(35, 20);
            Console.WriteLine("Bay -- Bay");
        }

        void CreateVolumeSwitch(int CurItem)
        {
            switch (CurItem)
            {
                case 1:
                    ConsoleLib.GotoXY(35, 15);
                    Console.WriteLine("  Volume ON   ");
                    Sp.PlayLooping();
                    break;
                case 2:
                    ConsoleLib.GotoXY(35, 15);
                    Console.WriteLine("  Volume OFF  ");
                    Sp.Stop();
                    break;
            }
        }

        void CreateGraphicsSwitch(int CurItem)
        {
            switch (CurItem)
            {
                case 1:
                    ConsoleLib.GotoXY(35, 15);
                    Console.WriteLine("Graphics ON ");
                    Grafica();
                    break;
                case 2:
                    ConsoleLib.GotoXY(35, 15);
                    Console.WriteLine("Graphics OFF");
                    break;
            }
        }

        public void Grafica()
        {
            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Green);
            ConsoleLib.WriteChars(15, 38, '$', 70);
            ConsoleLib.WriteChars(42, 35, '*', 3);
            ConsoleLib.WriteChars(41, 34, '*', 5);
            ConsoleLib.WriteChars(40, 33, '*', 6);
            ConsoleLib.WriteChars(39, 32, '*', 6);
            ConsoleLib.WriteChars(38, 31, '*', 6);
            ConsoleLib.WriteChars(39, 30, '*', 6);
            ConsoleLib.WriteChars(40, 29, '*', 6);
            ConsoleLib.WriteChars(41, 28, '*', 5);
            ConsoleLib.WriteChars(42, 27, '*', 3);
            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Red);
        }
    }
}

