﻿using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class IngredientUnitConfiguration : IEntityTypeConfiguration<IngredientUnit>
{
    public void Configure(EntityTypeBuilder<IngredientUnit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Ingredient).WithMany(x => x.IngredientUnits).HasForeignKey(x => x.IngredientId);
        builder.HasOne(x => x.IngredientUnitParent).WithMany(x => x.ChildUnits).HasForeignKey(x =>x.IngredientUnitParentId);
    }
}