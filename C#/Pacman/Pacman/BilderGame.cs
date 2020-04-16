using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public abstract class IBilder    // абстрактный bilder
    {
        public abstract void CreatePacman();

        public abstract void CreateRed();

        public abstract void CreateSpeedy();

        public abstract void CreateBlue();

        public abstract void CreateOrange();

        public abstract Game GetGame();
    }

    public class BilderGame : IBilder  // concret bilder
    {
        public Game TheGame { get; set; }

        public BilderGame()
        {
            TheGame = new Game(); // создание самой игры
            TheGame.Monsters = new List<Monster>(); // создание всех монстров
            TheGame.Map = new MyMap();              // создание карты
        }

        public override void CreatePacman()
        {
            var coordPacaman = new ConsoleLib.Coord();  // переменая координат для создания pacamen
            coordPacaman.x = 1;                                      // начальная точка для pacamen
            coordPacaman.y = 1;

            TheGame.PacMan = new Pacaman(coordPacaman); //создание pacamen
            {
                TheGame.PacMan.DoPoint += TheGame.ThePoint.Handler;
                TheGame.PacMan.DoSuperPoint += TheGame.TheSuperPoint.Handler;
                TheGame.PacMan.EatenMonster += TheGame.Eaten;
                TheGame.PacMan.EatMonster += TheGame.Eat;
                TheGame.PacMan.PauseP += TheGame.PauseInGame;

            }

            TheGame.DoPointInGame += TheGame.ThePoint.Handler;
            TheGame.DoSuperPointInGame += TheGame.TheSuperPoint.Handler;
        }

        public override void CreateRed()
        {
            ConsoleLib.Coord coordRed = new ConsoleLib.Coord(); // переменая координат для создания red
            coordRed.x = 15;                                    // начальная точка для red
            coordRed.y = 11;

            var RedMove = new List<StrategyMove>();  // масивв стратегий поведания
            var Red = new RedCreater();              // фабричный метод для стратегий

            RedMove.Add(Red.CreateFirstStrategy());   //  вызов методов и создание стратегий
            RedMove.Add(Red.CreateSecondStrategy());
            RedMove.Add(Red.CreateAfraidStrategy());

            TheGame.Monsters.Add(new AttackMonster(TheGame.PacMan, coordRed, RedMove, ConsoleColor.Red));  //создание red
            {
                TheGame.PacMan.DoSuperPoint += TheGame.Monsters[0].Handler;
                TheGame.PacMan.CancelSuperPoint += TheGame.Monsters[0].StopSupurMonstr;
            }
        }

        public override void CreateSpeedy()
        {
            var coordRed = new ConsoleLib.Coord();   // переменая координат для создания Speedy
            coordRed.x = 15;                         // начальная точка для Speedy
            coordRed.y = 13;

            var SpeedyMove = new List<StrategyMove>();         // масивв стратегий поведания
            var Speedy = new SpeedyCreater();                  // фабричный метод для стратегий

            SpeedyMove.Add(Speedy.CreateFirstStrategy());       //  вызов методов и создание стратегий
            SpeedyMove.Add(Speedy.CreateSecondStrategy());
            SpeedyMove.Add(Speedy.CreateAfraidStrategy());

            TheGame.Monsters.Add(new AttackMonster(TheGame.PacMan, coordRed, SpeedyMove, ConsoleColor.Green)); // создание speedy
            {
                TheGame.PacMan.DoSuperPoint += TheGame.Monsters[1].Handler;
                TheGame.PacMan.CancelSuperPoint += TheGame.Monsters[1].StopSupurMonstr;
            }
        }

        public override void CreateBlue()
        {
            var coordBlue = new ConsoleLib.Coord();   // переменая координат для создания Blue
            coordBlue.x = 13;                         // начальная точка для Blue
            coordBlue.y = 13;

            var BlueMove = new List<StrategyMove>();         // масивв стратегий поведания
            var Blue = new BlueCreater();                  // фабричный метод для стратегий

            BlueMove.Add(Blue.CreateFirstStrategy());       //  вызов методов и создание стратегий
            BlueMove.Add(Blue.CreateSecondStrategy());
            BlueMove.Add(Blue.CreateAfraidStrategy());

            TheGame.Monsters.Add(new AttackMonster(TheGame.PacMan, coordBlue, BlueMove, ConsoleColor.Blue)); // создание Blue
            {
                TheGame.PacMan.DoSuperPoint += TheGame.Monsters[2].Handler;
                TheGame.PacMan.CancelSuperPoint += TheGame.Monsters[2].StopSupurMonstr;
            }
        }

        public override void CreateOrange()
        { }

        public override Game GetGame() => TheGame;
    }

    class Director   // derector
    {
        private IBilder builderGame;    // поле bilder

        public Director(IBilder builder)  // constructor
        {
            this.builderGame = builder;
        }

        public void Construct()  // алгоритм создания нашего обьекта
        {
            builderGame.CreatePacman();
            builderGame.CreateRed();
            builderGame.CreateSpeedy();
            builderGame.CreateBlue();
        }
    }
}
