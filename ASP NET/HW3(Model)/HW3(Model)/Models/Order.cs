using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW3_Model_.Models
{
    public class Order
    {
        [Display(Name = "כתובת")]
        public Adress orderAdress;

        [Display(Name = "פרחים")]
        public string FlowerName {get; set;}
        
        [Display(Name = "כמות")]
        public int Count {get; set;}

        [Display(Name = "כותרת")]
        [DataType(DataType.MultilineText)]
        public string Note {get; set;}
        
        [Display(Name = "שם לקוח")]
        public string CostomerName {get; set;}
        
        [DataType(DataType.Date)]
        public DateTime DateOrder {get; set;}


        public Order(string flowerName, int count, string note, string costumer
            , DateTime dateOrder, Adress order)
        {
            FlowerName = flowerName;
            Count = count;
            Note = note;
            CostomerName = costumer;
            DateOrder = dateOrder;
            orderAdress = order;
        }

        public Adress OrderAdress { get => orderAdress; set => orderAdress = value; }
    }
}
