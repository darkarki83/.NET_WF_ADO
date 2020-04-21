using System;
using System.Collections.Generic;
using System.Text;

namespace LinqHW
{
    public class DaysOfWeek
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public string TimeTible { get; set; }
        public DaysOfWeek(int id, int day, string timeTible)
        {
            Id = id;
            Day = day;
            TimeTible = timeTible;
        }

        public DaysOfWeek()
        {
            Id = 0;
            Day = 0;
            TimeTible = string.Empty;
        }
    }
}
