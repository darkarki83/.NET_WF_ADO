using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
//            1)
            int count = 0;
            int sum = 0;

            while (count < 3)
            {
                Console.WriteLine("Write mespar");
                int number = int.Parse(Console.ReadLine());

                int i;
                for (i = number - 1; i >= 2; i--)
                {
                    if (number % i == 0)
                    {
                        break;
                    }
                }
                if (i == 1)
                {
                    sum += number;
                    count++;
                }
                else
                {
                    break;
                }
            }
            if (count == 3)
                Console.WriteLine($"sum ={sum}");
            else
                Console.WriteLine($"Not prime number");


         // 2)
            Console.WriteLine("Write Number");
            int num = int.Parse(Console.ReadLine());

            TimeSpan totalSecond = TimeSpan.FromSeconds(num);

            int a = 0, b = 0, c = 0;
            double  d;

            d = totalSecond.TotalSeconds;

            if (num > 0)
            {
                Console.WriteLine($"seconds, as follows: {totalSecond.TotalSeconds}");
                if ((totalSecond.TotalSeconds / (24 * 60 * 60)) > 1)
                {
                    a = (int)(d / (24 * 60 * 60));
                }
                if (totalSecond.TotalSeconds / (60 * 60) > 1)
                {
                    b = (int)((d - a * (24 * 60 * 60)) / (60 * 60));
                }
                if (totalSecond.TotalSeconds / (60) > 1)
                {
                    c = (int)((d - a * (24 * 60 * 60) - b * (60 * 60)) / 60);
                    d = (int)((d - a * (24 * 60 * 60) - b * (60 * 60)) % 60);
                }

                Console.WriteLine($"day: {a}");
                Console.WriteLine($"hour: {b}");
                Console.WriteLine($"min: {c}");
                Console.WriteLine($"sec: {d}");

            }
            else
            {
                Console.WriteLine("bAY -BAY");
            }


                //3)

            Console.WriteLine("Write Number");
            int numb = int.Parse(Console.ReadLine());

            int shearit = numb / 10 ;
            int choicePrint = 1;

            while (shearit != 0) 
            {
                shearit = shearit / 10;
                choicePrint++;

            } 

            switch(choicePrint)
            {
                case 1:
                    Console.WriteLine($"{numb}******");
                    break;
                case 2:
                    Console.WriteLine($"{numb}*****");
                    break;
                case 3:
                    Console.WriteLine($"{numb}****");
                    break;
                case 4:
                    Console.WriteLine($"{numb}***");
                    break;
                case 5:
                    Console.WriteLine($"{numb}**");
                    break;
                case 6:
                    Console.WriteLine($"{numb}*");
                    break;
                case 7:
                    Console.WriteLine($"{numb}");
                    break;

            }
            

        }
              
    }
}
