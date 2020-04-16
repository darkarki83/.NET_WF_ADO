using System;
using Pilote;

namespace RockersStuff
{
    public class Rocket
    {
        private double _power;
        private readonly Pilot _pilot = null;

        public Rocket(double power, Pilot pilot)
        {
            _power = power;
            _pilot = pilot;
        }
       // public double GetPower() => _power; 
       // public void SetPower(double power) => _power = power;  // пример гет и сетов

        public double Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public void Print()
        {
            Console.WriteLine("power {0}", _power);
            _pilot.Print();
        }

    }
}
