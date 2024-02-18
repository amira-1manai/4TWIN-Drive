using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Configurations
{
    public class EmployéCommercialConfiguration : IEntityTypeConfiguration<EmployéCommercial>
    {
        public void Configure(EntityTypeBuilder<EmployéCommercial> builder)
        {
            builder.HasOne(pvente => pvente.PointVente)
                .WithMany(emp => emp.EmployéCommercials)
                .OnDelete(DeleteBehavior.Cascade
                );

        }
    }
}
