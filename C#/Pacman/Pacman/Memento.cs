using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Memento
    {
        public MyMap MMap { get; set; }

        public SuperPoint MTheSuperPoint { get; set; }

        public Point MThePoint { get; set; }

        public Memento(MyMap Map, SuperPoint TheSuperPoint, Point ThePoint)
        {
            MMap = new MyMap();
            MMap = Map;

            MTheSuperPoint = new SuperPoint();
            MTheSuperPoint = TheSuperPoint;

            MThePoint = new Point();
            MThePoint = ThePoint;
        }
    }

    class Caretaker
    {
        private List<Memento> _mementos = new List<Memento>();

        private Game _game = null;

        public Caretaker(Game game)
        {
            this._game = game;
        }

        public void Backup()
        {
            this._mementos.Add(this._game.SaveGame());
        }

        public void Undo()
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            try
            {
                this._game.LoadGame(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }
    }
}
