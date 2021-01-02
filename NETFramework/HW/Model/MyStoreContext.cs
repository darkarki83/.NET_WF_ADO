using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MyStoreContext :DbContext
    {            
        public MyStoreContext() : base("MyStore")
        {
            // Заполняем БД дефолтными записями при ее создании
            Database.SetInitializer(new MyStoreContextInitializer());
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PartsInOrder> PartsInOrders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
