using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulls_and_cun
{
    class Game
    {
        private int[] Secret;
        private int[] ClientChoice;
        int Bull;
        int Cows;

        public Game()
        {
            Secret = new int[4];
            ClientChoice = new int[4];
            Bull = 0;
            Cows = 0;
        }

        public int BULL
        {
            get { return Bull; }
            set { Bull = value; }
        }

        public int COWS
        {
            get { return Cows; }
            set { Cows = value; }
        }
        public void RuleOfGame()
        {
            Console.WriteLine("\tПравила игры");
            Console.WriteLine("Компьютер задумывает четыре различные цифры из 0, 1, 2, ...9.");
            Console.WriteLine("Игрок делает ходы, чтобы узнать эти цифры и их порядок.\n");
            Console.WriteLine("Каждый ход состоит из четырёх цифр, 0 не может стоять на первом месте.В ответ компьютер показывает число отгаданных цифр,");
            Console.WriteLine("стоящих на своих местах(число быков) и число отгаданных цифр, стоящих не на своих местах(число коров).\n");
            Console.WriteLine("\tПример");
            Console.WriteLine("Компьютер задумал 0834. Игрок сделал ход 8134. Компьютер ответил : 2 быка(цифры 3 и 4) и 1 корова(цифра 8).\n");
            Console.WriteLine("Компьютер уже что - то задумал.Играем! \n");
        }

        public void RandNumber()
        {
            Random R = new Random();
            bool Flag = false;

            Secret[0] = R.Next(1, 9);

            for (int i = 1; i < Secret.Length; i++)
            {
                do
                {
                    Flag = false;
                    Secret[i] = R.Next(0, 9);
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (Secret[i] == Secret[j])
                        {
                            Flag = true;
                            break;
                        }
                    }
                } while (Flag != false);
            }
        }

        public void InputNumber()
        {
            bool Flag = false;
            do
            {
                if (Flag == true)
                {
                    Console.WriteLine("Wrong input read the rule and try again ");
                    Flag = false;
                }

                string tmp = Console.ReadLine();

                if (tmp.Length != 4)
                {
                    Flag = true;
                    continue;
                }
                for (int i = 0; i < ClientChoice.Length; i++)
                {
                    ClientChoice[i] = Convert.ToInt32(tmp[i]) - '0';
                }

                if (ClientChoice[0] == 0)
                {
                    Flag = true;
                    continue;
                }

                for (int i = 1; i < ClientChoice.Length; i++)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (ClientChoice[i] == ClientChoice[j])
                        {
                            Flag = true;
                            break;
                        }
                    }
                    if (Flag == true)
                        break;
                }
            } while (Flag == true);
        }

        public void Compare()
        {
            BULL = 0;
            COWS = 0;
            for (int i = 0; i < ClientChoice.Length; i++)
            {
                for (int j = 0; j < ClientChoice.Length; j++)
                {
                    if (ClientChoice[i] == Secret[j])
                    {
                        if (i == j)
                            BULL++;
                        else
                            COWS++;
                    }
                }
            }
        }

        public void PrintBC()
        {
            Console.WriteLine("Bull {0} : Cows {1} ", BULL, COWS);
        }

        public void PrintSecret()
        {
            foreach (var f in Secret)
                Console.Write(f);
            Console.WriteLine(" ");
        }



    }
}
