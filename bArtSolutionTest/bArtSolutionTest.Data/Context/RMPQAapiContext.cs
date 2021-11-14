using Microsoft.EntityFrameworkCore;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Data.EntityConfigurations;
using bArtSolutionTest.Data.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArtSolutionTest.Data.Context
{
    public class RMPQAapiContext : DbContext
    {

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public RMPQAapiContext(DbContextOptions<RMPQAapiContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            modelBuilder.Seed();
        }
    }

    
}
