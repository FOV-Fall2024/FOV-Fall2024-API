﻿using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class IngredientTransactionConfiguration : IEntityTypeConfiguration<IngredientUsage>
{
    public void Configure(EntityTypeBuilder<IngredientUsage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}
