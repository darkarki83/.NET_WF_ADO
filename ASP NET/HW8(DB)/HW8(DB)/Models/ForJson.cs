using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW8_DB_.Models
{
    public class ForJson
    {
        public ForJson(long id, string poductsName, decimal productsCost, int ordersCount)
        {
            Id = id;
            PoductsName = poductsName;
            ProductsCost = productsCost;
            OrdersCount= ordersCount;
        }

        public long Id { get; set; }
        public string PoductsName { get; set; }
        public decimal ProductsCost { get; set; }
        public int OrdersCount { get; set; }
    }
}
