﻿using Elastic.Clients.Elasticsearch;
using FOV.Domain.Entities.RestaurantAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Ingredients).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.Dishes).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.Combos).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.Tables).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.Employees).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasMany(x => x.GroupChats).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);
        builder.HasData(new Restaurant
        {
            Id = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
            RestaurantName = "Default Restaurant",
            IsDeleted = false,
            RestaurantPhone = "0902388123",
            Address = "Go Vap",
            RestataurantCode = "RE_001",
            Status = Domain.Entities.TableAggregator.Enums.Status.Active

        },
        new Restaurant
        {
            Id = Guid.Parse("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
            RestaurantName = "Vege Thu Duc",
            IsDeleted = false,
            RestaurantPhone = "0867960120",
            Address = "Thu Duc",
            RestataurantCode = "RE_002",
            Status = Domain.Entities.TableAggregator.Enums.Status.Active
        }
        );
    }
}
