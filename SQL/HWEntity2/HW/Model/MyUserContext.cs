using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MyUserContext : DbContext
    {
        public MyUserContext() :base ("MyUser")
        {
            Database.SetInitializer(new MyUserContextInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Information> Informations { get; set; } 
    }
}
