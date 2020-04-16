using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public abstract class FactoryMetod  // абстрактный базавый класс factory metod
    {                                   // для создания стратегии поведения
        public abstract StrategyMove CreateFirstStrategy();

        public abstract StrategyMove CreateSecondStrategy();

        public abstract StrategyMove CreateAfraidStrategy();
    }

    public class SpeedyCreater : FactoryMetod  // (factory metod) созданий стратегии поведения для speedy
    {
        public override StrategyMove CreateFirstStrategy()
        {
            return new SpeedyFirstMove();
        }

        public override StrategyMove CreateSecondStrategy()
        {
            return new SpeedySecondMove();
        }

        public override StrategyMove CreateAfraidStrategy()
        {
            return new SpeedyAfraidMove();
        }
    }

    public class RedCreater : FactoryMetod  // (factory metod) созданий стратегии поведения для red
    {
        public override StrategyMove CreateFirstStrategy()
        {
            return new RedFirstMove();
        }

        public override StrategyMove CreateSecondStrategy()
        {
            return new RedSecondMove();
        }

        public override StrategyMove CreateAfraidStrategy()
        {
            return new RedAfraidMove();
        }
    }

    public class BlueCreater : FactoryMetod // (factory metod) созданий стратегии поведения для blue
    {
        public override StrategyMove CreateFirstStrategy()
        {
            return new BlueFirstMove();
        }

        public override StrategyMove CreateSecondStrategy()
        {
            return new BlueSecondMove();
        }

        public override StrategyMove CreateAfraidStrategy()
        {
            return new BlueAfraidMove();
        }
    }
}
