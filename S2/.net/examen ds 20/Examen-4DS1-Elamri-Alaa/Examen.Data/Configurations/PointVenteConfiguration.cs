using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Configurations
{
    class PointVenteConfiguration : IEntityTypeConfiguration <PointVente>
    {

        public void Configure(EntityTypeBuilder<PointVente> builder)
        {
            builder.HasKey(c => c.PointVenteId);
        }
    }
}
