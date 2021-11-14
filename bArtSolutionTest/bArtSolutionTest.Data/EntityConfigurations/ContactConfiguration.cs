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
    class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(contact => contact.Id);
            builder.Property(contact => contact.Id).ValueGeneratedOnAdd();

            builder.Property(contact => contact.FirstName).HasMaxLength(100);

            builder.Property(contact => contact.LastName).HasMaxLength(100);

            builder.Property(contact => contact.Email).HasMaxLength(100);
            builder.HasIndex(account => account.Email).IsUnique();

            builder.HasOne<Account>(c => c.Account)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.AccountId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
