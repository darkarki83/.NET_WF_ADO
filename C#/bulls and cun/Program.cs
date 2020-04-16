using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulls_and_cun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetWindowSize(140, 40);  // ширина экрана

           

            Game TheGame = new Game();

            TheGame.RandNumber();

            //TheGame.RuleOfGame();

            do
            {
                if (TheGame.BULL + TheGame.COWS != 0)
                {

                    var key = Console.ReadKey().Key;
                }

                Console.Clear();

                TheGame.RuleOfGame();

                TheGame.InputNumber();

                TheGame.Compare();

                TheGame.PrintBC();
                
                TheGame.PrintSecret();


            } while (TheGame.BULL != 4);

            Console.WriteLine("You Are Win");

            /*foreach (var g in ClientChoice)
                Console.Write(g);
            Console.WriteLine(" ");*/


          
            //   на посмотреть
            //  foreach (var K in Secret)
            //    Console.WriteLine(K);


            /*
            string result = string.Format("Длина строки: {0}", s.Length);
            Console.WriteLine(result);

            string t = s.Substring(4, 7); // возвращает подстроку из 7 символов, начиная с 4 позиции
            Console.WriteLine(t);
            Console.WriteLine(s[5]);

            s = s.Replace("о", "О");
            Console.WriteLine(s);

            s = s.Remove(4, 8); // удаляет 8 символов, начиная с позиции 4
            Console.WriteLine(s);

            //str[5] = '!'; // недопустимо: доступ только на чтение
            char[] ar = { 'с', 'т', 'р', 'о', 'к', 'а' };

            string s2 = new string(ar);
            Console.WriteLine(s2);
            Console.WriteLine("Длина строки: " + s2.Length);

            string[] arstr = { " Platform ", " .NET ", " Framework " };
            for (int i = 0; i < arstr.Length; i++)
            {
                Console.WriteLine(arstr[i]);
            }
            arstr[0] = " Common ";
            arstr[1] = " Language ";
            arstr[2] = " Runtime ";
            for (int i = 0; i < arstr.Length; i++)
            {
                Console.WriteLine(arstr[i]);
            }

            Console.WriteLine("Введите первую строку: ");
            string s3 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку: ");
            string s4 = Console.ReadLine();
            if (s3.CompareTo(s4) > 0)
                Console.WriteLine(s3 + " больше, чем " + s4);
            else if (s3.CompareTo(s4) < 0)
                Console.WriteLine(s4 + " больше, чем " + s3);
            else
                Console.WriteLine("Строки равны");

            string text = "To be or not be";
            Console.WriteLine(" Индекс первого вхождения слова \"be\" = {0} ", text.IndexOf("be"));
            Console.WriteLine(" Индекс последнего вхождения слова \"be\" = {0} ", text.LastIndexOf("be"));

            Console.WriteLine();
            string words = "Эта    строка  будет  разбита  на  массив  строк";
            string[] arrayOfString = words.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s5 in arrayOfString)
            {
                Console.WriteLine(s5);
            }
            string res = string.Join(" ", arrayOfString);
            Console.WriteLine(res);

            string str1 = "Я ";
            string str2 = "учу ";
            string str3 = "C#";
            string str4 = str1 + str2 + str3;

            Console.WriteLine("{0} + {1} + {2} = {3}", str1, str2, str3, str4);

            str4 = str4.Replace("учу", "изучаю");
            Console.WriteLine(str4);

            str4 = str4.Insert(2, "упорно ").ToUpper();
            Console.WriteLine(str4);

            if (str4.Contains("упорно"))
                Console.WriteLine("Учу таки упорно :)");
            else
                Console.WriteLine("Учу как могу");*/
        }
    }
}
