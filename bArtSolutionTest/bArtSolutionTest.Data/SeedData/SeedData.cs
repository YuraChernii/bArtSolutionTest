using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bArtSolutionTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArtSolutionTest.Data.SeedData
{
    internal static class SeedData
    {
        internal static void Seed(this ModelBuilder builder)
        {
            SeedContacts(builder.Entity<Contact>());
        }

        internal static void SeedContacts(EntityTypeBuilder<Contact> builder) =>
            builder.HasData(
                new Contact()
                {
                    Id = 1,
                    FirstName = "Yura",
                    LastName = "Chernii",
                    Email = "mikkee@gmail.com"
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = "Yura2",
                    LastName = "Chernii2",
                    Email = "mikkee@gmail2.com"
                }
                );
                
    }
}
