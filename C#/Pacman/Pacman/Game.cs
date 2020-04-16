using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pacman
{
    [Serializable]
    public struct SaveLoad
    {
        public string name;

        public int score;
    }

    public class Game
    {
        public event EventHandler DoPointInGame;
        public event EventHandler DoSuperPointInGame;


        public Pacaman PacMan { get; set; }

        public List<Monster> Monsters { get; set; }

        public MyMap Map { get; set; }

        public SuperPoint TheSuperPoint { get; set; } = new SuperPoint();

        public Point ThePoint { get; set; } = new Point();

        public bool ExitFromGame { get; set; }

        public Game()
        {
            ExitFromGame = false;
        }

        public void Play()
        {
            Console.CursorVisible = false;
            Map.Draw(6, 20);
            PacMan.Draw(Map);

            for (int i = 0; i < Monsters.Count; i++)
                Monsters[i].Draw(Map);

            TimerStartGame();
            bool win = false;

            do
            {
                //----------------------------------------------------------------//
                /* for (int i = 0; i < Map.SizeY; i++)
                 {
                     ConsoleLib.GotoXY(80, 6 + i);
                     for (int j = 0; j < Map.SizeX; j++)
                     {
                         Console.Write(Map.GetPointInMap(i, j));
                     }
                 }*/
                //-----------------------------------------------------------------//
                PacManMove();
                if (ExitFromGame == true)
                    break;
                MonsterMove();

                ConsoleLib.GotoXY(1, 1);                                      /// на посмотреть
                Console.WriteLine("point count : {0}", ThePoint.PointCount);   // на посмотреть

                ConsoleLib.GotoXY(20, 5);         // вывод рекорда на посмотреть
                Console.Write("score :: {0}", PacMan.Score);

                if(ThePoint.PointCount < 3)
                    win = WinCheck();

            } while (((ThePoint.PointCount + TheSuperPoint.SuperPointCount) != 0  || win != true) && PacMan.Life != 0);
        }

        public void MonsterMove()
        {
            int count = 2;
            for (int i = 0; i < count; i++)
            {
                if (ThePoint.PointCount < 200 && count != 3)
                    count++;
                Monsters[i].Move(Map);
                if (Monsters[i].GetCoordMonster() == PacMan.GetCoordMonster())
                {
                    if (Monsters[i].SuperMonster == true)
                        Eaten(this, EventArgs.Empty);
                    else if (Monsters[i].SuperMonster == false)
                        Eat(this, EventArgs.Empty);
                }
            }
        }

        public void PacManMove()
        {
            ConsoleLib.Coord temp = PacMan.DirectionalCheck();
            Thread.Sleep(100);
            if (Console.KeyAvailable == true)
                PacMan.Move(Map);
            else if (Map.GetPointInMap(temp.y, temp.x) != 1)
            {
                PacMan.DeleteDraw(Map);
                PacMan.SetCoordMonster(temp);
                PacMan.Draw(Map);
            }
        }

        public void Eaten(object sender, EventArgs e)
        {
            for (int i = 0; i < Monsters.Count; i++)
            {
                if (Monsters[i].GetCoordMonster() == PacMan.GetCoordMonster())
                {
                    if (Monsters[i].PrevSymbol == 2)
                    {
                        DoPointInGame(this, EventArgs.Empty);
                    }
                    else if (Monsters[i].PrevSymbol == 3)
                    {
                        DoSuperPointInGame(this, EventArgs.Empty);
                    }
                    Monsters[i].PrevSymbol = 0;
                    if (i == 0)
                        Monsters[0].SetCoordMonster(Monsters[0].GetCoordMonsterStart().y, Monsters[0].GetCoordMonsterStart().x);
                    if (i == 1)
                        Monsters[1].SetCoordMonster(Monsters[1].GetCoordMonsterStart().y, Monsters[1].GetCoordMonsterStart().x);
                    if (i == 2)
                        Monsters[2].SetCoordMonster(Monsters[2].GetCoordMonsterStart().y, Monsters[2].GetCoordMonsterStart().x);
                    Monsters[i].Draw(Map);
                }
            }
        }

        public void Eat(object sender, EventArgs e)
        {
            for (int i = 0; i < Monsters.Count; i++)
            {
                if (Monsters[i].GetCoordMonster() == PacMan.GetCoordMonster())
                {
                    Caretaker caretaker = new Caretaker(this);
                    caretaker.Backup();

                    caretaker.Undo();
                    break;
                }
            }
        }

        public void TimerStartGame()
        {
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                ConsoleLib.GotoXY(34, 20);
                Console.WriteLine("START");
                ConsoleLib.GotoXY(36, 21);
                Console.WriteLine($"0{3 - i}");
            }
            ConsoleLib.GotoXY(34, 20);
            Console.WriteLine("     ");
            ConsoleLib.GotoXY(36, 21);
            Console.WriteLine("  ");
        }

        public ConsoleKey AfterPlay()
        {
            Console.Clear();
            ConsoleLib.GotoXY(35, 20);

            if ((ThePoint.PointCount + TheSuperPoint.SuperPointCount) == 0 || WinCheck() == true)
                SaveScore();
            else
                Console.WriteLine($"You are Loss sorry");

            ConsoleLib.GotoXY(35, 21);
            Console.WriteLine($"If You want new Game Press Enter");
            ConsoleLib.GotoXY(35, 22);
            Console.WriteLine($"Exit Press ESC");
            return Console.ReadKey().Key;
        }

        public void PauseInGame(object sender, EventArgs e)
        {
            ConsoleLib.GotoXY(34, 20);
            Console.WriteLine("PAUSE");
            ConsoleKey choice;

            ConsoleColor back = CaseLeft(ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Black);
            do
            {
                choice = Console.ReadKey().Key;
                if(choice == ConsoleKey.LeftArrow)
                {
                    back = CaseLeft(ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Black);
                }
                else if (choice == ConsoleKey.RightArrow)
                {
                    back = CaseLeft(ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Red);
                }
            } while (choice != ConsoleKey.Enter && choice != ConsoleKey.Escape);

            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
            ConsoleLib.GotoXY(34, 20);
            Console.WriteLine("      ");
            ConsoleLib.GotoXY(32, 21);
            Console.WriteLine("   ");
            ConsoleLib.GotoXY(36, 21);
            Console.WriteLine("    ");
            if(choice == ConsoleKey.Enter)
            {
                if (back == ConsoleColor.Red)
                    ExitFromGame = true;
            }
        }

        public ConsoleColor CaseLeft(ConsoleColor B, ConsoleColor T, ConsoleColor TB)
        {
            ConsoleLib.GotoXY(32, 21);
            ConsoleLib.SetColor(B, T);
            Console.WriteLine("Esc");
            ConsoleLib.GotoXY(36, 21);
            ConsoleLib.SetColor(B, TB);
            Console.WriteLine("Play");
            return T;
        }

        public bool WinCheck()
        {
            bool win = true;
            for (int i = 0; i < Map.SizeY; i++)
            {
                for (int j = 0; j < Map.SizeX; j++)
                {
                    if (Map.GetPointInMap(i, j) == 2)
                    {
                        win = false;
                        break;
                    }
                }
                if (!win)
                    break;
            }
            return win;
        }

        public void SaveScore()
        {
            ConsoleLib.GotoXY(35, 21);
            Console.WriteLine($"You are Win your score :: {PacMan.Score}");
            ConsoleLib.GotoXY(35, 22);
            Console.Write($"Write your name :: ");
            string name = Console.ReadLine();

            List<SaveLoad> saveLoads = new List<SaveLoad>(10);
            FileManager.Load(ref saveLoads);
            SaveLoad save = new SaveLoad()
            {
                name = name,
                score = PacMan.Score
            };

            if (saveLoads.Count == 10)
            {
                for (int i = 0; i < saveLoads.Count; i++)
                {
                    if (saveLoads[i].score < save.score)
                    {
                        for (int j = saveLoads.Count - 2; j > i; j--)
                        {
                            saveLoads[j + 1] = saveLoads[j];
                        }
                        saveLoads[i] = save;
                        break;
                    }
                }
            }
            else
            {
                saveLoads.Add(save);
            }
            FileManager.Save(saveLoads);
            Console.Clear();
        }

        public Memento SaveGame()
        {

            for (int i = 0; i < Monsters.Count; i++)
            {
                Monsters[i].DeleteDraw(Map);
                Monsters[i].PrevSymbol = 0;
                Monsters[i].Direction = 1;
                Monsters[i].SuperMonster = false;
                Monsters[i].SetCoordMonster(Monsters[i].GetCoordMonsterStart());
            }
            PacMan.SetCoordMonster(PacMan.GetCoordMonsterStart());

            return new Memento(Map, TheSuperPoint, ThePoint);
        }

        public void LoadGame(Memento m)
        {
            Map = m.MMap;
            TheSuperPoint = m.MTheSuperPoint;
            ThePoint = m.MThePoint;

            PacMan.Draw(Map);
            for (int i = 0; i < Monsters.Count; i++)
            {
                Monsters[i].Draw(Map);
            }
            // PacMan.CancelSuperPoint(PacMan, EventArgs.Empty);
            PacMan.Life--;
        }
    }
}
