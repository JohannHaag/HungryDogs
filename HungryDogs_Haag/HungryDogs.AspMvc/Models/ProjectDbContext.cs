using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryDogs.AspMvc.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurant { get; set; }

        public DbSet<OpeningHour> OpeningHour{ get; set; }

        public DbSet<SpecialOpeningHour> SpecialOpeningHour { get; set; }
    }
}

