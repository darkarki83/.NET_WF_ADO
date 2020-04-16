using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite
{
    class Composite : ClassComponent
    {
        protected List<ClassComponent> AllComponent = new List<ClassComponent>();

        public Composite(string name, double cost) : base(name,cost) { }
        public override double Get_Component_Cost()
        {
            double tmp = 0;
            for (int i = 0; i < AllComponent.Count(); i++)
            {
                tmp += AllComponent[i].Get_Component_Cost();
            }
            return tmp;
        }


        public override void Add(ClassComponent exe)
        {
            AllComponent.Add(exe);
           
        }
       
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Include//////////////////");
            foreach (ClassComponent i in AllComponent)
                i.Print();
        }
    }


    class Create_comp : Composite
    {
        public Create_comp(string the_name, double the_cost) : base(the_name, the_cost) { }

        public Composite Create_computer()
        {

            Add(new Hard_disc());
            Add(new Comp_body());
            Add(new Display());
            cost = Get_Component_Cost();
            return this;
        }
    }

    class Create_room : Composite
    {
        public Create_room(string the_name, double the_cost) : base(the_name, the_cost) { }

        public Composite Create_one_room()
        {
            Add(new Create_comp("computer", 1).Create_computer());
            Add(new Chair());
            cost = Get_Component_Cost();
            return this;
        }
    }


}