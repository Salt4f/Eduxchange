using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EduxchangeAPI.Models;

namespace EduxchangeAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        //public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<Give> Gives { get; set; }
        public DbSet<Helps> Helps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Helps>()
                .HasKey(h => new { h.IndividualID, h.NeedID });
        }

    }
}
