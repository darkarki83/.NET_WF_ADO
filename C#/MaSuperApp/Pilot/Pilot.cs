using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilote
{
    public class Pilot
    {
        private string _name;

        public Pilot(string name) => _name = name;


        public string  Name   // пример аргумента   // 
        {
            get { return _name; }
            set { _name = value; }
        }
       

        public void Print() => Console.WriteLine("name {0} ", _name);

    }
}
