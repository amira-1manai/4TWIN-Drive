using Examen.Data.Configurations;
using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen.Data
{
    public class ExamContext:DbContext
    {
        public ExamContext()
        {
            Database.EnsureCreated();// création de la BDD pour la 1 fois
        }
        //la liste des DbSet
        public DbSet<EmployéCommercial> EmployéCommercials { get; set; }
        public DbSet<PointVente> PointVentes { get; set; }
        public DbSet<PointFixe> PointFixes { get; set; }
        public DbSet<PointMobile> PointMobiles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=Examen-4DS1S;
            Integrated Security=true;
            MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployéCommercialConfiguration());
            modelBuilder.ApplyConfiguration(new PointMobileConfiguration());
            modelBuilder.ApplyConfiguration(new PointVenteConfiguration());


            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(DateTime)))
            {
                property.SetColumnType("datatime2");
            }
            //TPT : Table per type
            modelBuilder.Entity<PointFixe>().ToTable("PointFixes");
            modelBuilder.Entity<PointMobile>().ToTable("PointMobiles");

        }
    }
}
