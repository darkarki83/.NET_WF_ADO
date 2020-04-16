using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    abstract class Strategy
    {
        public abstract int Research(List<TaskList> AllTask);
    }
    class SearchByTeg :Strategy
    {
        public override int Research(List<TaskList> AllTask)
        {
            string tmp = "";
            Console.WriteLine("Введите тег который вы ищете: ");
            tmp = Console.ReadLine();
            for(int i = 0 ;i < AllTask.Count;i++)
            {
                if(AllTask[i].Tage == tmp)
                {
                    return i;
                }
            }
            return -1;      
        }
    }

    class SearchByTask:Strategy
    {
        public override int Research(List<TaskList> AllTask)
        {
            string tmp = "";
            Console.WriteLine("Введите задание которое вы ищете: ");
            tmp = Console.ReadLine();
            for (int i =0; i < AllTask.Count;i++)
            {
                if(AllTask[i].Task == tmp)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    class SearchByData:Strategy
    {
        public override int Research(List<TaskList> AllTask)
        {
            DateTime tmp;
            Console.WriteLine("Введите дату которую вы ищете: ");
            tmp = DateTime.Parse(Console.ReadLine());
            for (int i = 0; i < AllTask.Count; i++)
            {
                if (AllTask[i].dateTime == tmp)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
