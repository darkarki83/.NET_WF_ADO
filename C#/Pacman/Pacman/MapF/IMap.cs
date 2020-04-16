using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public interface IMap
    {
        int SizeY { get; set; }

        int SizeX { get; set; }

        int[,] Map { get; set; }

        int GetPointInMap(int newY, int newX);

        void SetPointInMap(int newY, int newX, int value);

        void SetPointInMap(ConsoleLib.Coord newCoord, int value);

        void Draw(int y, int x);
    }
}
