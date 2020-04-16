using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkSix
{
    class ComplexNumber
    {
        public double ComplexNum { get; set; }

        public ComplexNumber(double x, double y)
        {
            ComplexNum = 1;
        }

        public ComplexNumber()
        {
            ComplexNum = 0;
        }

        public static ComplexNumber operator +(ComplexNumber one, ComplexNumber second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum + second.ComplexNum;
            return temp;
        }
        public static ComplexNumber operator -(ComplexNumber one, ComplexNumber second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum - second.ComplexNum;
            return temp;
        }
        public static ComplexNumber operator *(ComplexNumber one, ComplexNumber second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum * second.ComplexNum;
            return temp;
        }
        public static ComplexNumber operator /(ComplexNumber one, ComplexNumber second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum / second.ComplexNum;
            return temp;
        }
        public static ComplexNumber operator -(ComplexNumber one)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum - 1;
            return temp;
        }
        public static ComplexNumber operator ++(ComplexNumber one)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum += 1; 
            return temp;
        }
       public static ComplexNumber operator +(ComplexNumber one, int second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum + second;
            return temp;
        }
        public static ComplexNumber operator +(int one, ComplexNumber second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one + second.ComplexNum;
            return temp;
        }
        public static ComplexNumber operator -(ComplexNumber one, int second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum - second;
            return temp;
        }
        public static ComplexNumber operator -(int one, ComplexNumber second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one - second.ComplexNum;
            return temp;
        }
        public static ComplexNumber operator *(ComplexNumber one, int second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one.ComplexNum * second;
            return temp;
        }
        public static ComplexNumber operator *(int one, ComplexNumber second)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.ComplexNum = one * second.ComplexNum;
            return temp;
        }
        public static bool operator <(ComplexNumber one, ComplexNumber second)
        {
            if (one.ComplexNum < second.ComplexNum)
                return true;
            else
                return false;
        }
        public static bool operator >(ComplexNumber one, ComplexNumber second)
        {
            if (one.ComplexNum > second.ComplexNum)
                return true;
            else
                return false;
        }
        public static bool operator ==(ComplexNumber one, ComplexNumber second)
        {
            if (one.ComplexNum == second.ComplexNum)
                return true;
            else
                return false;
        }
        public static bool operator !=(ComplexNumber one, ComplexNumber second)
        {
            if (one == second)
                return false;
            else
                return true;
        }
        public static implicit operator double(ComplexNumber one)
        {
            return one.ComplexNum;
        }

        public static implicit operator ComplexNumber(double one)
        {
            ComplexNumber TheNew = new ComplexNumber();
            TheNew.ComplexNum = one;
            return TheNew;
        }
        public void Print()
        {
            Console.WriteLine("Complex number {0}", ComplexNum);
        }

    }
}
