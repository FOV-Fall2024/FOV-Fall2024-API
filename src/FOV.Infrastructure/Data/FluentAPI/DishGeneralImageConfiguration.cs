using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.DishGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
internal class DishGeneralImageConfiguration : IEntityTypeConfiguration<DishGeneralImage>
{
    public void Configure(EntityTypeBuilder<DishGeneralImage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}
