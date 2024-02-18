using Examen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Configurations
{
    class PointMobileConfiguration : IEntityTypeConfiguration<PointMobile>
    {
        public void Configure(EntityTypeBuilder<PointMobile> builder)
        {
            builder.OwnsOne(ch => ch.Emplacement);
        }
    }
}
