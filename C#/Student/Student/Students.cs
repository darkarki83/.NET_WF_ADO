using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public struct OneStudent
    {
        public string Family { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public byte Group { get; set; }
        public byte Age { get; set; }
        public byte[][] Assessment { get; set; }
        public OneStudent(string family, string name, string fatherName, byte group, byte age, byte[][] assessment)
        {
            Family = family;
            Name = name;
            FatherName = fatherName;
            Group = group;
            Age = age;
            Assessment = new byte[3][ ];
            for (int i = 0; i < 3; i++)
            {
                Assessment[i] = new byte [10];
            }
            Assessment = assessment;
        }
    }
    class Students
    {
        public List<OneStudent> student;
        public Students() => student = new List<OneStudent>();
        public void InputNewStudent()
        {
            OneStudent one = new OneStudent();
            Console.Write("Write the Family : ");
            one.Family = Console.ReadLine();
            Console.Write("Write the Name : ");
            one.Name = Console.ReadLine();
            Console.Write("Write the FatherName : ");
            one.FatherName = Console.ReadLine();
            Console.Write("Write the Group : ");
            one.Group = byte.Parse(Console.ReadLine());
            Console.Write("Write the Age : ");
            one.Age = byte.Parse(Console.ReadLine());
            Console.Write("Write the Assessment : ");
            one.Assessment = new byte[3][];
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    Console.Write("How many Assessment Prograner have this student: ");
                else if (i == 1)
                    Console.Write("How many Assessment Grafic have this student: ");
                else if (i == 2)
                    Console.Write("How many Assessment Admin have this student: ");
                byte count = byte.Parse(Console.ReadLine());
                one.Assessment[i] = new byte[count];
                for (int j = 0; j < count; j++)
                {
                    Console.Write("Write Assessment :");
                    one.Assessment[i][j] = byte.Parse(Console.ReadLine());
                }
            }
            Add(one);
        }
        public void Add(OneStudent one)
        {
            student.Add(one);
        }
        public void Delete(OneStudent one)
        {
            if (student.Remove(one))
                Console.WriteLine("Delete is try");
            else
                Console.WriteLine("Delete is false");
        }
        public void AddAssessment()
        {
            Console.Write("Write the Family : ");
            string family = Console.ReadLine();
            int choice = 0;
            byte ass = 0;
            byte[] temp;
            int i;
            for (i = 0; i < student.Count; i++)
            {
                if (student[i].Family == family)
                {
                    Console.WriteLine("What assessment do you want added : ");
                    Console.WriteLine("1)Programer \n2)Grafic \n3)Admin \n ");
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write assessment : ");
                    ass = byte.Parse(Console.ReadLine());
                }
            }
            temp = new byte[(student[i - 1].Assessment[choice - 1].Length + 1)];
            temp = student[i - 1].Assessment[choice - 1];
            temp[temp.Length - 1] = ass;
            student[i - 1].Assessment[choice - 1] = new byte[temp.Length];
            student[i - 1].Assessment[choice - 1] = temp;
        }
        public void GetAssessment()
        {
            Console.WriteLine("What assessment do you want get : ");
            Console.WriteLine("1)Programer \n2)Grafic \n3)Admin \n ");
            int choice = int.Parse(Console.ReadLine());
            if (choice - 1 == 0)
                Console.Write("Assessment Program : ");
            else if (choice - 1 == 1)
                Console.Write("Assessment Grafic : ");
            else if (choice - 1 == 2)
                Console.Write("Assessment Admin: ");

            for (int i = 0; i < student[0].Assessment[choice - 1].Length; i++)
                Console.Write(" , {0}", student[0].Assessment[choice - 1][i]);
            Console.WriteLine();
        }

        public int Avarage(byte[] assessment)
        {
            int aver = 0;
            for (int i = 0; i < assessment.Length; i++)
            {
                aver += assessment[i];
            }
            return aver/ assessment.Length;
        }
        public void Print()
        {
            for (int i = 0; i < student.Count; i++)
            {
                Console.WriteLine("family :{0} name : {1} fatherName : {2}  group : {3} age : {4} " ,
                    student[i].Family, student[i].Name, student[i].FatherName, student[i].Group, student[i].Age);
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                        Console.Write("Assessment Program : ");
                    else if (j == 1)
                        Console.Write("Assessment Grafic : ");
                    else if (j == 2)
                        Console.Write("Assessment Admin: ");
                    Console.WriteLine(Avarage(student[i].Assessment[j]));
                }
            }
        }







    }
    /*   Разработать класс, описывающий студента и предусмотреть в нем следующие моменты:
   •	массив оценок(рваный) по программированию администрированию и дизайну.

   Добавить в класс функциональность по работе со всеми перечисленными данными:

   •	заполнение всех полей;
   •	возможность установки / получения оценки;
   •	получение среднего балла по заданному предмету;
   •	распечатка данных о студенте...

   ... и все, что пожелаете.*/

}
