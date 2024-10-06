using FOV.Domain.Common;
using FOV.Domain.Entities.DishGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
internal class DishIngredientGeneralConfiguration : IEntityTypeConfiguration<DishIngredientGeneral>
{
    public void Configure(EntityTypeBuilder<DishIngredientGeneral> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasData(new DishIngredientGeneral
        {
            Id = Guid.Parse("9ccc8ec6-6b72-4467-aaeb-1e45dc0540b0"),
            IngredientGeneralId = Guid.Parse("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"),
            DishGeneralId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
            Quantity = 2,
            IsDeleted = false,
            Created = DefaultDatetime.MinValue,
            LastModified = DefaultDatetime.MinValue,
            
        });
    }
}
