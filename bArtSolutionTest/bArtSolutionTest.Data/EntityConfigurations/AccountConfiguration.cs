using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bArtSolutionTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArtSolutionTest.Data.EntityConfigurations
{
    class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(account => account.Id);
            builder.Property(account => account.Id).ValueGeneratedOnAdd();

            builder.Property(account => account.Name).HasMaxLength(100);
            builder.HasIndex(account => account.Name).IsUnique();

            builder.HasOne<Incident>(c => c.Incident)
                .WithMany(c => c.Accounts)
                .HasForeignKey(c => c.IncidentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
