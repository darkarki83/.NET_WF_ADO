using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW3_Model_.Models
{
    public class Adress
    {
        private string town;
        private string street;
        private int house;
        private int apartment;


        public Adress(string _town, string _street, int _house, int _apartment)
        {
            town = _town;
            street = _street;
            house = _house;
            apartment = _apartment;
        }

        [Display(Name = "עיר")]
        [UIHint("Url")]
        public string Town
        {
            get => town;
            set => town = value;
        }

        [Display(Name = "רחוב")]
        public string Street
        {
            get => street;
            set => street = value;
        }

        [Display(Name = "בית")]
        public int House
        {
            get => house;
            set => house = value;
        }

        [Display(Name = "דירה")]
        public int Apartment
        {
            get => apartment;
            set => apartment = value;
        }

    }
}

