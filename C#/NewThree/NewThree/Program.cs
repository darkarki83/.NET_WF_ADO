using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThree
{
    class Program
    {
        static void Main(string[] args)
        {
            StringChange prov = new StringChange();
            prov.InputStr();
            prov.NewStr();
            prov.Print();
           /* TextChack prov = new TextChack();
            prov.Chack();
            prov.Print();*/

            /*TextWork prov = new TextWork();
            prov.InputText();
            if (prov.IsPolindrom())
                Console.WriteLine("It is polindrom");
            else
                Console.WriteLine("It is not polindrom");

            prov.Print();*/
        }
    }
}
