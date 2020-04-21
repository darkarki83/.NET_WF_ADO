using System;
using System.Collections.Generic;
using System.Text;

namespace LinqHW
{
    public class WorkerDay
    {
        public int Id { get; set; }
        public int WorkerFK { get; set; }
        public int DaysOfWeekFK { get; set; }

        public WorkerDay(int id, int workerFK, int daysOfWeekFK) 
        {
            Id = id;
            WorkerFK = workerFK;
            DaysOfWeekFK = daysOfWeekFK;
        }


    }
}
