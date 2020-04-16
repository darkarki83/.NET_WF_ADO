using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThree
{
    //•	Проверить не является ли заданная строка палиндромом.
    class TextWork
    {
        public string Text { get; set; }
        public TextWork() => Text = "";
        public void InputText()
        {
            Console.WriteLine("Write te text : ");
            Text = Console.ReadLine();
        }

        public void DeleteSpace()
        {
            char[] one = new char[Text.Length];
            int count = 0;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] != ' ')
                {
                    one[count] = Text[i];
                    count++;
                }
            }

            Text = new string(one , 0, count);
        }
        public bool IsPolindrom()
        {
            DeleteSpace();
            bool p = true;
            for (int i = 0; i < Text.Length / 2; i++)
            {
                if (Text[i] != Text[Text.Length - 1 - i])
                    p = false;
            }
            return p;
        }

        public void Print()
        {
            Console.WriteLine("strin {0}", Text);
        }
    }
    // •	Реализовать в заданном тексте поиск заданной подстроки и замены 
    //ее на другую заданную подстроку.
    class TextChack
    {
        public string Text { get; set; }
        public string SubText { get; set; }
        public string NewSubText { get; set; }


        public TextChack()
        {
            Text = "my name is Artem";
            SubText = "is";
            NewSubText = "are";
        }

        public void Chack()
        {
            int index = 0;
            index = Text.IndexOf(SubText);
            if(index >= 0)
            {
                Text = Text.Replace(SubText, NewSubText);
            }
        }
        public void Print()
        {
            Console.WriteLine("Text  : {0} ", Text);
        }
    }

    // •	Создать метод, принимающий введенную пользователем строку и выводящий на 
    //экран статистику по этой строке.Статистика должна включать:
    //a.общее количество символов;
    // b.количество букв в верхнем регистре;
    //c.количество букв в нижнем регистре;
    //d.количество цифр;
    // e.количество символов пунктуации;
    //f.количество пробельных символов.
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
                if (our_str[i] > '0' && our_str[i] < '9')
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


    // •	Пользователь вводит строку и символ.В строке найти все
    //вхождения этого символа и перевести в верхний регистр, а также удалить
    //часть строки, начиная с последнего вхождения этого символа и до конца.
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

    //•	Пользователь вводит с клавиатуры арифметическое выражение любой сложности и длины.
    //   Подсчитать его результат, согласно приоритета всех операторов.
    //a.Использовать можно (скобки) + - * / %(по модулю) и **(степень), целые и вещественные.
    //b.Если в выражении встречаются другие символы, выдать сообщение, что выражение введено некорректно и показать, где именно.

    class Calculator
    {
        public string Expression { get; set; }
        public Stack<double> Numbers { get; set; }
        public Stack<char> Symbol { get; set; }

        public Calculator()
        {
            Expression = " ";
            Numbers = new Stack<double>();
            Symbol = new Stack<char>();
        }

        public void InputExpression()
        {
            Console.WriteLine("Write the Expression");
            Expression = Console.ReadLine();
        }

        public void Check()
        {
            bool flag = true;
            for (int i = 0; i < Expression.Length; i++)
            {
                if (Expression[i] > 0 && Expression[i] < 9 || (Expression[i] == '^' ||
                    Expression[i] == '(' || Expression[i] == ')' || Expression[i] == '+' ||
                    Expression[i] == '-' || Expression[i] == '*' || Expression[i] == '/'))
                    flag = true;
                else
                    throw new Exception("Wrong input in Expression index = ");

            }


        }
        public void Parsing()
        {
            if()

        }

































    }
}
