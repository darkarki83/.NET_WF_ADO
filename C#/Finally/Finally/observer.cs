using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    abstract class Observer
    {
       public abstract void UpDate(Subject somechange);
        
    }

    abstract class Subject
    {
        public List<Observer> Obs {get;set;}

        public abstract void AddObserver(Observer first);
        public abstract void Notify();
    }
}
