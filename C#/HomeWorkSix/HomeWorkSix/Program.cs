using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkSix
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber one = new ComplexNumber(1, 1);
            ComplexNumber second = new ComplexNumber();


            second = one - (one * one * one - 1) / (3 * one * one);

            second.Print();

        }
    }
}
