using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Configurations
{
    public class ExempleConfiguration : IEntityTypeConfiguration<Exemple>
    {
        public void Configure(EntityTypeBuilder<Exemple> builder)
        {
            //builder.ToTable().............
            //OneToMany
            //ManytoMany .............
        }
    }
}
