using System;
using System.Collections.Generic;
using System.Text;

namespace LinqHW
{
    public class Worker
    {
        public int Id { get; set; }
        //public int DaysOfWeekFK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Worker(int id/*, int daysOfWeekFK*/, string firstName, string lastName, DateTime startDate, DateTime endDate)
        {
            Id = id;
            //DaysOfWeekFK = daysOfWeekFK;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Worker()
        {
            Id = 0;
            //DaysOfWeekFK = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            StartDate = default;
            EndDate = default;
        }

        public void Print()
        {
            Console.WriteLine($"Id = {Id} ");
            Console.WriteLine($"FirstName = {FirstName} ");
            Console.WriteLine($"LastName = {LastName} ");
            Console.WriteLine($"StartDate = {StartDate} ");
            Console.WriteLine($"EndDate = {EndDate} ");
        }
    }
}
