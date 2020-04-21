using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumberFk { get; set; }
        public string Adress { get; set; }
        public Book(int id, string firstName, string lastName, int foneNumberFK, string adress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumberFk = foneNumberFK;
            Adress = adress;
        }
    }
}
