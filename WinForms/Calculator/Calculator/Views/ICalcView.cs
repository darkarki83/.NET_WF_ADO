using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Common;

namespace Calculator.Views
{
    public interface ICalcView : IView
    {
        double Result { get; set; }
        double FirstNumber { get; set; }
        bool OutNumber { get; set; }
        char Sumbol { get; set; }
        string TextBoxInNumber { get; set; }

        event EventHandler InNumber;
        event EventHandler Clien;
        event EventHandler PlusAndProsent;
        event EventHandler SumbolCalc;
        event EventHandler Copy;
        event EventHandler Paste;
    }
}
