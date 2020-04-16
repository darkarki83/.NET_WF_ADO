using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne
{
    struct CoordAB
    {
        public int TheA;
        public int TheB;
        public CoordAB(int a = 0, int b = 0)
        {
            TheA = a;
            TheB = b;
        }
    }
    class Second        
    {
        public CoordAB A1B1 { get; set; }
        public CoordAB A2B2 { get; set; }
        public CoordAB YX { get; set; }


        public Second() { A1B1 = new CoordAB(); A2B2 = new CoordAB(); YX = new CoordAB(1,1); }

        static public string Input()
        {
            string str = Console.ReadLine();
            return str;
        }

        public static void Cheak(string str)
        {
            int CountSpace = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    CountSpace++;
                if (str[i] == ',')
                    CountSpace++;
                if ((str[i] < '0' || str[i] > '9') && (str[i] != ' ' && str[i] != ',') && str[i] != '-')
                {
                    throw new Exception("Исключение не верный ввод!");
                }
            }
            if (CountSpace != 1)
            {
                CountSpace = 0;
                throw new Exception("Исключение не верный ввод CountSpace!!");
            }
            CountSpace = 0;
        }

        public static CoordAB Parse(string str)
        {
            CoordAB first = new CoordAB();
           

            int tmp = 0;
            int count = 1;
            int i = 0;
            bool min = false;

            for (; i < str.Length; i++)
            {
                if(str[i] > '0' && str[i] < '9' || str[i] == '-')
                {
                    if (str[i] != '-')
                    {
                        tmp = (str[i] - '0') + tmp * count;
                        count *= 10;
                        if (i + 1 < str.Length && (str[i + 1] < '0' || str[i + 1] > '9'))
                        {

                            first.TheA = tmp;
                            count = 1;
                            tmp = 0;
                            if (min == true)
                            {
                                first.TheA *= -1;
                                min = false;
                            }
                        }
                        else if (i + 1 == str.Length)
                        {
                            first.TheB = tmp;
                            count = 1;
                            tmp = 0;
                            if (min == true)
                            {
                                first.TheB *= -1;
                                min = false;
                            }
                        }
                    }
                    else
                    {
                        min = true;
                    }
                }
            }
            return first;

        }

        public void Colculate()
        {
            if (A2B2.TheA - (A2B2.TheB * A1B1.TheA / A1B1.TheB) != 0)
            {
               // YX.TheB = 0;
            }
            else
            {
               // YX.TheB = A2B2.TheA - (A2B2.TheB * A1B1.TheA / A1B1.TheB);

            }





        }

        public void Print()
        {
            Console.WriteLine("A1 {0} B1 {1}", A1B1.TheA, A1B1.TheB);
            Console.WriteLine("A2 {0} B2 {1}", A2B2.TheA, A2B2.TheB);
            Console.WriteLine("Y {0} X {1}", YX.TheA, YX.TheB);
        }

    }
}
