using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models.Contaxt
{
    public class ChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
            // Создаем БД
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string moderatorRoleName = "moderator";
            string userRoleName = "user";
            string guestRoleName = "guest";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "123456";
            string adminName = "admin";

            // добавляем роли
            Role adminRole = new Role { Id = 4, Name = adminRoleName };
            Role moderatorRole = new Role { Id = 3, Name = moderatorRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            Role guestRole = new Role { Id = 1, Name = guestRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, Name = adminName, RoleFk = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, moderatorRole, userRole, guestRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
