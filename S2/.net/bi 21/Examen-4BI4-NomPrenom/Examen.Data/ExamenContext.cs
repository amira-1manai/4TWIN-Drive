using Examen.Data.Configurations;
using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen.Data
{
    public class ExamenContext :DbContext
    {
        public ExamenContext()
        {
            Database.EnsureCreated();// pour la création de la BDD pour la 1 fois
        }
        // la liste des DbSet<>
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Cagnotte> Cagnottes { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        //public DbSet<Exemple> Exemples { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                Initial Catalog=ExamenDB-4BI4;
                Integrated Security=true;
                MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new ParticipationConfiguration());
            //TPH ou TPT
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties())
           .Where(p => p.ClrType.Equals(typeof(String)) && p.Name.StartsWith("Mail")))
            {
                property.IsColumnNullable();
            }
        }
    }
}
