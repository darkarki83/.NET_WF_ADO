using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    /*Разработать класс Fraction, представляющий простую дробь. 
В классе предусмотреть два поля: числитель и знаменатель дроби. 
Выполнить перегрузку следующих операторов: 
+,-,*,/,==,!=,<,>, true и false
Арифметические действия и сравнение выполняется в соответствии с правилами  работы с дробями. 
Оператор true возвращает true если дробь правильная (числитель меньше знаменателя),  оператор false возвращает true если дробь неправильная (числитель больше знаменателя). 
Выполнить перегрузку операторов, необходимых для успешной компиляции следующего фрагмента кода: 
Fraction f = new Fraction(3, 4);
int a = 10;
Fraction f1 = f * a;
Fraction f2 = a * f;
double d = 1.5;
Fraction f3 = f + d; 
*/
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public Fraction()
        {
            Numerator = 0;
            Denominator = 1; 
        }
        public Fraction(int num, int den)
        {
            if (den == 0)
                throw new Exception("denominator cennot be 0");
            Numerator = num;
            Denominator = den;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator * 397) ^ Denominator;
            }
        }
        protected bool Equals(Fraction other)
        {
            return Numerator * other.Denominator == Denominator * other.Numerator;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            return Equals((Fraction)obj);
        }
        public static Fraction operator +(Fraction one, Fraction two)
        {
            Fraction temp = new Fraction();
            temp.Denominator = one.Denominator * two.Denominator;
            temp.Numerator = one.Numerator * two.Denominator + one.Denominator * two.Numerator;
            return temp;
        }
        public static Fraction operator +(Fraction one, int two)
        {
            Fraction temp = new Fraction();
            temp.Denominator = one.Denominator;
            temp.Numerator = one.Numerator + one.Denominator * two;
            return temp;
        }
        public static Fraction operator +(int one, Fraction two)
        {
            return two + one;
        }
        public static Fraction operator *(Fraction one, int two)
        {
            Fraction temp = new Fraction();
            temp.Denominator = one.Denominator;
            temp.Numerator = one.Numerator * two;
            return temp;
        }
        public static Fraction operator *(int two, Fraction one)
        {

            return one * two;
        }
        public static Fraction operator +(Fraction one, double two)
        {
            Fraction temp = new Fraction();
            temp.Denominator = one.Denominator * 10;
            temp.Numerator = (int)(one.Numerator * 10 + one.Denominator * two * 10);
            return temp;
        }


        public static Fraction operator -(Fraction one, Fraction two)
        {
            Fraction temp = new Fraction();
            temp.Denominator = one.Denominator * two.Denominator;
            temp.Numerator = one.Numerator * two.Denominator - one.Denominator * two.Numerator;
            return temp;
        }
        public static Fraction operator *(Fraction one, Fraction two)
        {
            Fraction temp = new Fraction();
            temp.Denominator = one.Denominator * two.Denominator;
            temp.Numerator = one.Numerator * two.Numerator;
            return temp;
        }
        public static Fraction operator /(Fraction one, Fraction two)
        {
            Fraction temp = new Fraction();
            temp.Denominator = one.Denominator * two.Numerator;
            temp.Numerator = one.Numerator * two.Denominator;
            return temp;
        }
        public static bool operator ==(Fraction one, Fraction two)
        {
            if (one.Numerator * two.Denominator == one.Denominator * two.Numerator)
                return true;
            else
                return false;
        }
        public static bool operator !=(Fraction one, Fraction two)
        {
            if (one.Numerator * two.Denominator == one.Denominator * two.Numerator)
                return false;
            else
                return true;
        }
        public static bool operator >(Fraction one, Fraction two)
        {
            if (one.Numerator * two.Denominator > one.Denominator * two.Numerator)
                return true;
            else
                return false;
        }
        public static bool operator <(Fraction one, Fraction two)
        {
            if (one.Numerator * two.Denominator< one.Denominator * two.Numerator)
                return true;
            else
                return false;
        }
        public static bool operator true(Fraction one)
        {
            return (one.Numerator < one.Denominator ? true : false);
        }

        public static bool operator false(Fraction one)
        {
            return (one.Numerator > one.Denominator ? true : false);
        }


        public void Print()
        {
            Console.WriteLine("Num / Den = {0} / {1}", Numerator, Denominator);
        }





















    }
    class Program
    {





        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 4);
            f.Print();
            int a = 10;
            Fraction f1 = f * a;
            f1.Print();
            Fraction f2 = a * f;
            f2.Print();

            double d = 1.5;
            Fraction f3 = f + d;
            f3.Print();


        }
    }
}
