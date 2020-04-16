using System;
using Pilote;
using RockersStuff;

namespace MaSuperApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rocket = new Rocket(233.33, new Pilot("Artem"));
            rocket.Print();

            var OnePilot = new Pilot("Vasiia");
            OnePilot.Name = "Big Bos";
        }


    }
}
