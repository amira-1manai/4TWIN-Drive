using Examen.Data.Configurations;
using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data
{
    public class ExamContext:DbContext
    {
        public ExamContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Mannequin> Mannequins { get; set; }
        public DbSet<Defile> Defiles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<StylisteModeliste> StylisteModelistes { get; set; }
        public DbSet<Affectation> Affectations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=Examen-4DS1;
            Integrated Security=true;
            MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DefileConfiguration());
            modelBuilder.ApplyConfiguration(new AffectationConfiguration());

        }
    }
}
