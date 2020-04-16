using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public interface ICalculator
    {
        double Result { get; set; }
        string TextBox { get; set; }
        double FirstNumber { get; set; }
        bool OutNumber { get; set; }
        char Sumbol { get; set; }
        string CopyStr { get; set; }

        void CleanAll();

        void InMunberModel(object sender);

        void ProsentModel(object sender);

        void CalculationZiro(object sender);

        void Calculation(object sender);
    }
}
