using System;
using System.Timers;

namespace Pacman
{
    public class Pacaman : Monster
    {
        public event EventHandler DoSuperPoint;
        public event EventHandler DoPoint;
        public event EventHandler CancelSuperPoint;
        public event EventHandler EatenMonster;
        public event EventHandler EatMonster;
        public event EventHandler PauseP;
        //public event SuperPacman DoSuperPoint;
        public int Life { get; set; }

        public int Score { get; set; }

        public int CountEaten { get; set; }

        public Pacaman(ConsoleLib.Coord coordMonsters) : base(coordMonsters, ConsoleColor.Yellow)
        {
            ConsoleLib.Coord coordMonsterStart = new ConsoleLib.Coord();
            coordMonsterStart = coordMonsters;

            Life = 3;
            Score = 0;
            CountEaten = 1;
        }

        public ConsoleLib.Coord DirectionalCheck()
        {
            ConsoleLib.Coord temp = new ConsoleLib.Coord(0, 0);

            switch (Direction)
            {
                case 1:
                    temp.y = GetCoordMonster().y - 1;
                    temp.x = GetCoordMonster().x;
                    break;
                case 2:
                    temp.y = GetCoordMonster().y + 1;
                    temp.x = GetCoordMonster().x;
                    break;
                case 3:
                    if (GetCoordMonster().x != 0)
                    {
                        temp.y = GetCoordMonster().y;
                        temp.x = GetCoordMonster().x - 1;
                    }
                    else
                    {
                        temp.y = GetCoordMonster().y;
                        temp.x = 31;
                    }
                    break;
                case 4:
                    if (GetCoordMonster().x != 31)
                    {
                        temp.y = GetCoordMonster().y;
                        temp.x = GetCoordMonster().x + 1;
                    }
                    else
                    {
                        temp.y = GetCoordMonster().y;
                        temp.x = 0;
                    }
                    break;
            }
            return temp;
        }

        public override void Move(MyMap map)
        {
            ConsoleKey choice;
            ConsoleLib.Coord temp = DirectionalCheck();

            var Up = ConsoleKey.UpArrow;
            var Down = ConsoleKey.DownArrow;
            var Right = ConsoleKey.RightArrow;
            var Left = ConsoleKey.LeftArrow;
            var Esc = ConsoleKey.Escape;

            choice = Console.ReadKey().Key;

            DeleteDraw(map);

            if (GetCoordMonster().x != 31)
            {
                if ((choice == Right) && (map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x + 1) != 1))
                {
                    SetCoordMonster(GetCoordMonster().y, GetCoordMonster().x + 1);
                    Direction = 4;
                }
            }
            if (GetCoordMonster().x != 0)
            {
                if ((choice == Left) && (map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x - 1) != 1))
                {
                    SetCoordMonster(GetCoordMonster().y, GetCoordMonster().x - 1);
                    Direction = 3;
                }
            }
            if ((choice == Down) && (map.GetPointInMap(GetCoordMonster().y + 1, GetCoordMonster().x) != 1))
            {
                SetCoordMonster(GetCoordMonster().y + 1, GetCoordMonster().x);
                Direction = 2;
            }
            if ((choice == Up) && (map.GetPointInMap(GetCoordMonster().y - 1, GetCoordMonster().x) != 1))
            {
                SetCoordMonster(GetCoordMonster().y - 1, GetCoordMonster().x);
                Direction = 1;
            }
            if (choice == Esc)
            {
                Draw(map);
                PauseP(this, EventArgs.Empty);
            }
            Draw(map);

        }

        public override void Draw(MyMap map)
        {
            const char Up = (char)86, Down = (char)94, Right = (char)60, Left = (char)62;

            ConsoleLib.SetColor(ConsoleColor.Black, GetConsoleColor());
            if (Direction == 4)
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x, GetCoordMonster().y + GetCoordStartMap().y, Right);
            if (Direction == 3)
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x, GetCoordMonster().y + GetCoordStartMap().y, Left);
            if (Direction == 2)
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x, GetCoordMonster().y + GetCoordStartMap().y, Down);
            if (Direction == 1)
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x, GetCoordMonster().y + GetCoordStartMap().y, Up);
            ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);

            Eat(map);
            DrawBack(map);
            ConsoleLib.GotoXY(20, 5);         // вывод рекорда на посмотреть
            Console.Write("score :: {0}", Score);
        }

        public override void DrawBack(MyMap map)
        {
            map.SetPointInMap(GetCoordMonster(), 5);
        }

        public override void DeleteDraw(MyMap map)
        {
            map.SetPointInMap(GetCoordMonster(), 0);
            ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x, GetCoordMonster().y + GetCoordStartMap().y, ' ');
        }

        public override void Eat(MyMap map)
        {
            //int flag = 1;
            if (map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x) == 2)
            {
                Score += 10;
                if (DoSuperPoint != null)
                {
                    // Дополнительная информация о событии
                    DoPoint(this, EventArgs.Empty);

                    // Вызываем по очереди всех подписчиков, передавая им себя в
                    // качестве отправителя события и экземпляр класса EventArgs
                    // или его потомка в качестве дополнительной информации о событии
                }
            }

            if (map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x) == 3)
            {
                Score += 50;
                System.Timers.Timer timer = new System.Timers.Timer();
                if (SuperMonster == false)
                {
                    SuperMonster = true;

                    if (DoSuperPoint != null)
                    {
                        // Дополнительная информация о событии
                        DoSuperPoint(this, EventArgs.Empty);
                        CountEaten = 1;
                        timer.Interval = 8000;
                        timer.Start();

                        timer.AutoReset = false;
                        timer.Elapsed += TimerEvenHandler;
                    }
                }
                else
                {
                    timer.Interval += 8000;
                }
            }

            if (map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x) == 7)
            {
                if (SuperMonster == true)
                {
                    Score += Score + (CountEaten * 200);
                    CountEaten += 1;
                    EatenMonster(this, EventArgs.Empty);
                }
                else if (SuperMonster == false)
                {
                    EatMonster(this, EventArgs.Empty);
                }
            }
        }

        public void TimerEvenHandler(object o, ElapsedEventArgs e)
        {
            //Thread.Sleep(8000);
            SuperMonster = false;
            if (CancelSuperPoint != null)
            {
                // Дополнительная информация о событии
                CancelSuperPoint(this, EventArgs.Empty);

                // Вызываем по очереди всех подписчиков, передавая им себя в
                // качестве отправителя события и экземпляр класса EventArgs
                // или его потомка в качестве дополнительной информации о событии 
            }
        }
    }
}
