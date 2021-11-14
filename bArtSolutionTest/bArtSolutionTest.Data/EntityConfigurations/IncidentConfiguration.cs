using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bArtSolutionTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArtSolutionTest.Data.EntityConfigurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incident");

            builder.HasKey(incident => incident.Name);
            builder.Property(incident => incident.Name).HasDefaultValueSql("NEWID()");

            builder.Property(incident => incident.Description).HasMaxLength(100);
        }
    }
}
