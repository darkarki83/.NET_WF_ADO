﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW9_Jurnal_.Models.Context
{
    public class JurnalDbContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Appraisal> Appraisals { get; set; }

        public JurnalDbContext(DbContextOptions<JurnalDbContext> options) : base(options)
        {
            // Если такая БД уже есть, то удаляем ее
           /* if (Database.CanConnect())
                Database.EnsureDeleted();*/

            // Создаем БД
            Database.EnsureCreated();
        }
    }
}
