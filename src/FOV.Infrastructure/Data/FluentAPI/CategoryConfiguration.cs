﻿using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.DishGenerals).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        builder.HasMany(x => x.Dishes).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        builder.HasData(
        new Category("Khai Vị")
        {
            Id = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c011"),  //? 
            Status = Domain.Entities.TableAggregator.Enums.Status.Active,
            Created = DefaultDatetime.MinValue,
            LastModified = DefaultDatetime.MinValue,

        },
        new Category("Món Chính")
        {
            Id = Guid.Parse("3140b8af-2124-44fa-8f43-907cddc26c3d"),  // Assign a unique ID
            Status = Domain.Entities.TableAggregator.Enums.Status.Active,
            Created = DefaultDatetime.MinValue,
            LastModified = DefaultDatetime.MinValue,
        }
    );

    }
}
