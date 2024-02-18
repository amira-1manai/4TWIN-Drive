using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Configurations
{
    public class DefileConfiguration : IEntityTypeConfiguration<Defile>
    {
        public void Configure(EntityTypeBuilder<Defile> builder)
        {
            builder.HasOne(sty => sty.StylisteModeliste)
                .WithMany(def => def.Defiles);
        }
    }
}
