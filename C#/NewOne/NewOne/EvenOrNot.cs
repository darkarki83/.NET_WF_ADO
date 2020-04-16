using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOne
{
    // •	Ввести с клавиатуры число в диапазоне от 100 до 100000000 (введенное число проверяется).
    //  Подсчитать количество четных и нечетных цифр в этом числе в процентном отношении.
   

    class EvenOrNot
    {
        public int Number { get; set; }
        public int CountEven { get; set; }
        public int CountNotEven { get; set; }

        public EvenOrNot()
        {
            Number = 0;
            CountEven = 0;
            CountNotEven = 0;
        }
        public void InputNum()
        {
            Console.Write("write number :");
            string str = Console.ReadLine();
            Number = int.Parse(str);
        }

        public void Enumiration()
        {
            int temp = Number;
            do
            {
                if ((temp % 10) % 2 == 0)
                    CountEven++;
                else
                    CountNotEven++;
                temp /= 10;
            } while (temp != 0);
        }

        public void PrintNum()
        {
            Console.WriteLine("the num {0} even {1} noteven {2} ", Number , CountEven, CountNotEven);
        }
    }

    //•	Ввести с клавиатуры номер трамвайного билета (6-значное число) и проверить является ли данный билет счастливым.

    class HappyTicket
    {
        public int Number { get; set; }
        public bool Happy { get; set; }

        public HappyTicket()
        {
            Random r = new Random();
            Number = r.Next(100000, 999999);
            Happy = false;
        }
        public void HappyChack()
        {
            int temp = Number;
            int numOne = 0;
            int numSecond = 0;
            int count = 0;
            do
            {
                if (count < 3)
                    numOne += temp % 10;
                else 
                    numSecond += temp % 10;
                temp /= 10;
                count++;
            } while (temp != 0);
            Happy = (numOne == numSecond) ? true : false;
        }

        public void Print()
        {
            Console.WriteLine("Ticket  : {0} This ticket happy : {1} ", Number, Happy);
        }
    }

    //•	Ввести с клавиатуры дату своего рождения и текущую дату.
    // Необходимо вычислить разницу в днях между этими датами.
    class TwoDate
    {
        public struct Date
        {
            public byte day;
            public byte month;
            public ushort year;
        }

        private Date yourDate;
        private Date todayDate;
        
        public TwoDate()
        {
            yourDate = new Date();
            todayDate = new Date();
        }
        public void InputDate()
        {
            Console.Write("write date of your bird : \n");
            Console.Write("day : ");
            string str = Console.ReadLine();
            yourDate.day = byte.Parse(str);
            Console.Write("month : ");
            str = Console.ReadLine();
            yourDate.month = byte.Parse(str);
            Console.Write("year : ");
            str = Console.ReadLine();
            yourDate.year = ushort.Parse(str);

            Console.Write("write date todey : \n");
            Console.Write("day : ");
            str = Console.ReadLine();
            todayDate.day = byte.Parse(str);
            Console.Write("month : ");
            str = Console.ReadLine();
            todayDate.month = byte.Parse(str);
            Console.Write("year : ");
            str = Console.ReadLine();
            todayDate.year = ushort.Parse(str);
        }

        public int Differens()
        {
            int days = 0;
            if(todayDate.year - yourDate.year < 0)
                throw new Exception("You are little 0 Yaer");
            if (todayDate.day > 31)
                throw new Exception("Wrong input in This day");
            if (yourDate.day > 31)
                throw new Exception("Wrong input in This day");
            if (todayDate.year - yourDate.year < 0)
                throw new Exception("You are little 0 Yaer");
            days = (todayDate.year - yourDate.year) * 365 + (todayDate.year - yourDate.year) / 4 + (MonthToDay(todayDate.month)
                - MonthToDay(yourDate.month) + (todayDate.day - yourDate.day));
            if (days < 0)
                throw new Exception("Wrong input => todey is day befor your born");
            return days;
        }
        static int MonthToDay(int _month)
        {
            int temp = 0;
            switch(_month)
            {
                case 1:
                    temp = 0;
                    break;
                case 2:
                    temp = 29;
                    break;
                case 3:
                    temp = 60;
                    break;
                case 4:
                    temp = 91;
                    break;
                case 5:
                    temp = 121;
                    break;
                case 6:
                    temp = 152;
                    break;
                case 7:
                    temp = 182;
                    break;
                case 8:
                    temp = 213;
                    break;
                case 9:
                    temp = 244;
                    break;
                case 10:
                    temp = 274;
                    break;
                case 11:
                    temp = 305;
                    break;
                case 12:
                    temp = 335;
                    break;
                default:
                    throw new Exception("Wrong input Month");
            }
            return temp;
        }
        public void Print()
        {
            Console.WriteLine("yourDate.day {0} yourDate.month {1}  yourDate.year {2}\ntodayDate.day {3} todayDate.month {4}  todayDate.year {5} ", yourDate.day, yourDate.month, yourDate.year, todayDate.day, todayDate.month, todayDate.year);
        }
    }

    //•	Вывести на консоль изображение государственного флага Швейцарии 
    //(например, в виде звездочек). Размер стороны флага задается случайным
    //числом в диапазоне от 21 до 41. 

    class Flag
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Flag()
        {
            Random r = new Random();
            Height = r.Next(21, 41);
            Width = Height / 2;
        }
        public void Draw()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (((i == Width / 2 - 1 || i == Width / 2) && (j > 3 && j < Height - 4)) ||
                        ((j == Height / 2 - 1 || j == Height / 2) && (i > 1 && i < Width - 2)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
