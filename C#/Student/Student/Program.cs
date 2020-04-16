using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Students prov = new Students();
            OneStudent one = new OneStudent();
            one.Family = "krol";
            one.Name = "artem";
            one.FatherName = "gregori";
            one.Group = 123;
            one.Age = 35;
            one.Assessment = new byte[3][];
            one.Assessment[0] = new byte[2] { 12, 10 };
            one.Assessment[1] = new byte[3] { 12, 10, 8 };
            one.Assessment[2] = new byte[4] { 12, 10, 7 , 7 };
            prov.Add(one);
            prov.GetAssessment();
            prov.AddAssessment();
           // prov.InputNewStudent();
           // prov.InputNewStudent();
           // prov.InputNewStudent();
            prov.Print();


        }
    }
}
