using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public interface IMonsterMoved
    {
        void Move(MyMap map);
	    void Draw(MyMap map);
        void DrawBack(MyMap map);
        void DeleteDraw(MyMap map);
	    void Eat(MyMap map);
    }

    public interface IMonsterPrimitiv
    {
        void Eaten();
    }

    public class Point : IMonsterPrimitiv
    {
        public int PointCount { get; private set; }

        public Point() => PointCount = 265;

        public void Handler(object sender, EventArgs e) => Eaten();

        public void Eaten() =>  PointCount--;
    }

    public class SuperPoint : IMonsterPrimitiv
    {
        public int SuperPointCount { get; private set; }

        public SuperPoint() => SuperPointCount = 4;

        public void Handler(object sender, EventArgs e) => Eaten();

        public void Eaten() => SuperPointCount--;
    }
}
