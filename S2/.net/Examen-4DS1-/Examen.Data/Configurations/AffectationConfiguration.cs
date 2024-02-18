using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Configurations
{
    public class AffectationConfiguration : IEntityTypeConfiguration<Affectation>
    {
        public void Configure(EntityTypeBuilder<Affectation> builder)
        {
            builder.HasKey(f => new { f.MannequinFK, f.DefileFK, f.DateEnvoi });
        }
    }
}
