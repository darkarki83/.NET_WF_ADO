using Calculator.Common;
using Calculator.Model;
using Calculator.Views;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presenters
{
    public class CalculatorPresenter : BasePresenter<ICalcView>
    {
        private ICalculator CalculatorModel { get; set; }

        public CalculatorPresenter(ICalcView view, ICalculator calculatorModel)
        {
            CalculatorModel = calculatorModel;
            View = view;
            View.InNumber += InMunberInBox;
            View.Clien += Cliening;
            View.PlusAndProsent += PlusProsent;
            View.SumbolCalc += SumbolClick;
            View.Copy += CopyString;
            View.Paste += PasteString;
        }

        public void InMunberInBox(object sender, EventArgs e)
        {
            CalculatorModel.InMunberModel(sender);
            View.TextBoxInNumber = CalculatorModel.TextBox;
        }

        public void Cliening(object sender, EventArgs e)
        {
            CalculatorModel.CleanAll();

            View.FirstNumber = CalculatorModel.FirstNumber;
            View.OutNumber = CalculatorModel.OutNumber;
            View.Result = CalculatorModel.Result;
            View.Sumbol = CalculatorModel.Sumbol;
            View.TextBoxInNumber = CalculatorModel.TextBox;
        }

        public void PlusProsent(object sender, EventArgs e)
        {
            CalculatorModel.ProsentModel(sender);
            View.TextBoxInNumber = CalculatorModel.TextBox;
        }

        public void SumbolClick(object sender, EventArgs e)
        {
            if (CalculatorModel.Sumbol == '\0')
            {
                CalculatorModel.CalculationZiro(sender);
                View.TextBoxInNumber = CalculatorModel.TextBox;
            }
            else
            {
                CalculatorModel.Calculation(sender);
                if (CalculatorModel.Sumbol == '\0')
                {
                    View.TextBoxInNumber = CalculatorModel.TextBox;
                }
                else
                {
                    View.TextBoxInNumber = CalculatorModel.FirstNumber.ToString();
                }
                View.OutNumber = CalculatorModel.OutNumber;
                CalculatorModel.OutNumber = false;
            }
        }

        public void CopyString(object sender, EventArgs e)
        {
            CalculatorModel.CopyStr = CalculatorModel.TextBox;
        }

        public void PasteString(object sender, EventArgs e)
        {
            CalculatorModel.TextBox = CalculatorModel.CopyStr;
            View.TextBoxInNumber = CalculatorModel.TextBox;
        }
    }
}
