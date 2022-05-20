using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
   public  class AvocatConfiguration : IEntityTypeConfiguration<Avocat>
    {
        public void Configure(EntityTypeBuilder<Avocat> builder)
        {
            builder.HasOne(A => A.Specialite).WithMany(A => A.Avocats).HasForeignKey(A => A.SpecialiteFK).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
