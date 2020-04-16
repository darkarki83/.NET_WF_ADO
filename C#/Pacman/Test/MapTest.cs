using NUnit.Framework;
using Pacman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class MapTest
    {
        [TestCase(0, 10, ExpectedResult = 1)]
        [TestCase(2, 30, ExpectedResult = 2)]
        [TestCase(4, 30, ExpectedResult = 3)]
        [TestCase(12, 10, ExpectedResult = 0)]
        public int GetPointInMap_Points_PointFromMap(int y, int x)
        {
            MyMap map = new MyMap();

            return map.GetPointInMap(y, x);
        }

        [TestCase(0, 10,  6)]
        [TestCase(2, 30,  0)]
        [TestCase(4, 30,  3)]
        [TestCase(12, 10, 5)]
        [TestCase(0, 10, 1)]
        [TestCase(2, 30, 2)]
        [TestCase(4, 30, 3)]
        [TestCase(12, 10, 0)]
        public void GSetPointInMap_Points_PointFromMap(int y, int x, int ourValue)
        {
            MyMap map = new MyMap();
            map.SetPointInMap(y, x, ourValue);

            Assert.That(ourValue, Is.EqualTo(map.GetPointInMap(y, x)));
        }

        [TestCase(0, 10, 6)]
        [TestCase(2, 30, 0)]
        [TestCase(4, 30, 3)]
        [TestCase(12, 10, 5)]
        [TestCase(0, 10, 1)]
        [TestCase(2, 30, 2)]
        [TestCase(4, 30, 3)]
        [TestCase(12, 10, 0)]
        public void SetPointInMap_Points_PointFromMap(int y,int x, int ourValue)
        {
            MyMap map = new MyMap();
            ConsoleLib.Coord newCoord = new ConsoleLib.Coord(0, 10);

            map.SetPointInMap(newCoord, ourValue);

            Assert.That(ourValue, Is.EqualTo(map.GetPointInMap(newCoord.y, newCoord.x)));
        }

        public void Draw(int y, int x)
        {

        }

    }
}
