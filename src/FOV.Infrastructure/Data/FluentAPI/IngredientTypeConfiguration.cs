using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class IngredientTypeConfiguration : IEntityTypeConfiguration<IngredientType>
{
    public void Configure(EntityTypeBuilder<IngredientType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.Ingredients).WithOne(x => x.IngredientType).HasForeignKey(x => x.IngredientTypeId);
        builder.HasMany(x => x.IngredientGenerals).WithOne(x => x.IngredientType).HasForeignKey(x => x.IngredientTypeId);
        builder.HasData(
     new IngredientType
     {
         Id = Guid.Parse("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a7"), // Ensure to provide a unique ID
         IngredientName = "Rau",
         Status = Status.Active,
         Created = DefaultDatetime.MinValue,
         LastModified = DefaultDatetime.MinValue,
     },
     new IngredientType
     {
         Id = Guid.Parse("b8f66bab-13c9-4390-8582-545ddc7d2ec8"),  // Ensure to provide a unique ID
         IngredientName = "Short Storage Ingredients",
         Status = Status.Active,
         Created = DefaultDatetime.MinValue,
         LastModified = DefaultDatetime.MinValue,
     }
 ); ;

    }
}
