using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHW
{
    public class Program
    {
        //public List<Worker> WorkerList;/* { get; set; }*/
        //public List<DaysOfWeek> DaysList { get; set; }





        static void Main(string[] args)
        {
            List<DaysOfWeek> ofWeek = new List<DaysOfWeek>();
            ofWeek.Add(new DaysOfWeek(1, 1, "9-16"));
            ofWeek.Add(new DaysOfWeek(2, 1, "16-22"));
            ofWeek.Add(new DaysOfWeek(3, 2, "9-16"));
            ofWeek.Add(new DaysOfWeek(4, 3, "9-16"));
            ofWeek.Add(new DaysOfWeek(5, 4, "9-16"));
            ofWeek.Add(new DaysOfWeek(6, 5, "9-16"));
            ofWeek.Add(new DaysOfWeek(7, 6, "16-22"));

            List<Worker> worker = new List<Worker>();
            worker.Add(new Worker(1, "Artem", "Krol", new DateTime(2019, 1, 1), new DateTime(2019, 5, 2)));
            worker.Add(new Worker(2, "Iliia", "Sokolov", new DateTime(2019, 2, 1), new DateTime(2019, 6, 3)));
            worker.Add(new Worker(3, "Vasiia", "ivanov", new DateTime(2019, 2, 15), new DateTime(2019, 7, 4)));

            List<WorkerDay> workerDay = new List<WorkerDay>();
            workerDay.Add(new WorkerDay(1, 1, 1));
            workerDay.Add(new WorkerDay(2, 1, 3));
            workerDay.Add(new WorkerDay(3, 1, 4));
            workerDay.Add(new WorkerDay(4, 2, 2));
            workerDay.Add(new WorkerDay(5, 2, 7));
            workerDay.Add(new WorkerDay(6, 3, 5));
            workerDay.Add(new WorkerDay(7, 3, 6));

            //string str = "Vasiia";

            //var en =
            //              from w in worker
            //              where w.FirstName == str
            //              select new
            //              {
            //                  ID  = w.Id,
            //                  SDate = w.StartDate,
            //                  EDate = w.EndDate
            //              };

            //Console.WriteLine("workDay:");
            //en.All(w => { Console.WriteLine($"Start Date :{w.SDate} , End Date :{w.EDate}"); return true; });
            //Console.WriteLine();
            //Console.WriteLine($"{en}");

            //var weekD =
            //            from o in ofWeek
            //            from d in workerDay
            //            where d.WorkerFK == en.First().ID && d.DaysOfWeekFK == o.Id
            //            select new
            //            {
            //                Days = o.Day
            //            };


            //Console.WriteLine("weekD:");
            //weekD.All(w => { Console.WriteLine($"Start Date :{w.Days}"); return true; });
            //Console.WriteLine();
            //Console.WriteLine($"{weekD}");

            //List<DateTime> dateTimes = new List<DateTime>();
            //for (DateTime i = en.First().SDate; i < en.First().EDate;)
            //{

            //    dateTimes.Add(i);
            //    i = i.AddDays(1);
            //}

            //Console.WriteLine("workDay:");
            //dateTimes.All(w => { Console.WriteLine($"Date :{w}"); return true; });
            //Console.WriteLine();
            //Console.WriteLine($"{dateTimes}");

            //var theDays =
            //                 from t in dateTimes
            //                 from w in weekD
            //                     //from  workerDay in d
            //                   where (int)t.DayOfWeek == (w.Days - 1)
            //                 select t;



            // Console.WriteLine("Day:");
            //theDays.All(w => { Console.WriteLine($"{w}"); return true; });
            // Console.WriteLine();
            // Console.WriteLine($"{theDays}");

            Console.WriteLine("Write name Worker Do you want see Dates");
            string str = Console.ReadLine().ToLower();
            var IsName =
                          from w in worker
                          where w.FirstName.ToLower() == str
                          select w.FirstName;

            Console.WriteLine("Name:");
            IsName.All(w => { Console.WriteLine($"{w}"); return true; });
            Console.WriteLine();
            Console.WriteLine($"{IsName}");
            if (IsName.First().ToLower() == str)
            {
                /*var en =
                              from w in worker
                              where w.FirstName == str
                              select new
                              {
                                  ID = w.Id,
                                  SDate = w.StartDate,
                                  EDate = w.EndDate
                              };

                Console.WriteLine("workDay:");
                en.All(w => { Console.WriteLine($"Start Date :{w.SDate} , End Date :{w.EDate}"); return true; });
                Console.WriteLine();
                Console.WriteLine($"{en}");*/

                var weekD =
                            from w in worker
                            from o in ofWeek
                            from d in workerDay
                            where d.WorkerFK == w.Id && d.DaysOfWeekFK == o.Id && w.FirstName.ToLower() == str
                            select new
                            {
                                Days = o.Day,
                                SDate = w.StartDate,
                                EDate = w.EndDate
                            };
                List<DateTime> dateTimes = new List<DateTime>();
                for (DateTime i = weekD.First().SDate; i < weekD.First().EDate;)
                {

                    dateTimes.Add(i);
                    i = i.AddDays(1);
                }
                var theDays =
                                 from t in dateTimes
                                 from w in weekD
                                 where (int)t.DayOfWeek == (w.Days - 1)
                                 select t;
                Console.WriteLine("Day:");
                theDays.All(w => { Console.WriteLine($"{w}"); return true; });
                Console.WriteLine();
                Console.WriteLine($"{theDays}");
            }
        }
    }
}
