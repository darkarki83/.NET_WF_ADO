using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW8_DB_.Models
{
    public class StoreModel
    {
        public IEnumerable<Product> StoreProducts { get; set; }
        public IEnumerable<User> StoreUsers { get; set; }
        public IEnumerable<Order> StoreOrders { get; set; }
    }
}
