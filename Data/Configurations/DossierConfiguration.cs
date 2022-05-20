using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class DossierConfiguration : IEntityTypeConfiguration<Dossier>
    {
        public void Configure(EntityTypeBuilder<Dossier> builder)
        {
            builder.HasKey(d => new { d.ClientFK, d.AvocatFK, d.DateDepot });
            builder.HasOne(d => d.Client).WithMany(d => d.Dossiers).HasForeignKey(d => d.ClientFK);
            builder.HasOne(A => A.Avocat).WithMany(A => A.Dossiers).HasForeignKey(A => A.AvocatFK);

        }
    }
}
