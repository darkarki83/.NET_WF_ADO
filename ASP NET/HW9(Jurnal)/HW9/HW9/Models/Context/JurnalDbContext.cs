using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW9.Models.Context
{
    public class JurnalDbContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Appraisal> Appraisals { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public JurnalDbContext(DbContextOptions<JurnalDbContext> options) : base(options)
        {
            // Создаем БД
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string lectorRoleName = "lector";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "123456";
            string adminName = "admin";

            // добавляем роли
            Role adminRole = new Role { Id = 3, Name = adminRoleName };
            Role lectorRole = new Role { Id = 2, Name = lectorRoleName };
            Role userRole = new Role { Id = 1, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, Name = adminName, RoleFk = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, lectorRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
