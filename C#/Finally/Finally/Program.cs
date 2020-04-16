using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    class Program
    {
        static void Main(string[] args)
        {
            Noot obj = new Noot();
            /*TaskList first = new TaskList();
            first.Tage = "meat";
            first.Task = "meat freand";
            first.dateTime = DateTime.Parse("12/11/2010 8:12:12 PM");


            //Noot.CreateTask(ref first);
            obj.AddTask(first);
            

            TaskList second = new TaskList();
            second.Tage = "dot";
            second.Task = "meat girls";
            second.dateTime = DateTime.Parse("12/11/2011 3:12:12 PM");
            //Noot.CreateTask(ref second);
            obj.AddTask(second);
            // obj.Print();*/


            //obj.DeleteTask(0);
            //obj.Print();

            //Strategy search;

            //obj.ChangeTask(out search);
            //obj.Print();

            FileManager file = new FileManager();
            file.LoadFile(ref obj);
            obj.Print();



        }
    }
}
