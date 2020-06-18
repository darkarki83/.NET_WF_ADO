using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MyLibraryContext : DbContext
    {
        public MyLibraryContext() : base("MyLibrary")
        {
            Database.SetInitializer(new MyLibraryContextInitializer());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Press> Presses { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
