using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class TheChat
    {
        public DbSet<Section> Section { get; set; }
        public DbSet<Theme> Theme { get; set; }
        public DbSet<Answer> Answer { get; set; }

        public TheChat(DbSet<Section> section, DbSet<Theme> theme, DbSet<Answer> answer)
        {
            Section = section;
            Theme = theme;
            Answer = answer;
        }
    }
}
