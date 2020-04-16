using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.Model
{
    public class CalculatorModel : ICalculator, IMenu
    {
        public CalculatorModel()
        {
            TextBox = "0";
        }

        #region ICalculator

        public double Result { get; set; }

        public string TextBox { get; set; }

        public double FirstNumber { get; set; }

        public bool OutNumber { get; set; }

        public char Sumbol { get; set; }

        public string CopyStr { get; set; }

        public void CleanAll()
        {
            FirstNumber = 0;
            OutNumber = false;
            Result = 0;
            TextBox = "0";
            Sumbol = '\0';
            CopyStr = string.Empty;
        }

        public void InMunberModel(object sender)
        {
            bool isPoint = false;
            Button b = (Button)sender;
            foreach (var item in TextBox)
                if (item == '.')
                    isPoint = true;
            if (isPoint == false)
            {
                if (b.Text == "00")
                    TextBox = (double.Parse(TextBox) * 100 + double.Parse(b.Text)).ToString();
                else if (b.Text == ",")
                {
                    TextBox = TextBox + '.';
                }
                else
                    TextBox = (double.Parse(TextBox) * 10 + double.Parse(b.Text)).ToString();
            }
            else
            {
                if(b.Text != ",")
                    TextBox = TextBox + b.Text;
            }
        }

        public void ProsentModel(object sender)
        {
            Button b = (Button)sender;

            if (b.Text == "%")
                TextBox = (double.Parse(TextBox) / 100).ToString();
            else if (b.Text == "+/-")
            {
                TextBox = (double.Parse(TextBox) * -1).ToString();
            }
        }

        public void CalculationZiro(object sender)
        {
            Button b = (Button)sender;
            Sumbol = b.Text[0];
            FirstNumber = double.Parse(TextBox);
            TextBox = "0";
        }

        public void Calculation(object sender)
        {
            Button b = (Button)sender;

                switch (Sumbol)
                {
                    case '+':
                        Result = FirstNumber + double.Parse(TextBox);
                        break;
                    case '-':
                        Result = FirstNumber - double.Parse(TextBox);
                        break;
                    case '*':
                        Result = FirstNumber * double.Parse(TextBox);
                        break;
                    case '/':
                        Result = FirstNumber / double.Parse(TextBox);
                        break;
                }
                if (b.Text[0] == '=')
                {
                    Sumbol = '\0';
                    FirstNumber = 0;
                    TextBox = Result.ToString();
                }
                else
                {
                    FirstNumber = Result;
                    Sumbol = b.Text[0];
                    TextBox = "0";
                }
            OutNumber = true;
        }

        #endregion


        #region IMenu
        
        #endregion
    }
}
