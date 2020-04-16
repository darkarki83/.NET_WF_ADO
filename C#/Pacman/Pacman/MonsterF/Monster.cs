using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pacman
{

    public class Monster : IMonsterMoved, IMonsterPrimitiv
    {
        private ConsoleLib.Coord _coordMonsterStart;
        private ConsoleLib.Coord _coordStartMap;

        protected ConsoleLib.Coord _coordMonster;
        protected ConsoleColor color;

        public int Direction { get; set; }

        public bool SuperMonster { get; set; }

        public int PrevSymbol { get; set; }

        public Monster(ConsoleLib.Coord coordMonsters, ConsoleColor colors)
        {
            _coordMonsterStart = new ConsoleLib.Coord();
            _coordMonsterStart = coordMonsters;
           
            _coordStartMap.y = 6;
            _coordStartMap.x = 20;

            _coordMonster = new ConsoleLib.Coord();
            _coordMonster = coordMonsters;

            color = colors;

            Direction = 1;
            SuperMonster = false;
        }

        public void Handler(object sender, EventArgs e) => SuperMonster = true;

        public void StopSupurMonstr(object sender, EventArgs e) => SuperMonster = false;

        public ConsoleLib.Coord GetCoordMonster() => _coordMonster;

        public ConsoleLib.Coord GetCoordStartMap() => _coordStartMap;

        public void SetCoordMonster(ConsoleLib.Coord coordMonster) => _coordMonster = coordMonster;

        public void SetCoordMonster(int newY, int newX) => _coordMonster = new ConsoleLib.Coord(newY, newX);

        public ConsoleLib.Coord GetCoordMonsterStart() => _coordMonsterStart;

        protected void SetCoordMonsterStart(ConsoleLib.Coord coordMonsterStart) => _coordMonsterStart = coordMonsterStart;

        public ConsoleColor GetConsoleColor() => color; 

        public void Tunnel(MyMap map)
        {
            if (GetCoordMonster().y == 14 && GetCoordMonster().x == 0)
            {
                if (Direction != 4)
                    SetCoordMonster(GetCoordMonster().y, 31);
                else if (Direction != 3)
                    SetCoordMonster(GetCoordMonster().y, 1);
            }
            else if (GetCoordMonster().y == 14 && GetCoordMonster().x == 31)
            {
                if (Direction != 3)
                    SetCoordMonster(GetCoordMonster().y, 0);
                else if (Direction != 4)
                    SetCoordMonster(GetCoordMonster().y, 30);
            }
        }

        public virtual void Move(MyMap map) { }
        public virtual void Draw(MyMap map) { }
        public virtual void DrawBack(MyMap map) { }
        public virtual void DeleteDraw(MyMap map) { }
        public virtual void Eat(MyMap map) { }
        public virtual void Eaten() { }
    }
}
