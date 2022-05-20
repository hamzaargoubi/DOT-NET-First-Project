using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class SpecialiteConfiguration : IEntityTypeConfiguration<Specialite>
    {
        public void Configure(EntityTypeBuilder<Specialite> builder)
        {
            builder.HasMany(S => S.Avocats).WithOne(S => S.Specialite).HasForeignKey(S => S.SpecialiteFK).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
