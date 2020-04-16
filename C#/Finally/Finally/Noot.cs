using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    
    struct TaskList
    {
       public string Tage;
       public string Task;
       public int priority;
       public  DateTime dateTime;
    }
    class Noot : Subject
    {

        public List<TaskList> AllTask { get; set; }
        public Noot()
        {
            AllTask = new List<TaskList>();
           
        }

        public void AddTask(TaskList first)
        {
            AllTask.Add(first);
        }
   
        public static void CreateTask(ref TaskList  NewTask)
        {
            Console.WriteLine("Внесите свои Задания.");
            Console.WriteLine("Теги :");
            NewTask.Tage = Console.ReadLine();
            Console.WriteLine("Задание :");
            NewTask.Task= Console.ReadLine();
            Console.WriteLine("Приоритет :");
            NewTask.priority = int.Parse(Console.ReadLine());
            Console.WriteLine("Дата :");
            NewTask.dateTime = DateTime.Parse(Console.ReadLine());
        }

        public void DeleteTask(int index)
        {
            Console.WriteLine("Удаление!");
            AllTask.Remove(AllTask[index]);
            Console.WriteLine();
        }

        public int Search(out Strategy search)
        {
            Console.WriteLine("Поиск по Критерию.");
            Console.WriteLine("1.Теги:\n2.Заданию:\n3.Дата:\n");
            
            int Change = 0;
            Change = int.Parse(Console.ReadLine());
            switch (Change)
            {
                case 1:
                    search = new SearchByTeg();
                    break;
                case 2:
                    search = new SearchByTask();
                    break;
                case 3:
                    search = new SearchByData();
                    break;
                default:
                    throw new Exception("Неверный ввод.");
            }

            return search.Research(AllTask);
        }

        public void ChangeTask(out Strategy search)
        {
            TaskList tmp = new TaskList();
            DeleteTask(Search(out search));
            CreateTask(ref tmp);
            AddTask(tmp);
        }

        public void Print()
        {
            foreach(var item in AllTask)
            {
                Console.WriteLine("Teg : {0}\n Task: {1}\n Data :{2}", item.Tage, item.Task, item.dateTime);
            }
        }

        public override void AddObserver(Observer first)
        {
            Obs.Add(first);
        }

        public override void Notify()
        {
            foreach(var item in Obs)
            {
                item.UpDate(this);
            }

        }


        public iterator MyIter;
    }

   
   

  










}
