using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW8_DB_.Models
{
    public class StoreDBContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
