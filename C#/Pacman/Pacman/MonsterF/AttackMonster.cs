using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class AttackMonster : Monster
    {
        private Pacaman _pacman;
        private List<StrategyMove>  ourMove;

        public int Time { get; set; }

        public AttackMonster(Pacaman pacaman, ConsoleLib.Coord coordMonsters, List<StrategyMove> theOurMove
            , ConsoleColor color) : base(coordMonsters, color)
        {
            _pacman = pacaman;

            ourMove = new List<StrategyMove>();
            ourMove = theOurMove;

            PrevSymbol = 0;
            Time = 0;
        }

        public override void Move(MyMap map)
        {
            Time++;

            if (SuperMonster != true)
            {
                if (Time <= 20)
                    ourMove[0].Move(this, map, _pacman);
                if (Time <= 30 && Time > 21)
                    ourMove[1].Move(this, map, _pacman);
                if (Time > 30)
                    Time = 0;
            }
            else
                ourMove[2].Move(this, map, _pacman);
        }

        public override void Draw(MyMap map)
        {
            if (SuperMonster == false)
            {
                ConsoleLib.SetColor(ConsoleColor.White, GetConsoleColor());
                ConsoleLib.WriteChar(GetCoordStartMap().x + GetCoordMonster().x, GetCoordStartMap().y + GetCoordMonster().y, (char)177);
                ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
            }
            else
            {
                ConsoleLib.SetColor(ConsoleColor.Black, ConsoleColor.White);
                ConsoleLib.WriteChar(GetCoordStartMap().x + GetCoordMonster().x, GetCoordStartMap().y + GetCoordMonster().y, (char)177);
                ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
            }
        }

        public override void DrawBack(MyMap map)
        {
            PrevSymbol = map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x);
            if (PrevSymbol == map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x))
                map.SetPointInMap(GetCoordMonster().y, GetCoordMonster().x, 7);
            else
            {
                PrevSymbol = map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x);
                if (PrevSymbol == map.GetPointInMap(GetCoordMonster().y, GetCoordMonster().x))
                    map.SetPointInMap(GetCoordMonster().y, GetCoordMonster().x, 7);
                throw new Exception("no DrowBack");
            }
        }

        public override void DeleteDraw(MyMap map)
        {
            const char Point = (char)183;
            const char SuperPoint = (char)164;
            const char GorizontInside = (char)9472;

            map.SetPointInMap(GetCoordMonster(), PrevSymbol);

            if (PrevSymbol == 0)
            {
                ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x,
                    GetCoordMonster().y + GetCoordStartMap().y, ' ');
            }
            else if (PrevSymbol == 1)
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x,
                    GetCoordMonster().y + GetCoordStartMap().y, GorizontInside);
            else if (PrevSymbol == 2)
            {
                ConsoleLib.SetColor(ConsoleColor.Yellow, ConsoleColor.Black);
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x,
                    GetCoordMonster().y + GetCoordStartMap().y, Point);
            }
            else if (PrevSymbol == 3)
            {
                ConsoleLib.SetColor(ConsoleColor.Green, ConsoleColor.Black);
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x, 
                    GetCoordMonster().y + GetCoordStartMap().y, SuperPoint);
            }
            else
            {
                ConsoleLib.SetColor(ConsoleColor.White, ConsoleColor.Black);
                ConsoleLib.WriteChar(GetCoordMonster().x + GetCoordStartMap().x,
                    GetCoordMonster().y + GetCoordStartMap().y, ' ');
                map.SetPointInMap(GetCoordMonster(), 0);
            }
        }

        //int eatan(my_map& map) override { return 1; }

    }
}
