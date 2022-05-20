using Data.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Data
{
    public class Context: DbContext
    {
        public DbSet<Avocat> Avocats { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<Specialite> Specialites { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source= (localdb)\MSSQLLOCALDB; INITIAL CATALOG= AvocatDB; INTEGRATED SECURITY= TRUE").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //     modelBuilder.Entity<Dossier>().HasKey(d => new { d.AvocatFK, d.ClientFK, d.DateDepot });
            modelBuilder.ApplyConfiguration(new DossierConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialiteConfiguration());
          //  modelBuilder.ApplyConfiguration(new AvocatConfiguration());
        }
    }
}
