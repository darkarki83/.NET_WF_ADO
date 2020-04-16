using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite
{
    abstract class ClassComponent
    {
        protected string name;
        protected double cost;

        public ClassComponent(string names, double costs)
        {
            this.name = names;
            this.cost = costs;

        }

        virtual public void Add(ClassComponent exe) { }

        virtual public double Get_Component_Cost() { return cost; }
       

        virtual public void Print()
        {
            Console.WriteLine("Name :" + name);
            Console.WriteLine("Cost :" + cost);
        }
    }
}
