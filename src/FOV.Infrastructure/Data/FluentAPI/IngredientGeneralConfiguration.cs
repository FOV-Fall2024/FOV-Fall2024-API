using FOV.Domain.Entities.IngredientGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;

public class IngredientGeneralConfiguration : IEntityTypeConfiguration<IngredientGeneral>
{
    public void Configure(EntityTypeBuilder<IngredientGeneral> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DishIngredientGenerals).WithOne(x => x.IngredientGeneral).HasForeignKey(x => x.IngredientGeneralId);
        builder.HasData(new IngredientGeneral
        {
            Id = Guid.Parse("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"),
            IngredientName = "Rice",
            IngredientDescription = "Can last 6 months to a year or more if kept in a cool, dry place.",
            IngredientTypeId = Guid.Parse("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a7")

        }, new IngredientGeneral
        {
            Id = Guid.Parse("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a0"),
            IngredientName = "Pasta",
            IngredientDescription = "Typically lasts 1-2 years when stored in an airtight container..",
            IngredientTypeId = Guid.Parse("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a7")
        },
         new IngredientGeneral
         {
             Id = Guid.Parse("9ccc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
             IngredientName = "Spinach",
             IngredientDescription = "Typically lasts 1-2 years when stored in an airtight container..",
             IngredientTypeId = Guid.Parse("b8f66bab-13c9-4390-8582-545ddc7d2ec8")
         }

        );
    }
}
