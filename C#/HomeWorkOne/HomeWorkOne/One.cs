using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne
{
    class One
    {
        private int[] MyArrays{ get; set; }

        public One() => MyArrays = new int[10];


        public void RandTheArray()
        {
            Random R = new Random();
            for (int i = 0; i < MyArrays.Length; i++)
                MyArrays[i] = R.Next(-5, 4);
        }

        public void Print()
        {
            foreach (int item in MyArrays)
                Console.WriteLine($"{item}");
            Console.WriteLine();
        }

        public void Sort()
        {
            for (int i = 0; i < MyArrays.Length; i++)
            {
                if(MyArrays[i] == 0)
                {
                    for (int j = i; j < MyArrays.Length - 1; j++)
                        MyArrays[j] = MyArrays[j + 1];
        
                    MyArrays[MyArrays.Length - 1] = -1;
                    i--;
                }
            }
        }

        public void SortPositiv()
        {
            int[] temp = new int[MyArrays.Length];
            int Count = 0;
            int LastCount = MyArrays.Length - 1;

            for (int i = 0; i < MyArrays.Length; i++)
            {
                if (MyArrays[i] < 0)
                {
                    temp[Count] = MyArrays[i];
                    Count++;
                }
                else
                {
                    temp[LastCount] = MyArrays[i];
                    LastCount--;
                }
            }
            MyArrays = temp;
        }

        public int InputNum() => Convert.ToInt32(Console.ReadLine());

        public int CountInArray(int value)
        {
            int count = 0;
            foreach (int val in MyArrays)
                if (val == value)
                    count++;
            return count;
        }
    }

    class SuperChange
    {
        private int[,] Arrays { get; set; }

        public SuperChange(int M, int N)
        {
            Arrays = new int[M, N];
        }

        public void RandArray()
        {
            Random R = new Random();
            for (int i = 0; i < Arrays.GetLength(0); i++)
            {
                for (int j = 0; j < Arrays.GetLength(1); j++)
                {
                    Arrays[i, j] = R.Next(1, 100);
                }
            }
        }

        public void ColumnWrap()
        {
            int temp = 0;
            for (int i = 0; i < Arrays.GetLength(0); i++)
            {
                for (int j = 0; j < Arrays.GetLength(1); j++)
                {
                    if (j == 0)
                        temp = Arrays[i, j];
                    if (j + 1 < Arrays.GetLength(1))
                        Arrays[i, j] = Arrays[i, j + 1];
                    else
                        Arrays[i, j] = temp;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Arrays.GetLength(0); i++)
            {
                for (int j = 0; j < Arrays.GetLength(1); j++)
                {
                    Console.Write("{0,4}", Arrays[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    class StringStatistic
    {
        private string our_str { get; set; }
        private int synbol { get; set; }
        private int letters { get; set; }
        private int number { get; set; }
        private int punctuation { get; set; }
        private int space { get; set; }

        public StringStatistic()
        {
            our_str = null;
            synbol = 0;
            letters = 0;
            number = 0;
            punctuation = 0;
            space = 0;
        }

        public void Input_Str()
        {
            Console.Write("write the string : ");
            our_str = Console.ReadLine();
        }

        public void Counting()
        {
            int i;
            for (i = 0; i < our_str.Length; i++)
            {
                if(our_str[i] > '0' && our_str[i] < '9')
                    number++;
                if (our_str[i] >= 'a' && our_str[i] <= 'z' || our_str[i] >= 'A' && our_str[i] <= 'Z')
                    letters++;
                if (our_str[i] >= 33 && our_str[i] <= 47 || our_str[i] >= 58 && our_str[i] <= 64)
                    punctuation++;
                if (our_str[i] == ' ')
                    space++;
            }
            synbol = i;
        }

        public void Print()
        {
            Console.WriteLine("symbil {0} letters {1} number {2} punctuation {3} space {4} ", synbol, letters, number, punctuation, space);
        }
    }

    class StringChange
    {
        private string our_str { get; set; }
        private char synbol { get; set; }

        public StringChange()
        {
            our_str = null;
            synbol = ' ';
        }

        public void InputStr()
        {
            Console.Write("write the string : ");
            our_str = Console.ReadLine();
            Console.Write("write the symbol : ");
            synbol = (char)Console.Read();
        }

        public void NewStr()
        {
            char NewC = char.ToUpperInvariant(synbol);
            our_str = our_str.Aggregate("", (current, t) => current + (t == synbol ? NewC : t));

            our_str = our_str.Remove(our_str.LastIndexOf(NewC) + 1, our_str.Length - our_str.LastIndexOf(NewC) - 1);
        }
        public void Print()
        {
            Console.WriteLine("new string {0} ", our_str);
        }
    }
}
