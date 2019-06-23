using Microsoft.EntityFrameworkCore;
using Sekreter.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekreter.API
{
    public class PersonContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Filename=MyPeople.db3");
        }

        public DbSet<PersonModel> People { get; set; }
    }
}
