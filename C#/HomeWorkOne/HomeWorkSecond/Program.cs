using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Town one = new Rusian.Moscow();
            Town second = new Ukraine.Kiev();
            Town thert = new USA.NewYork();

            Comparison.ComparisonPopulation(one, second, thert);

        }


    }
    class Town
    {
        public virtual int Civilization { get; set; }
        public virtual void Print() { }
    }

    namespace Rusian
    {

        class Moscow : Town
        {
            public override int Civilization {get;set;}
            public Moscow() => Civilization = 12322525;
            public override void Print() => Console.WriteLine("Rusian=>Moscow=>Civilization {0}", Civilization);

        }
    }

    namespace Ukraine
    {

        class Kiev : Town
        {
            public override int Civilization { get; set; }
            public Kiev() => Civilization = 3452154;
            public override void Print() => Console.WriteLine("Ukraine=>Kiev=>Civilization {0}", Civilization);

        }
    }

    namespace USA
    {

        class NewYork : Town
        {
            public override int Civilization { get; set; }
            public NewYork() => Civilization = 21548587;
            public override void Print() => Console.WriteLine("USA=>NewYork=>Civilization {0}", Civilization);

        }
    }

    namespace Chaina
    {

        class Beijing : Town
        {
            public override int Civilization { get; set; }
            public Beijing() => Civilization = 19354859;
            public override void Print() => Console.WriteLine("Chaina=>Beijing=>Civilization {0}", Civilization);

        }
    }

    class Comparison
    {
        static public void ComparisonPopulation(Town one, Town second, Town thert)
        {
            if (one.Civilization > second.Civilization)
            {
                if (one.Civilization > thert.Civilization)

                    one.Print();
                else
                    thert.Print();
            }
            else
            {
                if (second.Civilization > thert.Civilization)
                    second.Print();
                else
                    thert.Print();
            }
        }
    }

}
