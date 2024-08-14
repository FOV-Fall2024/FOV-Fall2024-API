using FOV.Domain.Entities.IngredientAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class IngredientTypeConfiguration : IEntityTypeConfiguration<IngredientType>
{
    public void Configure(EntityTypeBuilder<IngredientType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Ingredients).WithOne(x => x.IngredientType).HasForeignKey(x => x.IngredientTypeId);
        builder.HasMany(x => x.IngredientGenerals).WithOne(x => x.IngredientType).HasForeignKey(x => x.IngredientTypeId);
        builder.HasData(
     new IngredientType
     {
         Id = Guid.NewGuid(),  // Ensure to provide a unique ID
         IngredientName = "Processed Ingredient",
         IngredientMain = "Processed",
         Left = 1,
         Right = 2,
         ExpiredTime = 30,
         IsDeleted = false
     },
     new IngredientType
     {
         Id = Guid.NewGuid(),  // Ensure to provide a unique ID
         IngredientName = "Packaged Ingredient",
         IngredientMain = "Packaged",
         Left = 3,
         Right = 4,
         ExpiredTime = 60,
         IsDeleted = false
     }
 );

    }
}
